using System;
using Abp.Json;
using Newtonsoft.Json;

namespace Nankingcigar.Demo.Web.Models
{
    public class DemoDateTimeConverter: AbpDateTimeConverter
    {
        private static readonly DateTime Time1970 = (new DateTime(1970, 1, 1)).ToUniversalTime();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long? ticks = null;
            if (value is DateTime)
            {
                DateTime dateTime = (DateTime)value;
                ticks = dateTime.ToUniversalTime().Ticks - Time1970.Ticks;
            }
            else if (value is DateTimeOffset)
            {
                DateTimeOffset dateTimeOffset = (DateTimeOffset)value;
                ticks = dateTimeOffset.UtcDateTime.TimeOfDay.Ticks - Time1970.Ticks;
            }
            if (ticks.HasValue)
                ticks = (long)(TimeSpan.FromTicks(ticks.Value).TotalMilliseconds);
            writer.WriteValue(ticks);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                bool flag;
                if (objectType.IsValueType)
                {
                    if (objectType.IsGenericType)
                        flag = objectType.GetGenericTypeDefinition() == typeof(Nullable<>);
                    else
                        flag = false;
                }
                else
                {
                    flag = true;
                }
                Type type = flag ? Nullable.GetUnderlyingType(objectType) : objectType;
                if (type == typeof(DateTimeOffset))
                {
                    return new DateTimeOffset(Time1970).AddMilliseconds((long)reader.Value);
                }
                return Time1970.AddMilliseconds((long)reader.Value);
            }
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}