using System; 

namespace ConsoleApp1
{
    public class Parser
    {
        private string[] NumberCharArray = {"0","1","2","3","4","5","6","7","8","9","."}; 
        private string[] OpperatorNameArray = {"+","-","*","/"};
        private Calculator calc  = new Calculator();
        private int i = 0; 
        
        public void Parse(string expresion)
        {
            
            for (; i < expresion.Length; i++)
            {
                
                string substring = expresion.Substring(i, 1);
                
                if (substring == "(")
                {
                    EvaluateString(expresion, i);
                }
                
                foreach (var numberChar in NumberCharArray)
                {
                    if (numberChar == substring)
                    {
                        i++; 
                        string temp = substring;
                        for (; i < expresion.Length; i++)
                        {
                            substring = expresion.Substring(i, 1);
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
                        
                        //Do something with the gotten number 
                        Console.WriteLine(temp);
                        break;
                    }
                }
                GetOpperator(substring);
            }
        }

        private void EvaluateString(string expresion, int entryPoint)
        {
            var z = entryPoint;
            for (; z < expresion.Length; z++)
            {
                var tempSubstring = expresion.Substring(z, 1);
                if (tempSubstring == ")")
                {
                    string bracketSubstring = expresion.Substring(entryPoint + 1, z - entryPoint - 1);

                    // TODO calculate the bracketSubstring (it should return a value that can be used later)
                    Console.WriteLine("(");
                    calc.Calculate(bracketSubstring);
                    Console.WriteLine(")");
                    i = z; 
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
                    Console.WriteLine(mathOperator);
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