using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Com.Caimomo.Common
{
    public class JsonTool
    {
        /// <summary>
        /// 反序列化Json字符串到对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json, new CustomJsonConverter());
        }

        /// <summary>
        /// 反序列化Json字符串到对象
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

        /// <summary>
        /// 序列化对象到Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize<T>(T obj)
        {
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                //日期类型默认格式化处理
                setting.DateFormatString = "yyyy-MM-ddTHH:mm:ss";
                
                return setting;
            });
            return JsonConvert.SerializeObject(obj);

            /*
            using (var memoryStream = new MemoryStream())
            {
                using (var reader = new StreamReader(memoryStream))
                {
                    var serializer = new DataContractJsonSerializer(typeof(T));
                    serializer.WriteObject(memoryStream, obj);
                    memoryStream.Position = 0;
                    return reader.ReadToEnd();
                }
            }*/
        }

        /// <summary>
        /// 序列化对象到Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(Object obj)
        {
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                //日期类型默认格式化处理
                setting.DateFormatString = "yyyy-MM-ddTHH:mm:ss";

                return setting;
            });
            return JsonConvert.SerializeObject(obj);
            /*
            using (var memoryStream = new MemoryStream())
            {
                using (var reader = new StreamReader(memoryStream))
                {
                    var serializer = new DataContractJsonSerializer(obj.GetType());
                    serializer.WriteObject(memoryStream, obj);
                    memoryStream.Position = 0;
                    return reader.ReadToEnd();
                }
            }
            */
        }

        public static string DateTableToJson(DataTable tb)
        {
            if (tb == null || tb.Rows.Count == 0)
            {
                return "[]";
            }

            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            Dictionary<int, string> htColumns = new Dictionary<int, string>();
            Dictionary<int, Type> htColumnTypes = new Dictionary<int, Type>();
            for (int i = 0; i < tb.Columns.Count; i++)
            {
                htColumns.Add(i, tb.Columns[i].ColumnName.Trim());
                htColumnTypes.Add(i, tb.Columns[i].DataType);
            }

            for (int j = 0; j < tb.Rows.Count; j++)
            {
                if (j != 0)
                {
                    sbJson.Append(",");
                }
                sbJson.Append("{");
                for (int c = 0; c < tb.Columns.Count; c++)
                {
                    Type dataType = htColumnTypes[c];
                    if (tb.Rows[j][c] == null || tb.Rows[j][c] == DBNull.Value)
                    {
                        sbJson.Append("\"" + htColumns[c] + "\":null,");
                    }
                    else if (object.Equals(dataType, typeof(bool)))
                    {
                        sbJson.Append("\"" + htColumns[c] + "\":" + (((bool)tb.Rows[j][c]) ? 1 : 0) + ",");
                    }
                    else if (object.Equals(dataType, typeof(DateTime)))
                    {
                        sbJson.Append("\"" + htColumns[c] + "\":\"" + ((DateTime)tb.Rows[j][c]).ToString("yyyy-MM-ddTHH:mm:ss") + "\",");
                    }
                    else if (dataType.IsPrimitive || object.Equals(dataType, typeof(decimal)))
                    {
                        sbJson.Append("\"" + htColumns[c] + "\":" + tb.Rows[j][c].ToString() + ",");
                    }
                    else
                    {
                        sbJson.Append("\"" + htColumns[c] + "\":\"" + tb.Rows[j][c].ToString() + "\","); //.Replace(",", "，").Replace(":", "：").Replace("\r\n", "<br />") + "\",");
                    }
                }
                //sbJson.Append("\"index\":" + j.ToString()); //序号
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("}");
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }

        /// <summary>
        /// 将DataTable转换成Json字符串
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        //public static string DateTableToJson(DataTable tb)
        //{
        //    if (tb == null || tb.Rows.Count == 0)
        //    {
        //        return "";
        //    }

        //    string strName = "table";
        //    /*
        //    string strName = tb.TableName;
        //    if (strName.Trim().Length == 0)
        //    {
        //        strName = "table";
        //    }*/
        //    StringBuilder sbJson = new StringBuilder();
        //    sbJson.Append("{");
        //    sbJson.Append("\"" + strName + "\":[");
        //    Hashtable htColumns = new Hashtable();
        //    for (int i = 0; i < tb.Columns.Count; i++)
        //    {
        //        htColumns.Add(i, tb.Columns[i].ColumnName.Trim());
        //    }

        //    for (int j = 0; j < tb.Rows.Count; j++)
        //    {
        //        if (j != 0)
        //        {
        //            sbJson.Append(",");
        //        }
        //        sbJson.Append("{");
        //        for (int c = 0; c < tb.Columns.Count; c++)
        //        {
        //            sbJson.Append(htColumns[c].ToString() + ":\"" + tb.Rows[j][c].ToString().Replace(",", "，").Replace(":", "：").Replace("\r\n", "<br />") + "\",");
        //        }
        //        sbJson.Append("index:" + j.ToString()); //序号
        //        sbJson.Append("}");
        //    }
        //    sbJson.Append("]}");
        //    return sbJson.ToString();
        //}

        public static List<Dictionary<string, object>> ToDictionaryList(string jsonArrayStr)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            if (string.IsNullOrEmpty(jsonArrayStr))
                return result;

            JArray arrayObj = (JArray)JsonConvert.DeserializeObject(jsonArrayStr);
            foreach (JToken jo in arrayObj)
            {
                result.Add(JsonConvert.DeserializeObject<Dictionary<string, object>>(jo.ToString()));
            }

            return result;
        }

        public static Dictionary<string, object> ToDictionary(string jsonStr)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, Object>>(jsonStr);
        }

    }


    /// <summary>
    /// 自定义序列化和反序列化转换器
    /// </summary>
    public class CustomJsonConverter : JsonConverter
    {
        /// <summary>
        /// 用指定的值替换空值NULL
        /// </summary>
        public object PropertyNullValueReplaceValue { get; set; }

        /// <summary>
        /// 属性名称命名规则约定
        /// </summary>
        public ConverterPropertyNameCase PropertyNameCase { get; set; }

        /// <summary>
        /// 自定义属性名称映射规则
        /// </summary>
        public Func<string, string> ProperyNameConverter { get; set; }

        /// <summary>
        /// 从字符流读取对象
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            using (JTokenWriter writer = new JTokenWriter())
            {
                JsonReaderToJsonWriter(reader, writer,objectType);

                return writer.Token.ToObject(objectType);
            }
        }

        /// <summary>
        /// 通过对象写字符流
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jobject = JObject.FromObject(value);
            JsonReader reader = jobject.CreateReader();
            JsonReaderToJsonWriter(reader, writer,value.GetType());
        }

        public void JsonReaderToJsonWriter(JsonReader reader, JsonWriter writer,Type objectType)
        {            
            do
            {
                switch (reader.TokenType)
                {
                    case JsonToken.None:
                        break;
                    case JsonToken.StartObject:
                        writer.WriteStartObject();
                        break;
                    case JsonToken.StartArray:
                        writer.WriteStartArray();
                        break;
                    case JsonToken.PropertyName:
                        string propertyName = reader.Value.ToString();
                        writer.WritePropertyName(ConvertPropertyName(propertyName));
                        break;
                    case JsonToken.Comment:
                        writer.WriteComment((reader.Value != null) ? reader.Value.ToString() : null);
                        break;
                    case JsonToken.Integer:
                        writer.WriteValue(Convert.ToInt64(reader.Value, CultureInfo.InvariantCulture));
                        break;
                    case JsonToken.Float:
                        object value = reader.Value;
                        if (value is decimal)
                        {
                            writer.WriteValue((decimal)value);
                        }
                        else if (value is double)
                        {
                            writer.WriteValue((double)value);
                        }
                        else if (value is float)
                        {
                            writer.WriteValue((float)value);
                        }
                        else
                        {
                            writer.WriteValue(Convert.ToDouble(value, CultureInfo.InvariantCulture));
                        }
                        break;
                    case JsonToken.String:
                        writer.WriteValue(reader.Value.ToString());
                        break;
                    case JsonToken.Boolean:
                        writer.WriteValue(Convert.ToBoolean(reader.Value, CultureInfo.InvariantCulture));
                        break;
                    case JsonToken.Null:
                        PropertyInfo field = objectType.GetProperty(reader.Path, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                        if(! object.Equals(null,field) && (object.Equals(field.PropertyType,typeof(int)) || object.Equals(field.PropertyType, typeof(decimal)) || object.Equals(field.PropertyType, typeof(double)) || object.Equals(field.PropertyType, typeof(float)) || object.Equals(field.PropertyType,typeof(long)) ))
                            writer.WriteValue(0);
                        else if (this.PropertyNullValueReplaceValue != null)
                        {
                            writer.WriteValue(this.PropertyNullValueReplaceValue);
                        }
                        else
                        {
                            writer.WriteNull();
                        }
                        break;
                    case JsonToken.Undefined:
                        writer.WriteUndefined();
                        break;
                    case JsonToken.EndObject:
                        writer.WriteEndObject();
                        break;
                    case JsonToken.EndArray:
                        writer.WriteEndArray();
                        break;
                    case JsonToken.EndConstructor:
                        writer.WriteEndConstructor();
                        break;
                    case JsonToken.Date:
                        if (reader.Value is DateTimeOffset)
                        {
                            writer.WriteValue((DateTimeOffset)reader.Value);
                        }
                        else
                        {
                            writer.WriteValue(Convert.ToDateTime(reader.Value, CultureInfo.InvariantCulture));
                        }
                        break;
                    case JsonToken.Raw:
                        writer.WriteRawValue((reader.Value != null) ? reader.Value.ToString() : null);
                        break;
                    case JsonToken.Bytes:
                        if (reader.Value is Guid)
                        {
                            writer.WriteValue((Guid)reader.Value);
                        }
                        else
                        {
                            writer.WriteValue((byte[])reader.Value);
                        }
                        break;
                }
            } while (reader.Read());
        }

        /// <summary>
        /// 自定义转换器是否可用
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            if (objectType != typeof(DateTime))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据外部规则转换属性名
        /// </summary>
        private string ConvertPropertyName(string propertyName)
        {
            if (this.ProperyNameConverter != null)
            {
                propertyName = this.ProperyNameConverter(propertyName);
            }

            char[] chars = propertyName.ToCharArray();

            switch (this.PropertyNameCase)
            {
                case ConverterPropertyNameCase.None:
                    break;
                case ConverterPropertyNameCase.CamelCase:
                    for (int i = 0; i < chars.Length; i++)
                    {
                        bool hasNext = (i + 1 < chars.Length);
                        if (i > 0 && hasNext && !char.IsUpper(chars[i + 1]))
                            break;
                        chars[i] = char.ToLower(chars[i], CultureInfo.InvariantCulture);
                    }
                    break;
                case ConverterPropertyNameCase.PascalCase:
                    chars[0] = char.ToUpper(chars.First());
                    break;
            }

            return new string(chars);
        }
    }

    /// <summary>
    /// 属性命名规则
    /// </summary>
    public enum ConverterPropertyNameCase
    {
        /// <summary>
        /// 默认拼写法(默认首字母)
        /// </summary>
        None,

        /// <summary>
        /// 骆驼拼写法(首字母小写)
        /// </summary>
        CamelCase,

        /// <summary>
        /// 帕斯卡拼写法(首字母大写)
        /// </summary>
        PascalCase
    }

}