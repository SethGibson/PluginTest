using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace HTC.Unity.Cef
{
    public class TestClass : IDisposable
    {
        #region Wrapper
        private delegate IntPtr DLL_CREATE();
        private DLL_CREATE createInstance;

        private delegate void DLL_DESTROY(IntPtr pObj);
        private DLL_DESTROY destroyInstance;

        private delegate void DLL_SET_INT(IntPtr pObj, int pInt);
        private DLL_SET_INT setInt;

        private delegate void DLL_SET_FLOAT(IntPtr pObj, float pFloat);
        private DLL_SET_FLOAT setFloat;

        private delegate void DLL_SET_STR(IntPtr pObj, string pString);
        private DLL_SET_STR setString;

        private delegate int DLL_GET_INT(IntPtr pObj);
        private DLL_GET_INT getInt;

        private delegate float DLL_GET_FLOAT(IntPtr pObj);
        private DLL_GET_FLOAT getFloat;

        private delegate IntPtr DLL_GET_STR(IntPtr pObj);
        private DLL_GET_STR getString;
        #endregion

        private IntPtr mObject;

        public TestClass(int pModule)
        {
            createInstance = (DLL_CREATE)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "CreatePCInstance"), typeof(DLL_CREATE));
            destroyInstance = (DLL_DESTROY)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "DestroyPCInstance"), typeof(DLL_DESTROY));

            mObject = createInstance();
            setInt = (DLL_SET_INT)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "PC_SetInt"), typeof(DLL_SET_INT));
            setFloat = (DLL_SET_FLOAT)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "PC_SetFloat"), typeof(DLL_SET_FLOAT));
            setString = (DLL_SET_STR)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "PC_SetStr"), typeof(DLL_SET_STR));
            getInt = (DLL_GET_INT)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "PC_GetInt"), typeof(DLL_GET_INT));
            getFloat = (DLL_GET_FLOAT)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "PC_GetFloat"), typeof(DLL_GET_FLOAT));
            getString = (DLL_GET_STR)Marshal.GetDelegateForFunctionPointer(Interop.GetProcAddress(pModule, "PC_GetStr"), typeof(DLL_GET_STR));
        }

        ~TestClass()
        {
            cleanup(false);
        }

        public void SetInt(int pVal)
        {
            setInt(mObject, pVal);
        }

        public void SetFloat(float pVal)
        {
            setFloat(mObject, pVal);
        }

        public void SetString(string pVal)
        {
            setString(mObject, pVal);
        }

        public int GetInt()
        {
            return getInt(mObject);
        }

        public float GetFloat()
        {
            return getFloat(mObject);
        }

        public string GetString()
        {
            var str = Marshal.PtrToStringAnsi(getString(mObject));
            return str;
        }

        private void cleanup(bool pIsDisposing)
        {
            if (mObject != IntPtr.Zero)
            {
                destroyInstance(mObject);
                mObject = IntPtr.Zero;
            }

            if (pIsDisposing)
                GC.SuppressFinalize(this);

        }

        public void Dispose()
        {
            cleanup(true);
        }


    }
}
