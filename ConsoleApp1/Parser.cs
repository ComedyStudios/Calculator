using System;
using System.Collections.Generic;
using System.Data;

namespace ConsoleApp1
{
    public class Parser
    { 
        //TODO: Check for valid syntax
        
        private string[] NumberCharArray = {"0","1","2","3","4","5","6","7","8","9","."}; 
        private string[] OpperatorNameArray = {"+","-","*","/"};
        private List<string> OpperatorsAndNumbersList = new List<string>(); 
        
        private Calculator calc  = new Calculator();
        
        private int expressionLenght;
        private string substring; 
        private int PositionInString = 0;
        public List<string> Parse(string expresion)
        {
            expressionLenght = expresion.Length; 
            
            for (; PositionInString < expressionLenght; PositionInString++)
            {
                
                substring = expresion.Substring(PositionInString, 1);
                
                if (substring == "(")
                {
                    SearchForBrackets(expresion, PositionInString);
                }
                
                searchForNumbers(expresion);
                
                GetOpperator(substring);
            }

            return OpperatorsAndNumbersList; 
        }

        private void searchForNumbers(string expresion)
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

                    OpperatorsAndNumbersList.Add(temp);
                    break;
                }
            }
        }

        private void SearchForBrackets(string expresion, int entryPoint)
        {
            int openingBracketCount = 0; 
            var z = entryPoint;
            for (; z < expresion.Length; z++)
            {
                var tempSubstring = expresion.Substring(z, 1);
                if (tempSubstring == ")")
                {
                    openingBracketCount--;
                   
                }
                else if(tempSubstring == "(")
                {
                    openingBracketCount++;
                }

                if (openingBracketCount == 0)
                {
                    string bracketSubstring = expresion.Substring(entryPoint + 1, z - entryPoint - 2);

                    // TODO calculate the bracketSubstring (it should return a value that can be used later)
                    calc.Calculate(bracketSubstring);
                    PositionInString = z; 
                    break;
                }
            }
            
        }

        private void GetOpperator(string substring)
        {
            foreach (var mathOperator in OpperatorNameArray)
            {
                if (substring == mathOperator)
                {
                    OpperatorsAndNumbersList.Add(substring);
                    break;
                }
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