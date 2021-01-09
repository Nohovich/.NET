using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    // Default underlying type is int and the value starts at ZERO
    public enum GenderEx
    {
        Unknown,
        Male,
        Female
    }


    // Gender enum underlying type is now short and the value starts at ONE
    public enum GenderEX1 : short
    {
        Unknown = 1,
        Male = 2,
        Female = 3
    }


    // Enum values need not be in sequential order. Any valid underlying type value is allowed 
    public enum GenderEX2 : short
    {
        Unknown = 10,
        Male = 22,
        Female = 35
    }


    // This enum will not compile, bcos the maximum value allowed for short data type is 32767. 
    public enum GenderEX3 : short
    {
        Unknown = 10,
         //Male = 32768,
        Female = 35
    }
}
