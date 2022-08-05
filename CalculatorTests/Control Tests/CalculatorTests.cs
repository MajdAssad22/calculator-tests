using System;
using CalculatorControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        #region Test Attributes
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        // TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Calculator.Mode = CalculatorParams.CalculatorModes.Basic;
        }
        #endregion

        #region Calculate Function Tests
        [TestMethod]
        public void CalculateTest1()
        {
            try
            {
                // Expression: abs( -6 - 1 )
                string expression =
                    $"{CalculatorParams.ABS_FUNC} -6 {CalculatorParams.SUB} 1 {CalculatorParams.CLOSE_BRACK}";

                string expectedResult = "7";
                string actualResult = Calculator.Calculate(expression);

                // Check returned result
                Assert.AreEqual(expectedResult, actualResult);
                // Check history
                Assert.AreEqual(Calculator.History[Calculator.History.Count-1].Expression, expression);
                Assert.AreEqual(Calculator.History[Calculator.History.Count-1].Result, expectedResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region Format Function Tests
        [TestMethod]
        public void FormatTest1()
        {
            try
            {
                // Expression: 1101 - 1001
                Calculator.Mode = CalculatorParams.CalculatorModes.Programmer;
                Calculator.Base = CalculatorParams.Bases.Bin;
                ExpressionTree expressionTree = new ExpressionTree($"1101 {CalculatorParams.SUB} 1001");

                string expectedResult = "100";
                string actualResult = Calculator.Format(expressionTree);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void FormatTest2()
        {
            try
            {
                // Expression: 49 / 7
                Calculator.Mode = CalculatorParams.CalculatorModes.Basic;
                ExpressionTree expressionTree = new ExpressionTree($"49 {CalculatorParams.DIV} 7");

                string expectedResult = "7";
                string actualResult = Calculator.Format(expressionTree);

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
