using System;
using CalculatorControl;
using CalculatorTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Boundary_Tests
{
    [TestClass]
    public class DisplayLogicTests
    {
        private static DisplayLogic displayLogic;

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
            displayLogic = new DisplayLogic();
        }

        // TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize() {
            displayLogic.CurrentExpression = "";
            displayLogic.CurrentResult = "";
        }
        #endregion

        #region ResetDisplay Function Tests
        /*
         * This test checks the ResetDisplay function,
         * the data before:
         * 
         * CurrentExpression:   10 + 6
         * CurrentResult:   16
         */
        [TestMethod]
        public void ResetDisplayTest1()
        {
            try
            {
                displayLogic.CurrentExpression = "10 + 6";
                displayLogic.CurrentResult = "16";
            
                displayLogic.ResetDisplay();
            
                string expectedExpresssion = "";
                string expectedResult = "";

                string actualExpression = displayLogic.CurrentExpression;
                string actualResult = displayLogic.CurrentResult;

                Assert.AreEqual(expectedExpresssion, actualExpression);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region IsLastOperation Function Tests
        /*
         * This test checks the IsLastOperation function,
         * the data before:
         * 
         * CurrentExpression:   10 + 
         * ExpectedReturnValue: true
         */
        [TestMethod]
        public void IsLastOperationTest1()
        {
            try
            {
                displayLogic.CurrentExpression = "10 +";

                bool actualReturnValue = displayLogic.IsLastOperationCaller(); // A public function made to test the IsLastOperation function
                Assert.IsTrue(actualReturnValue);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the IsLastOperation function,
         * the data before:
         * 
         * CurrentExpression:   45 * 
         * ExpectedReturnValue: true
         */
        [TestMethod]
        public void IsLastOperationTest2()
        {
            try
            {
                displayLogic.CurrentExpression = "45 *";

                bool actualReturnValue = displayLogic.IsLastOperationCaller(); // A public function made to test the IsLastOperation function
                Assert.IsTrue(actualReturnValue);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the IsLastOperation function,
         * the data before:
         * 
         * CurrentExpression:   11 /  
         * ExpectedReturnValue: true
         */
        [TestMethod]
        public void IsLastOperationTest3()
        {
            try
            {
                displayLogic.CurrentExpression = "11 /";

                bool actualReturnValue = displayLogic.IsLastOperationCaller(); // A public function made to test the IsLastOperation function
                Assert.IsTrue(actualReturnValue);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the IsLastOperation function,
         * the data before:
         * 
         * CurrentExpression:   13 - 
         * ExpectedReturnValue: true
         */
        [TestMethod]
        public void IsLastOperationTest4()
        {
            try
            {
                displayLogic.CurrentExpression = "13 -";

                bool actualReturnValue = displayLogic.IsLastOperationCaller(); // A public function made to test the IsLastOperation function
                Assert.IsTrue(actualReturnValue);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the IsLastOperation function,
         * the data before:
         * 
         * CurrentExpression:   13 ^ 
         * ExpectedReturnValue: true
         */
        [TestMethod]
        public void IsLastOperationTest5()
        {
            try
            {
                displayLogic.CurrentExpression = "13 ^";

                bool actualReturnValue = displayLogic.IsLastOperationCaller(); // A public function made to test the IsLastOperation function
                Assert.IsTrue(actualReturnValue);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the IsLastOperation function,
         * the data before:
         * 
         * CurrentExpression:   13 !
         * ExpectedReturnValue: true
         */
        [TestMethod]
        public void IsLastOperationTest6()
        {
            try
            {
                displayLogic.CurrentExpression = "13 !";

                bool actualReturnValue = displayLogic.IsLastOperationCaller(); // A public function made to test the IsLastOperation function
                Assert.IsFalse(actualReturnValue);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region SelectHistory Function Tests
        /*
         * This test checks the SelectHistory function,
         * Input:
         * 
         * Tree: null
         */
        [TestMethod]
        public void SelectHistoryTest1()
        {
            try
            {
                ExpressionTree tree = null;
                //Demo data to validate that the expression and result are cleaned
                displayLogic.CurrentExpression = "10 + 5";
                displayLogic.CurrentResult = "15";

                string expectedExpression = "";
                string expectedResult = "";
                displayLogic.SelectHistory(tree);
                string actualExpression = displayLogic.CurrentExpression;
                string actualResult = displayLogic.CurrentResult;

                Assert.AreEqual(expectedExpression, actualExpression);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            
        }
        /*
         * This test checks the SelectHistory function,
         * Input:
         * 
         * Tree:        +
         *            /   \
         *           3     2
         */
        [TestMethod]
        public void SelectHistoryTest2()
        {
            try
            {
                ExpressionTree tree = new ExpressionTree("3 + 2");

                string expectedExpression = "3 + 2";
                string expectedResult = "5";
                displayLogic.SelectHistory(tree);
                string actualExpression = displayLogic.CurrentExpression;
                string actualResult = displayLogic.CurrentResult;

                Assert.AreEqual(expectedExpression, actualExpression);
                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            
        }
        #endregion

        #region ConcatinateOperation Function Tests
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => "10 + "
         *              CurrentResult => "Invalid Input"
         *      
         * Input:   Operation => +
         */
        [TestMethod]
        public void ConcatinateOperationTest1()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "10 + ";
                displayLogic.CurrentResult = CalculatorParams.INVALID_INPUT;

                // Running the function on "+"
                displayLogic.ConcatinateOperation("+");

                string expectedExpression = "+";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => "60 + 2"
         *              CurrentResult => "62"
         *      
         * Input:   Operation => %
         */
        [TestMethod]
        public void ConcatinateOperationTest2()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "60 + 2";
                displayLogic.CurrentResult = "62";

                // Running the function on "%"
                displayLogic.ConcatinateOperation("%");

                string expectedExpression = "62 %";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => "20 + 5"
         *              CurrentResult => "25"
         *      
         * Input:   Operation => 1 / (
         */
        [TestMethod]
        public void ConcatinateOperationTest3()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "20 + 5";
                displayLogic.CurrentResult = "25";

                // Running the function on "1/("
                displayLogic.ConcatinateOperation("1 / (");

                string expectedExpression = "1 / ( 25";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => "2 * 3"
         *              CurrentResult => "6"
         *      
         * Input:   Operation => 10 ^
         */
        [TestMethod]
        public void ConcatinateOperationTest4()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "2 * 3";
                displayLogic.CurrentResult = "6";

                // Running the function on "10^"
                displayLogic.ConcatinateOperation("10 ^");

                string expectedExpression = "10 ^ 6";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => "9 + 2"
         *              CurrentResult => "11"
         *      
         * Input:   Operation => *
         */
        [TestMethod]
        public void ConcatinateOperationTest5()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "9 + 2";
                displayLogic.CurrentResult = "11";

                // Running the function on "*"
                displayLogic.ConcatinateOperation("*");

                string expectedExpression = "11 * ";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => "47 - 2"
         *              CurrentResult => "45"
         *      
         * Input:   Operation => cos(
         */
        [TestMethod]
        public void ConcatinateOperationTest6()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "47 - 2";
                displayLogic.CurrentResult = "45";

                // Running the function on "cos("
                displayLogic.ConcatinateOperation("cos(");

                string expectedExpression = "cos( 45";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);                
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => "98 + 6"
         *              CurrentResult => ""
         *      
         * Input:   Operation => /
         */
        [TestMethod]
        public void ConcatinateOperationTest7()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "98 + 6";
                displayLogic.CurrentResult = "";

                // Running the function on "/"
                displayLogic.ConcatinateOperation("/");

                string expectedExpression = "98 + 6 / ";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => "15 * "
         *              CurrentResult => ""
         *      
         * Input:   Operation => -
         */
        [TestMethod]
        public void ConcatinateOperationTest8()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "15 * ";
                displayLogic.CurrentResult = "";

                // Running the function on "-"
                displayLogic.ConcatinateOperation("-");

                string expectedExpression = "15 * -";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);                
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => "6 * ("
         *              CurrentResult => ""
         *      
         * Input:   Operation => -
         */
        [TestMethod]
        public void ConcatinateOperationTest9()
        {
            try
            {                
                // Old Data
                displayLogic.CurrentExpression = "6 * (";
                displayLogic.CurrentResult = "";

                // Running the function on "-"
                displayLogic.ConcatinateOperation("-");

                string expectedExpression = "6 * ( -";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => ""
         *              CurrentResult => ""
         *      
         * Input:   Operation => -
         */
        [TestMethod]
        public void ConcatinateOperationTest10()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "";
                displayLogic.CurrentResult = "";

                // Running the function on "-"
                displayLogic.ConcatinateOperation("-");

                string expectedExpression = "-";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => "6 * 9"
         *              CurrentResult => ""
         *      
         * Input:   Operation => -
         */
        [TestMethod]
        public void ConcatinateOperationTest11()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "6 * 9";
                displayLogic.CurrentResult = "";

                // Running the function on "-"
                displayLogic.ConcatinateOperation("-");

                string expectedExpression = "6 * 9 - ";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateOperation function,
         * 
         * Old Data:    CurrentExpresison => "6 * "
         *              CurrentResult => ""
         *      
         * Input:   Operation => +
         */
        [TestMethod]
        public void ConcatinateOperationTest12()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "6 * ";
                displayLogic.CurrentResult = "";

                // Running the function on "+"
                displayLogic.ConcatinateOperation("+");

                string expectedExpression = "6 * +";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region ConcatinateNumber Function Tests
        /*
         * This test checks the ConcatinateNumber function,
         * 
         * Old Data:    CurrentExpresison => "20 + 6"
         *              CurrentResult => "26"
         *      
         * Input:   Number => 4
         */
        [TestMethod]
        public void ConcatinateNumberTest1()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "20 + 6";
                displayLogic.CurrentResult = "26";

                // Running the function on "4"
                displayLogic.ConcatinateNumber("4");

                string expectedExpression = "4";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the ConcatinateNumber function,
         * 
         * Old Data:    CurrentExpresison => "60 + 2"
         *              CurrentResult => ""
         *      
         * Input:   Number => 5
         */
        [TestMethod]
        public void ConcatinateNumberTest2()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "60 + 2";
                displayLogic.CurrentResult = "";

                // Running the function on "5"
                displayLogic.ConcatinateNumber("5");

                string expectedExpression = "60 + 25";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            
        }
        #endregion

        #region ClearHistory Function Tests
        /*
         * This test checks the ClearHistory function
         */
        [TestMethod]
        public void ClearHistoryTest1()
        {
            try
            {
                ExpressionTree exp1 = new ExpressionTree("16 + 9");
                ExpressionTree exp2 = new ExpressionTree("13 - 3");
                Calculator.History.Add(exp1);
                Calculator.History.Add(exp2);
                displayLogic.CurrentResult = exp2.Result;

                displayLogic.ClearHistory();

                string expectedResult = "";
                int expectedLength = 0;

                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
                Assert.AreEqual(expectedLength, Calculator.History.Count);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region RemoveLast Function Tests
        /*
         * This test checks the RemoveLast function,
         * 
         * Old Data:    CurrentExpresison => "5 + sin("
         *              CurrentResult => ""
         */
        [TestMethod]
        public void RemoveLastTest1()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "5 + sin(";
                displayLogic.CurrentResult = "";

                displayLogic.RemoveLast();

                string expectedExpression = "5 + ";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the RemoveLast function,
         * 
         * Old Data:    CurrentExpresison => "5 + "
         *              CurrentResult => ""
         */
        [TestMethod]
        public void RemoveLastTest2()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "5 + ";
                displayLogic.CurrentResult = "";

                displayLogic.RemoveLast();

                string expectedExpression = "5";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
}
        /*
         * This test checks the RemoveLast function,
         * 
         * Old Data:    CurrentExpresison => "5 + + "
         *              CurrentResult => ""
         */
        [TestMethod]
        public void RemoveLastTest3()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "5 + + ";
                displayLogic.CurrentResult = "";

                displayLogic.RemoveLast();

                string expectedExpression = "5 + ";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the RemoveLast function,
         * 
         * Old Data:    CurrentExpresison => "895"
         *              CurrentResult => "895"
         */
        [TestMethod]
        public void RemoveLastTest4()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "895";
                displayLogic.CurrentResult = "895";

                displayLogic.RemoveLast();

                string expectedExpression = "89";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
         * This test checks the RemoveLast function,
         * 
         * Old Data:    CurrentExpresison => ""
         *              CurrentResult => ""
         */
        [TestMethod]
        public void RemoveLastTest5()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "";
                displayLogic.CurrentResult = "";

                displayLogic.RemoveLast();

                string expectedExpression = "";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region Calculate Function Tests
        /*
        * This test checks the Calculate function,
        * 
        * Old Data:    CurrentExpresison => ""
        *              CurrentResult => ""
        */
        [TestMethod]
        public void CalculateTest1()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "";
                displayLogic.CurrentResult = "";

                displayLogic.Calculate();

                string expectedExpression = "";
                string expectedResult = "";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
        * This test checks the Calculate function,
        * 
        * Old Data:    CurrentExpresison => "5 + 6"
        *              CurrentResult => ""
        */
        [TestMethod]
        public void CalculateTest2()
        {
            try
            {
                // Old Data
                displayLogic.CurrentExpression = "5 + 6";
                displayLogic.CurrentResult = "";

                displayLogic.Calculate();

                string expectedExpression = "5 + 6";
                string expectedResult = "11";

                Assert.AreEqual(expectedExpression, displayLogic.CurrentExpression);
                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region ChangeBase Function Tests
        /*
        * This test checks the ChangeBase function,
        * 
        * Old Data:    CurrentResult => "5"
        *              CalculatorBase => Dec
        */
        [TestMethod]
        public void ChangeBaseTest1()
        {
            try
            {
                // Setup
                Calculator.Mode = CalculatorParams.CalculatorModes.Programmer;
                Calculator.Base = CalculatorParams.Bases.Dec;
                ExpressionTree tree = new ExpressionTree("5");
                Calculator.History.Add(tree);

                displayLogic.CurrentResult = tree.Result;

                displayLogic.ChangeBase(CalculatorParams.Bases.Bin);

                string expectedResult = "101";
                CalculatorParams.Bases expectedBase = CalculatorParams.Bases.Bin;

                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
                Assert.AreEqual(expectedBase, Calculator.Base);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /*
        * This test checks the ChangeBase function,
        * 
        * Old Data:    CurrentResult => ""
        *              CalculatorBase => Dec
        */
        [TestMethod]
        public void ChangeBaseTest2()
        {
            try
            {
                // Setup
                Calculator.Mode = CalculatorParams.CalculatorModes.Programmer;
                Calculator.Base = CalculatorParams.Bases.Dec;
                displayLogic.CurrentResult = "";

                displayLogic.ChangeBase(CalculatorParams.Bases.Hex);

                string expectedResult = "";
                CalculatorParams.Bases expectedBase = CalculatorParams.Bases.Hex;

                Assert.AreEqual(expectedResult, displayLogic.CurrentResult);
                Assert.AreEqual(expectedBase, Calculator.Base);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion

        #region RadDegToggle Function Tests
        /*
        * This test checks the RadDegToggle function,
        * 
        * Old Data:    Calculator's IsDegree => True
        */
        [TestMethod]
        public void RadDegToggleTest1()
        {
            try
            {
                // Setup
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = true;

                string actualReturnValue = displayLogic.RadDegToggle();
                string expectedReturnValue = "Radian";

                Assert.AreEqual(expectedReturnValue, actualReturnValue);
                Assert.IsFalse(Calculator.IsDegree);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /*
        * This test checks the RadDegToggle function,
        * 
        * Old Data:    Calculator's IsDegree => False
        */
        [TestMethod]
        public void RadDegToggleTest2()
        {
            try
            {
                // Setup
                Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                Calculator.IsDegree = false;

                string actualReturnValue = displayLogic.RadDegToggle();
                string expectedReturnValue = "Degree";

                Assert.AreEqual(expectedReturnValue, actualReturnValue);
                Assert.IsTrue(Calculator.IsDegree);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        #endregion
    }
}
