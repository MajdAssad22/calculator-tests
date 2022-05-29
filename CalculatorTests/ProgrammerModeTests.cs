using System;
using CalculatorControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class ProgrammerModeTests
    {
        [TestMethod]
        public void AddingBinary()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Programmer;
                CalculatorControl.Calculator.Base = CalculatorParams.Bases.Bin;
                var result = Calculator.Calculate("1001 + 11001");
                Assert.AreEqual("100010", result);
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
                Assert.AreEqual("1673", result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
