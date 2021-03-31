using System;

namespace ConsoleApp1
{
    class Program
    {
        private static string JsonPath = "../../resources/InputOutput.json";
        private static JsonInputOutput JsonInputOutputManager = new JsonInputOutput();
        static void Main()
        {
            Calculator calc = new Calculator();
            calc.Calculate(JsonInputOutputManager.ReadJson(JsonPath));
        }
    }
}