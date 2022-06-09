using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorControl
{
    public static class CalculatorLogic
    {
        public static bool TryConvertToNumber(string data, ref double number)
        {
            bool isNegative = false;
            if (data.StartsWith("-"))
            {
                isNegative = true;
                data = data.Trim('-');
            }

            if (Calculator.Mode == CalculatorParams.CalculatorModes.Programmer)
            {
                try
                {
                    number = Convert.ToInt32(data, (int)Calculator.Base);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else if (data.Equals(CalculatorParams.E))
            {
                number = Math.E;
            }
            else if (data.Equals(CalculatorParams.PI))
            {
                number = Math.PI;
            }
            else if (double.TryParse(data, out double output))
            {
                number = output;
            }
            else
            {
                return false;
            }

            if (isNegative)
            {
                number = -number;
            }
            return true;
        }
        /// <summary>
        /// This function calculates the given mathematical function on a given number,
        /// If the function is not defined then the number is returned.
        /// </summary>
        /// <param name="function">
        /// String that indicates which function to execute.
        /// </param>
        /// <param name="number">
        /// Double indicates the number to execute the function on.
        /// </param>
        /// <returns>
        /// Returns the calculated value or the number it self if the function is not defined.
        /// </returns>
        public static double CalculateFunction(string function, double number)
        {
            bool isNegative = false;
            if (function.StartsWith("-"))
            {
                isNegative = true;
                function = function.Trim('-');
            }

            // If the function is a trigonometric function
            if ((function == CalculatorParams.SIN_FUNC ||
                function == CalculatorParams.COS_FUNC ||
                function == CalculatorParams.TAN_FUNC) && Calculator.IsDegree)
            {
                number = number * Math.PI / 180;
            }
            switch (function)
            {
                case CalculatorParams.SIN_FUNC:
                    number = Math.Sin(number);
                    break;
                case CalculatorParams.COS_FUNC:
                    number = Math.Cos(number);
                    break;
                case CalculatorParams.TAN_FUNC:
                    number = Math.Tan(number);
                    break;
                case CalculatorParams.LOG_FUNC:
                    number = Math.Log10(number);
                    break;
                case CalculatorParams.LN_FUNC:
                    number = Math.Log(number);
                    break;
                case CalculatorParams.PERC:
                    number /= 100;
                    break;
                case CalculatorParams.ABS_FUNC:
                    number = Math.Abs(number);
                    break;
                case CalculatorParams.SQRT_FUNC:
                    number = Math.Sqrt(number);
                    break;
                default:
                    break;
            }

            if (isNegative)
            {
                return -number;
            }

            return number;
        }
        public static int GetPriority(string operation)
        {
            switch (operation)
            {
                case CalculatorParams.POW:
                    return 3;
                case CalculatorParams.MULT:
                case CalculatorParams.DIV:
                    return 2;
                case CalculatorParams.ADD:
                case CalculatorParams.SUB:
                    return 1;
                case CalculatorParams.CLOSE_BRACK:
                    return 0;
                default:
                    return -1;
            }
        }
        public static bool IsFunction(string function)
        {
            if (function.StartsWith("-"))
            {
                function = function.Trim('-');
                if (function.Equals(CalculatorParams.OPEN_BRACK))
                {
                    return true;
                }
            }
            switch (function)
            {
                case CalculatorParams.SIN_FUNC:
                case CalculatorParams.COS_FUNC:
                case CalculatorParams.TAN_FUNC:
                case CalculatorParams.LOG_FUNC:
                case CalculatorParams.LN_FUNC:
                case CalculatorParams.SQRT_FUNC:
                case CalculatorParams.ABS_FUNC:
                case CalculatorParams.PERC:
                    return true;
                default:
                    return false;
            }
        }
        public static string ChangeBase(string data, CalculatorParams.Bases wantedBase)
        {
            if (Int32.TryParse(data, out int result))
            {
                return Convert.ToString(result, (int)wantedBase);
            }
            return CalculatorParams.INVALID_INPUT;
        }
    }
}
