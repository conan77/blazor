using System;
using System.Collections.Generic;
using System.Text;

namespace com.caimomo.Dapper.Base
{
    public class EntityBase<TIdType,TKey> where TKey : IEntityKey , IEntity 
    {
        /// <summary>
        /// 得到主键
        /// </summary>
        /// <param name="idName">主键</param>
        /// <returns>主键值</returns>
        public TIdType GetEntityId(string idName)
        {
            TIdType value = default(TIdType);
            try
            {
                Type ts = this.GetType();
                object o = ts.GetProperty(idName).GetValue(this, null);
                if(o!=null)
                {
                    value = (TIdType)o;
                }
            }
            catch
            {
            }
            return value;
        }

        /// <summary>
        /// 设置Id值
        /// </summary>
        /// <param name="idname">主键</param>
        /// <param name="idvalue">主键值</param>
        public bool SetEntityId(string idname, TIdType idvalue)
        {
            try
            {
                Type ts = idvalue.GetType();
                object v = Convert.ChangeType(idvalue, ts.GetProperty(idname).PropertyType);
                ts.GetProperty(idname).SetValue(idvalue, v, null);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
