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

/*TODO (7*7-9)+60 
(7* 7-   9)+60
(7.7-4)/5
(7,7-4)/5
7.7-4-)5
(7*7-9)+((60)
4-3*-456+ (24)
+25-56
+25rte-56
+25rte-56

a=5*5
b=6
a*6/b
a*6/c
*/

//TODO read each line as new expression 