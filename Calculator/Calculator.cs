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
            
            var numbersAndOperatorsList = parser.Parse(expresion);

            if (numbersAndOperatorsList[0] == "Error")
            {
                return "The expression contains the following error:" + numbersAndOperatorsList[1];
            }
            else
            {
                return op.getResult(numbersAndOperatorsList);
            }
            //return "Calculator: the operator is deactivated";
        }
    }
}