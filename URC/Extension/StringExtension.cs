using System.Text.Json;

namespace URC.Extension
{
    public static class StringExtension
    {
        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}