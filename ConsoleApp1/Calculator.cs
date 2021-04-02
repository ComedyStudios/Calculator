using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    
    public class Calculator
    {
        internal void Calculate(string expresion)
        {
            //TODO calcutae should return a value; 
            Parser parser = new Parser();
            Operator op = new Operator();
            
            
            var numbersAndOpreatorsList = parser.Parse(expresion);
            
            op.getResult(numbersAndOpreatorsList);
            
            printSomeDebugGarbage(numbersAndOpreatorsList);
        }

        private static void printSomeDebugGarbage(List<string> NumbersAndOpreatorsList)
        {
            string temp = "";
            foreach (var numberOrOperator in NumbersAndOpreatorsList)
            {
                temp += numberOrOperator + " ";
            }

            //Console.WriteLine("the Json file contains the following exrpession: "+ temp);
        }
    }
}