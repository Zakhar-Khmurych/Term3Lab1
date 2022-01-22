using System;
using System.Collections;

namespace attempt3
{
    class Program
    {
        static void Main(string[] args)
        {
            string epression = "2+43*0+(1-1)+3";
            //string epression = "2 + 43 * 0 + ( 1 - 1 ) + 3";

           // string epression = fromconsole;
            Console.WriteLine(epression);      
            
            static string Algorythm(string input){
                string result = "";
                Stack opStack = new Stack();
                Queue numbers = new Queue();

                Console.WriteLine("Please insert your numbers. '+', '-', '*', '/', '^', '(', ')' are allowed");

                for (int i = 0; i < input.Length; i++)
                { 
                    if (Char.IsDigit(input[i]) || (input[i] == Convert.ToChar("-") && i == 0) ||(i > 0 && input[i - 1] == Convert.ToChar("(") && input[i] == Convert.ToChar("-")))
                    //if (Char.IsDigit(input[i]))
                    {
                        if (i + 1 == input.Length || Char.IsDigit(input[i+1]) || !Char.IsDigit(input[i]) || input[i + 1] == Convert.ToChar("(") || input[i + 1] == Convert.ToChar(")"))
                        //if (Char.IsDigit(input[i+1]))
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
            Console.WriteLine(Algorythm(epression));
        }
    }   
}
