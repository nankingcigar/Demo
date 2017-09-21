using Abp.Json;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Nankingcigar.Demo.Core.Extension.Json.Converter
{
    public class DemoDateTimeConverter : AbpDateTimeConverter
    {
        public DemoDateTimeConverter()
        {
            this.DateTimeStyles = (DateTimeStyles)(-1);
        }

        private static readonly DateTime Time1970 = (new DateTime(1970, 1, 1)).ToUniversalTime();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if ((int)this.DateTimeStyles == -1)
            {
                long? ticks = null;
                if (value is DateTime dateTime)
                {
                    ticks = dateTime.ToUniversalTime().Ticks - Time1970.Ticks;
                }
                else if (value is DateTimeOffset dateTimeOffset)
                {
                    ticks = dateTimeOffset.UtcDateTime.TimeOfDay.Ticks - Time1970.Ticks;
                }
                if (ticks.HasValue)
                {
                    ticks = (long)(TimeSpan.FromTicks(ticks.Value).TotalMilliseconds);
                }
                writer.WriteValue(ticks);
            }
            else
            {
                base.WriteJson(writer, value, serializer);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if ((int)this.DateTimeStyles == -1)
            {
                if (reader.TokenType == JsonToken.Integer)
                {
                    bool flag;
                    if (objectType.IsValueType)
                    {
                        if (objectType.IsGenericType)
                        {
                            flag = objectType.GetGenericTypeDefinition() == typeof(Nullable<>);
                        }
                        else
                        {
                            flag = false;
                        }
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
            }
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}