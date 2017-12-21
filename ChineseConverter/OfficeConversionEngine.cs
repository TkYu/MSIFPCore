/*
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter
{
    internal class OfficeConversionEngine
    {
        private static string MSOPath;
        private static string Mstr2tscPath;

        static OfficeConversionEngine()
        {
            string path1 = (string)null;
            RegistryKey registryKey1 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Office\\12.0\\Common\\InstallRoot");
            if (registryKey1 != null)
                path1 = Convert.ToString(registryKey1.GetValue("Path"), (IFormatProvider)null);
            RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Office\\12.0\\Common\\FilesPaths");
            if (registryKey2 != null)
                OfficeConversionEngine.MSOPath = Convert.ToString(registryKey2.GetValue("mso.dll"), (IFormatProvider)null);
            if (!string.IsNullOrEmpty(path1))
                OfficeConversionEngine.Mstr2tscPath = Path.Combine(path1, "ADDINS\\MSTR2TSC.DLL");
            if (!string.IsNullOrEmpty(OfficeConversionEngine.Mstr2tscPath) && File.Exists(OfficeConversionEngine.Mstr2tscPath))
                return;
            OfficeConversionEngine.Mstr2tscPath = (string)null;
        }

        private OfficeConversionEngine()
        {
        }

        public static OfficeConversionEngine Create()
        {
            if (string.IsNullOrEmpty(OfficeConversionEngine.MSOPath) || string.IsNullOrEmpty(OfficeConversionEngine.Mstr2tscPath))
                return (OfficeConversionEngine)null;
            return new OfficeConversionEngine();
        }

        /// <summary>使用Office12的轉換工具進行簡體中文和繁體中文之間的相互轉換。</summary>
        /// <param name="input">需要轉換的字串。</param>
        /// <param name="direction">轉換方式。</param>
        /// <returns>轉換的字串。</returns>
        public string TCSCConvert(string input, ChineseConversionDirection direction)
        {
            IntPtr handle1 = IntPtr.Zero;
            IntPtr handle2 = IntPtr.Zero;
            try
            {
                handle1 = NativeMethods.LoadLibrary(OfficeConversionEngine.MSOPath);
                handle2 = NativeMethods.LoadLibrary(OfficeConversionEngine.Mstr2tscPath);
                if (!NativeMethods.TCSCInitialize())
                    return (string)null;
                string str = (string)null;
                IntPtr ppwszOutput;
                int pcchOutput;
                if (NativeMethods.TCSCConvertText(input, input.Length, out ppwszOutput, out pcchOutput, direction, false, true))
                {
                    str = Marshal.PtrToStringUni(ppwszOutput);
                    NativeMethods.TCSCFreeConvertedText(ppwszOutput);
                }
                NativeMethods.TCSCUninitialize();
                return str;
            }
            finally
            {
                if (handle2 != IntPtr.Zero)
                    NativeMethods.FreeLibrary(new HandleRef((object)this, handle2));
                if (handle1 != IntPtr.Zero)
                    NativeMethods.FreeLibrary(new HandleRef((object)this, handle1));
            }
        }
    }
}
*/