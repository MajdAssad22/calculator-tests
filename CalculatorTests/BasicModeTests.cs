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
                Assert.AreEqual(Double.PositiveInfinity, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void AddingBinary()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Programmer;
                CalculatorControl.Calculator.Base = CalculatorParams.Bases.Bin;
                var result = Calculator.Calculate("1001 + 11001");
                Assert.AreEqual(34, result);                   
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void AddingOctal()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Programmer;
                CalculatorControl.Calculator.Base = CalculatorParams.Bases.Oct;
                var result = Calculator.Calculate("712 + 761");
                Assert.AreEqual(955, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
