﻿using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BasePackageDish:IEntity
    {
        public string Uid { get; set; }
        public string PackageId { get; set; }
        public string DishId { get; set; }
        public string DishName { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal DishNumber { get; set; }
        public decimal DishTzs { get; set; }
        public string ZuoFaId { get; set; }
        public string ZuoFaName { get; set; }
        public bool IfSelect { get; set; }
        public int DisplayId { get; set; }
        public int StoreId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }

        /// <summary>
        /// 得到主键
        /// </summary>
        /// <returns></returns>
        public object GetPrimaryKey()
        {
            return this.Uid;
        }

        /// <summary>
        /// 设置主键
        /// </summary>
        /// <param name="value">主键值</param>
        public void SetPrimaryKey(object value)
        {
            this.Uid = value.ToString();
        }
    }
}