using System.IO;

namespace ConsoleApp1
{
    public class JsonInputOutput
    {
        internal string ReadText(string path)
        {
            string InputString = File.ReadAllText(path); 
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