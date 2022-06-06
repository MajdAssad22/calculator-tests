using System;
using System.Collections.Generic;
using System.Linq;
using CalculatorControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class ExpressionTreeTests
    {
        private static ExpressionTree expressionTree;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            expressionTree = new ExpressionTree("");
            Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
            Calculator.IsDegree = true;
        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        // BuildTree Function Tests
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                string[] expression = { "" };

                ExpressionTree.Node expectedRoot = null;
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                string[] expression = { "%" };

                ExpressionTree.Node expectedRoot = null;
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            try
            {
                string[] expression = { "(", "5", ")", "%" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("5");
                expectedRoot.Functions.Enqueue("%");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod4()
        {
            try
            {
                string[] expression = { "15", "%" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("15");
                expectedRoot.Functions.Enqueue("%");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod5()
        {
            try
            {
                string[] expression = { "12", "%", "%" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("12");
                expectedRoot.Functions.Enqueue("%");
                expectedRoot.Functions.Enqueue("%");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod6()
        {
            try
            {
                string[] expression = { "15", "*", "(", "%", ")" };

                ExpressionTree.Node expectedRoot = null;
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod7()
        {
            try
            {
                string[] expression = { "12", "sin(", "4", ")" };

                ExpressionTree.Node expectedRoot = null;
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod8()
        {
            try
            {
                string[] expression = { "(", "(", "3", "+", "2", ")", ")" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("+");
                expectedRoot.Left = new ExpressionTree.Node("3");
                expectedRoot.Right = new ExpressionTree.Node("2");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod9()
        {
            try
            {
                string[] expression = { "cos(", "(", "90", ")", "+", "5", ")" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("+");
                expectedRoot.Left = new ExpressionTree.Node("90");
                expectedRoot.Right = new ExpressionTree.Node("5");
                expectedRoot.Functions.Enqueue("cos(");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod10()
        {
            try
            {
                string[] expression = { "8", "*", "(", "10", ")" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("*");
                expectedRoot.Left = new ExpressionTree.Node("8");
                expectedRoot.Right = new ExpressionTree.Node("10");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod11()
        {
            try
            {
                string[] expression = { "(", "180", ")" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("180");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod12()
        {
            try
            {
                string[] expression = { "8" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("8");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod13()
        {
            try
            {
                string[] expression = { "180", "/", "20" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("/");
                expectedRoot.Left = new ExpressionTree.Node("180");
                expectedRoot.Right = new ExpressionTree.Node("20");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod14()
        {
            try
            {
                string[] expression = { "60", "*", "(", "5", "+", "6", ")" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("*");
                expectedRoot.Left = new ExpressionTree.Node("60");
                expectedRoot.Right = new ExpressionTree.Node("+");
                expectedRoot.Right.Left = new ExpressionTree.Node("5");
                expectedRoot.Right.Right = new ExpressionTree.Node("6");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod15()
        {
            try
            {
                string[] expression = { "abs(", "5", "+", "-6", ")" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("+");
                expectedRoot.Left = new ExpressionTree.Node("5");
                expectedRoot.Right = new ExpressionTree.Node("-6");
                expectedRoot.Functions.Enqueue("abs(");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod16()
        {
            try
            {
                string[] expression = { "6", "+", "7", "^", "2" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("+");
                expectedRoot.Left = new ExpressionTree.Node("6");
                expectedRoot.Right = new ExpressionTree.Node("^");
                expectedRoot.Right.Left = new ExpressionTree.Node("7");
                expectedRoot.Right.Right = new ExpressionTree.Node("2");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod17()
        {
            try
            {
                string[] expression = { "6", "^", "2", "^", "3" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("^");
                expectedRoot.Left = new ExpressionTree.Node("6");
                expectedRoot.Right = new ExpressionTree.Node("^");
                expectedRoot.Right.Left = new ExpressionTree.Node("2");
                expectedRoot.Right.Right = new ExpressionTree.Node("3");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod18()
        {
            try
            {
                string[] expression = { "10", "*", "+" };

                ExpressionTree.Node expectedRoot = null;
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod19()
        {
            try
            {
                string[] expression = { "10", "*", "5", "+", "3" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("+");
                expectedRoot.Left = new ExpressionTree.Node("*");
                expectedRoot.Right = new ExpressionTree.Node("3");
                expectedRoot.Left.Left = new ExpressionTree.Node("10");
                expectedRoot.Left.Right = new ExpressionTree.Node("5");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod20()
        {
            try
            {
                string[] expression = { "(", "5", "6", ")" };

                ExpressionTree.Node expectedRoot = null;
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod21()
        {
            try
            {
                string[] expression = { "ln(", "52", ")" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("52");
                expectedRoot.Functions.Enqueue("ln(");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod22()
        {
            try
            {
                string[] expression = { "5", ")" };

                ExpressionTree.Node expectedRoot = null;
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod23()
        {
            try
            {
                string[] expression = { "(", "/", "5", ")" };

                ExpressionTree.Node expectedRoot = null;
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod24()
        {
            try
            {
                string[] expression = { "3", "+", "(", "5", "*", "9", "+", "2", ")" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("+");
                expectedRoot.Left = new ExpressionTree.Node("3");
                expectedRoot.Right = new ExpressionTree.Node("+");
                expectedRoot.Right.Right = new ExpressionTree.Node("2");
                expectedRoot.Right.Left = new ExpressionTree.Node("*");
                expectedRoot.Right.Left.Left = new ExpressionTree.Node("5");
                expectedRoot.Right.Left.Right = new ExpressionTree.Node("9");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod25()
        {
            try
            {
                // Expression : abs(3*2-10)
                string[] expression = { "abs(", "3", "*", "2", "-", "10", ")" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("-");
                expectedRoot.Left = new ExpressionTree.Node("*");
                expectedRoot.Right = new ExpressionTree.Node("10");
                expectedRoot.Left.Left = new ExpressionTree.Node("3");
                expectedRoot.Left.Right = new ExpressionTree.Node("2");
                expectedRoot.Functions.Enqueue("abs(");
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod26()
        {
            try
            {
                // Expression : (2+5
                string[] expression = { CalculatorParams.OPEN_BRACK, "2", CalculatorParams.ADD, "5" };

                ExpressionTree.Node expectedRoot = null;
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void TestMethod27()
        {
            try
            {
                // Expression : (2^+5)
                string[] expression = { CalculatorParams.OPEN_BRACK, "2", CalculatorParams.POW, CalculatorParams.ADD, "5", CalculatorParams.CLOSE_BRACK };

                ExpressionTree.Node expectedRoot = null;
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
