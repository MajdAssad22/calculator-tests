using System;
using System.Runtime.Remoting;
using CalculatorControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class ScientificModeTests
    {
        [TestMethod]
        public void SinFunctionTest()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                var result = Calculator.Calculate("sin( 5 + 9 - 1 )");
                Assert.AreEqual(Math.Sin(13).ToString(), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CosFunctionTest()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                var result = Calculator.Calculate("cos( 5 + 9 - 1 )");
                Assert.AreEqual(Math.Cos(13).ToString(), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
