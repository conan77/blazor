using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HuaDan
{
    public static class EntityUtil
    {
        /// <summary>
        /// DataTable 转化为对象集合
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<TEntity> ToList<TEntity>(DataTable dt) where TEntity : new()
        {
            List<TEntity> listEntity = new List<TEntity>();
            SetList(listEntity, dt);
            if (listEntity.Count == 0)
            {
				return listEntity;
            }
            return listEntity;
        }

        /// <summary>
        /// 把DataTable中数据赋值给一个List对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="list"></param>
        /// <param name="dt"></param>
        public static void SetList<TEntity>(List<TEntity> list, DataTable dt) where TEntity : new()
        {
            if (dt == null || dt.Rows.Count <= 0) return;
            int fieldCount = dt.Columns.Count;
            foreach (DataRow item in dt.Rows)
            {
                TEntity t = (TEntity)Activator.CreateInstance(typeof(TEntity));
                for (int i = 0; i < fieldCount; i++)
                {
                    PropertyInfo field = t.GetType().GetProperty(dt.Columns[i].ColumnName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                    if (field == null) continue;
                    if (!field.CanWrite) continue;//如果字段不可写，则跳过
                    if (item[i] == null || Convert.IsDBNull(item[i]))
                    {
                        field.SetValue(t, null, null);
                    }
                    else
                    {
                        field.SetValue(t, item[i], null);
                    }
                }
                list.Add(t);
            }
        }

        /// <summary>
        /// List转Datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
