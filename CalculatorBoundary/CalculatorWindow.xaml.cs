using CalculatorControl;
using CalculatorTestProject;
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

namespace CalculatorBoundary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {
        public BasicView basicView = new BasicView();
        public ProgrammerView programmerView = new ProgrammerView();
        public ScientificView scientificView = new ScientificView();

        public CalculatorWindow()
        {
            InitializeComponent();
            InitializeItems();
        }

        private void InitializeItems()
        {
            BasicTab.Content = basicView;
            ProgrammerTab.Content = programmerView;
            ScientificTab.Content = scientificView;
        }

        public void TabSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Calculator.History.Clear();
            switch (((TabControl)sender).SelectedIndex)
            {
                case 0:
                    Calculator.Mode = CalculatorParams.CalculatorModes.Basic;
                    basicView.DisplayLogic.ResetDisplay();
                    break;
                case 1:
                    Calculator.Mode = CalculatorParams.CalculatorModes.Programmer;
                    programmerView.DisplayLogic.ResetDisplay();
                    break;
                case 2:
                    Calculator.Mode = CalculatorParams.CalculatorModes.Scientific;
                    scientificView.DisplayLogic.ResetDisplay();
                    break;
            }
        }
    }
}
