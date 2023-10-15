using System;
using System.Text;
using System.Text.RegularExpressions;


namespace EAD_Assignment04
{
    internal class MyStringSolver
    {
        public static bool IsInfixExpression(string expression)
        {

            string fullPattern = @"^(\d+(\.\d+)?|[-]?\d+(\.\d+)?|\(\s*[^()]+\s*\))(\s*[+\-*/]\s*(\d+(\.\d+)?|[-]?\d+(\.\d+)?|\(\s*[^()]+\s*\)))*$";
            int openParenthesesCount = expression.Count(c => c == '(');
            int closeParenthesesCount = expression.Count(c => c == ')');
            if (openParenthesesCount != closeParenthesesCount)
            {
                return false;
            }
            return Regex.IsMatch(expression, fullPattern);
        }

        public static double Evaluate(string expression)
        {
            char[] tokens = expression.ToCharArray();

           
            Stack<double> values = new();

          
            Stack<char> ops = new();

            for (int i = 0; i < tokens.Length; i++)
            {
             
                if (tokens[i] == ' ')
                {
                    continue;
                }

             
                if (tokens[i] >= '0' && tokens[i] <= '9')
                {
                    StringBuilder sbuf = new();

          
                    while (i < tokens.Length && (char.IsDigit(tokens[i]) || tokens[i] == '.'))
                    {
                        sbuf.Append(tokens[i++]);
                    }
                    values.Push(double.Parse(sbuf.ToString()));
                    i--;
                } 
                else if (tokens[i] == '(')
                {
                    ops.Push(tokens[i]);
                }

          
                else if (tokens[i] == ')')
                {
                    while (ops.Peek() != '(')
                    {
                        values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    ops.Pop();
                }

                else if (tokens[i] == '+' ||
                         tokens[i] == '-' ||
                         tokens[i] == '*' ||
                         tokens[i] == '/')
                {

                    while (ops.Count > 0 && HasPrecedence(tokens[i], ops.Peek()))
                    {
                        values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                    }
 
                    ops.Push(tokens[i]);
                }
            }

  
            while (ops.Count > 0)
            {
                values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
            }

            return values.Pop();
        }


        public static bool HasPrecedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
            {
                return false;
            }
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static double ApplyOp(char op, double b, double a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        throw new
                        System.NotSupportedException("Cannot divide by zero");
                    }
                    return a / b;
            }
            return 0;
        }
    }
}
