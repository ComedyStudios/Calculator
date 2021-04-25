using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class Parser
    {
        private string[] NumberCharArray = {"0","1","2","3","4","5","6","7","8","9","."}; 
        private string[] OpperatorNameArray = {"+","-","*","/","("};
        private List<string> NewExpression = new List<string>(); 
        private List<string> Stack = new List<string>();
        private string LastOperatorInStack;

        private int expressionLenght;
        private string substring; 
        private int PositionInString = 0;
        public List<string> Parse(string expresion)
        {
            expressionLenght = expresion.Length;

            for (; PositionInString < expressionLenght; PositionInString++)
            {
                
                substring = expresion.Substring(PositionInString, 1);
                
                if (substring == ")")
                {
                    RearrangeBrackets();
                }
                
                SearchForNumbers(expresion);
                // updating the substring
                substring = expresion.Substring(PositionInString, 1);
                GetOperator(substring);
            }

            for (int temp = Stack.Count-1; temp >= 0; temp--)
            {
                NewExpression.Add(Stack[temp]);
            }
            
            return NewExpression; 
        }

        private void SearchForNumbers(string expresion)
        {
            foreach (var numberChar in NumberCharArray)
            {
                if (numberChar == substring)
                {
                    PositionInString++;
                    string temp = substring;
                    for (; PositionInString < expressionLenght; PositionInString++)
                    {
                        substring = expresion.Substring(PositionInString, 1);
                        foreach (var secondNumberChar in NumberCharArray)
                        {
                            if (substring == secondNumberChar)
                            {
                                temp += substring;
                                break;
                            }
                        }

                        if (CharIsNotNumber(substring))
                        {
                            break;
                        }
                    }
                    PositionInString--;
                    NewExpression.Add(temp);
                    break;
                }
            }
        }

        private void RearrangeBrackets()
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

        private void GetOperator(string substring)
        {
            foreach (var mathOperator in OpperatorNameArray)
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

        private bool OperatorHasSamePriorityAsLast(string operation)
        {
            if ( operation == "*" && LastOperatorInStack == "/"
                ||operation == "/" && LastOperatorInStack == "*"
                ||operation == "-"&& LastOperatorInStack == "*"
                ||operation == "-"&& LastOperatorInStack == "/"
                ||operation == "+"&& LastOperatorInStack == "*"
                ||operation == "+"&& LastOperatorInStack == "/")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CharIsNotNumber(string susbt)
        {
            foreach (var numberChar in NumberCharArray)
            {
                if (susbt == numberChar)
                {
                    return false;
                }
            }
            return true; 
        }
        }
    }