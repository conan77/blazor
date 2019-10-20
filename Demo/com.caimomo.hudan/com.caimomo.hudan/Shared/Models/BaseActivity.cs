﻿using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseActivity:IEntity
    {
        public string Uid { get; set; }
        public string ActivityName { get; set; }
        public int ActivityType { get; set; }
        public bool IsOverLay { get; set; }
        public bool IsZheKou { get; set; }
        public bool IsEnable { get; set; }
        public int StoreId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool? IsLongTerm { get; set; }
        public string DishTypeIds { get; set; }
        public string DishIds { get; set; }
        public string CanBieIds { get; set; }
        public string Weeks { get; set; }
        public decimal ActivityPrice { get; set; }
        public decimal ActivitySubtractPrice { get; set; }
        public decimal ActivitySubtractMaxPrice { get; set; }
        public string ZongBuUid { get; set; }
        public int MaxCount { get; set; }
        public int ActivityShare { get; set; }
        public int OptionalCount { get; set; }

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
