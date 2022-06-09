using CalculatorControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorControl
{
    public class ExpressionTree
    {
        public class Node
        {
            public string Data { get; set; }
            public Queue<string> Functions { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node(string data)
            {
                this.Data = data;
                Left = Right = null;
                Functions = new Queue<string>();
            }
#if IN_TEST
            public override bool Equals(object obj)
            {
                if (obj.GetType() == this.GetType())
                {
                    Node providedNode = (Node)obj;
                    if (providedNode.Data == this.Data && 
                        providedNode.Functions.SequenceEqual(this.Functions))
                    {
                        if (providedNode.Left == null && 
                            this.Left == null &&
                            providedNode.Right == null && 
                            this.Right ==null)
                        {
                            //If its a leaf node and the data and the functions are the same
                            return true;
                        }
                        if (providedNode.Left.Equals(this.Left) && 
                            providedNode.Right.Equals(this.Right))
                        {
                            //If its not a leaf node but the data and the functions are the same
                            return true;
                        }
                    }
                }
                return false;
            }
#endif
        }

        public string Expression { get; private set; }
        public string Result { get; private set; }

#if IN_TEST
        public ExpressionTree()
        {
            Expression = "";
            Result = "";
        }
#endif

        public ExpressionTree(string expression)
        {
            this.Expression = expression;
            var root = BuildTree(expression.Split(' ').ToList());
            if (root != null)
            {
                Result = Evaluate(root).ToString();
            }
        }

        public Node BuildTree(List<string> expression)
        {
            // Stack to hold nodes
            Stack<Node> stN = new Stack<Node>();
            // Stack to hold the operands and functions
            Stack<string> stC = new Stack<string>();
            List<string> formatedExp = new List<string>();
            formatedExp.Add("(");
            formatedExp.AddRange(expression);
            formatedExp.Add(")");
            expression = formatedExp;
            for (int i = 0; i < expression.Count; i++)
            {
                double number = 0;
                var currentItem = expression[i];
                string prevItem = "";
                if (i != 0)
                {
                    prevItem = expression[i - 1];
                }

                //In case of a percentage function
                if (currentItem.Equals(CalculatorParams.PERC))
                {
                    if (stN.Count != 0 && (prevItem.Equals(CalculatorParams.CLOSE_BRACK) ||
                                           CalculatorLogic.TryConvertToNumber(prevItem, ref number) ||
                                           prevItem.Equals(CalculatorParams.PERC)))
                    {
                        //If the previous item is a "closed bracket" or a "number" or "%"
                        stN.Peek().Functions.Enqueue(currentItem);
                    }
                    else
                    {
                        Result = CalculatorParams.INVALID_INPUT;
                        return null;
                    }
                }
                //In case of an open bracket or a function that isn't '%'
                else if (currentItem.Equals(CalculatorParams.OPEN_BRACK) || CalculatorLogic.IsFunction(currentItem))
                {
                    if ((stC.Count != 0 && (prevItem.Equals(CalculatorParams.OPEN_BRACK) ||
                                            CalculatorLogic.IsFunction(prevItem) ||
                                            CalculatorLogic.GetPriority(prevItem) > 0)) || i == 0)
                    {
                        stC.Push(currentItem);
                    }
                    else
                    {
                        Result = CalculatorParams.INVALID_INPUT;
                        return null;
                    }
                }
                // In case of a number
                else if (CalculatorLogic.TryConvertToNumber(currentItem, ref number))
                {
                    stN.Push(new Node(currentItem));
                }
                // In case of an operator
                else if (CalculatorLogic.GetPriority(currentItem) > 0)
                {
                    // If an operator with lower or
                    // same associativity appears
                    while (stC.Count != 0
                           && stC.Peek() != CalculatorParams.OPEN_BRACK
                           && !CalculatorLogic.IsFunction(stC.Peek())
                           && ((currentItem != CalculatorParams.POW && CalculatorLogic.GetPriority(stC.Peek()) >= CalculatorLogic.GetPriority(currentItem))
                               || (currentItem == CalculatorParams.POW && CalculatorLogic.GetPriority(stC.Peek()) > CalculatorLogic.GetPriority(currentItem))))
                    {
                        if (stN.Count < 2)
                        {
                            Result = CalculatorParams.INVALID_INPUT;
                            return null;
                        }

                        AddBranch(stC, stN);
                    }

                    // Push the item to string stack
                    stC.Push(currentItem);
                }
                // In case of a closed bracket
                else if (currentItem.Equals(CalculatorParams.CLOSE_BRACK))
                {
                    if (stC.Count == 0)
                    {
                        Result = CalculatorParams.INVALID_INPUT;
                        return null;
                    }

                    // In case of no operations in a function
                    if (CalculatorLogic.IsFunction(stC.Peek()))
                    {
                        var node = stN.Peek();
                        node.Functions.Enqueue(stC.Peek());
                        stC.Pop();
                        continue;
                    }

                    while (stC.Count != 0
                           && stC.Peek() != CalculatorParams.OPEN_BRACK)
                    {
                        if (stN.Count < 2)
                        {
                            Result = CalculatorParams.INVALID_INPUT;
                            return null;
                        }

                        AddBranch(stC, stN);
                        // If reached a function don't continue (the bracket is for the function)
                        if (CalculatorLogic.IsFunction(stC.Peek()))
                        {
                            stN.Peek().Functions.Enqueue(stC.Peek());
                            break;
                        }
                    }

                    // Remove open bracket or function
                    stC.Pop();
                }
            }

            if (stC.Count != 0 || stN.Count != 1)
            {
                Result = CalculatorParams.INVALID_INPUT;
                return null;
            }

            return stN.Peek();
        }

        public double Evaluate(Node root)
        {
            // Empty tree
            if (root == null)
                return 0;

            // Leaf node i.e, a number or math const
            if (root.Left == null && root.Right == null)
            {
                double number = 0;
                CalculatorLogic.TryConvertToNumber(root.Data, ref number);
                return ExecuteFunctions(root.Functions, number);
            }

            // Evaluate left subtree
            double leftEval = Evaluate(root.Left);

            // Evaluate right subtree
            double rightEval = Evaluate(root.Right);

            // Check which operator to apply
            if (root.Data.Equals(CalculatorParams.POW))
            {
                var number = Math.Pow(leftEval, rightEval);
                return ExecuteFunctions(root.Functions, number);
            }
            if (root.Data.Equals(CalculatorParams.MULT))
            {
                var number = leftEval * rightEval;
                return ExecuteFunctions(root.Functions, number);
            }
            if (root.Data.Equals(CalculatorParams.DIV))
            {
                var number = leftEval / rightEval;
                return ExecuteFunctions(root.Functions, number);
            }
            if (root.Data.Equals(CalculatorParams.ADD))
            {
                var number = leftEval + rightEval;
                return ExecuteFunctions(root.Functions, number);
            }
            if (root.Data.Equals(CalculatorParams.SUB))
            {
                var number = leftEval - rightEval;
                return ExecuteFunctions(root.Functions, number);
            }
            else
                throw new ArgumentException();
        }

        public override string ToString()
        {
            return $"{Expression}";
        }

        private void AddBranch(Stack<string> stC, Stack<Node> stN)
        {
            var root = new Node(stC.Peek());
            stC.Pop();
            var t1 = stN.Peek();
            stN.Pop();
            var t2 = stN.Peek();
            stN.Pop();
            root.Left = t2;
            root.Right = t1;
            stN.Push(root);
        }

        private double ExecuteFunctions(Queue<string> functions, double number)
        {
            while(functions.Count != 0)
            {
                number = CalculatorLogic.CalculateFunction(functions.Dequeue(), number);
            }
            return number;
        }

#if IN_TEST
        public double ExecuteFunctionsTest(Queue<string> functions, double number)
        {
            return ExecuteFunctions(functions, number);
        }

        public void AddBranchTest(Stack<string> stC, Stack<Node> stN)
        {
            AddBranch(stC, stN);
        }
#endif
    }
}
