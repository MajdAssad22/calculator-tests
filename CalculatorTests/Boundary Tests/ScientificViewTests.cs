using System;
using CalculatorTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Boundary_Tests
{
    [TestClass]
    public class ScientificViewTests
    {
        private static ScientificView scientificView;

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

        // TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            scientificView.CEBtn_OnClick(null, null);
        }
        #endregion

        [ClassInitialize()]
        public static void TestsClassInitialize(TestContext testContext)
        {
            scientificView = new ScientificView();
        }

        #region HistoryLv_OnSelectionChanged Event Tests

        #endregion

        #region CBtn_OnClick Event Tests

        #endregion

        #region CEBtn_OnClick Event Tests

        #endregion

        #region EqualBtn_OnClick Event Tests
        [TestMethod]
        public void EqualBtnOnClick1()
        {
            // 5 -> 6 -> 9 -> =
            scientificView.NumBtn_OnClick(scientificView.Num5Btn, null);
            scientificView.NumBtn_OnClick(scientificView.Num6Btn, null);
            scientificView.NumBtn_OnClick(scientificView.Num9Btn, null);
            scientificView.EqualBtn_OnClick(null, null);
            scientificView.UpdateGui();

            string expectedResult = "569";
            string actualResult = scientificView.ResultTb.Content.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion

        #region OperationBtn_OnClick Event Tests

        #endregion

        #region NumBtn_OnClick Event Tests
        [TestMethod]
        public void Number1ButtonClick()
        {
            // Sender, e: Number 1 Button, Null
            object sender = scientificView.Num1Btn;

            scientificView.NumBtn_OnClick(sender, null);
            scientificView.UpdateGui();

            Assert.AreEqual("1", scientificView.ExpressionTb.Content);
        }
        #endregion

        #region ClearBtn_OnClick Event Tests

        #endregion

        #region DeleteBtn_OnClick Event Tests

        #endregion

        #region FunctionBtn_OnClick Event Tests
        /*
         * Testing the SIN function,
         * by pressing this sequence of buttons:
         * 
         * radian/degree (want radian) → sin( → 3 → / → 2 → * → π → ) → =
         * 
         * Expected Expression: sin( 3 / 2 * π )
         * Expected Result: -1
         */
        [TestMethod]
        public void FunctionBtnTest1()
        {
            try
            {
                // If in degree change to radain
                if (scientificView.RadDegBtn.Content.ToString() == "Degree")
                {
                    scientificView.RadDegBtn_Click(scientificView.RadDegBtn, null);
                }

                scientificView.FunctionBtn_OnClick(scientificView.SinBtn, null); // sin(
                scientificView.NumBtn_OnClick(scientificView.Num3Btn, null); // 3
                scientificView.OperationBtn_OnClick(scientificView.DivBtn, null); // /
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null);// 2
                scientificView.OperationBtn_OnClick(scientificView.MulBtn, null); // *
                scientificView.NumBtn_OnClick(scientificView.PIBtn, null); // π 
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "sin( 3 / 2 * π )";
                string expectedResult = "-1";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Testing the COS function,
         * by pressing this sequence of buttons:
         * 
         * radian/degree (want degree) → cos( → 1 → 0 → 0 → * → 3 → . → 6 → ) → =
         * 
         * Expected Expression: cos( 100 * 3.6 )
         * Expected Result: 1
         */
        [TestMethod]
        public void FunctionBtnTest2()
        {
            try
            {
                // if in radian change to degree
                if (scientificView.RadDegBtn.Content.ToString() == "Radian")
                {
                    scientificView.RadDegBtn_Click(scientificView.RadDegBtn, null);
                }

                scientificView.FunctionBtn_OnClick(scientificView.CosBtn, null); // cos(
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.NumBtn_OnClick(scientificView.Num0Btn, null); // 0
                scientificView.NumBtn_OnClick(scientificView.Num0Btn, null); // 0
                scientificView.OperationBtn_OnClick(scientificView.MulBtn, null); // *
                scientificView.NumBtn_OnClick(scientificView.Num3Btn, null);// 3
                scientificView.NumBtn_OnClick(scientificView.DotBtn, null);// .
                scientificView.NumBtn_OnClick(scientificView.Num6Btn, null);// 6
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "cos( 100 * 3.6 )";
                string expectedResult = "1";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Testing the TAN function,
         * by pressing this sequence of buttons:
         * 
         * radian/degree (want radian) → tan( → π → / → ( → 3 → + → 1 → ) → ) → =
         * 
         * Expected Expression: tan( π * ( 9 + 3 ) )
         * Expected Result: 0
         */
        [TestMethod]
        public void FunctionBtnTest3()
        {
            try
            {
                // if in degree change to radian
                if (scientificView.RadDegBtn.Content.ToString() == "Degree")
                {
                    scientificView.RadDegBtn_Click(scientificView.RadDegBtn, null);
                }

                scientificView.FunctionBtn_OnClick(scientificView.TanBtn, null); // tan(
                scientificView.NumBtn_OnClick(scientificView.PIBtn, null); // π
                scientificView.OperationBtn_OnClick(scientificView.DivBtn, null); // /
                scientificView.OperationBtn_OnClick(scientificView.OpenBrackBtn, null); // (
                scientificView.NumBtn_OnClick(scientificView.Num3Btn, null); // 3
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null);// 1
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "tan( π / ( 3 + 1 ) )";
                string expectedResult = "1";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Testing the 1/( function,
         * by pressing this sequence of buttons:
         * 
         * 1/( → 5 → + → 2 → ) → * → 3 → =
         * 
         * Expected Expression: 1 / ( 5 + 2 ) * 3
         * Expected Result: 0.428571428571428
         */
        [TestMethod]
        public void FunctionBtnTest4()
        {
            try
            {
                scientificView.FunctionBtn_OnClick(scientificView.Div1Btn, null); // 1/(
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )
                scientificView.OperationBtn_OnClick(scientificView.MulBtn, null); // *
                scientificView.NumBtn_OnClick(scientificView.Num3Btn, null);// 3
                
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "1 / ( 5 + 2 ) * 3";
                string expectedResult = "0.428571428571429";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Testing the ASB function,
         * by pressing this sequence of buttons:
         * 
         * abs( → - → 5 → * → 2 → ) → =
         * 
         * Expected Expression: abs( -5 + 2 )
         * Expected Result: 3
         */
        [TestMethod]
        public void FunctionBtnTest5()
        {
            try
            {
                scientificView.FunctionBtn_OnClick(scientificView.AbsBtn, null); // abs(
                scientificView.OperationBtn_OnClick(scientificView.SubBtn, null); // -
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )
                
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "abs( -5 + 2 )";
                string expectedResult = "3";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Testing the LOG function,
         * by pressing this sequence of buttons:
         * 
         * log( → 1 → 0 → 0 → * → 1 → 0 → ) → =
         * 
         * Expected Expression: log( 100 * 10 )
         * Expected Result: 3
         */
        [TestMethod]
        public void FunctionBtnTest6()
        {
            try
            {
                scientificView.FunctionBtn_OnClick(scientificView.LogBtn, null); // log(
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.NumBtn_OnClick(scientificView.Num0Btn, null); // 0
                scientificView.NumBtn_OnClick(scientificView.Num0Btn, null); // 0
                scientificView.OperationBtn_OnClick(scientificView.MulBtn, null); // *
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.NumBtn_OnClick(scientificView.Num0Btn, null); // 0
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )
                
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "log( 100 * 10 )";
                string expectedResult = "3";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Testing the LN function,
         * by pressing this sequence of buttons:
         * 
         * ln( → 9 → * → e → ) → =
         * 
         * Expected Expression: ln( 9 * e )
         * Expected Result: 3.197224577336
         */
        [TestMethod]
        public void FunctionBtnTest7()
        {
            try
            {
                scientificView.FunctionBtn_OnClick(scientificView.LnBtn, null); // ln(
                scientificView.NumBtn_OnClick(scientificView.Num9Btn, null); // 9
                scientificView.OperationBtn_OnClick(scientificView.MulBtn, null); // *
                scientificView.NumBtn_OnClick(scientificView.EBtn, null); // e
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )
                
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "ln( 9 * e )";
                string expectedResult = Math.Log(9 * Math.E).ToString();
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Testing the x^y function,
         * by pressing this sequence of buttons:
         * 
         * 5 → x^y → ( → 1 → + → 2 → ) → =
         * 
         * Expected Expression: 5 ^ ( 1 + 2 )
         * Expected Result: 125
         */
        [TestMethod]
        public void FunctionBtnTest8()
        {
            try
            {
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.FunctionBtn_OnClick(scientificView.PowerBtn, null); // x^y
                scientificView.OperationBtn_OnClick(scientificView.OpenBrackBtn, null); // (
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "5 ^ ( 1 + 2 )";
                string expectedResult = Math.Pow(5,3).ToString();
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Testing the 10^y function,
         * by pressing this sequence of buttons:
         * 
         * 10^y → 5 → =
         * 
         * Expected Expression: 10 ^ 5
         * Expected Result: 100000
         */
        [TestMethod]
        public void FunctionBtnTest9()
        {
            try
            {
                scientificView.FunctionBtn_OnClick(scientificView.Powered10Btn, null); // 10^y
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "10 ^ 5";
                string expectedResult = Math.Pow(10,5).ToString();
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Testing the x^2 function,
         * by pressing this sequence of buttons:
         * 
         * ( → 5 → - → 1 → 1 → ) → x^2 → =
         * 
         * Expected Expression: ( 5 - 11 ) ^ 2
         * Expected Result: 36
         */
        [TestMethod]
        public void FunctionBtnTest10()
        {
            try
            {
                scientificView.OperationBtn_OnClick(scientificView.OpenBrackBtn, null); // (
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.SubBtn, null); // -
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )
                scientificView.FunctionBtn_OnClick(scientificView.SquaredBtn, null); // x^2

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "( 5 - 11 ) ^ 2";
                string expectedResult = Math.Pow(-6,2).ToString();
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Testing the Sqrt function,
         * by pressing this sequence of buttons:
         * 
         * sqrt( → 2 → 8 → - → 3 → ) → =
         * 
         * Expected Expression: sqrt( 28 - 3 )
         * Expected Result: 5
         */
        [TestMethod]
        public void FunctionBtnTest11()
        {
            try
            {
                scientificView.FunctionBtn_OnClick(scientificView.SqrtBtn, null); // sqrt(
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.NumBtn_OnClick(scientificView.Num8Btn, null); // 8
                scientificView.OperationBtn_OnClick(scientificView.SubBtn, null); // -
                scientificView.NumBtn_OnClick(scientificView.Num3Btn, null); // 3
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "sqrt( 28 - 3 )";
                string expectedResult = Math.Sqrt(28-3).ToString();
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region RadDegBtn_Click Event Tests
        /*
         * This test checks the functionality of the Radian/Degree button
         * 
         * First we check the current state of IsDegree in the calculator 
         * after that we press the button and check if it changed the
         * calculator's IsDegree state and the content of the button.
         */
        [TestMethod]
        public void RadDegBtnTest1()
        {
            try
            {
                // Old state of IsDegree:
                // True -> started as Degree
                // False -> started as Radian
                bool oldIsDegree = CalculatorControl.Calculator.IsDegree;

                scientificView.RadDegBtn_Click(scientificView.RadDegBtn, null);

                if (oldIsDegree)
                {
                    //Check the change from degree to radian in the calculator
                    Assert.IsFalse(CalculatorControl.Calculator.IsDegree);
                    Assert.AreEqual("Radian", scientificView.RadDegBtn.Content);
                }
                else
                {
                    //Check the change from radian to degree in the calculator
                    Assert.IsTrue(CalculatorControl.Calculator.IsDegree);
                    Assert.AreEqual("Degree", scientificView.RadDegBtn.Content);
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion
    }
}
