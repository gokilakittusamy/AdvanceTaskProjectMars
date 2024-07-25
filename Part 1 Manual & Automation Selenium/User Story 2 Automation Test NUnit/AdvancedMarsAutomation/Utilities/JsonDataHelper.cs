using AdvancedMarsAutomation.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMarsAutomation.Utilities
{
    public class JsonDataHelper
    {
        public static List<T> ReadJsonFile<T>(string filePath)
        {
            List<T> dataList = new List<T>();

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);

                try
                {
                    dataList = JsonConvert.DeserializeObject<List<T>>(jsonData);
                }
                catch (JsonException ex)
                {
                    // Handle deserialization errors if needed
                    Console.WriteLine("Error deserializing JSON: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File not found: " + filePath);
            }
            return dataList;
        }

    }
    public static class JsonEditDataHelper
    {
        public static Dictionary<string, List<SkillModel>> ReadEditSkillJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, List<SkillModel>>>(json);
        }

        public static Dictionary<string, List<LanguageModel>> ReadEditLanguageJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, List<LanguageModel>>>(json);
        }
    }
}
