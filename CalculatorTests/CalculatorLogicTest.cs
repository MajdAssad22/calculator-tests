using CalculatorControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorLogicTest
    {
        //CalculateFunction TEST
        [TestMethod]
        public void CalFunction01()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = false;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.SIN_FUNC, 13);
                Assert.AreEqual(Math.Sin(13), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction02()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = false;
                var result = CalculatorLogic.CalculateFunction("-" + CalculatorParams.SIN_FUNC, -15);
                Assert.AreEqual(-Math.Sin(-15), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction03()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = false;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.COS_FUNC, 13);
                Assert.AreEqual(Math.Cos(13), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction04()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = false;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.SIN_FUNC, 0);
                Assert.AreEqual(Math.Sin(0), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction05()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = false;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.SIN_FUNC, 90);
                Assert.AreEqual(Math.Sin(90), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction06()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = false;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.TAN_FUNC, 360);
                Assert.AreEqual(Math.Tan(360), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction07()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = false;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.COS_FUNC,0);
                Assert.AreEqual(Math.Cos(0), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction08()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = false;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.TAN_FUNC, 120);
                Assert.AreEqual(Math.Tan(120), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction09()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = true;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.SIN_FUNC, 90);
                Assert.AreEqual(Math.Sin(90 * Math.PI / 180), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction11()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = true;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.SQRT_FUNC, 9);
                Assert.AreEqual(Math.Sqrt(9), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
