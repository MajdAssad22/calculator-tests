﻿using System;
using System.Collections.Generic;
using System.Windows.Controls;
using CalculatorControl;
using CalculatorTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Boundary_Tests
{
    [TestClass]
    public class ScientificViewTests
    {
        private static ScientificView scientificView;

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
            scientificView = new ScientificView();
        }

        // TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
            Calculator.IsDegree = true;
            scientificView.CEBtn_OnClick(null, null);
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
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num6Btn, null); // 6
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.CEBtn_OnClick(null, null); // Clearing the view
                scientificView.UpdateGui();

                scientificView.HistoryLv.SelectedIndex = 0; // Selecting the first index
                var e = new SelectionChangedEventArgs(
                        System.Windows.Controls.Primitives.Selector.SelectionChangedEvent,
                        new List<ListView> { },
                        new List<ListView> { scientificView.HistoryLv });
                scientificView.HistoryLv_OnSelectionChanged(scientificView.HistoryLv, e);

                //Expression from the history
                string expectedExpression = ((ExpressionTree)scientificView.HistoryLv.SelectedItem).Expression;
                //Result from the history
                string expectedResult = ((ExpressionTree)scientificView.HistoryLv.SelectedItem).Result;

                Assert.AreEqual(expectedExpression, scientificView.ExpressionTb.Content.ToString().Trim());
                Assert.AreEqual(expectedResult, scientificView.ResultTb.Content.ToString().Trim());
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
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.NumBtn_OnClick(scientificView.Num6Btn, null); // 6
                scientificView.NumBtn_OnClick(scientificView.Num9Btn, null); // 9
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedResult = "569";
                string actualResult = scientificView.ResultTb.Content.ToString();

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
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.NumBtn_OnClick(scientificView.Num6Btn, null); // 6
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num9Btn, null); // 9
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.UpdateGui();

                string expectedResult = "65";
                string actualResult = scientificView.ResultTb.Content.ToString();

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
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.UpdateGui();

                Assert.AreEqual("+", scientificView.ExpressionTb.Content.ToString().Trim());
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
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.CBtn_OnClick(null, null); // clean the expression
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.UpdateGui();

                Assert.AreEqual("2 +", scientificView.ExpressionTb.Content.ToString().Trim());
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
                scientificView.OperationBtn_OnClick(scientificView.SubBtn, null); // -
                scientificView.UpdateGui();

                Assert.AreEqual("-", scientificView.ExpressionTb.Content.ToString().Trim());
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
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.CBtn_OnClick(null, null); // clean the expression
                scientificView.OperationBtn_OnClick(scientificView.SubBtn, null); // -
                scientificView.UpdateGui();

                Assert.AreEqual("2 -", scientificView.ExpressionTb.Content.ToString().Trim());
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
                scientificView.OperationBtn_OnClick(scientificView.MulBtn, null); // *
                scientificView.UpdateGui();

                Assert.AreEqual("*", scientificView.ExpressionTb.Content.ToString().Trim());
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
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.CBtn_OnClick(null, null); // clean the expression
                scientificView.OperationBtn_OnClick(scientificView.MulBtn, null); // *
                scientificView.UpdateGui();

                Assert.AreEqual("2 * ", scientificView.ExpressionTb.Content);
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
                scientificView.OperationBtn_OnClick(scientificView.DivBtn, null); // /
                scientificView.UpdateGui();

                Assert.AreEqual("/", scientificView.ExpressionTb.Content.ToString().Trim());
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
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.CBtn_OnClick(null, null); // clean the expression
                scientificView.OperationBtn_OnClick(scientificView.DivBtn, null); // /
                scientificView.UpdateGui();

                Assert.AreEqual("2 /", scientificView.ExpressionTb.Content.ToString().Trim());
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
                scientificView.OperationBtn_OnClick(scientificView.OpenBrackBtn, null); // (
                scientificView.UpdateGui();

                Assert.AreEqual("(", scientificView.ExpressionTb.Content.ToString().Trim());
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
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.CBtn_OnClick(null, null); // clean the expression
                scientificView.OperationBtn_OnClick(scientificView.OpenBrackBtn, null); // (
                scientificView.UpdateGui();

                Assert.AreEqual("2 (", scientificView.ExpressionTb.Content.ToString().Trim());
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
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )
                scientificView.UpdateGui();

                Assert.AreEqual(")", scientificView.ExpressionTb.Content.ToString().Trim());
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
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.CBtn_OnClick(null, null); // clean the expression
                scientificView.OperationBtn_OnClick(scientificView.CloseBrackBtn, null); // )
                scientificView.UpdateGui();

                Assert.AreEqual("2 )", scientificView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the Perc button:
         * 
         * Expected Result: %
         */
        [TestMethod]
        public void OperationBtn_OnClickTest13()
        {
            try
            {
                scientificView.OperationBtn_OnClick(scientificView.PercBtn, null); // %
                scientificView.UpdateGui();

                Assert.AreEqual("%", scientificView.ExpressionTb.Content.ToString().Trim());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Operation button press:
         * Check the Perc button:
         * 
         * 1 → + → 1 → = → C (clean the expresion button) → %
         * 
         * Expected Result: 2 %
         */
        [TestMethod]
        public void OperationBtn_OnClickTest14()
        {
            try
            {
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.CBtn_OnClick(null, null); // clean the expression
                scientificView.OperationBtn_OnClick(scientificView.PercBtn, null); // %
                scientificView.UpdateGui();

                Assert.AreEqual("2 %", scientificView.ExpressionTb.Content.ToString().Trim());
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
                scientificView.NumBtn_OnClick(scientificView.Num1Btn, null); // 1
                scientificView.UpdateGui();

                Assert.AreEqual("1", scientificView.ExpressionTb.Content);
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
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.UpdateGui();

                Assert.AreEqual("2", scientificView.ExpressionTb.Content);
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
                scientificView.NumBtn_OnClick(scientificView.Num3Btn, null); // 3
                scientificView.UpdateGui();

                Assert.AreEqual("3", scientificView.ExpressionTb.Content);
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
                scientificView.NumBtn_OnClick(scientificView.Num4Btn, null); // 4
                scientificView.UpdateGui();

                Assert.AreEqual("4", scientificView.ExpressionTb.Content);
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
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.UpdateGui();

                Assert.AreEqual("5", scientificView.ExpressionTb.Content);
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
                scientificView.NumBtn_OnClick(scientificView.Num6Btn, null); // 6
                scientificView.UpdateGui();

                Assert.AreEqual("6", scientificView.ExpressionTb.Content);
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
                scientificView.NumBtn_OnClick(scientificView.Num7Btn, null);
                scientificView.UpdateGui();

                Assert.AreEqual("7", scientificView.ExpressionTb.Content);
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
                scientificView.NumBtn_OnClick(scientificView.Num8Btn, null);
                scientificView.UpdateGui();

                Assert.AreEqual("8", scientificView.ExpressionTb.Content);
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
                scientificView.NumBtn_OnClick(scientificView.Num9Btn, null);
                scientificView.UpdateGui();

                Assert.AreEqual("9", scientificView.ExpressionTb.Content);
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
                scientificView.NumBtn_OnClick(scientificView.Num0Btn, null);
                scientificView.UpdateGui();

                Assert.AreEqual("0", scientificView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the e button:
         * 
         * Expected Result: e
         */
        [TestMethod]
        public void NumBtn_OnClickTest11()
        {
            try
            {
                scientificView.NumBtn_OnClick(scientificView.EBtn, null);
                scientificView.UpdateGui();

                Assert.AreEqual("e", scientificView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the π button:
         * 
         * Expected Result: π
         */
        [TestMethod]
        public void NumBtn_OnClickTest12()
        {
            try
            {
                scientificView.NumBtn_OnClick(scientificView.PIBtn, null);
                scientificView.UpdateGui();

                Assert.AreEqual(CalculatorParams.PI, scientificView.ExpressionTb.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * Check the Number button press:
         * Check the Dot button:
         * 
         * Expected Result: .
         */
        [TestMethod]
        public void NumBtn_OnClickTest13()
        {
            try
            {
                scientificView.NumBtn_OnClick(scientificView.DotBtn, null);
                scientificView.UpdateGui();

                Assert.AreEqual(".", scientificView.ExpressionTb.Content);
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
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.AddBtn, null); // +
                scientificView.NumBtn_OnClick(scientificView.Num6Btn, null); // 6
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.ClearBtn_OnClick(null, null); // clear history button
                scientificView.UpdateGui();

                Assert.AreEqual(0, scientificView.HistoryLv.Items.Count);
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
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.NumBtn_OnClick(scientificView.Num6Btn, null); // 6
                scientificView.DeleteBtn_OnClick(null, null); // Delete
                scientificView.UpdateGui();

                string actualResult = scientificView.ExpressionTb.Content.ToString();

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
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.MulBtn, null); // *
                scientificView.NumBtn_OnClick(scientificView.Num2Btn, null); // 2
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.DeleteBtn_OnClick(null, null); // Delete
                scientificView.UpdateGui();

                string actualExpression = scientificView.ExpressionTb.Content.ToString();
                string actualResult = scientificView.ResultTb.Content.ToString();

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
                scientificView.NumBtn_OnClick(scientificView.Num5Btn, null); // 5
                scientificView.OperationBtn_OnClick(scientificView.MulBtn, null); // *
                scientificView.NumBtn_OnClick(scientificView.Num6Btn, null); // 6
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.CEBtn_OnClick(null, null); // CE
                scientificView.UpdateGui();

                string actualExpression = scientificView.ExpressionTb.Content.ToString();
                string actualResult = scientificView.ResultTb.Content.ToString();

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
                scientificView.NumBtn_OnClick(scientificView.Num8Btn, null); // 8
                scientificView.OperationBtn_OnClick(scientificView.DivBtn, null); // /
                scientificView.NumBtn_OnClick(scientificView.Num4Btn, null); // 4
                scientificView.EqualBtn_OnClick(null, null); // =
                scientificView.CBtn_OnClick(null, null); // C (clean)
                scientificView.UpdateGui();

                string actualExpression = scientificView.ExpressionTb.Content.ToString();
                string actualResult = scientificView.ResultTb.Content.ToString();
                Assert.AreEqual("", actualExpression);
                Assert.AreEqual("2", actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
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
        public void FunctionBtn_OnClickTest1()
        {
            try
            {
                // If in degree change to radain
                if (Calculator.IsDegree)
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
        public void FunctionBtn_OnClickTest2()
        {
            try
            {
                // if in radian change to degree
                if (!Calculator.IsDegree)
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
        public void FunctionBtn_OnClickTest3()
        {
            try
            {
                // if in degree change to radian
                if (Calculator.IsDegree)
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
        public void FunctionBtn_OnClickTest4()
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
         * abs( → - → 5 → + → 2 → ) → =
         * 
         * Expected Expression: abs( -5 + 2 )
         * Expected Result: 3
         */
        [TestMethod]
        public void FunctionBtn_OnClickTest5()
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
        public void FunctionBtn_OnClickTest6()
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
        public void FunctionBtn_OnClickTest7()
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
        public void FunctionBtn_OnClickTest8()
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
        public void FunctionBtn_OnClickTest9()
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
        public void FunctionBtn_OnClickTest10()
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
        public void FunctionBtn_OnClickTest11()
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
         * Old Data: Calculator's IsDegree -> True (Started as Degree)
         * 
         * Then Checks if the value is inverted and the content is changed
         * accordingly
         */
        [TestMethod]
        public void RadDegBtn_ClickTest1()
        {
            try
            {
                // Started as Degree
                Calculator.IsDegree = true;

                scientificView.RadDegBtn_Click(scientificView.RadDegBtn, null);

                Assert.IsFalse(Calculator.IsDegree);
                Assert.AreEqual("Radian", scientificView.RadDegBtn.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the functionality of the Radian/Degree button
         * Old Data: Calculator's IsDegree -> False (Started as Radian)
         * 
         * Then Checks if the value is inverted and the content is changed
         * accordingly
         */
        [TestMethod]
        public void RadDegBtn_ClickTest2()
        {
            try
            {
                // Started as Radian
                Calculator.IsDegree = false;

                scientificView.RadDegBtn_Click(scientificView.RadDegBtn, null);

                Assert.IsTrue(Calculator.IsDegree);
                Assert.AreEqual("Degree", scientificView.RadDegBtn.Content);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion
    }
}
