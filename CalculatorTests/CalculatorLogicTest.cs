using CalculatorControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static CalculatorControl.CalculatorParams;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorLogicTest
    {

        #region TryConvertToNumber Function Tests

        [TestMethod]
        public void TryConvertToNumberTest1()
        {
            try
            {
                // Data , Number : "-10110" , 0
                Calculator.Mode = CalculatorModes.Programmer;
                Calculator.Base = Bases.Bin;
                string data = "-10110";
                double actualNumber = 0;

                bool expectedResult = true;
                double expectedNumber = -22;
                bool actualResult = CalculatorLogic.TryConvertToNumber(data, ref actualNumber);

                Assert.AreEqual(expectedResult, actualResult);
                Assert.AreEqual(expectedNumber, actualNumber);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TryConvertToNumberTest2()
        {
            try
            {
                // Data , Number : "A6" , 0
                Calculator.Mode = CalculatorModes.Programmer;
                Calculator.Base = Bases.Hex;
                string data = "A6";
                double actualNumber = 0;

                bool expectedResult = true;
                double expectedNumber = 166;
                bool actualResult = CalculatorLogic.TryConvertToNumber(data, ref actualNumber);

                Assert.AreEqual(expectedResult, actualResult);
                Assert.AreEqual(expectedNumber, actualNumber);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TryConvertToNumberTest3()
        {
            try
            {
                // Data , Number : "e" , 0
                Calculator.Mode = CalculatorModes.Scientific;
                string data = "e";
                double actualNumber = 0;

                bool expectedResult = true;
                double expectedNumber = Math.E;
                bool actualResult = CalculatorLogic.TryConvertToNumber(data, ref actualNumber);

                Assert.AreEqual(expectedResult, actualResult);
                Assert.AreEqual(expectedNumber, actualNumber);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TryConvertToNumberTest4()
        {
            try
            {
                // Data , Number : "π" , 0
                Calculator.Mode = CalculatorModes.Scientific;
                string data = "π";
                double actualNumber = 0;

                bool expectedResult = true;
                double expectedNumber = Math.PI;
                bool actualResult = CalculatorLogic.TryConvertToNumber(data, ref actualNumber);

                Assert.AreEqual(expectedResult, actualResult);
                Assert.AreEqual(expectedNumber, actualNumber);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TryConvertToNumberTest5()
        {
            try
            {
                // Data , Number : "150" , 0
                Calculator.Mode = CalculatorModes.Basic;
                string data = "150";
                double actualNumber = 0;

                bool expectedResult = true;
                double expectedNumber = 150;
                bool actualResult = CalculatorLogic.TryConvertToNumber(data, ref actualNumber);

                Assert.AreEqual(expectedResult, actualResult);
                Assert.AreEqual(expectedNumber, actualNumber);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TryConvertToNumberTest6()
        {
            try
            {
                // Data , Number : "sin(" , 0
                Calculator.Mode = CalculatorModes.Basic;
                string data = "sin(";
                double actualNumber = 0;

                bool expectedResult = false;
                double expectedNumber = 0;
                bool actualResult = CalculatorLogic.TryConvertToNumber(data, ref actualNumber);

                Assert.AreEqual(expectedResult, actualResult);
                Assert.AreEqual(expectedNumber, actualNumber);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        //Exception Tests
        [TestMethod]
        public void TryConvertToNumberExceptionTest1()
        {
            try
            {
                // Data , Number : "150" , 0
                Calculator.Mode = CalculatorModes.Programmer;
                Calculator.Base = Bases.Bin;
                string data = "150";
                double actualNumber = 0;

                bool expectedResult = false;
                double expectedNumber = 0;
                bool actualResult = CalculatorLogic.TryConvertToNumber(data, ref actualNumber);

                Assert.AreEqual(expectedResult, actualResult);
                Assert.AreEqual(expectedNumber, actualNumber);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TryConvertToNumberExceptionTest2()
        {
            try
            {
                // Data , Number : "A3" , 0
                Calculator.Mode = CalculatorModes.Programmer;
                Calculator.Base = Bases.Hex + 4;
                string data = "A3";
                double actualNumber = 0;

                bool expectedResult = false;
                double expectedNumber = 0;
                bool actualResult = CalculatorLogic.TryConvertToNumber(data, ref actualNumber);

                Assert.AreEqual(expectedResult, actualResult);
                Assert.AreEqual(expectedNumber, actualNumber);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        #endregion

        #region CalculateFunction Function Tests

        [TestMethod]
        public void CalculateFunctionTest1()
        {
            try
            {
                // Function , Number : "-sin(" , 50
                Calculator.Mode = CalculatorModes.Scientific;
                Calculator.IsDegree = true;
                string function = $"-{SIN_FUNC}";
                double number = 50;

                double expectedResult = -Math.Sin(number * Math.PI / 180);
                double actualResult = CalculatorLogic.CalculateFunction(function, number);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalculateFunctionTest2()
        {
            try
            {
                // Function , Number : "sin(" , 180
                Calculator.Mode = CalculatorModes.Scientific;
                Calculator.IsDegree = true;
                string function = SIN_FUNC;
                double number = 180;

                double expectedResult = Math.Sin(number * Math.PI / 180);
                double actualResult = CalculatorLogic.CalculateFunction(function, number);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalculateFunctionTest3()
        {
            try
            {
                // Function , Number : "cos(" , 85
                Calculator.Mode = CalculatorModes.Scientific;
                Calculator.IsDegree = true;
                string function = COS_FUNC;
                double number = 85;

                double expectedResult = Math.Cos(number * Math.PI / 180);
                double actualResult = CalculatorLogic.CalculateFunction(function, number);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalculateFunctionTest4()
        {
            try
            {
                // Function , Number : "tan(" , 95
                Calculator.Mode = CalculatorModes.Scientific;
                Calculator.IsDegree = true;
                string function = TAN_FUNC;
                double number = 95;

                double expectedResult = Math.Tan(number * Math.PI / 180);
                double actualResult = CalculatorLogic.CalculateFunction(function, number);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalculateFunctionTest5()
        {
            try
            {
                // Function , Number : "tan(" , 2π
                Calculator.Mode = CalculatorModes.Scientific;
                Calculator.IsDegree = false;
                string function = TAN_FUNC;
                double number = 2 * Math.PI;

                double expectedResult = Math.Tan(number);
                double actualResult = CalculatorLogic.CalculateFunction(function, number);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalculateFunctionTest6()
        {
            try
            {
                // Function , Number : "log(" , 46
                Calculator.Mode = CalculatorModes.Scientific;
                string function = LOG_FUNC;
                double number = 46;

                double expectedResult = Math.Log10(number);
                double actualResult = CalculatorLogic.CalculateFunction(function, number);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalculateFunctionTest7()
        {
            try
            {
                // Function , Number : "ln(" , e
                Calculator.Mode = CalculatorModes.Scientific;
                string function = LN_FUNC;
                double number = Math.E;

                double expectedResult = Math.Log(number);
                double actualResult = CalculatorLogic.CalculateFunction(function, number);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalculateFunctionTest8()
        {
            try
            {
                // Function , Number : "%" , 85
                Calculator.Mode = CalculatorModes.Scientific;
                string function = PERC;
                double number = 85;

                double expectedResult = number / 100;
                double actualResult = CalculatorLogic.CalculateFunction(function, number);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalculateFunctionTest9()
        {
            try
            {
                // Function , Number : "abs(" , -6
                Calculator.Mode = CalculatorModes.Scientific;
                string function = ABS_FUNC;
                double number = -6;

                double expectedResult = Math.Abs(number);
                double actualResult = CalculatorLogic.CalculateFunction(function, number);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalculateFunctionTest10()
        {
            try
            {
                // Function , Number : "sqrt(" , 16
                Calculator.Mode = CalculatorModes.Scientific;
                string function = SQRT_FUNC;
                double number = 16;

                double expectedResult = Math.Sqrt(number);
                double actualResult = CalculatorLogic.CalculateFunction(function, number);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalculateFunctionTest11()
        {
            try
            {
                // Function , Number : "factor(" , 75
                Calculator.Mode = CalculatorModes.Scientific;
                string function = "factor(";
                double number = 75;

                double expectedResult = number;
                double actualResult = CalculatorLogic.CalculateFunction(function, number);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        #endregion

        #region GetPriority Function Tests

        [TestMethod]
        public void GetPriorityTest1()
        {
            try
            {
                // Operation : "^"
                string operation = POW;

                int expectedResult = 3;
                int actualResult = CalculatorLogic.GetPriority(operation);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void GetPriorityTest2()
        {
            try
            {
                // Operation : "*"
                string operation = MULT;

                int expectedResult = 2;
                int actualResult = CalculatorLogic.GetPriority(operation);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void GetPriorityTest3()
        {
            try
            {
                // Operation : "/"
                string operation = DIV;

                int expectedResult = 2;
                int actualResult = CalculatorLogic.GetPriority(operation);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void GetPriorityTest4()
        {
            try
            {
                // Operation : "+"
                string operation = ADD;

                int expectedResult = 1;
                int actualResult = CalculatorLogic.GetPriority(operation);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void GetPriorityTest5()
        {
            try
            {
                // Operation : "-"
                string operation = SUB;

                int expectedResult = 1;
                int actualResult = CalculatorLogic.GetPriority(operation);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void GetPriorityTest6()
        {
            try
            {
                // Operation : ")"
                string operation = CLOSE_BRACK;

                int expectedResult = 0;
                int actualResult = CalculatorLogic.GetPriority(operation);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void GetPriorityTest7()
        {
            try
            {
                // Operation : "factor("
                string operation = "factor(";

                int expectedResult = -1;
                int actualResult = CalculatorLogic.GetPriority(operation);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        #endregion

        #region IsFunction Function Tests

        [TestMethod]
        public void IsFunctionTest1()
        {
            try
            {
                // Function  : "-("
                string function = $"-{OPEN_BRACK}";

                bool expectedResult = true;
                bool actualResult = CalculatorLogic.IsFunction(function);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void IsFunctionTest2()
        {
            try
            {
                // Function  : "-sin("
                string function = $"-{SIN_FUNC}";

                bool expectedResult = true;
                bool actualResult = CalculatorLogic.IsFunction(function);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void IsFunctionTest3()
        {
            try
            {
                // Function  : "sin("
                string function = SIN_FUNC;

                bool expectedResult = true;
                bool actualResult = CalculatorLogic.IsFunction(function);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void IsFunctionTest4()
        {
            try
            {
                // Function  : "cos("
                string function = COS_FUNC;

                bool expectedResult = true;
                bool actualResult = CalculatorLogic.IsFunction(function);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void IsFunctionTest5()
        {
            try
            {
                // Function  : "tan("
                string function = TAN_FUNC;

                bool expectedResult = true;
                bool actualResult = CalculatorLogic.IsFunction(function);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void IsFunctionTest6()
        {
            try
            {
                // Function  : "log("
                string function = LOG_FUNC;

                bool expectedResult = true;
                bool actualResult = CalculatorLogic.IsFunction(function);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void IsFunctionTest7()
        {
            try
            {
                // Function  : "ln("
                string function = LN_FUNC;

                bool expectedResult = true;
                bool actualResult = CalculatorLogic.IsFunction(function);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void IsFunctionTest8()
        {
            try
            {
                // Function  : "sqrt("
                string function = SQRT_FUNC;

                bool expectedResult = true;
                bool actualResult = CalculatorLogic.IsFunction(function);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void IsFunctionTest9()
        {
            try
            {
                // Function  : "abs("
                string function = ABS_FUNC;

                bool expectedResult = true;
                bool actualResult = CalculatorLogic.IsFunction(function);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void IsFunctionTest10()
        {
            try
            {
                // Function  : "%"
                string function = PERC;

                bool expectedResult = true;
                bool actualResult = CalculatorLogic.IsFunction(function);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void IsFunctionTest11()
        {
            try
            {
                // Function  : "factor("
                string function = "factor(";

                bool expectedResult = false;
                bool actualResult = CalculatorLogic.IsFunction(function);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        #endregion

        #region ChangeBase Function Tests

        [TestMethod]
        public void ChangeBaseTest1()
        {
            try
            {
                // Data , WantedBase : "2" , Bin
                string data = "2";
                Bases wantedBase = Bases.Bin;

                string expectedResult = Convert.ToString(Convert.ToInt32(data), (int)wantedBase);
                string actualResult = CalculatorLogic.ChangeBase(data, wantedBase);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void ChangeBaseTest2()
        {
            try
            {// Data , WantedBase : "1.2" , Oct
                string data = "1.2";
                Bases wantedBase = Bases.Oct;

                string expectedResult = INVALID_INPUT;
                string actualResult = CalculatorLogic.ChangeBase(data, wantedBase);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        #endregion
    }
}
