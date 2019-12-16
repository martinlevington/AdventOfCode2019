using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Day_14_2019_Code
{

    public static class Equations
    {
    public enum Sign
    {
        Comma,
        Makes,
    
    }

    public static string  ToString(this Sign sign)
    {
        switch (sign)
        {
            case Sign.Comma:
                return ",";
                break;
            case Sign.Makes:
                return "=>";
                break;
            default:
                throw new Exception("UnKnown Sign");
        }
    }
  

        public static Sign ToEquationSign(string sign)
        {
            switch (sign)
            {
                case ",":
                    return Sign.Comma;
                    break;
                case "=>":
                    return Sign.Makes;
                    break;
                default:
                    throw new Exception("UnKnown Sign");
            }
        }

    }
}
