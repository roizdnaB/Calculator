using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Calculator.Classes;
using System.Globalization;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private string result = "";
        private string operation = "";
        private bool isDot = false;
        private bool isFirstOperation = true;
        private bool isResult = false;
        private bool isLimitOfChar = false;

        public MainWindow()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
        }

        private void ClickClear(object sender, RoutedEventArgs e)
        {
            txbResult.Text = "0";
            isDot = false;
            isLimitOfChar = false;
            if (txbPrevious.Text == "")
                isFirstOperation = true;
        }

        private void ClickClearAll(object sender, RoutedEventArgs e)
        {
            txbResult.Text = "0";
            txbPrevious.Text = "";
            result = "";
            operation = "";
            isDot = false;
            isFirstOperation = true;
            isResult = false;
            isLimitOfChar = false;
        }

        private void ClickNumber(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (isLimitOfChar)
                return;
            else
            {
                if (isResult)
                {
                    txbResult.Text = "";
                    isResult = false;
                }
                else if (txbResult.Text == "0" || txbResult.Text == "Cannot divide by 0")
                    txbResult.Text = "";

                txbResult.Text += button.Content.ToString();
            }
        }

        private void ClickDot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (isLimitOfChar)
                return;
            else
            {
                if (txbResult.Text == "Cannot divide by 0" || isResult)
                {
                    isResult = false;
                    txbResult.Text = "0";
                }

                if (!isDot)
                {
                    if (txbResult.Text == "")
                        txbResult.Text += "0" + button.Content.ToString();
                    else if (txbResult.Text.Contains("."))
                        return;
                    else
                        txbResult.Text += button.Content.ToString();

                    isDot = true;
                }
            }
        }

        private void ClickOperation(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (isLimitOfChar)
                isLimitOfChar = false;

            if (txbResult.Text == "Cannot divide by 0")
                txbResult.Text = "0";

            if (isFirstOperation)
                result = txbResult.Text;
            else
                result += " " + operation + " " + txbResult.Text;

            if (divisionByZero())
            {
                txbResult.Text = "Cannot divide by 0";
                txbPrevious.Text = "";
                result = "";
                operation = "";
                isDot = false;
                isFirstOperation = true;
            }
            else
            {
                operation = button.Content.ToString();

                isFirstOperation = false;
                isDot = false;
                txbPrevious.Text += " " + txbResult.Text + " " + operation;
                txbResult.Text = "0";
            }
        }

        private void ClickEqual(object sender, RoutedEventArgs e)
        {
            result += " " + operation + " " + txbResult.Text;
            isResult = true;

            if (txbPrevious.Text.Length == 0)
                ClickClearAll(sender, e);
            else if (divisionByZero())
            {
                txbResult.Text = "Cannot divide by 0";
                txbPrevious.Text = "";
                result = "";
                operation = "";
                isDot = false;
                isFirstOperation = true;
            }
            else
            {
                txbPrevious.Text = "";
                isDot = false;
                isFirstOperation = true;

                result = Calculation.toRPN(result);
                Stack<string> stack = new Stack<string>();
                stack = Calculation.ConvertToStack(result);

                txbResult.Text = Calculation.evalRPN(stack).ToString();
            }
        }

        private void ResultFontControll(object sender, TextChangedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            textbox.FontSize = 70;

            if (textbox.Text.Length > 8)
            {
                textbox.FontSize = 50;

                if (textbox.Text.Length > 12)
                {
                    textbox.FontSize = 30;

                    if (textbox.Text.Length > 19)
                        isLimitOfChar = true;
                }
            }
        }

        private void PreviousLengthControll(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.CaretIndex = textBox.Text.Length;
            var rect = textBox.GetRectFromCharacterIndex(textBox.CaretIndex);
            textBox.ScrollToHorizontalOffset(rect.Right);
        }

        private void ClickPlusMinus(object sender, RoutedEventArgs e)
        {
            if (txbResult.Text == "Cannot divide by 0")
                txbResult.Text = "0";

            double value = Convert.ToDouble(this.LocalizationControll(txbResult.Text));

            if (value != 0)
            {
                value *= -1;
                txbResult.Text = value.ToString();
            }
            else
                return;
        }

        private void ClickBackspace(object sender, RoutedEventArgs e)
        {
            if (txbResult.Text == "Cannot divide by 0")
                ClickClearAll(sender, e);
            else
            {
                txbResult.Text = txbResult.Text.Substring(0, txbResult.Text.Length - 1);
                if (txbPrevious.Text == "")
                    isFirstOperation = true;

                if (txbResult.Text == "" || txbResult.Text == "-")
                    txbResult.Text = "0";

                if (txbResult.Text.Contains('.'))
                    isDot = true;
                else
                    isDot = false;
            }
        }

        private bool divisionByZero()
        {
            int size = result.Length;

            if (size < 5)
                return false;
            else if (result[size - 1] == '0' && result[size - 3] == '/')
                return true;
            else
                for (int i = 0; i < size; i++)
                    if (result[i] == '/' && result[i + 2] == '0' && result[i + 4] == ' ')
                        return true;

            return false;
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.Key == Key.NumPad0) || (e.Key == Key.D0))
                ClickNumber(btnZero, e);
            else if ((e.Key == Key.NumPad1) || (e.Key == Key.D1))
                ClickNumber(btnOne, e);
            else if ((e.Key == Key.NumPad2) || (e.Key == Key.D2))
                ClickNumber(btnTwo, e);
            else if ((e.Key == Key.NumPad3) || (e.Key == Key.D3))
                ClickNumber(btnThree, e);
            else if ((e.Key == Key.NumPad4) || (e.Key == Key.D4))
                ClickNumber(btnFour, e);
            else if ((e.Key == Key.NumPad5) || (e.Key == Key.D5))
                ClickNumber(btnFive, e);
            else if ((e.Key == Key.NumPad6) || (e.Key == Key.D6))
                ClickNumber(btnSix, e);
            else if ((e.Key == Key.NumPad7) || (e.Key == Key.D7))
                ClickNumber(btnSeven, e);
            else if ((e.Key == Key.NumPad8) || (e.Key == Key.D8))
                ClickNumber(btnEight, e);
            else if ((e.Key == Key.NumPad9) || (e.Key == Key.D9))
                ClickNumber(btnNine, e);
            else if (e.Key == Key.Back)
                ClickBackspace(btnBackspace, e);
            else if ((e.Key == Key.Decimal) || (e.Key == Key.OemPeriod))
                ClickDot(btnDot, e);
            else if ((e.Key == Key.Add) || (e.Key == Key.OemPlus))
                ClickOperation(btnAddition, e);
            else if ((e.Key == Key.Subtract) || (e.Key == Key.OemMinus))
                ClickOperation(btnSubstraction, e);
            else if ((e.Key == Key.Divide) || (e.Key == Key.OemQuestion))
                ClickOperation(btnDivision, e);
            else if (e.Key == Key.Multiply)
                ClickOperation(btnMultiplication, e);
            else if (e.Key == Key.Enter)
                ClickEqual(btnEqual, e);
        }

        public string LocalizationControll(string item)
        {
            string result = item;

            if (CultureInfo.CurrentCulture.Name == "pl-PL")
                result = item.Replace(".", ",");
    
            return result;
        }
    }
}