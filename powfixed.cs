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
            //Console.WriteLine(Math.Pow(2,3));
            Console.WriteLine("Please insert your numbers. '+', '-', '*', '/', '^', '(', ')' are allowed");
            //string  = " ";
            string epression = Console.ReadLine();
            //string epression = "2+43*0+(1-1)+3";
            //string epression = "2+43*0+(1-1)+3";
            //string epression = "2 + 43 * 0 + ( 1 - 1 ) + 3";


            //Console.WriteLine(epression);
            
            
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
                    else if (input[i] == '(')
                    {
                        opStack.Push("(");
                    }
                    else if (input[i] == ')')
                    {
                        result += " ";
                        //while (Convert.ToChar(opStack.Peek()) != Convert.ToChar("("))
                        while (opStack.Peek() != "(")
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
                        return '3'; 
                    case '*':
                    case '/':
                        return '2'; 
                    case '+':
                    case '-':
                        return '1';		
                }
                return '0';
            }
            
            //Console.WriteLine(Algorythm(epression));

            string whatWeGot = Algorythm(epression);
            
            whatWeGot += "";
            Stack stack_poles = new Stack();
            
            //int finish = 0;

            string[] arr_divided_by_spaces = whatWeGot.Split(' ');
            
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
                    //Console.WriteLine(stack_poles.Peek());
                    //Console.WriteLine(arr_divided_by_spaces[i]);
                }
                else
                {
                    if ((arr_divided_by_spaces[i]) == "+")
                    {
                        int finish = Convert.ToInt32(stack_poles.Pop()) + Convert.ToInt32(stack_poles.Pop());
                        stack_poles.Push(finish);
                    }
                    else if ((arr_divided_by_spaces[i]) == "-")
                    {
                        int finish = Convert.ToInt32(stack_poles.Pop()) - Convert.ToInt32(stack_poles.Pop());
                        stack_poles.Push(finish);
                    }
                    else if ((arr_divided_by_spaces[i]) == "*")
                    {
                        int finish = Convert.ToInt32(stack_poles.Pop()) * Convert.ToInt32(stack_poles.Pop());
                        stack_poles.Push(finish);
                    }
                    else if ((arr_divided_by_spaces[i]) == "/")
                    {
                        int finish = Convert.ToInt32(stack_poles.Pop()) / Convert.ToInt32(stack_poles.Pop());
                        stack_poles.Push(finish);
                    }
                    //else if (Convert.ToChar(arr_divided_by_spaces[i]) == Convert.ToChar("^") )
                    else if ((arr_divided_by_spaces[i]) == "^")
                    {
                        //int finish = (Convert.ToInt32(stack_poles.Pop()) ^ Convert.ToInt32(stack_poles.Pop()));
                        //double finish = Convert.ToInt32(Math.Pow(Convert.ToInt32(stack_poles.Pop()), Convert.ToInt32(stack_poles.Pop())));
                        int num1 = Convert.ToInt32(stack_poles.Pop());
                        int num2 = Convert.ToInt32(stack_poles.Pop());

                        int finish = Convert.ToInt32(Math.Pow(num2, num1));
                        stack_poles.Push(finish);
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    //stack_poles.Push(Convert.ToInt32(stack_poles.Pop()) + Convert.ToInt32(stack_poles.Pop()));
                }
            }
           // Console.WriteLine(stack_poles.Peek());
           Console.WriteLine(stack_poles.Peek());

        }
    }
    
    
}



