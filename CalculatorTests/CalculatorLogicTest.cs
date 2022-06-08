using CalculatorControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static CalculatorControl.CalculatorParams;

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
        [TestMethod]
        public void CalFunction12()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = true;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.LOG_FUNC, 10);
                Assert.AreEqual(Math.Log10(10), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction13()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = true;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.LN_FUNC, Math.E);
                Assert.AreEqual(Math.Log(Math.E), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction14()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = true;
                var result = CalculatorLogic.CalculateFunction(CalculatorParams.PERC, 10);
                Assert.AreEqual((double)10/100, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void CalFunction15()
        {
            try
            {
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = true;
                var result = CalculatorLogic.CalculateFunction("nor(", 10);
                Assert.AreEqual(10, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        // log ln % nor
        // TryConvertToNumber
        public void TryConvertToNumberTest()
        {

        }
        //// IsFunction Test
        [TestMethod]
        public void Function01()// check
        {
            try
            {
            var result = CalculatorLogic.IsFunction("factor(");
            Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        [TestMethod]
        public void Function02()
        {
            try
            {
            var result = CalculatorLogic.IsFunction("-" + CalculatorParams.COS_FUNC);
             Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            
        }
        [TestMethod]
        public void Function03()
        {
            try
            {
            var result = CalculatorLogic.IsFunction(CalculatorParams.COS_FUNC);
            Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void Function04()
        {
            try
            {
            var result = CalculatorLogic.IsFunction("-sin(");
            Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void Function05()
        {
            try
            {
                var result = CalculatorLogic.IsFunction("-(");
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }//-( → true
        
        // GetPriority
        [TestMethod]
        public void PriorityFunction1() // ask about this 
        {
            try
            {
                var result = CalculatorLogic.GetPriority(CalculatorParams.POW);

                Assert.AreEqual(3, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        } // pow
        [TestMethod]
        public void PriorityFunction2() // ask about this  // mult
        {
            try
            {
                var result = CalculatorLogic.GetPriority(CalculatorParams.MULT);

                Assert.AreEqual(2, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void PriorityFunction3() // ask about this //div
        {
            try
            {
                var result = CalculatorLogic.GetPriority(CalculatorParams.DIV);

                Assert.AreEqual(2, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void PriorityFunction4() // ask about this 
        {
            try
            {
                var result = CalculatorLogic.GetPriority(CalculatorParams.ADD);

                Assert.AreEqual(1, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }//add
        [TestMethod]
        public void PriorityFunction5() // ask about this 
        {
            try
            {
                var result = CalculatorLogic.GetPriority(CalculatorParams.SUB);

                Assert.AreEqual(1, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }//sub
        [TestMethod]
        public void PriorityFunction6() // ask about this 
        {
            try
            {
                var result = CalculatorLogic.GetPriority(CalculatorParams.CLOSE_BRACK);

                Assert.AreEqual(0, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }//close brack
        [TestMethod]
        public void PriorityFunction7() // ask about this 
        {
            try
            {
                var result = CalculatorLogic.GetPriority("factor()");

                Assert.AreEqual(-1, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        // ChangeBase
        [TestMethod]
        public void ChangeBaseTest01()
        {
            try
            {
                var result = CalculatorLogic.ChangeBase("2", Bases.Bin);//base 2
                Assert.AreEqual(Convert.ToString(2, 2), result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void ChangeBaseTest02()
        {
            try
            {
                var result = CalculatorLogic.ChangeBase("2.1", Bases.Bin);//base 2
                Assert.AreEqual(INVALID_INPUT, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}
