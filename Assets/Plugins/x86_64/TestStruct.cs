using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace HTC.Unity.Cef
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SimpleT
    {
        public int IntVal;
        public float FloatVal;
    }
}