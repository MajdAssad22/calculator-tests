using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CalculatorControl;
using CalculatorTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Boundary_Tests
{
    [TestClass]
    public class BasicViewTests
    {
        private static BasicView basicView;

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
            Calculator.Mode = CalculatorParams.CalculatorModes.Basic;
            basicView = new BasicView();
        }

        //This will run after every test
        [TestInitialize]
        public void TestInitialize()
        {
            basicView.CEBtn_OnClick(null, null);
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
        public void HistoryLv()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num6Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CEBtn_OnClick(null, null); // Clearing the view
            basicView.UpdateGui();

            basicView.HistoryLv.SelectedIndex = 0; // Selecting the first index
            var e = new SelectionChangedEventArgs(
                    System.Windows.Controls.Primitives.Selector.SelectionChangedEvent,
                    new List<ListView> { },
                    new List<ListView> { basicView.HistoryLv });
            basicView.HistoryLv_OnSelectionChanged(basicView.HistoryLv, e);

            //Expression from the history
            string expectedExpression = ((ExpressionTree)basicView.HistoryLv.SelectedItem).Expression;
            //Result from the history
            string expectedResult = ((ExpressionTree)basicView.HistoryLv.SelectedItem).Result;

            Assert.AreEqual(expectedExpression, basicView.ExpressionTb.Content.ToString().Trim());
            Assert.AreEqual(expectedResult, basicView.ResultTb.Content.ToString().Trim());

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
        public void EqualBtnOnClick1()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null); // 5
            basicView.NumBtn_OnClick(basicView.Num6Btn, null); // 6
            basicView.NumBtn_OnClick(basicView.Num9Btn, null); // 9
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.UpdateGui();

            string expectedResult = "569";
            string actualResult = basicView.ResultTb.Content.ToString();

            Assert.AreEqual(expectedResult, actualResult);
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
        public void EqualBtnOnClick2()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null); // 5
            basicView.NumBtn_OnClick(basicView.Num6Btn, null); // 6
            basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
            basicView.NumBtn_OnClick(basicView.Num9Btn, null); // 9
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.UpdateGui();

            string expectedResult = "65";
            string actualResult = basicView.ResultTb.Content.ToString();

            Assert.AreEqual(expectedResult, actualResult);
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
        public void AddClick()
        {
            basicView.OperationBtn_OnClick(basicView.AddBtn, null); // pressing +
            basicView.UpdateGui();

            Assert.AreEqual("+", basicView.ExpressionTb.Content.ToString().Trim());
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
        public void AddClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.CBtn_OnClick(null, null); // clean the expression
            basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
            basicView.UpdateGui();

            Assert.AreEqual("2 +", basicView.ExpressionTb.Content.ToString().Trim());
        }
        /*
         * Check the Operation button press:
         * Check the sub button:
         * 
         * Expected Result: -
         */
        [TestMethod]
        public void SubClick()
        {
            basicView.OperationBtn_OnClick(basicView.SubBtn, null); // -
            basicView.UpdateGui();

            Assert.AreEqual("-", basicView.ExpressionTb.Content.ToString().Trim());
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
        public void SubClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.CBtn_OnClick(null, null); // clean the expression
            basicView.OperationBtn_OnClick(basicView.SubBtn, null); // -
            basicView.UpdateGui();

            Assert.AreEqual("2 -", basicView.ExpressionTb.Content.ToString().Trim());
        }
        /*
         * Check the Operation button press:
         * Check the mult button:
         * 
         * Expected Result: *
         */
        [TestMethod]
        public void MultClick()
        {
            basicView.OperationBtn_OnClick(basicView.MulBtn, null); // *
            basicView.UpdateGui();

            Assert.AreEqual("*", basicView.ExpressionTb.Content.ToString().Trim());
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
        public void MultClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.CBtn_OnClick(null, null); // clean the expression
            basicView.OperationBtn_OnClick(basicView.MulBtn, null); // *
            basicView.UpdateGui();

            Assert.AreEqual("2 * ", basicView.ExpressionTb.Content);
        }
        /*
         * Check the Operation button press:
         * Check the div button:
         * 
         * Expected Result: /
         */
        [TestMethod]
        public void DivClick()
        {
            basicView.OperationBtn_OnClick(basicView.DivBtn, null); // /
            basicView.UpdateGui();

            Assert.AreEqual("/", basicView.ExpressionTb.Content.ToString().Trim());
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
        public void DivClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.CBtn_OnClick(null, null); // clean the expression
            basicView.OperationBtn_OnClick(basicView.DivBtn, null); // /
            basicView.UpdateGui();

            Assert.AreEqual("2 /", basicView.ExpressionTb.Content.ToString().Trim());
        }
        /*
         * Check the Operation button press:
         * Check the OpenBrack button:
         * 
         * Expected Result: (
         */
        [TestMethod]
        public void OpenBrackClick()
        {
            basicView.OperationBtn_OnClick(basicView.OpenBrackBtn, null); // (
            basicView.UpdateGui();

            Assert.AreEqual("(", basicView.ExpressionTb.Content.ToString().Trim());
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
        public void OpenBrackClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.CBtn_OnClick(null, null); // clean the expression
            basicView.OperationBtn_OnClick(basicView.OpenBrackBtn, null); // (
            basicView.UpdateGui();

            Assert.AreEqual("2 (", basicView.ExpressionTb.Content.ToString().Trim());
        }
        /*
         * Check the Operation button press:
         * Check the CloseBrack button:
         * 
         * Expected Result: )
         */
        [TestMethod]
        public void CloseBrackClick()
        {
            basicView.OperationBtn_OnClick(basicView.CloseBrackBtn, null); // )
            basicView.UpdateGui();

            Assert.AreEqual(")", basicView.ExpressionTb.Content.ToString().Trim());
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
        public void CloseBrackClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.CBtn_OnClick(null, null); // clean the expression
            basicView.OperationBtn_OnClick(basicView.CloseBrackBtn, null); // )
            basicView.UpdateGui();

            Assert.AreEqual("2 )", basicView.ExpressionTb.Content.ToString().Trim());
        }
        /*
         * Check the Operation button press:
         * Check the Perc button:
         * 
         * Expected Result: %
         */
        [TestMethod]
        public void PercClick()
        {
            basicView.OperationBtn_OnClick(basicView.PercBtn, null); // %
            basicView.UpdateGui();

            Assert.AreEqual("%", basicView.ExpressionTb.Content.ToString().Trim());
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
        public void PercClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.CBtn_OnClick(null, null); // clean the expression
            basicView.OperationBtn_OnClick(basicView.PercBtn, null); // %
            basicView.UpdateGui();

            Assert.AreEqual("2 %", basicView.ExpressionTb.Content.ToString().Trim());
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
        public void Number1ButtonClick()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null); // 1
            basicView.UpdateGui();

            Assert.AreEqual("1", basicView.ExpressionTb.Content);
        }
        /*
         * Check the Number button press:
         * Check the 2 button:
         * 
         * Expected Result: 2
         */
        [TestMethod]
        public void Number2ButtonClick()
        {
            basicView.NumBtn_OnClick(basicView.Num2Btn, null); // 2
            basicView.UpdateGui();

            Assert.AreEqual("2", basicView.ExpressionTb.Content);
        }
        /*
         * Check the Number button press:
         * Check the 3 button:
         * 
         * Expected Result: 3
         */
        [TestMethod]
        public void Number3ButtonClick()
        {
            basicView.NumBtn_OnClick(basicView.Num3Btn, null); // 3
            basicView.UpdateGui();

            Assert.AreEqual("3", basicView.ExpressionTb.Content);
        }
        /*
         * Check the Number button press:
         * Check the 4 button:
         * 
         * Expected Result: 4
         */
        [TestMethod]
        public void Number4ButtonClick()
        {
            basicView.NumBtn_OnClick(basicView.Num4Btn, null); // 4
            basicView.UpdateGui();

            Assert.AreEqual("4", basicView.ExpressionTb.Content);
        }
        /*
         * Check the Number button press:
         * Check the 5 button:
         * 
         * Expected Result: 5
         */
        [TestMethod]
        public void Number5ButtonClick()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null); // 5
            basicView.UpdateGui();

            Assert.AreEqual("5", basicView.ExpressionTb.Content);
        }
        /*
         * Check the Number button press:
         * Check the 6 button:
         * 
         * Expected Result: 6
         */
        [TestMethod]
        public void Number6ButtonClick()
        {
            basicView.NumBtn_OnClick(basicView.Num6Btn, null); // 6
            basicView.UpdateGui();

            Assert.AreEqual("6", basicView.ExpressionTb.Content);
        }
        /*
         * Check the Number button press:
         * Check the 7 button:
         * 
         * Expected Result: 7
         */
        [TestMethod]
        public void Number7ButtonClick()
        {
            basicView.NumBtn_OnClick(basicView.Num7Btn, null);
            basicView.UpdateGui();

            Assert.AreEqual("7", basicView.ExpressionTb.Content);
        }
        /*
         * Check the Number button press:
         * Check the 8 button:
         * 
         * Expected Result: 8
         */
        [TestMethod]
        public void Number8ButtonClick()
        {
            basicView.NumBtn_OnClick(basicView.Num8Btn, null);
            basicView.UpdateGui();

            Assert.AreEqual("8", basicView.ExpressionTb.Content);
        }
        /*
         * Check the Number button press:
         * Check the 9 button:
         * 
         * Expected Result: 9
         */
        [TestMethod]
        public void Number9ButtonClick()
        {
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.UpdateGui();

            Assert.AreEqual("9", basicView.ExpressionTb.Content);
        }
        /*
         * Check the Number button press:
         * Check the 0 button:
         * 
         * Expected Result: 0
         */
        [TestMethod]
        public void Number0ButtonClick()
        {
            basicView.NumBtn_OnClick(basicView.Num0Btn, null);
            basicView.UpdateGui();

            Assert.AreEqual("0", basicView.ExpressionTb.Content);
        }
        /*
         * Check the Number button press:
         * Check the Dot button:
         * 
         * Expected Result: .
         */
        [TestMethod]
        public void DotButtonClick()
        {
            basicView.NumBtn_OnClick(basicView.DotBtn, null);
            basicView.UpdateGui();

            Assert.AreEqual(".", basicView.ExpressionTb.Content);
        }
        #endregion

        #region ClearBtn_OnClick Event Tests
        /*
         * Check the Clear button press, we provide and solve an expression
         * then we press the clear button and expect the cound of the history list 
         * to be 0
         */
        [TestMethod]
        public void ClearBtnOnClick()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null); // 5
            basicView.OperationBtn_OnClick(basicView.AddBtn, null); // +
            basicView.NumBtn_OnClick(basicView.Num6Btn, null); // 6
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.ClearBtn_OnClick(null, null); // clear history button
            basicView.UpdateGui();

            Assert.AreEqual(0, basicView.HistoryLv.Items.Count);
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
        public void DeleteBtnOnClick()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null); // 5
            basicView.NumBtn_OnClick(basicView.Num6Btn, null); // 6
            basicView.DeleteBtn_OnClick(null, null); // Delete
            basicView.UpdateGui();

            string actualResult = basicView.ExpressionTb.Content.ToString();

            Assert.AreEqual("5", actualResult);
        }
        /*
         * Check the Delete button press:
         * Check the expression and the result after we press the delete button
         * 
         * 5 → * → 2 → = → Delete
         * 
         * Expected Expression: 5
         * Expected Result:
         */
        [TestMethod]
        public void DeleteBtnOnClick2()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null); // 5
            basicView.OperationBtn_OnClick(basicView.MulBtn, null); // *
            basicView.NumBtn_OnClick(basicView.Num2Btn, null); // 2
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.DeleteBtn_OnClick(null, null); // Delete
            basicView.UpdateGui();

            string actualExpression = basicView.ExpressionTb.Content.ToString();
            string actualResult = basicView.ResultTb.Content.ToString();

            Assert.AreEqual("5 * ", actualExpression);
            Assert.AreEqual("", actualResult);
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
        public void CEBtnOnClick()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null); // 5
            basicView.OperationBtn_OnClick(basicView.MulBtn, null); // *
            basicView.NumBtn_OnClick(basicView.Num6Btn, null); // 6
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.CEBtn_OnClick(null, null); // CE
            basicView.UpdateGui();

            string actualExpression = basicView.ExpressionTb.Content.ToString();
            string actualResult = basicView.ResultTb.Content.ToString();

            Assert.AreEqual("", actualExpression);
            Assert.AreEqual("", actualResult);
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
        public void CBtnOnClick1()
        {
            basicView.NumBtn_OnClick(basicView.Num8Btn, null); // 8
            basicView.OperationBtn_OnClick(basicView.DivBtn, null); // /
            basicView.NumBtn_OnClick(basicView.Num4Btn, null); // 4
            basicView.EqualBtn_OnClick(null, null); // =
            basicView.CBtn_OnClick(null, null); // C (clean)
            basicView.UpdateGui();

            string actualExpression = basicView.ExpressionTb.Content.ToString();
            string actualResult = basicView.ResultTb.Content.ToString();
            Assert.AreEqual("", actualExpression);
            Assert.AreEqual("2", actualResult);
        }
        #endregion
    }
}
