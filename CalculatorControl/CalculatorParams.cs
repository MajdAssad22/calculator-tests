using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorControl
{
    public static class CalculatorParams
    {
        public const string INVALID_INPUT = "Incorrect Input";
        public enum CalculatorModes { Basic, Programmer, Scientific }
        public enum Bases { Bin = 2, Oct = 8, Dec = 10, Hex = 16}
        public const string ADD = "+";
        public const string SUB = "-";
        public const string MULT = "*";
        public const string DIV = "/";
        public const string POW = "^";
        public const string PERC = "%";
        public const string OPEN_BRACK = "(";
        public const string CLOSE_BRACK = ")";
        public const string SQRT_FUNC = "sqrt(";
        public const string ABS_FUNC = "abs(";
        public const string SIN_FUNC = "sin(";
        public const string COS_FUNC = "cos(";
        public const string TAN_FUNC = "tan(";
        public const string LOG_FUNC = "log(";
        public const string LN_FUNC = "ln(";
        public const string E = "e";
        public const string PI = "π";
    }
}
