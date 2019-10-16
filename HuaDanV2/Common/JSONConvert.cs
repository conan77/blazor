using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace HuaDan
{
    public class JSONConvert
    {
        public static string serialToJson(Object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static Dictionary<string, object> ToDictionary(DataRow dr)
        {
            Dictionary<string, object> dct = new Dictionary<string, object>(); ;
            foreach (DataColumn dc in dr.Table.Columns)
            {
                dct.Add(dc.ColumnName, dr[dc.ColumnName]);
            }
            return dct;
        }

        public static string ToJsonString(object obj)
        {
            if (object.Equals(obj, null))
                return "";
            JavaScriptSerializer jserizor = new JavaScriptSerializer();
            jserizor.RegisterConverters(new JavaScriptConverter[]
                 { new DateTimeConverter()
                 });
            jserizor.MaxJsonLength = 102400000;
            return jserizor.Serialize(obj);
        }

        #region 序列化用到的类
        public class DateTimeConverter : JavaScriptConverter
        {

            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                return new JavaScriptSerializer().ConvertToType(dictionary, type);
            }

            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                if (obj is DateTime)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    return new CustomString(((DateTime)obj).ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                else if (obj is TimeSpan)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    return new CustomString(((TimeSpan)obj).ToString(@"hh\:mm\:ss"));
                }
                else
                    return null;
            }

            public override IEnumerable<Type> SupportedTypes
            {
                get
                {
                    return new[] { typeof(DateTime), typeof(TimeSpan) };
                }
            }

        }

        internal class CustomString : Uri, IDictionary<string, object>
        {
            public CustomString(string str)
                : base(str, UriKind.Relative)
            {

            }

            void IDictionary<string, object>.Add(string key, object value)
            {
                throw new NotImplementedException();
            }

            bool IDictionary<string, object>.ContainsKey(string key)
            {
                throw new NotImplementedException();
            }

            ICollection<string> IDictionary<string, object>.Keys
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            bool IDictionary<string, object>.Remove(string key)
            {
                throw new NotImplementedException();
            }

            bool IDictionary<string, object>.TryGetValue(string key, out object value)
            {
                throw new NotImplementedException();
            }

            ICollection<object> IDictionary<string, object>.Values
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            object IDictionary<string, object>.this[string key]
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }

            void ICollection<KeyValuePair<string, object>>.Clear()
            {
                throw new NotImplementedException();
            }

            bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }

            void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            int ICollection<KeyValuePair<string, object>>.Count
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            bool ICollection<KeyValuePair<string, object>>.IsReadOnly
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
            {
                throw new NotImplementedException();
            }

            IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

      
        #endregion
    }
}
