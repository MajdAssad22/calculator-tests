using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorControl
{
    public class Calculator
    {
        public static ObservableCollection<ExpressionTree> History = new ObservableCollection<ExpressionTree>();
        public static bool IsDegree { get; set; }
        public static CalculatorParams.Bases Base = CalculatorParams.Bases.Dec;
        public static CalculatorParams.CalculatorModes Mode = CalculatorParams.CalculatorModes.Basic;
        
        public static string Calculate(string expression)
        {
            ExpressionTree tree = new ExpressionTree(expression);
            History.Add(tree);
            return tree.Result;
        }
    }
}
