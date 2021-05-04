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
            //TODO create output file if it doesnt exist yet
            File.WriteAllText(path, value);
        }
        
    }
}