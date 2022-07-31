using System;
using CalculatorControl;
using CalculatorTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Boundary_Tests
{
    [TestClass]
    public class DisplayLogicTests
    {

        private static DisplayLogic displayLogic;

        #region Additional test attributes

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

        #endregion

        [ClassInitialize()]
        public static void TestsClassInitialize(TestContext testContext)
        {
            displayLogic = new DisplayLogic();
        }

        #region Additional test attributes
        // TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize() {
            displayLogic.CurrentExpression = "10 + 6";
            displayLogic.CurrentResult = "16";
        }
        #endregion

        #region ResetDisplay Function Tests

        [TestMethod]
        public void ResetDisplay1()
        {
            // CurrentExpression, CurrentResult: "10 + 6", "16"
            displayLogic.CurrentExpression = "10 + 6";
            displayLogic.CurrentResult = "16";

            string expectedExpresssion = "";
            string expectedResult = "";
            displayLogic.ResetDisplay();
            string actualExpression = displayLogic.CurrentExpression;
            string actualResult = displayLogic.CurrentResult;

            Assert.AreEqual(expectedExpresssion, actualExpression);
            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion

        #region SelectHistory Function Tests

        [TestMethod]
        public void SelectHistory1()
        {
            // ExpressionTree: Null
            ExpressionTree tree = null;

            string expectedExpression = "";
            string expectedResult = "";
            displayLogic.SelectHistory(tree);
            string actualExpression = displayLogic.CurrentExpression;
            string actualResult = displayLogic.CurrentResult ;


            Assert.AreEqual(expectedExpression, actualExpression);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void SelectHistory2()
        {
            // ExpressionTree: "3 + 2"
            ExpressionTree tree = new ExpressionTree("3 + 2");

            string expectedExpression = "3 + 2";
            string expectedResult = "5";
            displayLogic.SelectHistory(tree);
            string actualExpression = displayLogic.CurrentExpression;
            string actualResult = displayLogic.CurrentResult;


            Assert.AreEqual(expectedExpression, actualExpression);
            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion

        #region ConcatinateOperation Function Tests

        #endregion

        #region ConcatinateNumber Function Tests
        [TestMethod]
        public void ConcatinateNumber2()
        {
            // ExpressionTree: "3 + 2"
            ExpressionTree tree = new ExpressionTree("3 + 2");

            string expectedExpression = "3 + 2";
            string expectedResult = "5";
            displayLogic.SelectHistory(tree);
            string actualExpression = displayLogic.CurrentExpression;
            string actualResult = displayLogic.CurrentResult;


            Assert.AreEqual(expectedExpression, actualExpression);
            Assert.AreEqual(expectedResult, actualResult);
        }

        #endregion

        #region ClearHistory Function Tests

        #endregion

        #region RemoveLast Function Tests

        #endregion

        #region Calculate Function Tests

        #endregion

        #region ChangeBase Function Tests

        #endregion

        #region RadDegToggle Function Tests

        #endregion
    }
}
