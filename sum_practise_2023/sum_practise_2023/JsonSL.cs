using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
/*
using System.IO;
using System.Linq.Expressions;
*/
namespace sum_practise_2023
{
    public static class JsonSL
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true};// probably needs custom type info resolver to work for deserialization
        public static string Serialize<T>(T data)
        {
            
            return JsonSerializer.Serialize(data, options);
        }

        public static T Deserialize<T>(string json)
        {
            // doesnt works right now, but will be fixed later probaly)
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
