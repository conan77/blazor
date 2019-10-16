using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HuaDan
{
    public class DBOperator
    {
        /// <summary>
        /// DataTable转换实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> TableToList<T>(DataTable dt) where T : class,new()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                PropertyInfo[] pArray = type.GetProperties();
                T entity = new T();
                foreach (PropertyInfo p in pArray)
                {
                    try
                    {
                        if (row[p.Name] != DBNull.Value)
                        {
                            if (row[p.Name] is Int64)
                            {
                                p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                                continue;
                            }
                            p.SetValue(entity, row[p.Name], null);
                        }
                    }
                    catch (Exception ex) { continue; }
                }
                list.Add(entity);
            }
            return list;
        }
    }
}
