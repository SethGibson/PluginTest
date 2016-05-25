using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace HTC.Unity.Cef
{
    public static class Interop
    {
        [DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
        public static extern int LoadLibrary([MarshalAs(UnmanagedType.LPStr)]string lpLibFileName);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
        public static extern IntPtr GetProcAddress(int hModule, [MarshalAs(UnmanagedType.LPStr)]string lpProcName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
        public static extern int FreeLibrary(int hModule);
    }

    public sealed class LibLoader
    {

        private static readonly LibLoader _instance = new LibLoader();
        public static LibLoader Instance {
            get {
                return _instance;
            }
        }

        private int libHandle = 0;
        private bool isLoaded = false;

        public int ModuleHandle { get { return libHandle; } }
        public bool IsLoaded { get { return isLoaded; } }

        private LibLoader()
        {
        }

        static LibLoader()
        {
        }

        public void LoadModule()
        {
            var assetRoot = Path.Combine(Application.dataPath, "Plugins/x86_64/Plugin.dll");
            libHandle = Interop.LoadLibrary(assetRoot);
            isLoaded = libHandle != 0;
        }

        public void UnloadModule()
        {
            if (isLoaded)
                Interop.FreeLibrary(libHandle);
        }
    }
}