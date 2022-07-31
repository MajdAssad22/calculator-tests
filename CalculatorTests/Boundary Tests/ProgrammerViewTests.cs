using System;
using CalculatorTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Boundary_Tests
{
    [TestClass]
    public class ProgrammerViewTests
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
    }
}
