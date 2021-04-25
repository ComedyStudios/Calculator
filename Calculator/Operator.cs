using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp1
{
    //TODO make the Operator compatible with the new parser
    public class Operator
    {
        public string getResult(List<string> operatorsAndNumbers)
        {
            while (operatorsAndNumbers.Count > 1)
            {
                PerformOpperations(operatorsAndNumbers);
            }
            return operatorsAndNumbers[0];
        }
        private void PerformOpperations(List<string> operatorsAndNumbers)
        {
            for (int i = 0; i < operatorsAndNumbers.Count; i++)
            {
                if (operatorsAndNumbers[i] == "*")
                {
                    changeList(i, MyMath.Mulitply(operatorsAndNumbers[i - 2], operatorsAndNumbers[i - 1]),
                        operatorsAndNumbers);
                    i = 0;
                }
                else if (operatorsAndNumbers[i] == "/")
                {
                    changeList(i, MyMath.Divide(operatorsAndNumbers[i - 2], operatorsAndNumbers[i - 1]),
                        operatorsAndNumbers);
                    i = 0;
                }
                else if (operatorsAndNumbers[i] == "+")
                {
                    changeList(i, MyMath.Add(operatorsAndNumbers[i - 2], operatorsAndNumbers[i - 1]),
                        operatorsAndNumbers);
                    i = 0;
                }
                else if (operatorsAndNumbers[i] == "-")
                {
                    changeList(i, MyMath.Subtract(operatorsAndNumbers[i - 2], operatorsAndNumbers[i - 1]),
                        operatorsAndNumbers);
                    i = 0;
                }
            }
        }
        private void changeList(int index, float value, List<string> operatorsAndNumbersList)
        {
            operatorsAndNumbersList[index] = value.ToString();
            operatorsAndNumbersList.RemoveAt(index - 1);
            operatorsAndNumbersList.RemoveAt(index - 2);
        }
    }
}