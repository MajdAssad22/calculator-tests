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
            expressionTree = new ExpressionTree();
            Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
            Calculator.IsDegree = true;
        }

        #region BuildTree Function Tests

        [TestMethod]
        public void BuildTreeTest1()
        {
            try
            {
                // Expression : [ ]
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
        public void BuildTreeTest2()
        {
            try
            {
                // Expression : [ % ]
                string[] expression = { CalculatorParams.PERC };

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
        public void BuildTreeTest3()
        {
            try
            {
                // Expression :[ (, 5, ), % ]
                string[] expression = { CalculatorParams.OPEN_BRACK, "5", CalculatorParams.CLOSE_BRACK, CalculatorParams.PERC };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("5");
                expectedRoot.Functions.Enqueue(CalculatorParams.PERC);
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void BuildTreeTest4()
        {
            try
            {
                // Expression : [ 15, % ]
                string[] expression = { "15", CalculatorParams.PERC };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("15");
                expectedRoot.Functions.Enqueue(CalculatorParams.PERC);
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void BuildTreeTest5()
        {
            try
            {
                // Expression : [ 12, %, % ]
                string[] expression = { "12", CalculatorParams.PERC, CalculatorParams.PERC };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("12");
                expectedRoot.Functions.Enqueue(CalculatorParams.PERC);
                expectedRoot.Functions.Enqueue(CalculatorParams.PERC);
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void BuildTreeTest6()
        {
            try
            {
                // Expression : [ 15, *, (, %, ) ]
                string[] expression = { "15", CalculatorParams.MULT, CalculatorParams.OPEN_BRACK, CalculatorParams.PERC, CalculatorParams.CLOSE_BRACK };

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
        public void BuildTreeTest7()
        {
            try
            {
                // Expression : [ 12, sin(, 4, ) ]
                string[] expression = { "12", CalculatorParams.SIN_FUNC, "4", CalculatorParams.CLOSE_BRACK };

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
        public void BuildTreeTest8()
        {
            try
            {
                // Expression : [ (, (, 3, +, 2, ), ) ]
                string[] expression = { CalculatorParams.OPEN_BRACK, CalculatorParams.OPEN_BRACK, "3", CalculatorParams.ADD, "2", CalculatorParams.CLOSE_BRACK, CalculatorParams.CLOSE_BRACK };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node(CalculatorParams.ADD);
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
        public void BuildTreeTest9()
        {
            try
            {
                // Expression : [ cos(, (, 90, ), +, 5, ) ]
                string[] expression = { CalculatorParams.COS_FUNC, CalculatorParams.OPEN_BRACK, "90", CalculatorParams.CLOSE_BRACK, CalculatorParams.ADD, "5", CalculatorParams.CLOSE_BRACK };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node(CalculatorParams.ADD);
                expectedRoot.Left = new ExpressionTree.Node("90");
                expectedRoot.Right = new ExpressionTree.Node("5");
                expectedRoot.Functions.Enqueue(CalculatorParams.COS_FUNC);
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void BuildTreeTest10()
        {
            try
            {
                // Expression : [ 8, *, (, 10, ) ]
                string[] expression = { "8", CalculatorParams.MULT, CalculatorParams.OPEN_BRACK, "10", CalculatorParams.CLOSE_BRACK };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node(CalculatorParams.MULT);
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
        public void BuildTreeTest11()
        {
            try
            {
                // Expression : [ (, 180, ) ]
                string[] expression = { CalculatorParams.OPEN_BRACK, "180", CalculatorParams.CLOSE_BRACK };

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
        public void BuildTreeTest12()
        {
            try
            {
                // Expression : [ 8 ]
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
        public void BuildTreeTest13()
        {
            try
            {
                // Expression : 180 / 20
                string[] expression = { "180", CalculatorParams.DIV, "20" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node(CalculatorParams.DIV);
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
        public void BuildTreeTest14()
        {
            try
            {
                // Expression : [ 60, *, (, 5, +, 6, ) ]
                string[] expression = { "60", CalculatorParams.MULT, CalculatorParams.OPEN_BRACK, "5", CalculatorParams.ADD, "6", CalculatorParams.CLOSE_BRACK };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node(CalculatorParams.MULT);
                expectedRoot.Left = new ExpressionTree.Node("60");
                expectedRoot.Right = new ExpressionTree.Node(CalculatorParams.ADD);
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
        public void BuildTreeTest15()
        {
            try
            {
                // Expression : [ abs(, 5, +, -6, ) ]
                string[] expression = { CalculatorParams.ABS_FUNC, "5", CalculatorParams.ADD, "-6", CalculatorParams.CLOSE_BRACK };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node(CalculatorParams.ADD);
                expectedRoot.Left = new ExpressionTree.Node("5");
                expectedRoot.Right = new ExpressionTree.Node("-6");
                expectedRoot.Functions.Enqueue(CalculatorParams.ABS_FUNC);
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void BuildTreeTest16()
        {
            try
            {
                // Expression : [ 6, +, 7, ^, 2 ]
                string[] expression = { "6", CalculatorParams.ADD, "7", CalculatorParams.POW, "2" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node(CalculatorParams.ADD);
                expectedRoot.Left = new ExpressionTree.Node("6");
                expectedRoot.Right = new ExpressionTree.Node(CalculatorParams.POW);
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
        public void BuildTreeTest17()
        {
            try
            {
                // Expression : [ 6, ^, 2, ^, 3 ]
                string[] expression = { "6", CalculatorParams.POW, "2", CalculatorParams.POW, "3" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node(CalculatorParams.POW);
                expectedRoot.Left = new ExpressionTree.Node("6");
                expectedRoot.Right = new ExpressionTree.Node(CalculatorParams.POW);
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
        public void BuildTreeTest18()
        {
            try
            {
                // Expression : [ 10, *, + ]
                string[] expression = { "10", CalculatorParams.MULT, CalculatorParams.ADD };

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
        public void BuildTreeTest19()
        {
            try
            {
                // Expression : [ 10, *, 5, +, 3 ]
                string[] expression = { "10", CalculatorParams.MULT, "5", CalculatorParams.ADD, "3" };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node(CalculatorParams.ADD);
                expectedRoot.Left = new ExpressionTree.Node(CalculatorParams.MULT);
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
        public void BuildTreeTest20()
        {
            try
            {
                // Expression : [ (, 5, 6, ) ]
                string[] expression = { CalculatorParams.OPEN_BRACK, "5", "6", CalculatorParams.CLOSE_BRACK };

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
        public void BuildTreeTest21()
        {
            try
            {
                // Expression : [ ln(, 52, ) ]
                string[] expression = { CalculatorParams.LN_FUNC, "52", CalculatorParams.CLOSE_BRACK };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node("52");
                expectedRoot.Functions.Enqueue(CalculatorParams.LN_FUNC);
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void BuildTreeTest22()
        {
            try
            {
                // Expression : [ 5, ) ]
                string[] expression = { "5", CalculatorParams.CLOSE_BRACK };

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
        public void BuildTreeTest23()
        {
            try
            {
                // Expression : [ (, /, 5, ) ]
                string[] expression = { CalculatorParams.OPEN_BRACK, CalculatorParams.DIV, "5", CalculatorParams.CLOSE_BRACK };

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
        public void BuildTreeTest24()
        {
            try
            {
                // Expression : [ 3, +, (, 5, *, 9, +, 2, ) ]
                string[] expression = { "3", CalculatorParams.ADD, CalculatorParams.OPEN_BRACK, "5", CalculatorParams.MULT, "9", CalculatorParams.ADD, "2", CalculatorParams.CLOSE_BRACK };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node(CalculatorParams.ADD);
                expectedRoot.Left = new ExpressionTree.Node("3");
                expectedRoot.Right = new ExpressionTree.Node(CalculatorParams.ADD);
                expectedRoot.Right.Right = new ExpressionTree.Node("2");
                expectedRoot.Right.Left = new ExpressionTree.Node(CalculatorParams.MULT);
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
        public void BuildTreeTest25()
        {
            try
            {
                // Expression : [ abs(, 3, *, 2, -, 10, ) ]
                string[] expression = { CalculatorParams.ABS_FUNC, "3", CalculatorParams.MULT, "2", CalculatorParams.SUB, "10", CalculatorParams.CLOSE_BRACK };

                ExpressionTree.Node expectedRoot = new ExpressionTree.Node(CalculatorParams.SUB);
                expectedRoot.Left = new ExpressionTree.Node(CalculatorParams.MULT);
                expectedRoot.Right = new ExpressionTree.Node("10");
                expectedRoot.Left.Left = new ExpressionTree.Node("3");
                expectedRoot.Left.Right = new ExpressionTree.Node("2");
                expectedRoot.Functions.Enqueue(CalculatorParams.ABS_FUNC);
                ExpressionTree.Node actualRoot = expressionTree.BuildTree(expression.ToList());

                Assert.AreEqual(expectedRoot, actualRoot);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void BuildTreeTest26()
        {
            try
            {
                // Expression : [ (, 2, +, 5 ]
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
        public void BuildTreeTest27()
        {
            try
            {
                // Expression : [ (, 2, ^, +, 5, ) ]
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

        #endregion

        #region Evaluate Function Tests

        [TestMethod]
        public void EvaluateTest1()
        {
            try
            {
                // Root : null
                ExpressionTree.Node root = null;

                double expectedResult = 0;
                double actualResult = expressionTree.Evaluate(root);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void EvaluateTest2()
        {
            try
            {
                // Root :   5
                ExpressionTree.Node root = new ExpressionTree.Node("5");

                double expectedResult = 5;
                double actualResult = expressionTree.Evaluate(root);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void EvaluateTest3()
        {
            try
            {
                // Root :    ^
                //            \
                //             3

                ExpressionTree.Node root = new ExpressionTree.Node(CalculatorParams.POW);
                root.Right = new ExpressionTree.Node("3");

                double expectedResult = 0;
                double actualResult = expressionTree.Evaluate(root);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void EvaluateTest4()
        {
            try
            {
                // Root :       ^
                //            /   \
                //           3     2

                ExpressionTree.Node root = new ExpressionTree.Node(CalculatorParams.POW);
                root.Left = new ExpressionTree.Node("3");
                root.Right = new ExpressionTree.Node("2");

                double expectedResult = 9;
                double actualResult = expressionTree.Evaluate(root);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void EvaluateTest5()
        {
            try
            {
                // Root :       *
                //            /   \
                //          -9     5

                ExpressionTree.Node root = new ExpressionTree.Node(CalculatorParams.MULT);
                root.Left = new ExpressionTree.Node("-9");
                root.Right = new ExpressionTree.Node("5");

                double expectedResult = -45;
                double actualResult = expressionTree.Evaluate(root);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void EvaluateTest6()
        {
            try
            {
                // Root :       /
                //            /   \
                //           6     2

                ExpressionTree.Node root = new ExpressionTree.Node(CalculatorParams.DIV);
                root.Left = new ExpressionTree.Node("6");
                root.Right = new ExpressionTree.Node("2");

                double expectedResult = 3;
                double actualResult = expressionTree.Evaluate(root);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void EvaluateTest7()
        {
            try
            {
                // Root :       +
                //             /
                //            8

                ExpressionTree.Node root = new ExpressionTree.Node(CalculatorParams.ADD);
                root.Left = new ExpressionTree.Node("8");

                double expectedResult = 8;
                double actualResult = expressionTree.Evaluate(root);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void EvaluateTest8()
        {
            try
            {
                // Root :       -
                //            "abs("    
                //           /      \
                //          5        9

                ExpressionTree.Node root = new ExpressionTree.Node(CalculatorParams.SUB);
                root.Left = new ExpressionTree.Node("5");
                root.Right = new ExpressionTree.Node("9");
                root.Functions.Enqueue(CalculatorParams.ABS_FUNC);

                double expectedResult = 4;
                double actualResult = expressionTree.Evaluate(root);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EvaluateTest9()
        {
            // Root :      Test
            //            /    \
            //           6      1

            ExpressionTree.Node root = new ExpressionTree.Node("Test");
            root.Left = new ExpressionTree.Node("6");
            root.Right = new ExpressionTree.Node("1");

            expressionTree.Evaluate(root);

            // Expecting Exception of type ArgumentException
        }

        #endregion

        #region Constructor Tests

        [TestMethod]
        public void ConstuctorTest1()
        {
            try
            {
                // Expression : ( 2 + 5
                string expression = $"{CalculatorParams.OPEN_BRACK} 2 {CalculatorParams.ADD} 5";

                string expectedResult = CalculatorParams.INVALID_INPUT;
                string expectedExpression = expression;
                ExpressionTree tree = new ExpressionTree(expression);
                string actualExpression = tree.Expression;
                string actualResult = tree.Result;

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void ConstuctorTest2()
        {
            try
            {
                // Expression : ( 3 - 7 )
                string expression = $"{CalculatorParams.OPEN_BRACK} 3 {CalculatorParams.SUB} 7 {CalculatorParams.CLOSE_BRACK}";

                string expectedResult = "-4";
                string expectedExpression = expression;
                ExpressionTree tree = new ExpressionTree(expression);
                string actualExpression = tree.Expression;
                string actualResult = tree.Result;

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        #endregion

        #region AddBranch Funciton Tests

        [TestMethod]
        public void AddBranchTest1()
        {
            try
            {
                //                ↓ ↑       ↓ ↑ 
                // stC , stN :  |  ^  | , |  2  |
                //                        |  5  |
                //                  

                Stack<string> stC = new Stack<string>();
                Stack<ExpressionTree.Node> stN = new Stack<ExpressionTree.Node>();
                stC.Push(CalculatorParams.POW);
                stN.Push(new ExpressionTree.Node("5"));
                stN.Push(new ExpressionTree.Node("2"));

                ExpressionTree.Node expectedBranch = new ExpressionTree.Node(CalculatorParams.POW);
                expectedBranch.Left = new ExpressionTree.Node("5");
                expectedBranch.Right = new ExpressionTree.Node("2");

                expressionTree.AddBranchTest(stC,stN);

                Assert.AreEqual(0, stC.Count);
                Assert.AreEqual(stN.Peek(), expectedBranch);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        #endregion

        #region ExecuteFunctions Funciton Tests

        [TestMethod]
        public void ExecuteFunctionsTest1()
        {
            try
            {
                // Queue , Number : Empty Queue , 5
                Queue<string> functions = new Queue<string>();
                double number = 5;

                double expectedResult = 5;
                double actualResult = expressionTree.ExecuteFunctionsTest(functions, number);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        public void ExecuteFunctionsTest2()
        {
            try
            {
                //                     	↓
                // Queue , Number : |   ln( | , -e
                //                  |  abs( |
                //                      ↓

                Queue<string> functions = new Queue<string>();
                functions.Enqueue(CalculatorParams.ABS_FUNC);
                functions.Enqueue(CalculatorParams.LN_FUNC);
                double number = -Math.E;

                double expectedResult = 1;
                double actualResult = expressionTree.ExecuteFunctionsTest(functions, number);

                Assert.AreEqual(expectedResult, actualResult);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        #endregion
    }
}
