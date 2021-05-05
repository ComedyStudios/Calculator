using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    public class Calculator
    {
        internal string Calculate(string expresion)
        {
            Parser parser = new Parser();
            Operator op = new Operator();
            
            var numbersAndOpreatorsList = parser.Parse(expresion);
            if (numbersAndOpreatorsList.Count >= 3)
            {
                return op.getResult(numbersAndOpreatorsList);
            }
            else
            {
                Console.WriteLine("the Input has an incorrect expression");
                return " ?";
            }
            //return "Calculator: the operator is deactivated";
        }
    }
}