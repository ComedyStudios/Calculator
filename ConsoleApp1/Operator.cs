using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp1
{
    public class Operator
    {
        //TODO check if syntax is correct
        public string getResult(List<string> operatorsAndNumbers )
        {
            while (operatorsAndNumbers.Count > 1)
            {
                PerformPrimaryOpperations(operatorsAndNumbers);
                PerformSecondaryOpperations(operatorsAndNumbers);
                PerformTertiaryOpperations(operatorsAndNumbers);
            }

            return operatorsAndNumbers[0];
        }

        private void PerformSecondaryOpperations(List<string> operatorsAndNumbers)
        {
            for (int i = 0; i < operatorsAndNumbers.Count; i++)
            {
                if (i == 0)
                {
                    if (operatorsAndNumbers[i] == "-")
                    {
                        changeListSpecial(i, Subtract( operatorsAndNumbers[i+1]), operatorsAndNumbers);
                    }
                }
                else
                {
                    if (operatorsAndNumbers[i] == "-")
                    {
                        changeList(i, Subtract(operatorsAndNumbers[i+1], operatorsAndNumbers[i-1]), operatorsAndNumbers);
                    }
                }
            }
        }

        private void PerformTertiaryOpperations(List<string> operatorsAndNumbers)
        {
            for (int i = 0; i < operatorsAndNumbers.Count; i++)
            {
                if (i == 0)
                {
                    if (operatorsAndNumbers[i] == "+")
                    {
                        changeListSpecial(i, Add( operatorsAndNumbers[i+1]), operatorsAndNumbers);
                    }
                }
                else
                {
                    if (operatorsAndNumbers[i] == "+")
                    {
                        changeList(i, Add(operatorsAndNumbers[i+1], operatorsAndNumbers[i-1]), operatorsAndNumbers);
                    }
                }
            }
        }

        private void changeList(int i, float value, List<string> operatorsAndNumbersList)
        {
            operatorsAndNumbersList[i] = value.ToString();
            operatorsAndNumbersList.RemoveAt(i + 1); 
            operatorsAndNumbersList.RemoveAt(i-1);
        }
        private void changeListSpecial(int i, float value, List<string> operatorsAndNumbersList)
        {
            operatorsAndNumbersList[i] = value.ToString();
            operatorsAndNumbersList.RemoveAt(i + 1);
        }
        
        private void PerformPrimaryOpperations(List<string> operatorsAndNumbers)
        {
            for (int i = 0; i < operatorsAndNumbers.Count; i++)
            {
                if (operatorsAndNumbers[i] == "*")
                {
                    changeList(i, Mulitply(operatorsAndNumbers[i-1], operatorsAndNumbers[i+1]), operatorsAndNumbers);
                }
                else if (operatorsAndNumbers[i] == "/")
                {
                    changeList(i, Divide(operatorsAndNumbers[i-1], operatorsAndNumbers[i+1]), operatorsAndNumbers);
                }
            }
        }
        
        //TODO syntax is wierd change the order of the params 
        private float Subtract( string number2, string number1 = "0")
        {
            var num1 =float.Parse(number1);
            var num2 =float.Parse(number2);

            return num1 - num2;
        }
        
        private float Add( string number2, string number1 = "0")
        {
            var num1 =float.Parse(number1);
            var num2 =float.Parse(number2);

            return num1 + num2;
        }
        
        private float Mulitply(string number1, string number2)
        {
            var num1 =float.Parse(number1);
            var num2 =float.Parse(number2);

            return num1 * num2;
        }
        
        private float Divide(string number1, string number2)
        {
            var num1 =float.Parse(number1);
            var num2 =float.Parse(number2);

            return num1 / num2;
        }
    }
}