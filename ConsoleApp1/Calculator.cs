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
            
            
            string temp = "";
            foreach (var symbol in numbersAndOpreatorsList)
            {
                temp += symbol+ " ";
            }
            Console.WriteLine(temp);
            
            //return op.getResult(numbersAndOpreatorsList);
            return "";
        }
    }
}