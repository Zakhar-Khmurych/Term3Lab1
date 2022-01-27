using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace attempt3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert your numbers. '+', '-', '*', '/', '^', '(', ')' are allowed");

            string epression = Console.ReadLine();

            Console.WriteLine(epression);
            
            
            static string Algorythm(string input){
                string result = "";
                Stack opStack = new Stack();
                Queue numbers = new Queue();
                
                for (int i = 0; i < input.Length; i++)
                { 
                    if (Char.IsDigit(input[i]) || (input[i] == Convert.ToChar("-") && i == 0) ||(i > 0 && input[i - 1] == Convert.ToChar("(") && input[i] == Convert.ToChar("-")))
  
                    {
                        if (i + 1 == input.Length || Char.IsDigit(input[i+1]) || !Char.IsDigit(input[i]) || input[i + 1] == Convert.ToChar("(") || input[i + 1] == Convert.ToChar(")"))

                        {
                            result += input[i] + "";
                        }
                        else
                        {
                            result += input[i] + " ";
                        }
                    }
                    else if (input[i] == Convert.ToChar("("))
                    {
                        opStack.Push("(");
                    }
                    else if (input[i] == Convert.ToChar(")"))
                    {
                        result += " ";
                        while (Convert.ToChar(opStack.Peek()) != Convert.ToChar("("))
                        {
                            result += opStack.Pop() + " ";
                        }
                        opStack.Pop();
                    }
                    else if (!Char.IsDigit(input[i]))
                    {
                        while (opStack.Count > 0 && (Prio(Convert.ToChar(opStack.Peek())) >= Prio(input[i])))
                        {
                            result += opStack.Pop() + " ";
                        }
                        opStack.Push(input[i]);
                    }
                    else
                    {
                        Console.WriteLine("nope");
                    }
                }
                if (opStack.Count > 0)
                {
                    result += " ";
                    for (int j = 0; j < opStack.Count - 1; j++)
                    {
                        result += opStack.Pop() + " ";
                    }

                    result += opStack.Pop() + " ";
                }

                return result;
            }
            

            static char Prio(char ch)
            {
                switch(ch)
                {
                    case '^':
                        return Convert.ToChar("3"); 
                    case '*':
                    case '/':
                        return Convert.ToChar("2"); 
                    case '+':
                    case '-':
                        return Convert.ToChar("1");		
                }
                return Convert.ToChar("0");
            }
        
            string whatWeGot = Algorythm(epression);
            
            whatWeGot += " ";
            Stack stack_poles = new Stack();

            int num1 = 0;
            int num2 = 0;

            string[] arr_divided_by_spaces = whatWeGot.Split(" ");
            
            bool IsNumber(string element)
            {
                bool IsNum = false;
                for (int c = 0; c < element.Length; c++)
                {
                    if (Char.IsDigit(element[c]))
                    {
                        IsNum = true;
                    }
                    else
                    {
                        IsNum = false;
                    }
                }
                return IsNum;
            }

            for (int  i = 0;  i < arr_divided_by_spaces.Length-1;  i++)
            {
                if (IsNumber(arr_divided_by_spaces[i]))
                {
                    stack_poles.Push(arr_divided_by_spaces[i]);
                }
                else
                {
                    if (Convert.ToChar(arr_divided_by_spaces[i]) == Convert.ToChar("+") )
                    {
                        int finish = Convert.ToInt32(stack_poles.Pop()) + Convert.ToInt32(stack_poles.Pop());
                        stack_poles.Push(finish);
                    }
                    else if (Convert.ToChar(arr_divided_by_spaces[i]) == Convert.ToChar("-") )
                    {
                        int finish = Convert.ToInt32(stack_poles.Pop()) - Convert.ToInt32(stack_poles.Pop());
                        stack_poles.Push(finish);
                    }
                    else if (Convert.ToChar(arr_divided_by_spaces[i]) == Convert.ToChar("*") )
                    {
                        int finish = Convert.ToInt32(stack_poles.Pop()) * Convert.ToInt32(stack_poles.Pop());
                        stack_poles.Push(finish);
                    }
                    else if (Convert.ToChar(arr_divided_by_spaces[i]) == Convert.ToChar("/") )
                    {
                        int finish = Convert.ToInt32(stack_poles.Pop()) / Convert.ToInt32(stack_poles.Pop());
                        stack_poles.Push(finish);
                    }
                    else if (Convert.ToChar(arr_divided_by_spaces[i]) == Convert.ToChar("^") )
                    {
                        int finish = Convert.ToInt32(stack_poles.Pop()) ^ Convert.ToInt32(stack_poles.Pop());
                        stack_poles.Push(finish);
                    }
                }
            }
           Console.WriteLine(stack_poles.Peek());

        }
    }
    
    
}



