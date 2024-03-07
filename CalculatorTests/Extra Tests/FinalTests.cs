using System;
using CalculatorBoundary;
using CalculatorTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Extra_Tests
{
    [TestClass]
    public class FinalTests
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

        #region Basic Mode Operations Tests
        [TestMethod]
        public void BasicModeOperationTest1()
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
                basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
                basicView.NumBtn_OnClick(basicView.Num3Btn, null); // 3
                basicView.EqualBtn_OnClick(null, null); // =
                basicView.UpdateGui();

                string expectedExpression = "150 + 3";
                string expectedResult = "153";
                Assert.AreEqual(expectedExpression, basicView.ExpressionTb.Content); // Check the expression
                Assert.AreEqual(expectedResult, basicView.ResultTb.Content); // Check the result
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void BasicModeOperationTest2()
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
                basicView.OperationBtn_OnClick(basicView.SubBtn, null); // -
                basicView.NumBtn_OnClick(basicView.Num9Btn, null); // 9
                basicView.EqualBtn_OnClick(null, null); // =
                basicView.UpdateGui();

                string expectedExpression = "150 - 9";
                string expectedResult = "141";
                Assert.AreEqual(expectedExpression, basicView.ExpressionTb.Content); // Check the expression
                Assert.AreEqual(expectedResult, basicView.ResultTb.Content); // Check the result
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void BasicModeOperationTest3()
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
                basicView.NumBtn_OnClick(basicView.Num2Btn, null); // 2
                basicView.EqualBtn_OnClick(null, null); // =
                basicView.UpdateGui();

                string expectedExpression = "150 * 2";
                string expectedResult = "300";
                Assert.AreEqual(expectedExpression, basicView.ExpressionTb.Content); // Check the expression
                Assert.AreEqual(expectedResult, basicView.ResultTb.Content); // Check the result
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void BasicModeOperationTest4()
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
                basicView.OperationBtn_OnClick(basicView.DivBtn, null); // /
                basicView.NumBtn_OnClick(basicView.Num5Btn, null); // 5
                basicView.EqualBtn_OnClick(null, null); // =
                basicView.UpdateGui();

                string expectedExpression = "150 / 5";
                string expectedResult = "30";
                Assert.AreEqual(expectedExpression, basicView.ExpressionTb.Content); // Check the expression
                Assert.AreEqual(expectedResult, basicView.ResultTb.Content); // Check the result
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        
        [TestMethod]
        public void BasicModeOperationTest5()
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
                basicView.OperationBtn_OnClick(basicView.DivBtn, null); // /
                basicView.OperationBtn_OnClick(basicView.OpenBrackBtn, null); // (
                basicView.NumBtn_OnClick(basicView.Num3Btn, null); // 3
                basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
                basicView.NumBtn_OnClick(basicView.Num2Btn, null); // 2
                basicView.OperationBtn_OnClick(basicView.CloseBrackBtn, null); // )
                basicView.EqualBtn_OnClick(null, null); // =
                basicView.UpdateGui();

                string expectedExpression = "150 / ( 3 + 2 )";
                string expectedResult = "30";
                Assert.AreEqual(expectedExpression, basicView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, basicView.ResultTb.Content); // Check the result
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region Programmer Mode Operations Tests
        [TestMethod]
        public void ProgrammerModeOperationTest1()
        {
            try
            {
                // Switching to the programmer tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ProgrammerTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ProgrammerView programmerView = calculatorWindow.programmerView;
                programmerView.ChangeBaseBtn_OnClick(programmerView.BinBtn, null); // Change to bin base
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.NumBtn_OnClick(programmerView.Num0Btn, null); // 0
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.UpdateGui();

                string expectedExpression = "10 + 11";
                string expectedResult = "101";
                Assert.AreEqual(expectedExpression, programmerView.ExpressionTb.Content); // Check the expression
                Assert.AreEqual(expectedResult, programmerView.ResultTb.Content); // Check the result
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void ProgrammerModeOperationTest2()
        {
            try
            {
                // Switching to the programmer tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ProgrammerTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ProgrammerView programmerView = calculatorWindow.programmerView;
                programmerView.ChangeBaseBtn_OnClick(programmerView.OctBtn, null); // Change to oct base
                programmerView.NumBtn_OnClick(programmerView.Num4Btn, null); // 4
                programmerView.NumBtn_OnClick(programmerView.Num2Btn, null); // 2
                programmerView.OperationBtn_OnClick(programmerView.SubBtn, null); // -
                programmerView.NumBtn_OnClick(programmerView.Num2Btn, null); // 2
                programmerView.NumBtn_OnClick(programmerView.Num3Btn, null); // 3
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.UpdateGui();

                string expectedExpression = "42 - 23";
                string expectedResult = "17";
                Assert.AreEqual(expectedExpression, programmerView.ExpressionTb.Content); // Check the expression
                Assert.AreEqual(expectedResult, programmerView.ResultTb.Content); // Check the result
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void ProgrammerModeOperationTest3()
        {
            try
            {
                // Switching to the programmer tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ProgrammerTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ProgrammerView programmerView = calculatorWindow.programmerView;
                programmerView.ChangeBaseBtn_OnClick(programmerView.DecBtn, null); // Change to dec base
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.NumBtn_OnClick(programmerView.Num9Btn, null); // 9
                programmerView.OperationBtn_OnClick(programmerView.MulBtn, null); // *
                programmerView.NumBtn_OnClick(programmerView.Num2Btn, null); // 2
                programmerView.NumBtn_OnClick(programmerView.Num7Btn, null); // 7
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.UpdateGui();

                string expectedExpression = "19 * 27";
                string expectedResult = "513";
                Assert.AreEqual(expectedExpression, programmerView.ExpressionTb.Content); // Check the expression
                Assert.AreEqual(expectedResult, programmerView.ResultTb.Content); // Check the result
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void ProgrammerModeOperationTest4()
        {
            try
            {
                // Switching to the programmer tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ProgrammerTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ProgrammerView programmerView = calculatorWindow.programmerView;
                programmerView.ChangeBaseBtn_OnClick(programmerView.HexBtn, null); // Change to hex base
                programmerView.NumBtn_OnClick(programmerView.NumFBtn, null); // F
                programmerView.NumBtn_OnClick(programmerView.Num5Btn, null); // 5
                programmerView.OperationBtn_OnClick(programmerView.DivBtn, null); // /
                programmerView.NumBtn_OnClick(programmerView.NumBBtn, null); // B
                programmerView.NumBtn_OnClick(programmerView.Num2Btn, null); // 2
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.UpdateGui();

                string expectedExpression = "F5 / B2";
                string expectedResult = "1";
                Assert.AreEqual(expectedExpression, programmerView.ExpressionTb.Content); // Check the expression
                Assert.AreEqual(expectedResult, programmerView.ResultTb.Content); // Check the result
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void ProgrammerModeOperationTest5()
        {
            try
            {
                // Switching to the programmer tab
                calculatorWindow.ModeTabs.SelectedItem = calculatorWindow.ProgrammerTab;
                calculatorWindow.TabSelector_OnSelectionChanged(calculatorWindow.ModeTabs, null);

                // Feeding the expression
                ProgrammerView programmerView = calculatorWindow.programmerView;
                programmerView.ChangeBaseBtn_OnClick(programmerView.HexBtn, null); // Change to hex base
                programmerView.NumBtn_OnClick(programmerView.NumFBtn, null); // F
                programmerView.NumBtn_OnClick(programmerView.Num5Btn, null); // 5
                programmerView.OperationBtn_OnClick(programmerView.DivBtn, null); // /
                programmerView.OperationBtn_OnClick(programmerView.OpenBrackBtn, null); // (
                programmerView.NumBtn_OnClick(programmerView.Num3Btn, null); // 3
                programmerView.NumBtn_OnClick(programmerView.NumABtn, null); // A
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num2Btn, null); // 2
                programmerView.NumBtn_OnClick(programmerView.NumBBtn, null); // B
                programmerView.OperationBtn_OnClick(programmerView.CloseBrackBtn, null); // )
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.UpdateGui();

                string expectedExpression = "F5 / ( 3A + 2B )";
                string expectedResult = "2";
                Assert.AreEqual(expectedExpression, programmerView.ExpressionTb.Content.ToString().Trim()); // Check the expression
                Assert.AreEqual(expectedResult, programmerView.ResultTb.Content); // Check the result
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion
    }
}
