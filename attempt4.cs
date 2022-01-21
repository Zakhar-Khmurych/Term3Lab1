using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace attempt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "2+43*0-(1-1)";
            //string expression = "2+43*0-1";
            //string expression = "2+3-1";
            Console.WriteLine("Please insert your numbers. '+', '-', '*', '/', '^', '(', ')' are allowed");
            Console.WriteLine(expression);
            
            
            Stack operators_s = new Stack();
            string result = "";
            Queue<char> numbers_q = new Queue<char>();
            
            
           // for (int i=0; i < expression.Length; i++)
            for (int i = 0; i < expression.Length; i++)
            {
                if (Char.IsDigit(expression[i]))
                {
                    if (Char.IsDigit(expression[i + 1]))
                    {
                        numbers_q.Enqueue(expression[i]);
                        result += numbers_q.Dequeue();
                    }
                    else
                    {
                        numbers_q.Enqueue(expression[i]);
                        result += numbers_q.Dequeue() + " ";
                    }
                }
                else
                {
                    operators_s.Push(expression[i]);
                }
               /* else if (expression[i] == char.Parse("("))
                {
                    operators_s.Push("(");
                }
                else if (expression[i] == char.Parse(")"))
                {
                    while (operators_s.Peek() != char.Parse("("))
                    {
                        result += operators_s.Pop() + "";
                    }
                    operators_s.Pop();
                } */
                
            }

            for (int i = 0; i < operators_s.Count; i++)
            {
                result += operators_s.Pop();
            }
            
            Console.WriteLine();
            
            static void PrintValues( IEnumerable myCollection )  {
                foreach ( Object obj in myCollection )
                    Console.Write( obj );
                Console.WriteLine();
            }
            Console.WriteLine("###########################################################################################################");
            //PrintValues( numbers_q );
            //PrintValues( operators_s );
            
            Console.WriteLine(result);
            
        }
    }
}
