﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiFilme.Shared.Converts
{
    public class DecimalJsonConverter : JsonConverter<decimal>
    {
        public DecimalJsonConverter()
        {
            
        }
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetDecimal();
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(Math.Round(value, 2));
        }
    }
}
