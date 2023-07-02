using System.IO;
using System.Text.Json;

namespace sum_practise_2023
{
    public static class JsonSL
    {
        public static string Serialize<T>(T data)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(data, options);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
