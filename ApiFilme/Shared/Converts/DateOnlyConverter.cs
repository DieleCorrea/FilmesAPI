using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiFilme.Shared.Converts
{
    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string _serializationFormat;

        public DateOnlyConverter(string? serializationFormat)
        {
            _serializationFormat = serializationFormat ?? "dd-MM-yyyy";
        }
        public DateOnlyConverter()
        {

        }


        public override DateOnly Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.Parse(value!, new CultureInfo("pt-br"));
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_serializationFormat));
        }
    }
}
