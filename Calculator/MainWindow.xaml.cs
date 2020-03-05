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
using Calculator.Classes;

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
                else if (txbResult.Text == "0" || txbResult.Text == "Cannot divide by zero")
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
                if (txbResult.Text == "Cannot divide by zero" || isResult)
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

            if (txbResult.Text == "Cannot divide by zero")
                txbResult.Text = "0";
           
            if (isFirstOperation)
                result = txbResult.Text;
            else
                result += " " + operation + " " + txbResult.Text;

            if (divisionByZero())
            {
                txbResult.Text = "Cannot divide by zero";
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
                txbResult.Text = "Cannot divide by zero";
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
                Console.WriteLine(result);
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

                    if (textbox.Text.Length > 18)
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
            if (txbResult.Text == "Cannot divide by zero")
                txbResult.Text = "0";

            double value = Double.Parse(txbResult.Text);

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
            if (txbResult.Text == "Cannot divide by zero")
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
    }
}