using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace MySingingBird.Core.Utilities
{
    public static class StringHelpers
    {
        public static string ToInsecureString(this SecureString input)
        {
            string returnValue;
            IntPtr intPtr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input);
            try
            {
                returnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(intPtr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(intPtr);
            }
            return returnValue;
        }
    }
}
