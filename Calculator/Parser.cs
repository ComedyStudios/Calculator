using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    public class Parser
    {
        private string[] NumberCharArray = {"0","1","2","3","4","5","6","7","8","9","."}; 
        private string[] OpperatorArray = {"+","-","*","/"};
        private string[] PriorityOperator = {"(", ")"};
        private List<string> NewExpression = new List<string>(); 
        private List<string> Stack = new List<string>();
        
        private string LastOperatorInStack;
        private int expressionLenght;
        private int PositionInString;
        
        /// Types of possible inputs:
        /// operator
        /// number
        /// bracket
        ///
        /// Make an issue if:
        /// Stack isn't empty: invalid syntax
        /// number ends with a letter: 1231a
        /// no operator between numbers: 12 13
        /// semicolon: 7,7 instead of 7.7
        /// operator isnt surounded by numbers
        
        public List<string> Parse(string expresion)
        {
            expressionLenght = expresion.Length;
            
            //TODO Change from substring to char Array
            //use Char.isNumber or similar function
            
            //building the stack and the expression
            for (; PositionInString < expressionLenght; PositionInString++)
            {
                var substring = expresion.Substring(PositionInString, 1);
                if (SymbolIsNumber(substring))
                {
                    AddFullNumberToExpression(expresion);
                }
                else if (SymbolIsOperator(substring))
                {
                    AddOperatorToStackOrExpression(substring);
                }
                else if (SymbolIsBracket(substring))
                {
                    ManageBrackets(substring);
                }
            }

            //moving the stack into the expresion
            for (int temp = Stack.Count-1; temp >= 0; temp--)
            {
                NewExpression.Add(Stack[temp]);
            }
            
            return NewExpression; 
        }

        private void AddFullNumberToExpression(string expresion)
        {
            string temp = "";
            for (; PositionInString < expresion.Length; PositionInString++)
            {
                var symbol = expresion.Substring(PositionInString, 1);
                foreach (var secondNumberChar in NumberCharArray)
                {
                    if (symbol == secondNumberChar)
                    {
                        temp += symbol;
                        break;
                    }
                }

                if (!SymbolIsNumber(symbol))
                {
                    PositionInString--;
                    break;
                }
            }
            NewExpression.Add(temp);
        }
        private void AddOperatorToStackOrExpression(string substring)
        {
            foreach (var mathOperator in OpperatorArray)
            {
                if (substring == mathOperator)
                {
                    if (OperatorHasSamePriorityAsLast(substring))
                    {
                        LastOperatorInStack = substring;
                        NewExpression.Add(Stack[^1]);
                        Stack.RemoveAt(Stack.Count-1);
                        Stack.Add(substring);
                        break;
                    }
                    else
                    {
                        LastOperatorInStack = substring;
                        Stack.Add(substring);
                        break;
                    }
                }
            }
        }
        private void ManageBrackets(string substring)
        {
            if (substring == "(")
            {
                Stack.Add("(");
            }
            else
            {
                for (int temp = Stack.Count-1;temp >= 0 ;temp--)
                {
                    if (Stack[temp] == "(")
                    {
                        Stack.RemoveAt(temp);
                    
                        for (; temp < Stack.Count; temp++)
                        {
                            NewExpression.Add(Stack[temp]);
                            Stack.RemoveAt(temp);
                        }
                        break;
                    }
                }
            }
        }
        
        private bool OperatorHasSamePriorityAsLast(string operation)
        {
            if (  operation == "*" && LastOperatorInStack == "/"
                ||operation == "/" && LastOperatorInStack == "*"
                ||operation == "-" && LastOperatorInStack == "*"
                ||operation == "-" && LastOperatorInStack == "/"
                ||operation == "+" && LastOperatorInStack == "*"
                ||operation == "+" && LastOperatorInStack == "/") 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool SymbolIsNumber(string symbol)
        {
            foreach (var number in NumberCharArray)
            {
                if (number == symbol)
                {
                    return true;
                }
            }

            return false;
        }
        private bool SymbolIsOperator(string symbol)
        {
            foreach (var mathOperaor in OpperatorArray)
            {
                if (mathOperaor == symbol)
                {
                    return true; 
                }
            }

            return false;
        }

        private bool SymbolIsBracket(string symbol)
        {
            foreach (var bracket in PriorityOperator)
            {
                if (symbol == bracket)
                {
                    return true;
                }
            }

            return false; 
        }
    }
}