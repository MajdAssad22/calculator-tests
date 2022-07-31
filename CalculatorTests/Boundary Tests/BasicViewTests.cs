using System;
using System.Threading.Tasks;
using System.Windows;
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
            basicView.NumBtn_OnClick(basicView.Num5Btn, null);
            basicView.NumBtn_OnClick(basicView.Num6Btn, null);
            basicView.NumBtn_OnClick(basicView.Num9Btn, null);
            basicView.EqualBtn_OnClick(null, null);
            basicView.UpdateGui();

            string expectedResult = "569";
            string actualResult = basicView.ResultTb.Content.ToString();

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
            object sender = basicView.Num1Btn;
            RoutedEventArgs e = null;

            basicView.NumBtn_OnClick(sender, e);
            basicView.UpdateGui();

            Assert.AreEqual("1", basicView.ExpressionTb.Content);
        }
        #endregion

        #region ClearBtn_OnClick Event Tests

        #endregion

        #region DeleteBtn_OnClick Event Tests

        #endregion
    }
}
