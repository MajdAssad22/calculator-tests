using System;
using CalculatorControl;
using CalculatorTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Boundary_Tests
{
    [TestClass]
    public class ProgrammerViewTests
    {
        private static ProgrammerView programmerView;


        #region Additional test attributes
        // TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            programmerView.CEBtn_OnClick(null, null);
        }
        #endregion

        [ClassInitialize()]
        public static void TestsClassInitialize(TestContext testContext)
        {
            programmerView = new ProgrammerView();
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
            programmerView.NumBtn_OnClick(programmerView.Num5Btn, null);
            programmerView.NumBtn_OnClick(programmerView.Num6Btn, null);
            programmerView.NumBtn_OnClick(programmerView.Num9Btn, null);
            programmerView.EqualBtn_OnClick(null, null);
            programmerView.UpdateGui();

            string expectedResult = "569";
            string actualResult = programmerView.ResultTb.Content.ToString();

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
            object sender = programmerView.Num1Btn;

            programmerView.NumBtn_OnClick(sender, null);
            programmerView.UpdateGui();

            Assert.AreEqual("1", programmerView.ExpressionTb.Content);
        }
        #endregion

        #region ClearBtn_OnClick Event Tests

        #endregion

        #region DeleteBtn_OnClick Event Tests

        #endregion

        #region ChangeBaseBtn_OnClick Event Tests
        /*
         * This test checks after changing the base if all the appropriate buttons
         * have been disabled and checks the calculator's base if changed.
         * 
         * Done For BIN
         */
        [TestMethod]
        public void BINChangeBaseTest1()
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
        public void OCTChangeBaseTest1()
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
        public void DECChangeBaseTest1()
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
        public void HEXChangeBaseTest1()
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
