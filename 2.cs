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
            Console.WriteLine(inputstuff);
            
            Stack tokens = new Stack();

            Queue<string> stuff = new Queue<string>();

            
           
            for (int i=0; i < inputstuff.Length; i++)
            {

                if (true) //перевірити, чи inputstuff[i] є числом
                {
                    Console.WriteLine(inputstuff[i]);
                    stuff.Enqueue(inputstuff);
                }
                
                tokens.Push(inputstuff[i]);
            }

            
            static void PrintValues( IEnumerable myCollection )  {
                foreach ( Object obj in myCollection )
                    Console.Write( obj );
                Console.WriteLine();
            }
            
            PrintValues( tokens );
            
        }
    }
}
