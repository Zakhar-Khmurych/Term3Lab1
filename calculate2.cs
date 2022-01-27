using System;
using System.Collections;

namespace attempt5
{
    class Program
    {
        static void Main(string[] args)
        {
            string whatWeGot = "2 43 0 * + 1 1 - + 3 +";
            whatWeGot += " ";
            Stack stack_poles = new Stack();

            int num1 = 0;
            int num2 = 0;

            string[] arr_divided_by_spaces = whatWeGot.Split(" ");
            
            float IsNumber(string element)
            {
                bool IsNum = false;
                float finish = 0;
                for (int c = 0; c < element.Length; c++)
                {
                    if (Char.IsDigit(element[c]))
                    {
                        IsNum = true;
                        Console.WriteLine(element[c]);
                        stack_poles.Push(element[c]);
                    }
                    else
                    {
                        IsNum = false;
                    }
                }
                return finish;
               // return IsNum;
            }

            for (int  i = 0;  i < arr_divided_by_spaces.Length;  i++)
            {
                IsNumber(arr_divided_by_spaces[i]);
            }

        }
    }
}


            
