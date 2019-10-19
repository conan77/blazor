using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazoriseDemo.Shared;

namespace BlazoriseDemo.Server
{
    public partial class _182810Context : DbContext
    {

        public _182810Context(DbContextOptions<_182810Context> options)
            : base(options)
        {
        }

        public virtual DbQuery<AbnormalSettlement> AbnormalSettlement { get; set; }
        public virtual DbQuery<ActivityQuanList> ActivityQuanList { get; set; }
        public virtual DbQuery<BanquetManagement> BanquetManagement { get; set; }
        public virtual DbQuery<BaseActivity> BaseActivity { get; set; }
        public virtual DbQuery<BaseActivityDetail> BaseActivityDetail { get; set; }
        public virtual DbQuery<BaseCaiWuKeMu> BaseCaiWuKeMu { get; set; }
        public virtual DbQuery<BaseCaiWuKeMuDiYongQuan> BaseCaiWuKeMuDiYongQuan { get; set; }
        public virtual DbQuery<BaseCaiWuKeMuTemplate> BaseCaiWuKeMuTemplate { get; set; }
        public virtual DbQuery<BaseCaiWuKeMuType> BaseCaiWuKeMuType { get; set; }
        public virtual DbQuery<BaseCanBie> BaseCanBie { get; set; }
        public virtual DbQuery<BaseDepartment> BaseDepartment { get; set; }
        public virtual DbQuery<BaseDictionary> BaseDictionary { get; set; }
        public virtual DbQuery<BaseDish> BaseDish { get; set; }
        public virtual DbQuery<BaseDishCuXiao> BaseDishCuXiao { get; set; }
        public virtual DbQuery<BaseDishCuXiaoDetail> BaseDishCuXiaoDetail { get; set; }
        public virtual DbQuery<BaseDishPeiCai> BaseDishPeiCai { get; set; }
        public virtual DbQuery<BaseDishStatisticsType> BaseDishStatisticsType { get; set; }
        public virtual DbQuery<BaseDishType> BaseDishType { get; set; }
        public virtual DbQuery<BaseDishZuoFa> BaseDishZuoFa { get; set; }
        public virtual DbQuery<BaseFeiShiShouFenTan> BaseFeiShiShouFenTan { get; set; }
        public virtual DbQuery<BaseJueSe> BaseJueSe { get; set; }
        public virtual DbQuery<BaseKouBeiDish> BaseKouBeiDish { get; set; }
        public virtual DbQuery<BaseKouBeiDishPeiLiao> BaseKouBeiDishPeiLiao { get; set; }
        public virtual DbQuery<BaseKouWei> BaseKouWei { get; set; }
        public virtual DbQuery<BaseMdbrand> BaseMdbrand { get; set; }
        public virtual DbQuery<BasePackageDish> BasePackageDish { get; set; }
        public virtual DbQuery<BasePackageNotUsed> BasePackageNotUsed { get; set; }
        public virtual DbQuery<BasePackageReplaceDish> BasePackageReplaceDish { get; set; }
        public virtual DbQuery<BasePrinter> BasePrinter { get; set; }
        public virtual DbQuery<BaseSystemConfig> BaseSystemConfig { get; set; }
        public virtual DbQuery<BaseSystemConfigDefault> BaseSystemConfigDefault { get; set; }
        public virtual DbQuery<BaseTingMianLouCeng> BaseTingMianLouCeng { get; set; }
        public virtual DbQuery<BaseTmlcdish> BaseTmlcdish { get; set; }
        public virtual DbQuery<BaseUserDepartment> BaseUserDepartment { get; set; }
        public virtual DbQuery<BaseUserJueSe> BaseUserJueSe { get; set; }
        public virtual DbQuery<BaseUserRight> BaseUserRight { get; set; }
        public virtual DbQuery<BaseWaiMaiManage> BaseWaiMaiManage { get; set; }
        public virtual DbQuery<BaseWeiXinDish> BaseWeiXinDish { get; set; }
        public virtual DbQuery<BaseWeiXinDishType> BaseWeiXinDishType { get; set; }
        public virtual DbQuery<BaseXiaoFeiLeiXing> BaseXiaoFeiLeiXing { get; set; }
        public virtual DbQuery<BaseXiaoFeiLeiXingDetail> BaseXiaoFeiLeiXingDetail { get; set; }
        public virtual DbQuery<BaseZheKouCwkm> BaseZheKouCwkm { get; set; }
        public virtual DbQuery<BaseZheKouDetail> BaseZheKouDetail { get; set; }
        public virtual DbQuery<BaseZheKouRight> BaseZheKouRight { get; set; }
        public virtual DbQuery<BaseZheKouTemplate> BaseZheKouTemplate { get; set; }
        public virtual DbQuery<BaseZhuoTai> BaseZhuoTai { get; set; }
        public virtual DbQuery<BaseZuoFa> BaseZuoFa { get; set; }
        public virtual DbQuery<BaseZuoFaType> BaseZuoFaType { get; set; }
        public virtual DbQuery<CccheckDish> CccheckDish { get; set; }
        public virtual DbQuery<CccheckDishDetail> CccheckDishDetail { get; set; }
        public virtual DbQuery<CcorderDish> CcorderDish { get; set; }
        public virtual DbQuery<CcreplenishRecord> CcreplenishRecord { get; set; }
        public virtual DbQuery<Cctemplate> Cctemplate { get; set; }
        public virtual DbQuery<CctemplateDetail> CctemplateDetail { get; set; }
        public virtual DbQuery<ContractManagement> ContractManagement { get; set; }
        public virtual DbQuery<DailyBalanceRecord> DailyBalanceRecord { get; set; }
        public virtual DbQuery<DishItemBg> DishItemBg { get; set; }
        public virtual DbQuery<HandlingWeiXinOrder> HandlingWeiXinOrder { get; set; }
        public virtual DbQuery<HandlingWeiXinPreordainOrder> HandlingWeiXinPreordainOrder { get; set; }
        public virtual DbQuery<HisOrderBanCi> HisOrderBanCi { get; set; }
        public virtual DbQuery<HisOrderFanJieSuan> HisOrderFanJieSuan { get; set; }
        public virtual DbQuery<HisOrderGuQing> HisOrderGuQing { get; set; }
        public virtual DbQuery<HisOrderHuaDan> HisOrderHuaDan { get; set; }
        public virtual DbQuery<HisOrderInfo> HisOrderInfo { get; set; }
        public virtual DbQuery<HisOrderJieSuan> HisOrderJieSuan { get; set; }
        public virtual DbQuery<HisOrderPackageDishDetail> HisOrderPackageDishDetail { get; set; }
        public virtual DbQuery<HisOrderShouQuanRecords> HisOrderShouQuanRecords { get; set; }
        public virtual DbQuery<HisOrderTuiCaiDish> HisOrderTuiCaiDish { get; set; }
        public virtual DbQuery<HisOrderWaiMaiAddress> HisOrderWaiMaiAddress { get; set; }
        public virtual DbQuery<HisOrderZengSongDish> HisOrderZengSongDish { get; set; }
        public virtual DbQuery<HisOrderZheKou> HisOrderZheKou { get; set; }
        public virtual DbQuery<HisOrderZhuoTai> HisOrderZhuoTai { get; set; }
        public virtual DbQuery<HisOrderZhuoTaiDish> HisOrderZhuoTaiDish { get; set; }
        public virtual DbQuery<HisPreordain> HisPreordain { get; set; }
        public virtual DbQuery<HisPreordainBanquet> HisPreordainBanquet { get; set; }
        public virtual DbQuery<HisRefusedWaiMaiOrder> HisRefusedWaiMaiOrder { get; set; }
        public virtual DbQuery<JiaoHaoRecord> JiaoHaoRecord { get; set; }
        public virtual DbQuery<KouBeiAfterPayOrders> KouBeiAfterPayOrders { get; set; }
        public virtual DbQuery<KouBeiOrder> KouBeiOrder { get; set; }
        public virtual DbQuery<LocalParams> LocalParams { get; set; }
        public virtual DbQuery<LoginInfo> LoginInfo { get; set; }
        public virtual DbQuery<MachineJiaoHaoRecord> MachineJiaoHaoRecord { get; set; }
        public virtual DbQuery<OrderBanCi> OrderBanCi { get; set; }
        public virtual DbQuery<OrderFanJieSuan> OrderFanJieSuan { get; set; }
        public virtual DbQuery<OrderGuQing> OrderGuQing { get; set; }
        public virtual DbQuery<OrderHuaDan> OrderHuaDan { get; set; }
        public virtual DbQuery<OrderInfo> OrderInfo { get; set; }
        public virtual DbQuery<OrderInfoForKouBei> OrderInfoForKouBei { get; set; }
        public virtual DbQuery<OrderJieSuan> OrderJieSuan { get; set; }
        public virtual DbQuery<OrderPackageDishDetail> OrderPackageDishDetail { get; set; }
        public virtual DbQuery<OrderPayMethod> OrderPayMethod { get; set; }
        public virtual DbQuery<OrderShouQuanRecords> OrderShouQuanRecords { get; set; }
        public virtual DbQuery<OrderTuiCaiDish> OrderTuiCaiDish { get; set; }
        public virtual DbQuery<OrderWaiMaiAddress> OrderWaiMaiAddress { get; set; }
        public virtual DbQuery<OrderZengSongDish> OrderZengSongDish { get; set; }
        public virtual DbQuery<OrderZheKou> OrderZheKou { get; set; }
        public virtual DbQuery<OrderZhuoTai> OrderZhuoTai { get; set; }
        public virtual DbQuery<OrderZhuoTaiDish> OrderZhuoTaiDish { get; set; }
        public virtual DbQuery<PhoneCallRecord> PhoneCallRecord { get; set; }
        public virtual DbQuery<PreordainDishTmp> PreordainDishTmp { get; set; }
        public virtual DbQuery<PreorderDish> PreorderDish { get; set; }
        public virtual DbQuery<PreorderPackageDish> PreorderPackageDish { get; set; }
        public virtual DbQuery<PrintHistory> PrintHistory { get; set; }
        public virtual DbQuery<PrintHistoryCount> PrintHistoryCount { get; set; }
        public virtual DbQuery<SysBiaoQian> SysBiaoQian { get; set; }
        public virtual DbQuery<SysBiaoQianDetail> SysBiaoQianDetail { get; set; }
        public virtual DbQuery<SysGroupInfo> SysGroupInfo { get; set; }
        public virtual DbQuery<SysGroupUser> SysGroupUser { get; set; }
        public virtual DbQuery<SysMedias> SysMedias { get; set; }
        public virtual DbQuery<SysRight> SysRight { get; set; }
        public virtual DbQuery<SysStoreInfo> SysStoreInfo { get; set; }
        public virtual DbQuery<SysUnit> SysUnit { get; set; }
        public virtual DbQuery<SysWelcome> SysWelcome { get; set; }
        public virtual DbQuery<TransferDishRecord> TransferDishRecord { get; set; }
        public virtual DbQuery<UploadedData> UploadedData { get; set; }
        public virtual DbQuery<UploadedDataTmp> UploadedDataTmp { get; set; }
        public virtual DbQuery<WaiMaiDishMap> WaiMaiDishMap { get; set; }
        public virtual DbQuery<WuXianLsh> WuXianLsh { get; set; }
        public virtual DbQuery<Wxorder> Wxorder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderBanCi>()
                .HasKey(p => p.Uid);

        }
    }
}
