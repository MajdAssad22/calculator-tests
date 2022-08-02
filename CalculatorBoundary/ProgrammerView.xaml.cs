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
    /// Interaction logic for ProgrammerView.xaml
    /// </summary>
    public partial class ProgrammerView : UserControl
    {
        public DisplayLogic DisplayLogic { get; set; } = new DisplayLogic();
        public ProgrammerView()
        {
            InitializeComponent();
            InitializeItems();
            this.DataContext = this;
            DisplayLogic.ChangeBase(CalculatorParams.Bases.Dec);
            DisableUnwantedButtons(CalculatorParams.Bases.Dec);
        }
        //Extra Functions
        private void InitializeItems()
        {
            HistoryLv.ItemsSource = Calculator.History;
            //Operation Buttons Initialization
            OpenBrackBtn.Content = CalculatorParams.OPEN_BRACK;
            CloseBrackBtn.Content = CalculatorParams.CLOSE_BRACK;
            MulBtn.Content = CalculatorParams.MULT;
            DivBtn.Content = CalculatorParams.DIV;
            AddBtn.Content = CalculatorParams.ADD;
            SubBtn.Content = CalculatorParams.SUB;
            BinBtn.Tag = CalculatorParams.Bases.Bin;
            OctBtn.Tag = CalculatorParams.Bases.Oct;
            DecBtn.Tag = CalculatorParams.Bases.Dec;
            HexBtn.Tag = CalculatorParams.Bases.Hex;
        }
        private void DisableUnwantedButtons(CalculatorParams.Bases newBase)
        {
            switch (newBase)
            {
                case CalculatorParams.Bases.Bin:
                    Num2Btn.IsEnabled = false;
                    Num3Btn.IsEnabled = false;
                    Num4Btn.IsEnabled = false;
                    Num5Btn.IsEnabled = false;
                    Num6Btn.IsEnabled = false;
                    Num7Btn.IsEnabled = false;
                    Num8Btn.IsEnabled = false;
                    Num9Btn.IsEnabled = false;
                    NumABtn.IsEnabled = false;
                    NumBBtn.IsEnabled = false;
                    NumCBtn.IsEnabled = false;
                    NumDBtn.IsEnabled = false;
                    NumEBtn.IsEnabled = false;
                    NumFBtn.IsEnabled = false;
                    break;
                case CalculatorParams.Bases.Oct:
                    Num2Btn.IsEnabled = true;
                    Num3Btn.IsEnabled = true;
                    Num4Btn.IsEnabled = true;
                    Num5Btn.IsEnabled = true;
                    Num6Btn.IsEnabled = true;
                    Num7Btn.IsEnabled = true;
                    Num8Btn.IsEnabled = false;
                    Num9Btn.IsEnabled = false;
                    NumABtn.IsEnabled = false;
                    NumBBtn.IsEnabled = false;
                    NumCBtn.IsEnabled = false;
                    NumDBtn.IsEnabled = false;
                    NumEBtn.IsEnabled = false;
                    NumFBtn.IsEnabled = false;
                    break;
                case CalculatorParams.Bases.Dec:
                    Num2Btn.IsEnabled = true;
                    Num3Btn.IsEnabled = true;
                    Num4Btn.IsEnabled = true;
                    Num5Btn.IsEnabled = true;
                    Num6Btn.IsEnabled = true;
                    Num7Btn.IsEnabled = true;
                    Num8Btn.IsEnabled = true;
                    Num9Btn.IsEnabled = true;
                    NumABtn.IsEnabled = false;
                    NumBBtn.IsEnabled = false;
                    NumCBtn.IsEnabled = false;
                    NumDBtn.IsEnabled = false;
                    NumEBtn.IsEnabled = false;
                    NumFBtn.IsEnabled = false;
                    break;
                case CalculatorParams.Bases.Hex:
                    Num2Btn.IsEnabled = true;
                    Num3Btn.IsEnabled = true;
                    Num4Btn.IsEnabled = true;
                    Num5Btn.IsEnabled = true;
                    Num6Btn.IsEnabled = true;
                    Num7Btn.IsEnabled = true;
                    Num8Btn.IsEnabled = true;
                    Num9Btn.IsEnabled = true;
                    NumABtn.IsEnabled = true;
                    NumBBtn.IsEnabled = true;
                    NumCBtn.IsEnabled = true;
                    NumDBtn.IsEnabled = true;
                    NumEBtn.IsEnabled = true;
                    NumFBtn.IsEnabled = true;
                    break;
                default:
                    break;
            }
        }

        //Events
        public void HistoryLv_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTree = (ExpressionTree)((ListView)sender).SelectedItem;
            if (DisplayLogic.SelectHistory(selectedTree))
            {
                e.Handled = true;
            }
        }
        public void CBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.CurrentExpression = "";
        }
        public void CEBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.ResetDisplay();
        }
        public void EqualBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.Calculate();
        }
        public void OperationBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.ConcatinateOperation(((Button)sender).Content.ToString());
        }
        public void NumBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.ConcatinateNumber(((Button)sender).Content.ToString());
        }
        public void ClearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.ClearHistory();
        }
        public void DeleteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayLogic.RemoveLast();
        }
        public void ChangeBaseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var wantedBase = (CalculatorParams.Bases)((Button)sender).Tag;
            DisplayLogic.ChangeBase(wantedBase);
            DisableUnwantedButtons(wantedBase);
        }

        #if IN_TEST
        public void UpdateGui()
        {
            this.ExpressionTb.DataContext = null;
            this.ExpressionTb.DataContext = DisplayLogic;
            this.ResultTb.DataContext = null;
            this.ResultTb.DataContext = DisplayLogic;
        }
        #endif
    }
}
