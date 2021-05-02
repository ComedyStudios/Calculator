using System;

namespace ConsoleApp1
{
    class Program
    {
        private static string JsonInputPath = "../../resources/Input.txt";
        private static string JsonOutputPath = "../../resources/Output.txt";
        private static JsonInputOutput JsonInputOutputManager = new JsonInputOutput();
        static void Main()
        {
            Calculator calc = new Calculator();
            
            var input = JsonInputOutputManager.ReadText(JsonInputPath);
            if (input != null)
            {
                var result = calc.Calculate(input);
                JsonInputOutputManager.WriteJson(JsonOutputPath,result);
                Console.WriteLine(input+" = "+ result);
                Console.ReadLine();
            }
            else Console.WriteLine("the Input is Empty");
        }
    }
}