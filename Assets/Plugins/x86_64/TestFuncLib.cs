using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace HTC.Unity.Cef
{
    public static class FuncLib
    {
        public delegate int DLL_PRINT_A_NUMBER();
        public static DLL_PRINT_A_NUMBER PrintANumber;

        public delegate IntPtr DLL_PRINT_HELLO();
        public static DLL_PRINT_HELLO PrintHello;

        public delegate int DLL_ADD_TWO_INTS(int i1, int i2);
        public static DLL_ADD_TWO_INTS AddTwoIntegers;

        public delegate float DLL_ADD_TWO_FLOATS(float f1, float f2);
        public static DLL_ADD_TWO_FLOATS AddTwoFloats;

        public delegate IntPtr DLL_GREETING(string name);
        public static DLL_GREETING Greeting;

        public delegate SimpleT DLL_GET_STRUCT(int a, float b);
        public static DLL_GET_STRUCT GetStruct;

        public static void LoadFuncs(int pModule)
        {
            try
            {
                PrintANumber = (DLL_PRINT_A_NUMBER)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "PrintANumber"), typeof(DLL_PRINT_A_NUMBER));
                PrintHello = (DLL_PRINT_HELLO)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "PrintHello"), typeof(DLL_PRINT_HELLO));
                AddTwoIntegers = (DLL_ADD_TWO_INTS)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "AddTwoIntegers"), typeof(DLL_ADD_TWO_INTS));
                AddTwoFloats = (DLL_ADD_TWO_FLOATS)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "AddTwoFloats"), typeof(DLL_ADD_TWO_FLOATS));
                Greeting = (DLL_GREETING)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "Greeting"), typeof(DLL_GREETING));
                GetStruct = (DLL_GET_STRUCT)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "GetStruct"), typeof(DLL_GET_STRUCT));
                Debug.Log("Loaded Functions Succesfully");
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}
