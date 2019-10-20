using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class HisOrderInfo:IEntity
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderCode { get; set; }
        public string Tmlcid { get; set; }
        public bool IsMember { get; set; }
        public bool IsFromWeb { get; set; }
        public int PriceType { get; set; }
        public int TotalPeopleNum { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public int MemberLevel { get; set; }
        public byte OrderStatus { get; set; }
        public string PreordainTypeId { get; set; }
        public string PreordainId { get; set; }
        public decimal OrderYuanShiMoney { get; set; }
        public decimal OrderCostMoney { get; set; }
        public decimal OrderShiJiMoney { get; set; }
        public decimal OrderZheKouMoney { get; set; }
        public decimal OrderYouMianMoney { get; set; }
        public decimal OrderMoLingMoney { get; set; }
        public decimal OrderMemberMoney { get; set; }
        public decimal FaPiaoMoney { get; set; }
        public string OrderDesc { get; set; }
        public bool IsMerge { get; set; }
        public string MergeTag { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int FanJieSuanNum { get; set; }
        public int? SongDanNum { get; set; }
        public int? Source { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string AddName { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public string TaiKaHao { get; set; }
        public string JieSuanUserId { get; set; }
        public string JieSuanUserName { get; set; }
        public DateTime? JieSuanTime { get; set; }
        public string BanCiHaoId { get; set; }
        public string LianTaiMark { get; set; }
        public bool? IsWaiMai { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string Bak3 { get; set; }
        public string ManagerId { get; set; }
        public string ManagerName { get; set; }
        public bool? IsEnterPayQueue { get; set; }
        public string Bak4 { get; set; }
        public string Bak5 { get; set; }
        public string Bak6 { get; set; }
        public string Bak7 { get; set; }
        public decimal OrderFenTanShiShouMoney { get; set; }
        public int ReportFormat { get; set; }
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
