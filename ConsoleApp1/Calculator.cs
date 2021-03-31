using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Calculator
    {

        internal void Calculate(string expresion)
        {
            List<string> op = new List<string>();
            List<int> val = new List<int>();

            int SubstringLenght = 1; 
            for (int i = 0 ; i < expresion.Length;)
            {
                string subst = expresion.Substring(i, SubstringLenght);
                if (subst == "+")
                {
                    Console.WriteLine("addition");
                    i++;
                }
                else if(int.TryParse(subst,out int temp))
                {
                    Console.WriteLine(getNumber(expresion, ref i));
                }
                else
                {
                    Console.WriteLine(subst);
                    i++;
                }
            }
        }

        private int getNumber(string expresion, ref int i)
        {
            int x = 0;
            for (int y = 1; y < expresion.Length - i; y++)
            {
                string newSubst = expresion.Substring(i, y);

                if (!int.TryParse(newSubst, out int z))
                {
                    i += y - 1;
                }
                else
                {
                    x = z;
                }
            }

            return x; 
        }
    }
}