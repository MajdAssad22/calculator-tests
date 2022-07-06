using CalculatorControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for BasicView.xaml
    /// </summary>
    public partial class BasicView : UserControl
    {
        public DisplayLogic DisplayLogic { get; set; } = new DisplayLogic(); 

        public BasicView()
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
    }
}
