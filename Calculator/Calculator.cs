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

            if (numbersAndOpreatorsList[0] == "Error")
            {
                return "The expression contains the following error:" + numbersAndOpreatorsList[1];
            }
            else
            {
                return op.getResult(numbersAndOpreatorsList);
            }
            //return "Calculator: the operator is deactivated";
        }
    }
}