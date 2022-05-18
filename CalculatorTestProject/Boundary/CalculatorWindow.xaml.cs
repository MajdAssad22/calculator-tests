using CalculatorProject.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CalculatorProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {
        public CalculatorWindow()
        {
            InitializeComponent();
            history_lv.ItemsSource = Calculator.History;

            //Basic Mode
            result_lbl.Content = Calculator.Calculate("3 + 9");
            result_lbl.Content = Calculator.Calculate("3 - 9");
            result_lbl.Content = Calculator.Calculate("3 * 9");
            result_lbl.Content = Calculator.Calculate("3 / 9");
            result_lbl.Content = Calculator.Calculate("( 3 - 18 ) / 5");
            result_lbl.Content = Calculator.Calculate("50 %");
            result_lbl.Content = Calculator.Calculate("( 50 - 25 ) % - 6 * 100");

            //Programer Mode

            //Scientific Mode
            result_lbl.Content = Calculator.Calculate("1 / ( 2 * π )");
            result_lbl.Content = Calculator.Calculate("1 / abs( 2 - 5 )");
            result_lbl.Content = Calculator.Calculate("abs( 2 - 10 )");
            result_lbl.Content = Calculator.Calculate("abs( sin( 10 ) - 5 )");
            result_lbl.Content = Calculator.Calculate("abs( sin( 50 ) - 9 )");
            result_lbl.Content = Calculator.Calculate("abs( 10 - -9 )");
            result_lbl.Content = Calculator.Calculate("sin( 50 )");
            result_lbl.Content = Calculator.Calculate("ln( 8 * e )");
            result_lbl.Content = Calculator.Calculate("log( 30 )");
            result_lbl.Content = Calculator.Calculate("10 ^ ( 5 + 2 )");
            result_lbl.Content = Calculator.Calculate("( 15 + 9 ) ^ ( 5 + 2 )");
            result_lbl.Content = Calculator.Calculate("sqrt( 16 ) ^ ( 5 + 2 )");
            result_lbl.Content = Calculator.Calculate("sqrt( 15 + 9 ) ^ ( 2 )");
            result_lbl.Content = Calculator.Calculate("sqrt( -5 )");
            result_lbl.Content = Calculator.Calculate("( 18 + 2 ) ^ 2");
            result_lbl.Content = Calculator.Calculate("sin( 5 * π )");
            result_lbl.Content = Calculator.Calculate("cos( sin( 9 + 1.5 ) )");
            result_lbl.Content = Calculator.Calculate("tan( 100 )");
            result_lbl.Content = Calculator.Calculate("π");
            result_lbl.Content = Calculator.Calculate("e");

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rand = new Random(); 
            result_lbl.Content = Calculator.Calculate($"10 - ( 150 / 100 ) ^ 8 * {rand.Next(10)}");
        }

        private void history_lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTree = (ExpressionTree)((ListView)sender).SelectedItem;
            result_lbl.Content = selectedTree.Result;
        }
    }
}
