using System.Text.Json;

namespace UdpChat.Services;
public class JsonConverter
{
    public string Serialize<T>(T obj) => JsonSerializer.Serialize(obj);
    public T? Desirialize<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString);
}