using System;
using System.Collections.Generic;
using System.Windows.Controls;
using CalculatorBoundary;
using CalculatorTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class AcceptanceTests
    {
        private static CalculatorWindow calculatorWindow;

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

        #region Additional test attributes
        // TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            calculatorWindow.basicView.DisplayLogic.ResetDisplay();
            calculatorWindow.programmerView.DisplayLogic.ResetDisplay();
            calculatorWindow.scientificView.DisplayLogic.ResetDisplay();
        }
        #endregion

        [ClassInitialize()]
        public static void TestsClassInitialize(TestContext testContext)
        {
            calculatorWindow = new CalculatorWindow();
        }


        #region Mathematical Expression Feeding Tests
        /*
         * Check the way to enter this mathematical expression:
         * 
         * Expression:  150*(60+163)/2
         * Result:  16725
         */
        [TestMethod]
        public void ExpressionFeedingTest1()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.BasicTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);
                
                // Feeding the expression
                BasicView basicView = calculatorWindow.basicView;
                basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
                basicView.NumBtn_OnClick(basicView.Num5Btn, null); // 5
                basicView.NumBtn_OnClick(basicView.Num0Btn, null); // 0
                basicView.OperationBtn_OnClick(basicView.MulBtn, null); // *
                basicView.OperationBtn_OnClick(basicView.OpenBrackBtn , null); // (
                basicView.NumBtn_OnClick(basicView.Num6Btn, null); // 6
                basicView.NumBtn_OnClick(basicView.Num0Btn, null); // 0
                basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
                basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
                basicView.NumBtn_OnClick(basicView.Num6Btn, null); // 6
                basicView.NumBtn_OnClick(basicView.Num3Btn, null); // 3
                basicView.OperationBtn_OnClick(basicView.CloseBrackBtn , null); // )
                basicView.OperationBtn_OnClick(basicView.DivBtn , null); // /
                basicView.NumBtn_OnClick(basicView.Num2Btn, null); // 2
                basicView.EqualBtn_OnClick(null, null); // =
                basicView.UpdateGui();

                string expectedExpression = "150 * ( 60 + 163 ) / 2";
                string expectedResult = "16725";
                Assert.AreEqual(expectedExpression, basicView.ExpressionTb.Content); // Check the expression
                Assert.AreEqual(expectedResult, basicView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the way to enter this mathematical expression:
         * 
         * Expression:  110110+1101 (In Binary)
         * Result:  1000011
         */
        [TestMethod]
        public void ExpressionFeedingTest2()
        {
            try
            {
                // Switching to the programmer tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ProgrammerTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                ProgrammerView programmerView = calculatorWindow.programmerView;
                programmerView.ChangeBaseBtn_OnClick(programmerView.BinBtn, null); // Change to binary base
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.NumBtn_OnClick(programmerView.Num0Btn, null); // 0
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.NumBtn_OnClick(programmerView.Num0Btn, null); // 0
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.NumBtn_OnClick(programmerView.Num0Btn, null); // 0
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.UpdateGui();

                string expectedExpression = "110110 + 1101";
                string expectedResult = "1000011";
                Assert.AreEqual(expectedExpression, programmerView.ExpressionTb.Content); // Check the expression
                Assert.AreEqual(expectedResult, programmerView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region Functions Feeding Tests
        /*
         * Check the way to enter this mathematical function:
         * 
         * Expression:  sin(95+20) (in degree)
         * Result:  0.90630778703665
         */
        [TestMethod]
        public void ExpressionFuncitonTest1()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;
                if (scientificView.RadDegBtn.Content.ToString() == "Radian")
                {
                    // If in radian change back to degree
                    scientificView.RadDegBtn_Click(scientificView.RadDegBtn, null);
                }

                scientificView.FunctionBtn_OnClick(scientificView.SinBtn, null); // Sin
                scientificView.NumBtn_OnClick(scientificView.Num9Btn, null); // 9
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.NumBtn_OnClick(scientificView.Num0Btn, null); // 0
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "sin( 95 + 20 )";
                string expectedResult = "0.90630778703665";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the way to enter this mathematical function:
         * 
         * Expression:  cos(2*π) (in radian)
         * Result:  1
         */
        [TestMethod]
        public void ExpressionFuncitonTest2()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;
                if (scientificView.RadDegBtn.Content.ToString() == "Degree")
                {
                    // If in degree change to radian
                    scientificView.RadDegBtn_Click(scientificView.RadDegBtn, null);
                }

                scientificView.FunctionBtn_OnClick(scientificView.CosBtn, null); // Cos
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.OperationBtn_OnClick(scientificView.MulBtn, null); // *
                scientificView.NumBtn_OnClick(scientificView.PIBtn, null); // π
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "cos( 2 * π )";
                string expectedResult = "1";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the way to enter this mathematical function:
         * 
         * Expression:  tan(120) (in degree)
         * Result:  -1.73205080756888
         */
        [TestMethod]
        public void ExpressionFuncitonTest3()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;
                if(scientificView.RadDegBtn.Content.ToString() == "Radian")
                {
                    // If in radian change back to degree
                    scientificView.RadDegBtn_Click(scientificView.RadDegBtn, null);
                }

                scientificView.FunctionBtn_OnClick(scientificView.TanBtn, null); // Tan
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.NumBtn_OnClick(scientificView.Num0Btn, null); // 0
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "tan( 120 )";
                string expectedResult = "-1.73205080756888";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the way to enter this mathematical function:
         * 
         * Expression:  1/(5+2)
         * Result:  0.142857142857143
         */
        [TestMethod]
        public void ExpressionFuncitonTest4()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;

                scientificView.FunctionBtn_OnClick(scientificView.Div1Btn, null); // 1/(
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "1 / ( 5 + 2 )";
                string expectedResult = "0.142857142857143";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the way to enter this mathematical function:
         * 
         * Expression:  abs(-95+20)
         * Result:  75
         */
        [TestMethod]
        public void ExpressionFuncitonTest5()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;

                scientificView.FunctionBtn_OnClick(scientificView.AbsBtn, null); // abs(
                scientificView.OperationBtn_OnClick(scientificView.SubBtn, null); // -
                scientificView.NumBtn_OnClick(scientificView.Num9Btn, null); // 9
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.NumBtn_OnClick(scientificView.Num0Btn, null); // 0
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "abs( -95 + 20 )";
                string expectedResult = "75";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the way to enter this mathematical function:
         * 
         * Expression:  log(2+1.5)
         * Result:  0.544068044350276
         */
        [TestMethod]
        public void ExpressionFuncitonTest6()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;

                scientificView.FunctionBtn_OnClick(scientificView.LogBtn, null); // log(
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.NumBtn_OnClick(scientificView.DotBtn, null); // .
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "log( 2 + 1.5 )";
                string expectedResult = "0.544068044350276";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the way to enter this mathematical function:
         * 
         * Expression:  ln⁡(e+1.5)
         * Result:  1.43942789548574
         */
        [TestMethod]
        public void ExpressionFuncitonTest7()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;

                scientificView.FunctionBtn_OnClick(scientificView.LnBtn, null); // ln(
                scientificView.NumBtn_OnClick(scientificView.EBtn, null); // e
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.NumBtn_OnClick(scientificView.DotBtn, null); // .
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "ln( e + 1.5 )";
                string expectedResult = "1.43942789548574";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the way to enter this mathematical function:
         * 
         * Expression:  95^1.2
         * Result:  236.19370917015
         */
        [TestMethod]
        public void ExpressionFuncitonTest8()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;

                scientificView.NumBtn_OnClick(scientificView.Num9Btn, null); // 9
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.FunctionBtn_OnClick(scientificView.PowerBtn, null); // ^
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.NumBtn_OnClick(scientificView.DotBtn, null); // .
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "95 ^ 1.2";
                string expectedResult = "236.19370917015";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the way to enter this mathematical function:
         * 
         * Expression:  10^(1.5-2)
         * Result:  0.316227766016838
         */
        [TestMethod]
        public void ExpressionFuncitonTest9()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;

                scientificView.FunctionBtn_OnClick(scientificView.Powered10Btn, null); // 10^
                scientificView.OperationBtn_OnClick(scientificView.OpenBrackBtn, null); // (
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.NumBtn_OnClick(scientificView.DotBtn, null); // .
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.SubBtn, null); // -
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "10 ^ ( 1.5 - 2 )";
                string expectedResult = "0.316227766016838";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the way to enter this mathematical function:
         * 
         * Expression:  (11+2)^2
         * Result:  169
         */
        [TestMethod]
        public void ExpressionFuncitonTest10()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;

                scientificView.OperationBtn_OnClick(scientificView.OpenBrackBtn, null); // (
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )
                scientificView.FunctionBtn_OnClick(scientificView.SquaredBtn, null); // ^2

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "( 11 + 2 ) ^ 2";
                string expectedResult = "169";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the way to enter this mathematical function:
         * 
         * Expression:  sqrt(20+5)
         * Result:  5
         */
        [TestMethod]
        public void ExpressionFuncitonTest11()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;

                scientificView.FunctionBtn_OnClick(scientificView.SqrtBtn, null); // sqrt(
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.NumBtn_OnClick(scientificView.Num0Btn, null); // 0
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "sqrt( 20 + 5 )";
                string expectedResult = "5";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region Limit Tests
        /*
        * Check the limit of characters for the expression
        */
        [TestMethod]
        public void LimitTest1()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.BasicTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                BasicView basicView = calculatorWindow.basicView;

                var expectedExpression = "";
                for (int i = 0; i < 99; i++)
                {
                    basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
                    expectedExpression += "1";
                }
                expectedExpression += "2";
                basicView.NumBtn_OnClick(basicView.Num2Btn, null); // 2
                basicView.NumBtn_OnClick(basicView.Num3Btn, null); // 3

                basicView.UpdateGui();
                Assert.AreEqual(expectedExpression, basicView.ExpressionTb.Content.ToString().Trim()); // Check the expression
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
        * Check the limit of characters for the result
        */
        [TestMethod]
        public void LimitTest2()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.BasicTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                BasicView basicView = calculatorWindow.basicView;

                basicView.NumBtn_OnClick(basicView.Num9Btn, null); // 9
                basicView.OperationBtn_OnClick(basicView.MulBtn, null); // *
                basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
                for (int i = 0; i < 25; i++)
                {
                    basicView.NumBtn_OnClick(basicView.Num0Btn, null); // 0
                }
                basicView.EqualBtn_OnClick(null, null);
                basicView.UpdateGui();

                string expectedResult = "9E+25";
                Assert.AreEqual(expectedResult, basicView.ResultTb.Content.ToString().Trim()); // Check the expression
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region Expression Manipulation Tests
        /*
        * Check the delete button and expression manipulation:
        * Expression:   sqrt( → 2 → delete → 4 → ) → =
        * Result:   2
        */
        [TestMethod]
        public void ManipulationTest1()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;

                scientificView.FunctionBtn_OnClick(scientificView.SqrtBtn, null); //sqrt(
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.DeleteBtn_OnClick(null, null);
                scientificView.NumBtn_OnClick(scientificView.Num4Btn, null); // 4
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedExpression = "sqrt( 4 )";
                string expectedResult = "2";
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
        * Check the history selection and expression manipulation:
        * in this test we will enter two expressions in this order:
        * 
        * 1) sqrt(25)
        * 2) abs(-9)
        * 
        * After we have added the expressions we select the first expression (from the history) and 
        * see if the "CurrentExpression" and "CurrentResult" change to the apropriate values. 
        */
        [TestMethod]
        public void ManipulationTest2()
        {
            try
            {
                // Switching to the basic tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ScientificTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ScientificView scientificView = calculatorWindow.scientificView;

                // First Expression
                scientificView.FunctionBtn_OnClick(scientificView.SqrtBtn, null); //sqrt(
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                scientificView.CEBtn_OnClick(null, null); // Clean the workspace

                // Second Expression
                scientificView.FunctionBtn_OnClick(scientificView.AbsBtn, null); //abs(
                scientificView.OperationBtn_OnClick(scientificView.SubBtn, null); // -
                scientificView.NumBtn_OnClick(scientificView.Num9Btn, null); // 9
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )

                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                // Select the first expression from the history
                scientificView.HistoryLv.SelectedIndex = 0;
                // e is created to be handled in the event
                var e = new SelectionChangedEventArgs(
                    System.Windows.Controls.Primitives.Selector.SelectionChangedEvent,
                    new List<ListView> { },
                    new List<ListView> { scientificView.HistoryLv });
                scientificView.HistoryLv_OnSelectionChanged(scientificView.HistoryLv, e);

                string expectedExpression = "sqrt( 25 )"; // The first expression
                string expectedResult = "5"; // The result for the first expression
                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content); // Check the result;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion
    }
}
