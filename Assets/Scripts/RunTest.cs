using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using HTC.Unity.Cef;

public class RunTest : MonoBehaviour
{
    LibLoader ll;
    TestClass tc;

    void Awake()
    {
        ll = LibLoader.Instance;
        ll.LoadModule();

        FuncLib.LoadFuncs(ll.ModuleHandle);
        tc = new TestClass(ll.ModuleHandle);
    }
    void Start()
    {
        if (ll.IsLoaded)
        {
            Debug.Log("////////// FUNCS ///////////");
            Debug.Log(FuncLib.PrintANumber());
            Debug.Log(Marshal.PtrToStringAnsi(FuncLib.PrintHello()));
            Debug.Log(FuncLib.AddTwoIntegers(5, 10));
            Debug.Log(FuncLib.AddTwoFloats(2.5f, 5.5f));
            Debug.Log(Marshal.PtrToStringAnsi(FuncLib.Greeting("Player 1")));

            var s = FuncLib.GetStruct(2, 4.5f);
            Debug.Log(String.Format("Struct contains: {0}, {1}", s.IntVal, s.FloatVal));

            Debug.Log("////////// CLASS ///////////");
            tc.SetInt(5);
            tc.SetFloat(6.0f);
            tc.SetString("Seven");

            Debug.Log(tc.GetInt());
            Debug.Log(tc.GetFloat());
            Debug.Log(tc.GetString());
        }
    }

    void OnApplicationQuit()
    {
        tc.Dispose();
        ll.UnloadModule();
    }
}
