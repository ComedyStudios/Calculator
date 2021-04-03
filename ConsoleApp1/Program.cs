using System;

namespace ConsoleApp1
{
    class Program
    {
        private static string JsonInputPath = "../../resources/Input.json";
        private static string JsonOutputPath = "../../resources/Output.json";
        private static JsonInputOutput JsonInputOutputManager = new JsonInputOutput();
        static void Main()
        {
            Calculator calc = new Calculator();
            var input = JsonInputOutputManager.ReadJson(JsonInputPath);
            var result = calc.Calculate(input);
            JsonInputOutputManager.WriteJson(JsonOutputPath,result);
            Console.WriteLine(input+" = "+ result);
            Console.ReadLine();
        }
    }
}