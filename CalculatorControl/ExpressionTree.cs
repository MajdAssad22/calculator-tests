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
            public string data;
            public Queue<string> functions;
            public Node left;
            public Node right;
            public Node(string data)
            {
                this.data = data;
                left = right = null;
                functions = new Queue<string>();
            }
        }

        public string Expression { get; private set; }
        public string Result { get; private set; }

        public ExpressionTree(string expression)
        {
            this.Expression = expression;
            var root = BuildTree(expression.Split(' '));
            if (root != null)
            {
                Result = Evaluate(root).ToString();
            }
        }

        public Node BuildTree(string[] expression)
        {
            // Stack to hold nodes
            Stack<Node> stN = new Stack<Node>();
            // Stack to hold the operands and functions
            Stack<string> stC = new Stack<string>();

            foreach (var item in expression)
            {
                double number = 0;
                //In case of a percentage function
                if (item.Equals(CalculatorParams.PERC))
                {
                    stN.Peek().functions.Enqueue(item);
                    continue;
                }
                //In case of an open bracket or a function that isn't '%'
                else if (item.Equals(CalculatorParams.OPEN_BRACK) || CalculatorLogic.IsFunction(item))
                {
                    stC.Push(item);
                }
                // In case of a number
                else if (CalculatorLogic.TryConvertToNumber(item, ref number))
                {
                    stN.Push(new Node(item));
                }
                // In case of an operator
                else if (CalculatorLogic.GetPriority(item) > 0)
                {
                    // If an operator with lower or
                    // same associativity appears
                    while (stC.Count != 0
                        && stC.Peek() != CalculatorParams.OPEN_BRACK
                        && !CalculatorLogic.IsFunction(stC.Peek())
                        && ((item != CalculatorParams.POW && CalculatorLogic.GetPriority(stC.Peek()) >= CalculatorLogic.GetPriority(item))
                            || (item == CalculatorParams.POW && CalculatorLogic.GetPriority(stC.Peek()) > CalculatorLogic.GetPriority(item))))
                    {
                        if (stN.Count < 2)
                        {
                            Result = CalculatorParams.INVALID_INPUT;
                            return null;
                        }
                        AddBranch(stC, stN);
                    }
                    // Push the item to string stack
                    stC.Push(item);
                }
                // In case of a closed bracket
                else if (item.Equals(CalculatorParams.CLOSE_BRACK))
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
                        node.functions.Enqueue(stC.Peek());
                        stC.Pop();
                        continue;
                    }
                    while (stC.Count != 0
                        && stC.Peek() != CalculatorParams.OPEN_BRACK)
                    {
                        if(stN.Count < 2)
                        {
                            Result = CalculatorParams.INVALID_INPUT;
                            return null;
                        }
                        AddBranch(stC, stN);
                        // If reached a function don't continue (the bracket is for the function)
                        if (CalculatorLogic.IsFunction(stC.Peek()))
                        {
                            stN.Peek().functions.Enqueue(stC.Peek());
                            break;
                        }
                    }
                    // Remove open bracket or function
                    stC.Pop();
                }
            }
            while (stC.Count != 0)
            {
                if (stN.Count < 2)
                {
                    Result = CalculatorParams.INVALID_INPUT;
                    return null;
                }
                AddBranch(stC, stN);
            }
            return stN.Peek();
        }

        public double Evaluate(Node root)
        {
            // Empty tree
            if (root == null)
                return 0;

            // Leaf node i.e, a number or math const
            if (root.left == null && root.right == null)
            {
                double number = 0;
                CalculatorLogic.TryConvertToNumber(root.data, ref number);
                return ExecuteFunctions(root.functions, number);
            }

            // Evaluate left subtree
            double leftEval = Evaluate(root.left);

            // Evaluate right subtree
            double rightEval = Evaluate(root.right);

            // Check which operator to apply
            if (root.data.Equals(CalculatorParams.POW))
            {
                var number = Math.Pow(leftEval, rightEval);
                return ExecuteFunctions(root.functions, number);
            }
            if (root.data.Equals(CalculatorParams.MULT))
            {
                var number = leftEval * rightEval;
                return ExecuteFunctions(root.functions, number);
            }
            if (root.data.Equals(CalculatorParams.DIV))
            {
                var number = leftEval / rightEval;
                return ExecuteFunctions(root.functions, number);
            }
            if (root.data.Equals(CalculatorParams.ADD))
            {
                var number = leftEval + rightEval;
                return ExecuteFunctions(root.functions, number);
            }
            if (root.data.Equals(CalculatorParams.SUB))
            {
                var number = leftEval - rightEval;
                return ExecuteFunctions(root.functions, number);
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
            root.left = t2;
            root.right = t1;
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
    }
}
