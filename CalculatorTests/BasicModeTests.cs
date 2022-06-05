using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorControl;

namespace CalculatorTests
{
    [TestClass]
    public class BasicModeTests
    {
        [TestMethod]
        public void DivideByZeroTest()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Basic;
                var result = CalculatorControl.Calculator.Calculate("2 / 0");
                Assert.AreEqual(Double.PositiveInfinity.ToString(), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        
        [TestMethod]
        public void PercentageTest()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Basic;
                var result = CalculatorControl.Calculator.Calculate("5 %");
                Assert.AreEqual("0.05", result);
                result = CalculatorControl.Calculator.Calculate("% 5");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result); 
                result = CalculatorControl.Calculator.Calculate("3 * 9 + 2 %");
                Assert.AreEqual("27.02", result);
                result = CalculatorControl.Calculator.Calculate("( 10 % )");
                Assert.AreEqual("0.1", result);
                result = CalculatorControl.Calculator.Calculate("( 10 + 6 ) %");
                Assert.AreEqual("0.16", result);
                result = CalculatorControl.Calculator.Calculate("( 10 + 6 ) % %");
                Assert.AreEqual("0.0016", result);
                result = CalculatorControl.Calculator.Calculate("( e ) %");
                Assert.AreEqual((Math.E / 100).ToString(), result);
                result = CalculatorControl.Calculator.Calculate("( % 5 + 6 )");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result);
                result = CalculatorControl.Calculator.Calculate("5 + % 5");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result);
                result = CalculatorControl.Calculator.Calculate("5 + -%");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void OpenBracketTest()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Basic;
                Calculator.IsDegree = true;
                var result = CalculatorControl.Calculator.Calculate("5 ( 5 + 6 )");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result);
                result = CalculatorControl.Calculator.Calculate("6 + ( 5 + 6 )");
                Assert.AreEqual("17", result);
                result = CalculatorControl.Calculator.Calculate("( + 6 )");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result);
                result = CalculatorControl.Calculator.Calculate("( 8 + )");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result);
                result = CalculatorControl.Calculator.Calculate("( 5");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result);
                result = CalculatorControl.Calculator.Calculate("sin( ( 4 + 5 ) * 7 )");
                Assert.AreEqual(Math.Sin(63 * Math.PI / 180).ToString(), result);
                result = CalculatorControl.Calculator.Calculate("( ( 4 + 5 ) * 7 )");
                Assert.AreEqual("63", result);
                result = CalculatorControl.Calculator.Calculate("4 + ( ( 5 ) )");
                Assert.AreEqual("9", result);
                result = CalculatorControl.Calculator.Calculate("- ( 5 )");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result);
                result = CalculatorControl.Calculator.Calculate("( 5 + 9 ) ( 5 )");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result);
                result = CalculatorControl.Calculator.Calculate("5 + 9 ( 5 + 8 )");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result);
                result = CalculatorControl.Calculator.Calculate(" 5 + 9 % ( 5 )");
                Assert.AreEqual(CalculatorParams.INVALID_INPUT, result);
                result = CalculatorControl.Calculator.Calculate("100 + -( 3 + 6 )");
                Assert.AreEqual("91", result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
