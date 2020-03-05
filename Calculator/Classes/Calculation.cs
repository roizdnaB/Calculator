using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    class Calculation
    {
        public static string toRPN(string token)
        {
            Dictionary<string, int> precedence = new Dictionary<string, int>();
            precedence.Add("+", 1);
            precedence.Add("-", 1);
            precedence.Add("/", 2);
            precedence.Add("*", 2);

            Stack<string> stack = new Stack<string>();
            
            string result = "";
            string[] equation = token.Split();

            foreach (string item in equation)
            {
                try
                {
                    double temp = Convert.ToDouble(item);
                    result += " " + item;
                }
                catch
                {
                    while(stack.Count != 0 && precedence[item] <= precedence[stack.Peek()])
                    result += " " + stack.Pop();

                    stack.Push(item);
                }
            }

            while (stack.Count != 0)
                result += " " + stack.Pop();

            result = result.Remove(0, 1);

            return result;
        }

        public static Stack<string> ConvertToStack(string tokens)
        {
            string[] result = tokens.Split();
            Stack<string> stack = new Stack<string>();

            foreach (string token in result)
                stack.Push(token);

            return stack;
        }

        public static double evalRPN(Stack<string> tokens)
        {
            string token = tokens.Pop();
            double firstNumber, secondNumber;

            if (!Double.TryParse(token, out firstNumber))
            {
                secondNumber = evalRPN(tokens);
                firstNumber = evalRPN(tokens);

                if (token == "+")
                    firstNumber += secondNumber;
                else if (token == "-")
                    firstNumber -= secondNumber;
                else if (token == "*")
                    firstNumber *= secondNumber;
                else if (token == "/")
                    firstNumber /= secondNumber;
                else throw new Exception();
            }

            return firstNumber;
        }        
    }
}
