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
            basicView = new BasicView();
        }

        //This will run after every test
        [TestInitialize]
        public void TestInitialize()
        {
            //basicView = new BasicView();
            basicView.CEBtn_OnClick(null, null);
        }

        #region HistoryLv_OnSelectionChanged Event Tests
        [TestMethod]
        public void HistoryLv()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num6Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            //string res = basicView.ResultTb.ToString();
            basicView.CEBtn_OnClick(null, null);
            basicView.UpdateGui();

            basicView.HistoryLv.SelectedIndex = 0;
            var e = new SelectionChangedEventArgs(
                    System.Windows.Controls.Primitives.Selector.SelectionChangedEvent,
                    new List<ListView> { },
                    new List<ListView> { basicView.HistoryLv });
            basicView.HistoryLv_OnSelectionChanged(basicView.HistoryLv, e);

            //string checkIsEmpty = basicView.HistoryLv.Items[0].;
            string checkIsEmpty = ((ExpressionTree)basicView.HistoryLv.Items[0]).Expression;
            string checkResult = ((ExpressionTree)basicView.HistoryLv.Items[0]).Result;

            Assert.AreEqual(checkIsEmpty, basicView.ExpressionTb.Content.ToString().Trim());
            Assert.AreEqual(checkResult, basicView.ResultTb.Content.ToString().Trim());

        }//Check the expression that appear inside the history
        #endregion

        #region EqualBtn_OnClick Event Tests
        [TestMethod]
        public void EqualBtnOnClick1()
        {
            // 5 -> 6 -> 9 -> =
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.NumBtn_OnClick(basicView.Num6Btn, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.UpdateGui();

            string expectedResult = "569";
            string actualResult = basicView.ResultTb.Content.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void EqualBtnOnClick2()
        {
            // 5 -> 6 -> 9 -> =
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.NumBtn_OnClick(basicView.Num6Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);//56 + 9
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.UpdateGui();
            string expectedResult = "65";
            string actualResult = basicView.ResultTb.Content.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void EqualBtnOnClick3()
        {
            // 5 -> 6 -> 9 -> =
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.NumBtn_OnClick(basicView.DotBtn, null);
            basicView.NumBtn_OnClick(basicView.Num6Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.UpdateGui();
            string expectedResult = "14.6";
            string actualResult = basicView.ResultTb.Content.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion

        #region OperationBtn_OnClick Event Tests
        [TestMethod]
        public void AddClick()
        {
            object sender = basicView.AddBtn;
            RoutedEventArgs e = null;
            basicView.OperationBtn_OnClick(sender, e);
            basicView.UpdateGui();
            Assert.AreEqual(" + ", basicView.ExpressionTb.Content);
        }//check Plus Operations
        [TestMethod]
        public void AddClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CBtn_OnClick(null, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual("2 + ", basicView.ExpressionTb.Content);
        }//check Plus after clicking 1,+,1,=,CB,+
        [TestMethod]
        public void SubClick()
        {
            basicView.OperationBtn_OnClick(basicView.SubBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual(" -", basicView.ExpressionTb.Content);//there is ' -' 
        }//check Minus Operations
        [TestMethod]
        public void SubClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CBtn_OnClick(null, null);
            basicView.OperationBtn_OnClick(basicView.SubBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual("2 -", basicView.ExpressionTb.Content);
        }//check Plus after clicking 1,+,1,=,CB,-
        [TestMethod]
        public void MultClick()
        {
            basicView.OperationBtn_OnClick(basicView.MulBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual(" * ", basicView.ExpressionTb.Content);
        }//check Multiple Operations
        [TestMethod]
        public void MultClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CBtn_OnClick(null, null);
            basicView.OperationBtn_OnClick(basicView.MulBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual("2 * ", basicView.ExpressionTb.Content);
        }//check Plus after clicking 1,+,1,=,CB,*
        [TestMethod]
        public void DivClick()
        {
            basicView.OperationBtn_OnClick(basicView.DivBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual(" / ", basicView.ExpressionTb.Content);
        }//check Divide Operations
        [TestMethod]
        public void DivClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CBtn_OnClick(null, null);
            basicView.OperationBtn_OnClick(basicView.DivBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual("2 / ", basicView.ExpressionTb.Content);
        }//check Plus after clicking 1,+,1,=,CB,/
        [TestMethod]
        public void OpenBrackClick()
        {
            basicView.OperationBtn_OnClick(basicView.OpenBrackBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual(" ( ", basicView.ExpressionTb.Content);
        }//check 1111Open Brackets
        [TestMethod]
        public void OpenBrackClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CBtn_OnClick(null, null);
            basicView.OperationBtn_OnClick(basicView.OpenBrackBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual("2 ( ", basicView.ExpressionTb.Content);
        }// check Plus after clicking 1,+,1,=,CB,(
        [TestMethod]
        public void CloseBrackClick()
        {
            basicView.OperationBtn_OnClick(basicView.CloseBrackBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual(" ) ", basicView.ExpressionTb.Content);
        }//check 1111Close Brackets
        [TestMethod]
        public void CloseBrackClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CBtn_OnClick(null, null);
            basicView.OperationBtn_OnClick(basicView.CloseBrackBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual("2 ) ", basicView.ExpressionTb.Content);
        }// check Brack after clicking 1,+,1,=,CB,)
        [TestMethod]
        public void PercClick()
        {
            basicView.OperationBtn_OnClick(basicView.PercBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual(" % ", basicView.ExpressionTb.Content);
        }//check Percentage
        [TestMethod]
        public void PercClick02()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CBtn_OnClick(null, null);
            basicView.OperationBtn_OnClick(basicView.PercBtn, null);
            basicView.UpdateGui();
            Assert.AreEqual("2 %", basicView.ExpressionTb.Content);
        }//check Perc after clicking 1,+,1,=,CB,%
        #endregion

        #region NumBtn_OnClick Event Tests
        [TestMethod]
        public void Number1ButtonClick()
        {
            // Sender, e: Number 1 Button, Null
            object sender = basicView.Num1Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual("1", basicView.ExpressionTb.Content);
        }// check button 1
        [TestMethod]
        public void Number1ButtonClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.UpdateGui();
            Assert.AreEqual("1", basicView.ExpressionTb.Content);
        }// click 1
        [TestMethod]
        public void Number2ButtonClick()
        {
            // Sender, e: Number 2 Button, Null
            object sender = basicView.Num2Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual("2", basicView.ExpressionTb.Content);
        }// check button 2
        [TestMethod]
        public void Number2ButtonClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.NumBtn_OnClick(basicView.Num2Btn, null);//we check here
            basicView.UpdateGui();
            Assert.AreEqual("2", basicView.ExpressionTb.Content);
        }// check button 2
        [TestMethod]
        public void Number3ButtonClick()
        {
            // Sender, e: Number 3 Button, Null
            object sender = basicView.Num3Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual("3", basicView.ExpressionTb.Content);
        }// check button 3
        [TestMethod]
        public void Number3ButtonClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.NumBtn_OnClick(basicView.Num3Btn, null);//we check here
            basicView.UpdateGui();
            Assert.AreEqual("3", basicView.ExpressionTb.Content);
        }// check button 3
        [TestMethod]
        public void Number4ButtonClick()
        {
            // Sender, e: Number 4 Button, Null
            object sender = basicView.Num4Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual("4", basicView.ExpressionTb.Content);
        }// check button 4
        [TestMethod]
        public void Number4ButtonClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.NumBtn_OnClick(basicView.Num4Btn, null);//we check here
            basicView.UpdateGui();
            Assert.AreEqual("4", basicView.ExpressionTb.Content);
        }// check button 4
        [TestMethod]
        public void Number5ButtonClick()
        {
            // Sender, e: Number 5 Button, Null
            object sender = basicView.Num5Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual("5", basicView.ExpressionTb.Content);
        }// check button 5
        [TestMethod]
        public void Number5ButtonClick02()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);//we check here
            basicView.UpdateGui();
            Assert.AreEqual("5", basicView.ExpressionTb.Content);
        }// check button 5
        [TestMethod]
        public void Number6ButtonClick()
        {
            // Sender, e: Number 6 Button, Null
            object sender = basicView.Num6Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual("6", basicView.ExpressionTb.Content);
        }// check button 6
        [TestMethod]
        public void Number6ButtonClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.NumBtn_OnClick(basicView.Num6Btn, null);//we check here
            basicView.UpdateGui();
            Assert.AreEqual("6", basicView.ExpressionTb.Content);
        }// check button 6
        [TestMethod]
        public void Number7ButtonClick()
        {
            // Sender, e: Number 3 Button, Null
            object sender = basicView.Num7Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual("7", basicView.ExpressionTb.Content);
        }// check button 7
        [TestMethod]
        public void Number7ButtonClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.NumBtn_OnClick(basicView.Num7Btn, null);//we check here
            basicView.UpdateGui();
            Assert.AreEqual("7", basicView.ExpressionTb.Content);
        }// check button 7
        [TestMethod]
        public void Number8ButtonClick()
        {
            // Sender, e: Number 3 Button, Null
            object sender = basicView.Num8Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual("8", basicView.ExpressionTb.Content);
        }// check button 8
        [TestMethod]
        public void Number8ButtonClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.NumBtn_OnClick(basicView.Num8Btn, null);//we check here
            basicView.UpdateGui();
            Assert.AreEqual("8", basicView.ExpressionTb.Content);
        }// check button 6
        [TestMethod]
        public void Number9ButtonClick()
        {
            // Sender, e: Number 9 Button, Null
            object sender = basicView.Num9Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual("9", basicView.ExpressionTb.Content);
        }// check button 9
        [TestMethod]
        public void Number9ButtonClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);//we check here
            basicView.UpdateGui();
            Assert.AreEqual("9", basicView.ExpressionTb.Content);
        }// check button 6
        [TestMethod]
        public void Number0ButtonClick()
        {
            // Sender, e: Number 3 Button, Null
            object sender = basicView.Num0Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual("0", basicView.ExpressionTb.Content);
        }// check button 0
        [TestMethod]
        public void Number0ButtonClick01()
        {
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.NumBtn_OnClick(basicView.Num0Btn, null);//we check here
            basicView.UpdateGui();
            Assert.AreEqual("0", basicView.ExpressionTb.Content);
        }// check button 0
        [TestMethod]
        public void Number0ButtonClick2()
        {
            // Sender, e: Number 3 Button, Null
            object sender = basicView.Num0Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.NumBtn_OnClick(sender, e);
            basicView.NumBtn_OnClick(sender, e);
            basicView.EqualBtn_OnClick(null, null);
            basicView.UpdateGui();

            Assert.AreEqual("0", basicView.ResultTb.Content);
        }// check multiple zeros then equal and check the <result box>
        [TestMethod]
        public void DotButtonClick()
        {
            // Sender, e: Dot Button, Null
            object sender = basicView.DotBtn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual(".", basicView.ExpressionTb.Content);
        }// check dot button
        [TestMethod]
        public void DotButtonClick2()
        {
            // Sender, e: Dot Button, Null
            object sender = basicView.DotBtn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.NumBtn_OnClick(basicView.Num0Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num1Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.UpdateGui();

            Assert.AreEqual("1", basicView.ResultTb.Content);
        }// check dot button .0+1 = 1
        [TestMethod]
        public void DotButtonClick3()
        {
            // Sender, e: Dot Button, Null
            object sender = basicView.DotBtn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.NumBtn_OnClick(sender, e);
            basicView.EqualBtn_OnClick(null, null);
            basicView.UpdateGui();

            Assert.AreEqual("Incorrect Input", basicView.ResultTb.Content);
        }// check Incorrect Input Message
        #endregion

        #region ClearBtn_OnClick Event Tests
        [TestMethod]
        public void ClearBtnOnClick()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num6Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.ClearBtn_OnClick(null, null);
            basicView.UpdateGui();


            //string actualResult = basicView.HistoryLv;
            string checkIsEmpty = basicView.HistoryLv.Items.Count.ToString();

            Assert.AreEqual("0", checkIsEmpty);
        }//check the button with an operation
        [TestMethod]
        public void ClearBtnOnClick2()
        {
            basicView.NumBtn_OnClick(basicView.Num0Btn, null);
            basicView.NumBtn_OnClick(basicView.Num0Btn, null);
            basicView.NumBtn_OnClick(basicView.Num0Btn, null);

            basicView.EqualBtn_OnClick(null, null);
            basicView.ClearBtn_OnClick(null, null);
            basicView.UpdateGui();


            //string actualResult = basicView.HistoryLv;
            string checkIsEmpty = basicView.HistoryLv.Items.Count.ToString();

            Assert.AreEqual("0", checkIsEmpty);
        }
        [TestMethod]
        public void ClearBtnOnClick3()
        {
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.ClearBtn_OnClick(null, null);
            basicView.UpdateGui();


            //string actualResult = basicView.HistoryLv;
            string checkIsEmpty = basicView.HistoryLv.Items.Count.ToString();

            Assert.AreEqual("0", checkIsEmpty);
        }//typing big number 
        [TestMethod]
        public void ClearBtnOnClick4()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num6Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CBtn_OnClick(null, null);
            basicView.UpdateGui();

            basicView.HistoryLv.SelectedIndex = 0;
            var e = new SelectionChangedEventArgs(
                    System.Windows.Controls.Primitives.Selector.SelectionChangedEvent,
                    new List<ListView> { },
                    new List<ListView> { basicView.HistoryLv });
            basicView.HistoryLv_OnSelectionChanged(basicView.HistoryLv, e);

            string checkIsEmpty = basicView.HistoryLv.Items[0].ToString();
            Assert.AreEqual(checkIsEmpty, basicView.ExpressionTb.Content.ToString().Trim());
        }
        #endregion

        #region DeleteBtn_OnClick Event Tests
        [TestMethod]
        public void DeleteBtnOnClick()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.NumBtn_OnClick(basicView.Num6Btn, null);
            basicView.DeleteBtn_OnClick(null, null);
            basicView.UpdateGui();

            string actualResult = basicView.ExpressionTb.Content.ToString();

            Assert.AreEqual("5", actualResult);
        }// check that if the Expression before clicking equal button
        [TestMethod]
        public void DeleteBtnOnClick2()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.OperationBtn_OnClick(basicView.MulBtn, null);
            basicView.NumBtn_OnClick(basicView.Num2Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.DeleteBtn_OnClick(null, null);
            basicView.UpdateGui();

            string actualResult = basicView.ExpressionTb.Content.ToString();

            Assert.AreEqual("5 * ", actualResult);
        }// check the <Input Expression> changed after clicking equal button 
        [TestMethod]
        public void DeleteBtnOnClick3()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.OperationBtn_OnClick(basicView.MulBtn, null);
            basicView.NumBtn_OnClick(basicView.Num2Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.DeleteBtn_OnClick(null, null);
            basicView.UpdateGui();

            string actualResult = basicView.ResultTb.Content.ToString();

            Assert.AreEqual("", actualResult);
        }// check that after clicking the delete button the <result box> is empty
        #endregion

        #region CEBtn_OnClick Event Tests
        [TestMethod]
        public void CEBtnOnClick()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.OperationBtn_OnClick(basicView.MulBtn, null);
            basicView.NumBtn_OnClick(basicView.Num6Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CEBtn_OnClick(null, null);
            basicView.UpdateGui();

            string actualResult01 = basicView.ExpressionTb.Content.ToString();
            string actualResult02 = basicView.ResultTb.Content.ToString();
            string check = actualResult01 + actualResult02;
            Assert.AreEqual("", check);
        }//check the CE with Operation include equal button ,checking that the exprssion and the result are empty 
        [TestMethod]
        public void CEBtnOnClick2()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.CEBtn_OnClick(null, null);
            basicView.UpdateGui();

            string actualResult = basicView.ExpressionTb.Content.ToString();
            Assert.AreEqual("", actualResult);
        }//check the CE with an Expression before clicking equal operation
        [TestMethod]
        public void CEBtnOnClick3()
        {
            basicView.OperationBtn_OnClick(basicView.MulBtn, null);
            basicView.OperationBtn_OnClick(basicView.DivBtn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.UpdateGui();

            basicView.CEBtn_OnClick(null, null);
            
            string actualResult = basicView.ExpressionTb.Content.ToString();
            Assert.AreEqual("", actualResult);
        }// Include incorrect input
        [TestMethod]
        public void CEBtnOnClick4()
        {
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.OperationBtn_OnClick(basicView.MulBtn, null);
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CBtn_OnClick(null, null);
            basicView.CEBtn_OnClick(null, null);
            basicView.UpdateGui();

            string actualResult = basicView.ResultTb.Content.ToString();
            Assert.AreEqual("", actualResult);
        }//check the result after clicking  5 , * ,5  , = , C , CE
        #endregion

        #region CBtn_OnClick Event Tests
        [TestMethod]
        public void CBtnOnClick1()
        {
            basicView.NumBtn_OnClick(basicView.Num8Btn, null);
            basicView.OperationBtn_OnClick(basicView.DivBtn, null);
            basicView.NumBtn_OnClick(basicView.Num4Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CBtn_OnClick(null, null);
            basicView.UpdateGui();

            string actualResult = basicView.ExpressionTb.Content.ToString();
            Assert.AreEqual("", actualResult);
        }// Check the Expression after clicking equal button
        [TestMethod]
        public void CBtnOnClick2()
        {
            basicView.NumBtn_OnClick(basicView.Num8Btn, null);
            basicView.CBtn_OnClick(null, null);
            basicView.UpdateGui();

            string actualResult = basicView.ExpressionTb.Content.ToString();
            Assert.AreEqual("", actualResult);
        }// Clicking one number
        [TestMethod]
        public void CBtnOnClick3()
        {
            basicView.NumBtn_OnClick(basicView.PercBtn, null);
            basicView.CBtn_OnClick(null, null);
            basicView.UpdateGui();

            string actualResult = basicView.ExpressionTb.Content.ToString();
            Assert.AreEqual("", actualResult);
        }//check clicking
        [TestMethod]
        public void CBtnOnClick4()
        {
            basicView.NumBtn_OnClick(basicView.Num8Btn, null);
            basicView.OperationBtn_OnClick(basicView.AddBtn, null);
            basicView.NumBtn_OnClick(basicView.Num4Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.CBtn_OnClick(null, null);
            basicView.UpdateGui();

            string actualResult = basicView.ResultTb.Content.ToString();
            Assert.AreEqual("12", actualResult);
        }// Check that clicking CB button not effect the result button
        #endregion
    }
}
