using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    public class JsonInputOutput
    {
        internal List<string> ReadText(string path)
        {
            var InputString = File.ReadLines(path).ToList(); 
            return InputString; 
        }

        internal void WriteJson(string path, string value)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(value);
            }
        }
        
    }
}