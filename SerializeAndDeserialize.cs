using Newtonsoft.Json;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YMAL_to_JSON_converter
{
    public static class SerializeAndDeserialize
    {
        public static string Serialize<T>(T obj)
        {
            var serializer = new SerializerBuilder().Build();

            return serializer.Serialize(obj);
        }
        public static T Deserialize<T>(string yaml)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            return deserializer.Deserialize<T>(yaml);
        }
        public static string SerializeToJson(string yaml)
        {
            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize(yaml);

            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            serializer.Serialize(writer, yamlObject);
            return sb.ToString();    
            // var serializer = new SerializerBuilder()
            //     .JsonCompatible().Build();
            // return serializer.Serialize(yamlObject);
        }
    }

}