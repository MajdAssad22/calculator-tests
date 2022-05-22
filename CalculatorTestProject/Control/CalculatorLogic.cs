using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.Control
{
    public static class CalculatorLogic
    {
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
            // If the function is a trigonometric function
            if((function == CalculatorParams.SIN_FUNC ||
                function == CalculatorParams.COS_FUNC ||
                function == CalculatorParams.TAN_FUNC) && Calculator.IsDegree)
            {
                number = number * Math.PI / 180;
            }
            switch (function)
            {
                case CalculatorParams.SIN_FUNC:
                    return Math.Sin(number);

                case CalculatorParams.COS_FUNC:
                    return Math.Cos(number);
                
                case CalculatorParams.TAN_FUNC:
                    return Math.Tan(number);
                
                case CalculatorParams.LOG_FUNC:
                    return Math.Log10(number);
                
                case CalculatorParams.LN_FUNC:
                    return Math.Log(number);

                case CalculatorParams.PERC:
                    return number / 100;

                case CalculatorParams.ABS_FUNC:
                    return Math.Abs(number);

                case CalculatorParams.SQRT_FUNC:
                    return Math.Sqrt(number);
                
                default:
                    return number;
            }
        }
        public static double ConvertToNumber(string data)
        {
            if (data.Equals(CalculatorParams.E))
            {
                return Math.E;
            }
            else if (data.Equals(CalculatorParams.PI))
            {
                return Math.PI;
            }
            else
            {
                return Convert.ToDouble(data);
            }
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
        public static bool IsFunction(string expression)
        {
            if (expression.Equals(CalculatorParams.SIN_FUNC)
                || expression.Equals(CalculatorParams.COS_FUNC)
                || expression.Equals(CalculatorParams.TAN_FUNC)
                || expression.Equals(CalculatorParams.LOG_FUNC)
                || expression.Equals(CalculatorParams.LN_FUNC)
                || expression.Equals(CalculatorParams.PERC)
                || expression.Equals(CalculatorParams.ABS_FUNC)
                || expression.Equals(CalculatorParams.SQRT_FUNC))
                return true;
            return false;
        }
        public static bool IsMathConst(string expression)
        {
            if (expression.Equals(CalculatorParams.E) || expression.Equals(CalculatorParams.PI))
            {
                return true;
            }
            return false;
        }
    }
}
