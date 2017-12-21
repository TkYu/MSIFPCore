using System;
using System.Runtime.InteropServices;

namespace Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter
{
    internal static class NativeMethods
    {
        public const uint LCMAP_SIMPLIFIED_CHINESE = 33554432;
        public const uint LCMAP_TRADITIONAL_CHINESE = 67108864;
        public const int zh_CN = 2052;

        [DllImport("KERNEL32.DLL", CharSet = CharSet.Unicode)]
        public static extern int LCMapString(int Locale, uint dwMapFlags, [MarshalAs(UnmanagedType.LPWStr)] string lpSrcStr, int cchSrc, IntPtr lpDestStr, int cchDest);

        //[DllImport("KERNEL32.DLL", CharSet = CharSet.Unicode)]
        //public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

        //[DllImport("KERNEL32.DLL", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool FreeLibrary(HandleRef hModule);

        //[DllImport("MSTR2TSC.DLL")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool TCSCInitialize();

        //[DllImport("MSTR2TSC.DLL")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool TCSCUninitialize();

        //[DllImport("MSTR2TSC.DLL")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool TCSCFreeConvertedText(IntPtr pv);

        //[DllImport("MSTR2TSC.DLL", CharSet = CharSet.Unicode)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool TCSCConvertText([MarshalAs(UnmanagedType.LPWStr)] string pwszInput, int cchInput, out IntPtr ppwszOutput, out int pcchOutput, ChineseConversionDirection dwDirection, [MarshalAs(UnmanagedType.Bool)] bool fCharBase, [MarshalAs(UnmanagedType.Bool)] bool fLocalTerm);
    }
}
