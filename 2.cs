using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace attempt1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string inputstuff = "2+43*0-1";
            Console.WriteLine("Please insert your numbers. '+', '-', '*', '/', '^', '(', ')' are allowed");
            //inputstuff = Console.ReadLine();
            Console.WriteLine(inputstuff);
            
            Stack tokens = new Stack();

            Queue<string> stuff = new Queue<string>();

            
            
            for (int i=0; i < inputstuff.Length; i++)
            {
                //stuff.Enqueue(inputstuff);
                //Console.WriteLine(inputstuff[i]);

                if (Char.IsDigit(inputstuff[i])) //перевірити, чи inputstuff[i] є числом
                {
                    Console.WriteLine(inputstuff[i]);
                    stuff.Enqueue(inputstuff);
                }
                else
                {
                    Console.WriteLine(stuff.Dequeue());
                }
                tokens.Push(inputstuff[i]);
            }

            
            static void PrintValues( IEnumerable myCollection )  {
                foreach ( Object obj in myCollection )
                    Console.Write( obj );
                Console.WriteLine();
            }
            
            PrintValues( tokens );
            PrintValues( stuff );
            
        }
    }
}
