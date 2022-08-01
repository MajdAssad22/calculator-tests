using CalculatorControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CalculatorTestProject
{
    public class DisplayLogic: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _currentExpression = "";
        private string _currentResult = "";
        private int _expressionMaxLength = 100;
        private int _resultMaxLength = 25;

        public string CurrentExpression
        {
            get { return _currentExpression; }
            set
            {
                if (string.Equals(value, _currentExpression) || value.Replace(" ","").Length > _expressionMaxLength)
                    return;
                _currentExpression = value;
                OnPropertyChanged("CurrentExpression");
            }
        }
        public string CurrentResult
        {
            get { return _currentResult; }
            set
            {
                if (string.Equals(value, _currentResult))
                    return;
                if (value.Length > _resultMaxLength) {
                    _currentResult = value.Substring(0, _resultMaxLength);
                    OnPropertyChanged("CurrentResult");
                    return;
                }
                _currentResult = value;
                OnPropertyChanged("CurrentResult");

            }
        }
        public DisplayLogic()
        {
            CurrentExpression = "";
            CurrentResult = "";
        }

        public void ResetDisplay()
        {
            CurrentExpression = "";
            CurrentResult = "";
        }
        private bool IsLastOperation()
        {
            return CurrentExpression.TrimEnd().EndsWith(CalculatorParams.SUB) ||
                CurrentExpression.TrimEnd().EndsWith(CalculatorParams.ADD) ||
                CurrentExpression.TrimEnd().EndsWith(CalculatorParams.DIV) ||
                CurrentExpression.TrimEnd().EndsWith(CalculatorParams.MULT) ||
                CurrentExpression.TrimEnd().EndsWith(CalculatorParams.POW);
        }
        public bool SelectHistory(ExpressionTree tree)
        {
            if (tree != null)
            {
                CurrentExpression = tree.Expression;
                CurrentResult = Calculator.Format(tree);
                return true;
            }
            else
            {
                ResetDisplay();
                return false;
            }
        }
        public void ConcatinateOperation(string operation)
        {
            string finalExp;
            bool isResultHandled = false;
            //Check if there is a result
            if (CurrentResult == String.Empty)
            {
                //If there is no result
                finalExp = $"{CurrentExpression.TrimEnd()}";
            }
            else if (CurrentResult == CalculatorParams.INVALID_INPUT)
            {
                //If there is an invalid input result
                finalExp = "";
                CurrentResult = "";
            }
            else
            {
                if (CalculatorLogic.IsFunction(operation) ||
                    operation == $"1 {CalculatorParams.DIV} {CalculatorParams.OPEN_BRACK}" ||
                    operation == $"10 {CalculatorParams.POW}")
                {
                    //If the given operation is a function or 1/( or 10^
                    finalExp = $"{operation} {CurrentResult}";
                    CurrentResult = "";
                    isResultHandled = true;
                }
                else
                {
                    finalExp = $"{CurrentResult}";
                    CurrentResult = "";
                }
            }
            if (!isResultHandled)
            {
                if ((operation == CalculatorParams.SUB) &&
                    (IsLastOperation() ||
                     CurrentExpression.TrimEnd().EndsWith(CalculatorParams.OPEN_BRACK)||
                     string.IsNullOrWhiteSpace(CurrentExpression)))
                {
                    //If input is '-' and last input is operation or open bracket.
                    finalExp += $" {operation}";
                }
                else
                {
                    finalExp += $" {operation} ";
                }
            }
            CurrentExpression = finalExp;
        }
        public void ConcatinateNumber(string number)
        {
            if (!string.IsNullOrWhiteSpace(CurrentResult))
            {
                ResetDisplay();
            }
            CurrentExpression = $"{CurrentExpression}{number}";
        }
        public void ClearHistory()
        {
            Calculator.History.Clear();
        }
        public void RemoveLast()
        {
            if (!string.IsNullOrWhiteSpace(CurrentResult))
            {
                CurrentResult = "";
            }
            var trimmedExp = CurrentExpression.TrimEnd();
            if (!String.IsNullOrEmpty(trimmedExp))
            {
                var splitedExpression = trimmedExp.Split(' ');
                var lastItem = splitedExpression[splitedExpression.Length - 1];

                if (CalculatorLogic.IsFunction(lastItem))
                {
                    CurrentExpression = trimmedExp.Remove(trimmedExp.Length - lastItem.Length, lastItem.Length);
                }
                else
                {
                    CurrentExpression = trimmedExp.Remove(trimmedExp.Length - 1, 1);
                }
            }
        }
        public void Calculate()
        {
            if (!String.IsNullOrWhiteSpace(CurrentExpression))
            {
                CurrentResult = Calculator.Calculate(CurrentExpression.Trim());
            }
        }
        public void ChangeBase(CalculatorParams.Bases wantedBase)
        {
            Calculator.Base = wantedBase;
            if (!string.IsNullOrEmpty(CurrentResult))
            {
                CurrentResult = Calculator.Format(Calculator.History[Calculator.History.Count - 1]);
            }
        }
        public string RadDegToggle()
        {
            Calculator.IsDegree = !Calculator.IsDegree;
            if (Calculator.IsDegree)
            {
                return "Degree";
            }
            else
            {
                return "Radian";
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
