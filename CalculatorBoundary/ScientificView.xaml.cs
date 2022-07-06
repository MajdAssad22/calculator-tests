using CalculatorControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorTestProject
{
    /// <summary>
    /// Interaction logic for ScientificView.xaml
    /// </summary>
    public partial class ScientificView : UserControl
    {
        public DisplayLogic DisplayLogic { get; set; } = new DisplayLogic();
        public ScientificView()
        {
            InitializeComponent();
            InitializeItems();
            this.DataContext = this;
        }
        //Extra Functions
        private void InitializeItems()
        {
            HistoryLv.ItemsSource = Calculator.History;
            //Operation Buttons Initialization
            PercBtn.Content = CalculatorParams.PERC;
            OpenBrackBtn.Content = CalculatorParams.OPEN_BRACK;
            CloseBrackBtn.Content = CalculatorParams.CLOSE_BRACK;
            MulBtn.Content = CalculatorParams.MULT;
            DivBtn.Content = CalculatorParams.DIV;
            AddBtn.Content = CalculatorParams.ADD;
            SubBtn.Content = CalculatorParams.SUB;

            //Function Buttons Initialization
            SqrtBtn.Tag = CalculatorParams.SQRT_FUNC;
            SquaredBtn.Tag = $"{CalculatorParams.POW} 2";
            Powered10Btn.Tag = $"10 {CalculatorParams.POW}";
            PowerBtn.Tag = CalculatorParams.POW;
            LnBtn.Tag = CalculatorParams.LN_FUNC;
            LogBtn.Tag = CalculatorParams.LOG_FUNC;
            AbsBtn.Tag = CalculatorParams.ABS_FUNC;
            Div1Btn.Tag = $"1 {CalculatorParams.DIV} {CalculatorParams.OPEN_BRACK}";
            SinBtn.Tag = CalculatorParams.SIN_FUNC;
            CosBtn.Tag = CalculatorParams.COS_FUNC;
            TanBtn.Tag = CalculatorParams.TAN_FUNC;

            //Math Const Initialization
            PIBtn.Content = CalculatorParams.PI;
            EBtn.Content = CalculatorParams.E;

            //Radian Degree Initialization
            RadDegBtn.Content = DisplayLogic.RadDegToggle();
        }

        //Events
        private void HistoryLv_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTree = (ExpressionTree)((ListView)sender).SelectedItem;
            if (DisplayLogic.SelectHistory(selectedTree))
            {
                e.Handled = true;
            }
        }
        private void CBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.CurrentExpression = "";
        }
        private void CEBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.ResetDisplay();
        }
        private void EqualBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.Calculate();
        }
        private void OperationBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.ConcatinateOperation(((Button)sender).Content.ToString());
        }
        private void FunctionBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.ConcatinateOperation(((Button)sender).Tag.ToString());
        }
        private void NumBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.ConcatinateNumber(((Button)sender).Content.ToString());
        }
        private void ClearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.ClearHistory();
        }
        private void DeleteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.RemoveLast();
        }
        private void RadDegBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = DisplayLogic.RadDegToggle();
        }
    }
}
