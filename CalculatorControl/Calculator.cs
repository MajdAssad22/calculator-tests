using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorControl
{
    public static class Calculator
    {
        public static ObservableCollection<ExpressionTree> History = new ObservableCollection<ExpressionTree>();
        public static bool IsDegree { get; set; }
        public static CalculatorParams.Bases Base { get; set; } = CalculatorParams.Bases.Dec;
        public static CalculatorParams.CalculatorModes Mode { get; set; } = CalculatorParams.CalculatorModes.Basic;
        
        public static string Calculate(string expression)
        {
            ExpressionTree tree = new ExpressionTree(expression);
            History.Add(tree);
            return Format(tree);
        }
        public static string Format(ExpressionTree tree)
        {
            if(Mode == CalculatorParams.CalculatorModes.Programmer)
            {
                return CalculatorLogic.ChangeBase(tree.Result, Base);
            }
            return tree.Result;
        }
    }
}
