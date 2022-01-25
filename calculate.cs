using System;
using System.Collections;

namespace attempt5
{
    class Program
    {
        static void Main(string[] args)
        {
            string whatWeGot = "2 4 +";
            whatWeGot += " ";
            Stack stack_poles = new Stack();

            int finish = 0;

            string[] arr_divided_by_spaces = whatWeGot.Split(" ");
            
            
            static bool IsNumber(string element)
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
            
            Console.WriteLine(arr_divided_by_spaces);

            for (int i = 0; i < arr_divided_by_spaces.Length; i++)
            {
                if (IsNumber(arr_divided_by_spaces[i]))
                {
                    stack_poles.Push(arr_divided_by_spaces[i]);
                }
                else
                {
                    int num1 = Convert.ToInt32(stack_poles.Peek());
                    int num2 = Convert.ToInt32(stack_poles.Peek());
                    
                    if (Convert.ToChar(arr_divided_by_spaces[i]) == Convert.ToChar("+"))
                    {
                        finish = num1 + num2;
                    }
                    else if (Convert.ToChar(arr_divided_by_spaces[i]) == Convert.ToChar("-"))
                    {
                        finish = num1 - num2;
                    }
                    else if (Convert.ToChar(arr_divided_by_spaces[i]) == Convert.ToChar("/"))
                    {
                        finish = num1 / num2;
                    }
                    else if (Convert.ToChar(arr_divided_by_spaces[i]) == Convert.ToChar("*"))
                    {
                        finish = num1 * num2;
                    }
                    else if (Convert.ToChar(arr_divided_by_spaces[i]) == Convert.ToChar("^"))
                    {
                        finish = num1 ^ num2;
                    }
                    stack_poles.Clear();
                    stack_poles.Push(Convert.ToString(finish));

                }
            }

            Console.WriteLine(Convert.ToString(finish));
        }
    }
}

            
