using System;
using System.Collections.Generic;
using System.Windows.Controls;
using CalculatorControl;
using CalculatorTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Boundary_Tests
{
    [TestClass]
    public class ProgrammerViewTests
    {
        private static ProgrammerView programmerView;

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

        [ClassInitialize()]
        public static void TestsClassInitialize(TestContext testContext)
        {
            programmerView = new ProgrammerView();
        }

        // TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Calculator.Mode = CalculatorParams.CalculatorModes.Programmer;
            programmerView.CEBtn_OnClick(null, null);
            programmerView.ChangeBaseBtn_OnClick(programmerView.DecBtn, null);
        }
        #endregion

        #region HistoryLv_OnSelectionChanged Event Tests
        /*
         * This test is to check the functionality of the history list view
         * its done by solving an expression and adding it to the history
         * and reseting the view then we select it from the history and see if it 
         * apears in the view
         */
        [TestMethod]
        public void HistoryLv_OnSelectionChangedTest1()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num5Btn, null); // 5
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num6Btn, null); // 6
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.CEBtn_OnClick(null, null); // Clearing the view
                programmerView.UpdateGui();

                programmerView.HistoryLv.SelectedIndex = 0; // Selecting the first index
                var e = new SelectionChangedEventArgs(
                        System.Windows.Controls.Primitives.Selector.SelectionChangedEvent,
                        new List<ListView> { },
                        new List<ListView> { programmerView.HistoryLv });
                programmerView.HistoryLv_OnSelectionChanged(programmerView.HistoryLv, e);

                //Expression from the history
                string expectedExpression = ((ExpressionTree)programmerView.HistoryLv.SelectedItem).Expression;
                //Result from the history
                string expectedResult = ((ExpressionTree)programmerView.HistoryLv.SelectedItem).Result;

                Assert.AreEqual(expectedExpression, programmerView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, programmerView.ResultTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region EqualBtn_OnClick Event Tests
        /*
         * Check the Equal button press:
         * 
         * 5 → 6 → 9 → =
         * 
         * Expected Result: 569
         */
        [TestMethod]
        public void EqualBtn_OnClickTest1()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num5Btn, null); // 5
                programmerView.NumBtn_OnClick(programmerView.Num6Btn, null); // 6
                programmerView.NumBtn_OnClick(programmerView.Num9Btn, null); // 9
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.UpdateGui();

                string expectedResult = "569";
                string actualResult = programmerView.ResultTb.Content.ToString();

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Equal button press,
         * done by pressing this sequence of buttons:
         * 
         * 5 → 6 → + → 9 → =
         * 
         * Expected Result: 65
         */
        [TestMethod]
        public void EqualBtn_OnClickTest2()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num5Btn, null); // 5
                programmerView.NumBtn_OnClick(programmerView.Num6Btn, null); // 6
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num9Btn, null); // 9
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.UpdateGui();

                string expectedResult = "65";
                string actualResult = programmerView.ResultTb.Content.ToString();

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Equal button press,
         * done by pressing this sequence of buttons:
         * 
         * 1 → 0 → + → 1 → 1 → =
         * 
         * Expected Result: 101
         */
        [TestMethod]
        public void EqualBtn_OnClickTest3()
        {
            try
            {
                programmerView.ChangeBaseBtn_OnClick(programmerView.BinBtn, null); // Change to binary
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.NumBtn_OnClick(programmerView.Num0Btn, null); // 0
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.UpdateGui();

                string expectedResult = "101";
                string actualResult = programmerView.ResultTb.Content.ToString();

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region OperationBtn_OnClick Event Tests
        /*
         * Check the Operation button press:
         * Check the add button:
         * 
         * Expected Result: +
         */
        [TestMethod]
        public void OperationBtn_OnClickTest1()
        {
            try
            {
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.UpdateGui();

                Assert.AreEqual("+", programmerView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the add button:
         * 
         * 1 → + → 1 → = → C (clean the expresion button) → +
         * 
         * Expected Result: 2 +
         */
        [TestMethod]
        public void OperationBtn_OnClickTest2()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.CBtn_OnClick(null, null); // clean the expression
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.UpdateGui();

                Assert.AreEqual("2 +", programmerView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the sub button:
         * 
         * Expected Result: -
         */
        [TestMethod]
        public void OperationBtn_OnClickTest3()
        {
            try
            {
                programmerView.OperationBtn_OnClick(programmerView.SubBtn, null); // -
                programmerView.UpdateGui();

                Assert.AreEqual("-", programmerView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the sub button:
         * 
         * 1 → + → 1 → = → C (clean the expresion button) → -
         * 
         * Expected Result: 2 -
         */
        [TestMethod]
        public void OperationBtn_OnClickTest4()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.CBtn_OnClick(null, null); // clean the expression
                programmerView.OperationBtn_OnClick(programmerView.SubBtn, null); // -
                programmerView.UpdateGui();

                Assert.AreEqual("2 -", programmerView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the mult button:
         * 
         * Expected Result: *
         */
        [TestMethod]
        public void OperationBtn_OnClickTest5()
        {
            try
            {
                programmerView.OperationBtn_OnClick(programmerView.MulBtn, null); // *
                programmerView.UpdateGui();

                Assert.AreEqual("*", programmerView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the mult button:
         * 
         * 1 → + → 1 → = → C (clean the expresion button) → *
         * 
         * Expected Result: 2 *
         */
        [TestMethod]
        public void OperationBtn_OnClickTest6()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.CBtn_OnClick(null, null); // clean the expression
                programmerView.OperationBtn_OnClick(programmerView.MulBtn, null); // *
                programmerView.UpdateGui();

                Assert.AreEqual("2 * ", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the div button:
         * 
         * Expected Result: /
         */
        [TestMethod]
        public void OperationBtn_OnClickTest7()
        {
            try
            {
                programmerView.OperationBtn_OnClick(programmerView.DivBtn, null); // /
                programmerView.UpdateGui();

                Assert.AreEqual("/", programmerView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the sub button:
         * 
         * 1 → + → 1 → = → C (clean the expresion button) → /
         * 
         * Expected Result: 2 /
         */
        [TestMethod]
        public void OperationBtn_OnClickTest8()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.CBtn_OnClick(null, null); // clean the expression
                programmerView.OperationBtn_OnClick(programmerView.DivBtn, null); // /
                programmerView.UpdateGui();

                Assert.AreEqual("2 /", programmerView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the OpenBrack button:
         * 
         * Expected Result: (
         */
        [TestMethod]
        public void OperationBtn_OnClickTest9()
        {
            try
            {
                programmerView.OperationBtn_OnClick(programmerView.OpenBrackBtn, null); // (
                programmerView.UpdateGui();

                Assert.AreEqual("(", programmerView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the OpenBrack button:
         * 
         * 1 → + → 1 → = → C (clean the expresion button) → (
         * 
         * Expected Result: 2 (
         */
        [TestMethod]
        public void OperationBtn_OnClickTest10()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.CBtn_OnClick(null, null); // clean the expression
                programmerView.OperationBtn_OnClick(programmerView.OpenBrackBtn, null); // (
                programmerView.UpdateGui();

                Assert.AreEqual("2 (", programmerView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the CloseBrack button:
         * 
         * Expected Result: )
         */
        [TestMethod]
        public void OperationBtn_OnClickTest11()
        {
            try
            {
                programmerView.OperationBtn_OnClick(programmerView.CloseBrackBtn, null); // )
                programmerView.UpdateGui();

                Assert.AreEqual(")", programmerView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the CloseBrack button:
         * 
         * 1 → + → 1 → = → C (clean the expresion button) → )
         * 
         * Expected Result: 2 )
         */
        [TestMethod]
        public void OperationBtn_OnClickTest12()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.CBtn_OnClick(null, null); // clean the expression
                programmerView.OperationBtn_OnClick(programmerView.CloseBrackBtn, null); // )
                programmerView.UpdateGui();

                Assert.AreEqual("2 )", programmerView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region NumBtn_OnClick Event Tests
        /*
         * Check the Number button press:
         * Check the 1 button:
         * 
         * Expected Result: 1
         */
        [TestMethod]
        public void NumBtn_OnClickTest1()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num1Btn, null); // 1
                programmerView.UpdateGui();

                Assert.AreEqual("1", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the 2 button:
         * 
         * Expected Result: 2
         */
        [TestMethod]
        public void NumBtn_OnClickTest2()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num2Btn, null); // 2
                programmerView.UpdateGui();

                Assert.AreEqual("2", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the 3 button:
         * 
         * Expected Result: 3
         */
        [TestMethod]
        public void NumBtn_OnClickTest3()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num3Btn, null); // 3
                programmerView.UpdateGui();

                Assert.AreEqual("3", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the 4 button:
         * 
         * Expected Result: 4
         */
        [TestMethod]
        public void NumBtn_OnClickTest4()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num4Btn, null); // 4
                programmerView.UpdateGui();

                Assert.AreEqual("4", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the 5 button:
         * 
         * Expected Result: 5
         */
        [TestMethod]
        public void NumBtn_OnClickTest5()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num5Btn, null); // 5
                programmerView.UpdateGui();

                Assert.AreEqual("5", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the 6 button:
         * 
         * Expected Result: 6
         */
        [TestMethod]
        public void NumBtn_OnClickTest6()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num6Btn, null); // 6
                programmerView.UpdateGui();

                Assert.AreEqual("6", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the 7 button:
         * 
         * Expected Result: 7
         */
        [TestMethod]
        public void NumBtn_OnClickTest7()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num7Btn, null);
                programmerView.UpdateGui();

                Assert.AreEqual("7", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the 8 button:
         * 
         * Expected Result: 8
         */
        [TestMethod]
        public void NumBtn_OnClickTest8()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num8Btn, null);
                programmerView.UpdateGui();

                Assert.AreEqual("8", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the 9 button:
         * 
         * Expected Result: 9
         */
        [TestMethod]
        public void NumBtn_OnClickTest9()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num9Btn, null);
                programmerView.UpdateGui();

                Assert.AreEqual("9", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the 0 button:
         * 
         * Expected Result: 0
         */
        [TestMethod]
        public void NumBtn_OnClickTest10()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num0Btn, null);
                programmerView.UpdateGui();

                Assert.AreEqual("0", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the A button:
         * 
         * Expected Result: A
         */
        [TestMethod]
        public void NumBtn_OnClickTest11()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.NumABtn, null);
                programmerView.UpdateGui();

                Assert.AreEqual("A", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the B button:
         * 
         * Expected Result: B
         */
        [TestMethod]
        public void NumBtn_OnClickTest12()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.NumBBtn, null);
                programmerView.UpdateGui();

                Assert.AreEqual("B", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the C button:
         * 
         * Expected Result: C
         */
        [TestMethod]
        public void NumBtn_OnClickTest13()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.NumCBtn, null);
                programmerView.UpdateGui();

                Assert.AreEqual("C", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the D button:
         * 
         * Expected Result: D
         */
        [TestMethod]
        public void NumBtn_OnClickTest14()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.NumDBtn, null);
                programmerView.UpdateGui();

                Assert.AreEqual("D", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the E button:
         * 
         * Expected Result: E
         */
        [TestMethod]
        public void NumBtn_OnClickTest15()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.NumEBtn, null);
                programmerView.UpdateGui();

                Assert.AreEqual("E", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the F button:
         * 
         * Expected Result: F
         */
        [TestMethod]
        public void NumBtn_OnClickTest16()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.NumFBtn, null);
                programmerView.UpdateGui();

                Assert.AreEqual("F", programmerView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region ClearBtn_OnClick Event Tests
        /*
         * Check the Clear button press, we provide and solve an expression
         * then we press the clear button and expect the cound of the history list 
         * to be 0
         */
        [TestMethod]
        public void ClearBtn_OnClickTest1()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num5Btn, null); // 5
                programmerView.OperationBtn_OnClick(programmerView.AddBtn, null); // +
                programmerView.NumBtn_OnClick(programmerView.Num6Btn, null); // 6
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.ClearBtn_OnClick(null, null); // clear history button
                programmerView.UpdateGui();

                Assert.AreEqual(0, programmerView.HistoryLv.Items.Count);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region DeleteBtn_OnClick Event Tests
        /*
         * Check the Delete button press:
         * Check the expression after we press the delete button
         * 
         * 5 → 6 → Delete
         * 
         * Expected Expression: 5
         */
        [TestMethod]
        public void DeleteBtn_OnClickTest1()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num5Btn, null); // 5
                programmerView.NumBtn_OnClick(programmerView.Num6Btn, null); // 6
                programmerView.DeleteBtn_OnClick(null, null); // Delete
                programmerView.UpdateGui();

                string actualResult = programmerView.ExpressionTb.Content.ToString();

                Assert.AreEqual("5", actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Delete button press:
         * Check the expression and the result after we press the delete button
         * 
         * 5 → * → 2 → = → Delete
         * 
         * Expected Expression: 5 *
         * Expected Result:
         */
        [TestMethod]
        public void DeleteBtn_OnClickTest2()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num5Btn, null); // 5
                programmerView.OperationBtn_OnClick(programmerView.MulBtn, null); // *
                programmerView.NumBtn_OnClick(programmerView.Num2Btn, null); // 2
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.DeleteBtn_OnClick(null, null); // Delete
                programmerView.UpdateGui();

                string actualExpression = programmerView.ExpressionTb.Content.ToString();
                string actualResult = programmerView.ResultTb.Content.ToString();

                Assert.AreEqual("5 * ", actualExpression);
                Assert.AreEqual("", actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region CEBtn_OnClick Event Tests
        /*
         * Check the CE button press:
         * Check if the expression and result are empty
         * 
         * 5 → * → 6 → = → CE 
         * 
         * Expected Expression: 
         * Expected Result: 
         */
        [TestMethod]
        public void CEBtn_OnClickTest1()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num5Btn, null); // 5
                programmerView.OperationBtn_OnClick(programmerView.MulBtn, null); // *
                programmerView.NumBtn_OnClick(programmerView.Num6Btn, null); // 6
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.CEBtn_OnClick(null, null); // CE
                programmerView.UpdateGui();

                string actualExpression = programmerView.ExpressionTb.Content.ToString();
                string actualResult = programmerView.ResultTb.Content.ToString();

                Assert.AreEqual("", actualExpression);
                Assert.AreEqual("", actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region CBtn_OnClick Event Tests
        /*
         * Check the C button press:
         * Check if the expression is empty and the result still have data
         * 
         * 8 → / → 4 → = → C
         * 
         * Expected Expression: 
         * Expected Result: 2
         */
        [TestMethod]
        public void CBtn_OnClickTest1()
        {
            try
            {
                programmerView.NumBtn_OnClick(programmerView.Num8Btn, null); // 8
                programmerView.OperationBtn_OnClick(programmerView.DivBtn, null); // /
                programmerView.NumBtn_OnClick(programmerView.Num4Btn, null); // 4
                programmerView.EqualBtn_OnClick(null, null); // =
                programmerView.CBtn_OnClick(null, null); // C (clean)
                programmerView.UpdateGui();

                string actualExpression = programmerView.ExpressionTb.Content.ToString();
                string actualResult = programmerView.ResultTb.Content.ToString();
                Assert.AreEqual("", actualExpression);
                Assert.AreEqual("2", actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region ChangeBaseBtn_OnClick Event Tests
        /*
         * This test checks after changing the base if all the appropriate buttons
         * have been disabled and checks the calculator's base if changed.
         * 
         * Done For BIN
         */
        [TestMethod]
        public void ChangeBaseBtn_OnClickTest1()
        {
            try
            {
                programmerView.ChangeBaseBtn_OnClick(programmerView.BinBtn, null);
                Assert.IsFalse(programmerView.Num2Btn.IsEnabled);
                Assert.IsFalse(programmerView.Num3Btn.IsEnabled);
                Assert.IsFalse(programmerView.Num4Btn.IsEnabled);
                Assert.IsFalse(programmerView.Num5Btn.IsEnabled);
                Assert.IsFalse(programmerView.Num6Btn.IsEnabled);
                Assert.IsFalse(programmerView.Num7Btn.IsEnabled);
                Assert.IsFalse(programmerView.Num8Btn.IsEnabled);
                Assert.IsFalse(programmerView.Num9Btn.IsEnabled);
                Assert.IsFalse(programmerView.NumABtn.IsEnabled);
                Assert.IsFalse(programmerView.NumBBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumCBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumDBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumEBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumFBtn.IsEnabled);
                Assert.AreEqual(Calculator.Base, CalculatorParams.Bases.Bin);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks after changing the base if all the appropriate buttons
         * have been disabled and checks the calculator's base if changed.
         * 
         * Done For OCT
         */
        [TestMethod]
        public void ChangeBaseBtn_OnClickTest2()
        {
            try
            {
                programmerView.ChangeBaseBtn_OnClick(programmerView.OctBtn, null);
                Assert.IsTrue(programmerView.Num2Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num3Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num4Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num5Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num6Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num7Btn.IsEnabled);
                Assert.IsFalse(programmerView.Num8Btn.IsEnabled);
                Assert.IsFalse(programmerView.Num9Btn.IsEnabled);
                Assert.IsFalse(programmerView.NumABtn.IsEnabled);
                Assert.IsFalse(programmerView.NumBBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumCBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumDBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumEBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumFBtn.IsEnabled);
                Assert.AreEqual(Calculator.Base, CalculatorParams.Bases.Oct);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks after changing the base if all the appropriate buttons
         * have been disabled and checks the calculator's base if changed.
         * 
         * Done For DEC
         */
        [TestMethod]
        public void ChangeBaseBtn_OnClickTest3()
        {
            try
            {
                programmerView.ChangeBaseBtn_OnClick(programmerView.DecBtn, null);
                Assert.IsTrue(programmerView.Num2Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num3Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num4Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num5Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num6Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num7Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num8Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num9Btn.IsEnabled);
                Assert.IsFalse(programmerView.NumABtn.IsEnabled);
                Assert.IsFalse(programmerView.NumBBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumCBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumDBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumEBtn.IsEnabled);
                Assert.IsFalse(programmerView.NumFBtn.IsEnabled);
                Assert.AreEqual(Calculator.Base, CalculatorParams.Bases.Dec);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks after changing the base if all the appropriate buttons
         * have been disabled and checks the calculator's base if changed.
         * 
         * Done For HEX
         */
        [TestMethod]
        public void ChangeBaseBtn_OnClickTest4()
        {
            try
            {

                programmerView.ChangeBaseBtn_OnClick(programmerView.HexBtn, null);
                Assert.IsTrue(programmerView.Num2Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num3Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num4Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num5Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num6Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num7Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num8Btn.IsEnabled);
                Assert.IsTrue(programmerView.Num9Btn.IsEnabled);
                Assert.IsTrue(programmerView.NumABtn.IsEnabled);
                Assert.IsTrue(programmerView.NumBBtn.IsEnabled);
                Assert.IsTrue(programmerView.NumCBtn.IsEnabled);
                Assert.IsTrue(programmerView.NumDBtn.IsEnabled);
                Assert.IsTrue(programmerView.NumEBtn.IsEnabled);
                Assert.IsTrue(programmerView.NumFBtn.IsEnabled);
                Assert.AreEqual(Calculator.Base, CalculatorParams.Bases.Hex);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion
    }
}
