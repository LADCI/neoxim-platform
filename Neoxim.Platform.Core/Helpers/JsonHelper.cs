using System.Text.Json;
using System.Text.Json.Serialization;

namespace Neoxim.Platform.Core.Helpers
{
    public static class JsonHelper
    {
        public static JsonSerializerOptions SerializerOptions => new()
        {
            MaxDepth = 0,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            Converters = {
                new JsonStringEnumConverter()
            }
        };
    }
}