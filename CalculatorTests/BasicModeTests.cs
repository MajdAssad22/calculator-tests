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
    }
}
