using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    public class JsonInputOutput
    {

        internal string ReadJson(string path)
        {
            string InputString;   
            using (StreamReader streamReader = new StreamReader(path))
            {
                string json = streamReader.ReadToEnd();
                InputString = JsonConvert.DeserializeObject<string>(json);
            }
            return InputString; 
        }
    }
}