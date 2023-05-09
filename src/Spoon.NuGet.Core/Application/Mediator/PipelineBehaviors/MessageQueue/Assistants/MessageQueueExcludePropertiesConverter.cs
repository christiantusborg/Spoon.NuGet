namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue.Assistants;

using System.Text.Json;
using System.Text.Json.Serialization;
using Attributes;

/// <summary>
///   Class ExcludePropertiesConverter.
/// </summary>
public class MessageQueueExcludePropertiesConverter : JsonConverter<object>
{
    /// <summary>
    ///  Determines whether this instance can convert the specified object type.
    /// </summary>
    /// <param name="objectType"></param>
    /// <returns></returns>
    public override bool CanConvert(Type objectType)
    {
        return true;
    }

    /// <summary>
    ///  Reads and converts the JSON to type.
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return null;
    }
    
    /// <summary>
    ///  Writes the JSON representation of the object.
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        foreach (var prop in value.GetType().GetProperties())
        {
            if (prop.CustomAttributes.Any(x => x.AttributeType == typeof(MessageQueuePropertyExcludeAttribute)))
            {
                continue;
            }

            writer.WritePropertyName(prop.Name);
            JsonSerializer.Serialize(writer, prop.GetValue(value), prop.PropertyType, options);
        }

        writer.WriteEndObject();
    }
}