using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Linq;
/*
using System.IO;
using System.Linq.Expressions;
*/
namespace sum_practise_2023
{
    
    public static class JsonSL
    {
        // 
        private static JsonSerializerOptions options = new JsonSerializerOptions { 
            WriteIndented = true,
            Converters = { new TypeDiscriminatorConverter<Config>() },
        };// probably needs custom type info resolver to work for deserialization
        public static string Serialize<T>(T data)
        {
            SerializeWrapper<T> wrapper = new SerializeWrapper<T>();
            wrapper.Object = data;
            return JsonSerializer.Serialize(wrapper, options);
        }

        // redundancy
        private struct SerializeWrapper<T>
        {
            public T Object { get; set; }
        }

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<SerializeWrapper<T>>(json, options).Object;
        }

        // кастомный конвертер, позволяет конвертировать дочерние типы корректно
        public class TypeDiscriminatorConverter<T> : JsonConverter<T> where T : ITypeDiscriminator
        {
            private readonly IEnumerable<Type> _types;

            public TypeDiscriminatorConverter()
            {
                var type = typeof(T);
                _types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
                    .ToList();
            }

            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }

                using (var jsonDocument = JsonDocument.ParseValue(ref reader))
                {
                    if (!jsonDocument.RootElement.TryGetProperty(nameof(ITypeDiscriminator.TypeDiscriminator), out var typeProperty))
                    {
                        throw new JsonException();
                    }

                    var type = _types.FirstOrDefault(x => x.Name == typeProperty.GetString());
                    if (type == null)
                    {
                        throw new JsonException();
                    }

                    var jsonObject = jsonDocument.RootElement.GetRawText();
                    var result = (T)JsonSerializer.Deserialize(jsonObject, type, options);

                    return result;
                }
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                JsonSerializer.Serialize(writer, (object)value, options);
            }
        }
        public interface ITypeDiscriminator
        {
            string TypeDiscriminator { get; }
        }
    }
}
