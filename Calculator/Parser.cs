using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    public class Parser
    {
        private char[] OpperatorArray = {'+','-','*','/'};
        private char[] PriorityOperator = {'(', ')'};
        private List<string> NewExpression = new List<string>(); 
        private List<char> Stack = new List<char>();
        private string Error;
        
        private char LastOperatorInStack;
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
            char[] charArray = expresion.ToCharArray();
            
            
            //building the stack and the expression
            for (; PositionInString < charArray.Length; PositionInString++)
            {
                if (Error != null)
                {
                    NewExpression.Clear();
                    NewExpression.Add("Error");
                    NewExpression.Add(Error);
                    return NewExpression;
                }

                var symbol = charArray[PositionInString];
                if (Char.IsDigit(symbol)||symbol == '.' )
                {
                    AddFullNumberToExpression(charArray);
                }
                else if (SymbolIsOperator(symbol))
                {
                    AddOperatorToStackOrExpression(symbol);
                }
                else if (SymbolIsBracket(symbol))
                {
                    ManageBrackets(symbol);
                }
                //CreateError("test");
            }

            //moving the stack into the expresion
            for (int temp = Stack.Count-1; temp >= 0; temp--)
            {
                NewExpression.Add(Stack[temp].ToString());
            }
            
            return NewExpression; 
        }

        private void AddFullNumberToExpression(char[] expresion)
        {
            string temp = "";
            for (; PositionInString < expresion.Length; PositionInString++)
            {
                char symbol = expresion[PositionInString];
                if (Char.IsDigit(symbol)|| symbol == '.')
                {
                        temp += symbol;
                }

                if (!Char.IsDigit(symbol) && symbol != '.')
                {
                    PositionInString--;
                    break;
                }
            }
            NewExpression.Add(temp);
        }
        private void AddOperatorToStackOrExpression(char substring)
        {
            foreach (var mathOperator in OpperatorArray)
            {
                if (substring == mathOperator)
                {
                    if (OperatorHasSamePriorityAsLast(substring))
                    {
                        LastOperatorInStack = substring;
                        NewExpression.Add(Stack[^1].ToString());
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
        private void ManageBrackets(char substring)
        {
            if (substring == '(')
            {
                Stack.Add('(');
            }
            else
            {
                for (int temp = Stack.Count-1;temp >= 0 ;temp--)
                {
                    if (Stack[temp] == '(')
                    {
                        Stack.RemoveAt(temp);
                    
                        for (; temp < Stack.Count; temp++)
                        {
                            NewExpression.Add(Stack[temp].ToString());
                            Stack.RemoveAt(temp);
                        }
                        break;
                    }
                }
            }
        }
        
        private bool OperatorHasSamePriorityAsLast(char operation)
        {
            if (  operation == '*' && LastOperatorInStack == '/'
                ||operation == '/' && LastOperatorInStack == '*'
                ||operation == '-' && LastOperatorInStack == '*'
                ||operation == '-' && LastOperatorInStack == '/'
                ||operation == '+' && LastOperatorInStack == '*'
                ||operation == '+' && LastOperatorInStack == '/') 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool SymbolIsOperator(char symbol)
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

        private bool SymbolIsBracket(char symbol)
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

        private void CreateError(string Error)
        {
            this.Error = Error;
        }
    }
}