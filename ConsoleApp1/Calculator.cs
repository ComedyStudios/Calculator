using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    
    public class Calculator
    {
        private string[] NumberCharArray = {"0","1","2","3","4","5","6","7","8","9","."};
        private string[] OpperatorNameArray = {"+","-","*","/"};

        internal void Calculate(string expresion)
        {
            //TODO calcutae should return a value; 
            Parser parser = new Parser();
            parser.Parse(expresion);
        }


    }
}