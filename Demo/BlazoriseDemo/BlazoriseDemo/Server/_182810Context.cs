using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazoriseDemo.Shared
{
    public partial class _182810Context : DbContext
    {
        public _182810Context()
        {
        }

        public _182810Context(DbContextOptions<_182810Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AbnormalSettlement> AbnormalSettlement { get; set; }
        public virtual DbSet<ActivityQuanList> ActivityQuanList { get; set; }
        public virtual DbSet<BanquetManagement> BanquetManagement { get; set; }
        public virtual DbSet<BaseActivity> BaseActivity { get; set; }
        public virtual DbSet<BaseActivityDetail> BaseActivityDetail { get; set; }
        public virtual DbSet<BaseCaiWuKeMu> BaseCaiWuKeMu { get; set; }
        public virtual DbSet<BaseCaiWuKeMuDiYongQuan> BaseCaiWuKeMuDiYongQuan { get; set; }
        public virtual DbSet<BaseCaiWuKeMuTemplate> BaseCaiWuKeMuTemplate { get; set; }
        public virtual DbSet<BaseCaiWuKeMuType> BaseCaiWuKeMuType { get; set; }
        public virtual DbSet<BaseCanBie> BaseCanBie { get; set; }
        public virtual DbSet<BaseDepartment> BaseDepartment { get; set; }
        public virtual DbSet<BaseDictionary> BaseDictionary { get; set; }
        public virtual DbSet<BaseDish> BaseDish { get; set; }
        public virtual DbSet<BaseDishCuXiao> BaseDishCuXiao { get; set; }
        public virtual DbSet<BaseDishCuXiaoDetail> BaseDishCuXiaoDetail { get; set; }
        public virtual DbSet<BaseDishPeiCai> BaseDishPeiCai { get; set; }
        public virtual DbSet<BaseDishStatisticsType> BaseDishStatisticsType { get; set; }
        public virtual DbSet<BaseDishType> BaseDishType { get; set; }
        public virtual DbSet<BaseDishZuoFa> BaseDishZuoFa { get; set; }
        public virtual DbSet<BaseFeiShiShouFenTan> BaseFeiShiShouFenTan { get; set; }
        public virtual DbSet<BaseJueSe> BaseJueSe { get; set; }
        public virtual DbSet<BaseKouBeiDish> BaseKouBeiDish { get; set; }
        public virtual DbSet<BaseKouBeiDishPeiLiao> BaseKouBeiDishPeiLiao { get; set; }
        public virtual DbSet<BaseKouWei> BaseKouWei { get; set; }
        public virtual DbSet<BaseMdbrand> BaseMdbrand { get; set; }
        public virtual DbSet<BasePackageDish> BasePackageDish { get; set; }
        public virtual DbSet<BasePackageNotUsed> BasePackageNotUsed { get; set; }
        public virtual DbSet<BasePackageReplaceDish> BasePackageReplaceDish { get; set; }
        public virtual DbSet<BasePrinter> BasePrinter { get; set; }
        public virtual DbSet<BaseSystemConfig> BaseSystemConfig { get; set; }
        public virtual DbSet<BaseSystemConfigDefault> BaseSystemConfigDefault { get; set; }
        public virtual DbSet<BaseTingMianLouCeng> BaseTingMianLouCeng { get; set; }
        public virtual DbSet<BaseTmlcdish> BaseTmlcdish { get; set; }
        public virtual DbSet<BaseUserDepartment> BaseUserDepartment { get; set; }
        public virtual DbSet<BaseUserJueSe> BaseUserJueSe { get; set; }
        public virtual DbSet<BaseUserRight> BaseUserRight { get; set; }
        public virtual DbSet<BaseWaiMaiManage> BaseWaiMaiManage { get; set; }
        public virtual DbSet<BaseWeiXinDish> BaseWeiXinDish { get; set; }
        public virtual DbSet<BaseWeiXinDishType> BaseWeiXinDishType { get; set; }
        public virtual DbSet<BaseXiaoFeiLeiXing> BaseXiaoFeiLeiXing { get; set; }
        public virtual DbSet<BaseXiaoFeiLeiXingDetail> BaseXiaoFeiLeiXingDetail { get; set; }
        public virtual DbSet<BaseZheKouCwkm> BaseZheKouCwkm { get; set; }
        public virtual DbSet<BaseZheKouDetail> BaseZheKouDetail { get; set; }
        public virtual DbSet<BaseZheKouRight> BaseZheKouRight { get; set; }
        public virtual DbSet<BaseZheKouTemplate> BaseZheKouTemplate { get; set; }
        public virtual DbSet<BaseZhuoTai> BaseZhuoTai { get; set; }
        public virtual DbSet<BaseZuoFa> BaseZuoFa { get; set; }
        public virtual DbSet<BaseZuoFaType> BaseZuoFaType { get; set; }
        public virtual DbSet<CccheckDish> CccheckDish { get; set; }
        public virtual DbSet<CccheckDishDetail> CccheckDishDetail { get; set; }
        public virtual DbSet<CcorderDish> CcorderDish { get; set; }
        public virtual DbSet<CcreplenishRecord> CcreplenishRecord { get; set; }
        public virtual DbSet<Cctemplate> Cctemplate { get; set; }
        public virtual DbSet<CctemplateDetail> CctemplateDetail { get; set; }
        public virtual DbSet<ContractManagement> ContractManagement { get; set; }
        public virtual DbSet<DailyBalanceRecord> DailyBalanceRecord { get; set; }
        public virtual DbSet<DishItemBg> DishItemBg { get; set; }
        public virtual DbSet<HandlingWeiXinOrder> HandlingWeiXinOrder { get; set; }
        public virtual DbSet<HandlingWeiXinPreordainOrder> HandlingWeiXinPreordainOrder { get; set; }
        public virtual DbSet<HisOrderBanCi> HisOrderBanCi { get; set; }
        public virtual DbSet<HisOrderFanJieSuan> HisOrderFanJieSuan { get; set; }
        public virtual DbSet<HisOrderGuQing> HisOrderGuQing { get; set; }
        public virtual DbSet<HisOrderHuaDan> HisOrderHuaDan { get; set; }
        public virtual DbSet<HisOrderInfo> HisOrderInfo { get; set; }
        public virtual DbSet<HisOrderJieSuan> HisOrderJieSuan { get; set; }
        public virtual DbSet<HisOrderPackageDishDetail> HisOrderPackageDishDetail { get; set; }
        public virtual DbSet<HisOrderShouQuanRecords> HisOrderShouQuanRecords { get; set; }
        public virtual DbSet<HisOrderTuiCaiDish> HisOrderTuiCaiDish { get; set; }
        public virtual DbSet<HisOrderWaiMaiAddress> HisOrderWaiMaiAddress { get; set; }
        public virtual DbSet<HisOrderZengSongDish> HisOrderZengSongDish { get; set; }
        public virtual DbSet<HisOrderZheKou> HisOrderZheKou { get; set; }
        public virtual DbSet<HisOrderZhuoTai> HisOrderZhuoTai { get; set; }
        public virtual DbSet<HisOrderZhuoTaiDish> HisOrderZhuoTaiDish { get; set; }
        public virtual DbSet<HisPreordain> HisPreordain { get; set; }
        public virtual DbSet<HisPreordainBanquet> HisPreordainBanquet { get; set; }
        public virtual DbSet<HisRefusedWaiMaiOrder> HisRefusedWaiMaiOrder { get; set; }
        public virtual DbSet<JiaoHaoRecord> JiaoHaoRecord { get; set; }
        public virtual DbSet<KouBeiAfterPayOrders> KouBeiAfterPayOrders { get; set; }
        public virtual DbSet<KouBeiOrder> KouBeiOrder { get; set; }
        public virtual DbSet<LocalParams> LocalParams { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<MachineJiaoHaoRecord> MachineJiaoHaoRecord { get; set; }
        public virtual DbSet<OrderBanCi> OrderBanCi { get; set; }
        public virtual DbSet<OrderFanJieSuan> OrderFanJieSuan { get; set; }
        public virtual DbSet<OrderGuQing> OrderGuQing { get; set; }
        public virtual DbSet<OrderHuaDan> OrderHuaDan { get; set; }
        public virtual DbSet<OrderInfo> OrderInfo { get; set; }
        public virtual DbSet<OrderInfoForKouBei> OrderInfoForKouBei { get; set; }
        public virtual DbSet<OrderJieSuan> OrderJieSuan { get; set; }
        public virtual DbSet<OrderPackageDishDetail> OrderPackageDishDetail { get; set; }
        public virtual DbSet<OrderPayMethod> OrderPayMethod { get; set; }
        public virtual DbSet<OrderShouQuanRecords> OrderShouQuanRecords { get; set; }
        public virtual DbSet<OrderTuiCaiDish> OrderTuiCaiDish { get; set; }
        public virtual DbSet<OrderWaiMaiAddress> OrderWaiMaiAddress { get; set; }
        public virtual DbSet<OrderZengSongDish> OrderZengSongDish { get; set; }
        public virtual DbSet<OrderZheKou> OrderZheKou { get; set; }
        public virtual DbSet<OrderZhuoTai> OrderZhuoTai { get; set; }
        public virtual DbSet<OrderZhuoTaiDish> OrderZhuoTaiDish { get; set; }
        public virtual DbSet<PhoneCallRecord> PhoneCallRecord { get; set; }
        public virtual DbSet<PreordainDishTmp> PreordainDishTmp { get; set; }
        public virtual DbSet<PreorderDish> PreorderDish { get; set; }
        public virtual DbSet<PreorderPackageDish> PreorderPackageDish { get; set; }
        public virtual DbSet<PrintHistory> PrintHistory { get; set; }
        public virtual DbSet<PrintHistoryCount> PrintHistoryCount { get; set; }
        public virtual DbSet<SysBiaoQian> SysBiaoQian { get; set; }
        public virtual DbSet<SysBiaoQianDetail> SysBiaoQianDetail { get; set; }
        public virtual DbSet<SysGroupInfo> SysGroupInfo { get; set; }
        public virtual DbSet<SysGroupUser> SysGroupUser { get; set; }
        public virtual DbSet<SysMedias> SysMedias { get; set; }
        public virtual DbSet<SysRight> SysRight { get; set; }
        public virtual DbSet<SysStoreInfo> SysStoreInfo { get; set; }
        public virtual DbSet<SysUnit> SysUnit { get; set; }
        public virtual DbSet<SysWelcome> SysWelcome { get; set; }
        public virtual DbSet<TransferDishRecord> TransferDishRecord { get; set; }
        public virtual DbSet<UploadedData> UploadedData { get; set; }
        public virtual DbSet<UploadedDataTmp> UploadedDataTmp { get; set; }
        public virtual DbSet<WaiMaiDishMap> WaiMaiDishMap { get; set; }
        public virtual DbSet<WuXianLsh> WuXianLsh { get; set; }
        public virtual DbSet<Wxorder> Wxorder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=182810; Pooling=True; UID=sa;PWD=sql1234;connect Timeout=10");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbnormalSettlement>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CwkmId)
                    .IsRequired()
                    .HasColumnName("CwkmID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Memo3)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PayMark)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PayMoney).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RelatedOrderId)
                    .IsRequired()
                    .HasColumnName("RelatedOrderID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ActivityQuanList>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityId)
                    .IsRequired()
                    .HasColumnName("ActivityID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasColumnName("MemberID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuanId)
                    .IsRequired()
                    .HasColumnName("QuanID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BanquetManagement>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_DepositTypeManagement");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SeqId).HasColumnName("SeqID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseActivity>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityPrice).HasColumnType("money");

                entity.Property(e => e.ActivityShare).HasDefaultValueSql("((1))");

                entity.Property(e => e.ActivitySubtractMaxPrice).HasColumnType("money");

                entity.Property(e => e.ActivitySubtractPrice).HasColumnType("money");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CanBieIds)
                    .IsRequired()
                    .HasColumnName("CanBieIDs")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishIds)
                    .IsRequired()
                    .HasColumnName("DishIDs")
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishTypeIds)
                    .IsRequired()
                    .HasColumnName("DishTypeIDs")
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsLongTerm)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('2017-01-01')");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Weeks)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZongBuUid)
                    .IsRequired()
                    .HasColumnName("ZongBuUID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<BaseActivityDetail>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityDishId1)
                    .IsRequired()
                    .HasColumnName("ActivityDishID1")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityDishId2)
                    .IsRequired()
                    .HasColumnName("ActivityDishID2")
                    .HasColumnType("text");

                entity.Property(e => e.ActivityId)
                    .IsRequired()
                    .HasColumnName("ActivityID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityZheKou).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .HasColumnName("BAK1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .HasColumnName("BAK2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .HasColumnName("BAK3")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LaterDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TimeType).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ZongBuUid)
                    .IsRequired()
                    .HasColumnName("ZongBuUID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<BaseCaiWuKeMu>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__Base_CaiWuKeMu__7ECCED9D");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Cwkmcode)
                    .IsRequired()
                    .HasColumnName("CWKMCode")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cwkmname)
                    .IsRequired()
                    .HasColumnName("CWKMName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CwkmtypeId)
                    .IsRequired()
                    .HasColumnName("CWKMTypeID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((1))");

                entity.Property(e => e.IfQianTai)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IfShiShou)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IfShouQuan)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseCaiWuKeMuDiYongQuan>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseCaiW__C5B1960258D1FB74");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CaipinIds)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CaipinTypeIds)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Cwkmid)
                    .IsRequired()
                    .HasColumnName("CWKMID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.DiYongMoney).HasColumnType("money");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.GuanLianCwkm)
                    .IsRequired()
                    .HasColumnName("GuanLianCWKM")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MinPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShiShouMoney).HasColumnType("money");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseCaiWuKeMuTemplate>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Cwkmcode)
                    .IsRequired()
                    .HasColumnName("CWKMCode")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cwkmname)
                    .IsRequired()
                    .HasColumnName("CWKMName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((1))");

                entity.Property(e => e.IfShiShou)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseCaiWuKeMuType>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseCaiW__C5B19602DDCED647");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseCanBie>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Base_CanBie");

                entity.HasComment("餐别");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.CanPreordain)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cbname)
                    .IsRequired()
                    .HasColumnName("CBName")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("餐别名称");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasComment("结束时间(单位为秒)");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeqId).HasColumnName("SeqID");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasComment("开始时间(单位为秒)");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("门店ID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");
            });

            modelBuilder.Entity<BaseDepartment>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseDepa__C5B196028D0884A4");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("部门名称");

                entity.Property(e => e.DeptNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("部门编码");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.IsNeedInventory).HasComment("是否需要盘点");

                entity.Property(e => e.IsWarehouse).HasComment("是否是仓库");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("负责人名称");

                entity.Property(e => e.ManagerUid)
                    .HasColumnName("ManagerUID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("负责人编码");

                entity.Property(e => e.Memo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("上级部门ＩＤ");

                entity.Property(e => e.QuickCode)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("部门助记码");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<BaseDictionary>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_BaseCommonDictionary");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DicName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DicType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.QuickCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ZongBuUid)
                    .HasColumnName("ZongBuUID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<BaseDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Base_Dish");

                entity.HasComment("菜品");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .HasComment("唯一码");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.Bak1)
                    .HasColumnName("BAK1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .HasColumnName("BAK2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .HasColumnName("BAK3")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BarCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("条形码");

                entity.Property(e => e.ChangePrice)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CostMoney).HasColumnType("money");

                entity.Property(e => e.DishCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品编码(必须)");

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品名称(必须)");

                entity.Property(e => e.DishName2)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("是否隐藏 1 ： 启用  0：隐藏");

                entity.Property(e => e.IsPerPerson).HasComment("是否各客菜");

                entity.Property(e => e.MemberPrice).HasColumnType("money");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.QuickCode1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("速查码");

                entity.Property(e => e.QuickCode2)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SalePrice)
                    .HasColumnType("money")
                    .HasComment("单价");

                entity.Property(e => e.SelfHelpDishUid)
                    .HasColumnName("SelfHelpDishUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpecsDishUid)
                    .HasColumnName("SpecsDishUID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecsName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecsUid)
                    .HasColumnName("SpecsUID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StatisticsTypeId)
                    .HasColumnName("StatisticsTypeID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("统计类别");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')")
                    .HasComment("菜谱ID");

                entity.Property(e => e.TiChengPrice).HasColumnType("money");

                entity.Property(e => e.TypeId)
                    .IsRequired()
                    .HasColumnName("TypeID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品类型ID(必须)");

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("单位ID(必须)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");

                entity.Property(e => e.WebPrice).HasColumnType("money");

                entity.Property(e => e.ZongBuUid)
                    .HasColumnName("ZongBuUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseDishCuXiao>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityShare).HasDefaultValueSql("((1))");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CanBieIds)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CuXiaoName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Weeks)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseDishCuXiaoDetail>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CuXiaoUid)
                    .IsRequired()
                    .HasColumnName("CuXiaoUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseDishPeiCai>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishUid)
                    .IsRequired()
                    .HasColumnName("DishUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.PeiCaiUid)
                    .IsRequired()
                    .HasColumnName("PeiCaiUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseDishStatisticsType>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseDish__C5B19602A7D1AD42");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StatisticsCode)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.StatisticsName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseDishType>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Base_DishType");

                entity.HasComment("菜品类型");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品类型说明");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment(" 菜品类型状态 0：禁用  1：启用");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrintOrder).HasComment("打印顺序");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')")
                    .HasComment("菜谱ID");

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品类别编码 ");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品类型名称");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");

                entity.Property(e => e.ZongBuUid)
                    .HasColumnName("ZongBuUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseDishZuoFa>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Base_DishZuoFa");

                entity.HasComment("菜品做法表");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddMoneyPer)
                    .HasColumnType("money")
                    .HasComment("加价参数");

                entity.Property(e => e.AddPriceTypeId)
                    .HasColumnName("AddPriceTypeID")
                    .HasDefaultValueSql("((1000))")
                    .HasComment("加价类型(必须)");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品ID");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')")
                    .HasComment("菜谱ID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");

                entity.Property(e => e.ZuoFaId)
                    .IsRequired()
                    .HasColumnName("ZuoFaID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("做法ID(必须)");
            });

            modelBuilder.Entity<BaseFeiShiShouFenTan>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseFeiS__C5B1960240313633");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CaipinIds)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CaipinTypeIds)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseJueSe>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseJueS__C5B19602F0A652BF");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RightIds)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseKouBeiDish>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak4)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak5)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak6)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak7)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak8)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak9)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CmmDishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CmmDishUid)
                    .IsRequired()
                    .HasColumnName("CmmDishUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.KouBeiDishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KouBeiDishUid)
                    .IsRequired()
                    .HasColumnName("KouBeiDishUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasColumnName("PID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");
            });

            modelBuilder.Entity<BaseKouBeiDishPeiLiao>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak4)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak5)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CmmDishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CmmDishUid)
                    .IsRequired()
                    .HasColumnName("CmmDishUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.KouBeiDishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KouBeiDishUid)
                    .IsRequired()
                    .HasColumnName("KouBeiDishUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");
            });

            modelBuilder.Entity<BaseKouWei>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("状态 0:禁用  1:启用");

                entity.Property(e => e.Kwcode)
                    .IsRequired()
                    .HasColumnName("KWCode")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("口味类型编码");

                entity.Property(e => e.Kwname)
                    .IsRequired()
                    .HasColumnName("KWName")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("口味类型名称");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("编码（数字）");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')")
                    .HasComment("门店ID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");

                entity.Property(e => e.ZongBuUid)
                    .HasColumnName("ZongBuUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseMdbrand>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK__BaseMDBr__DAD4F3BEF3D89286");

                entity.ToTable("BaseMDBrand");

                entity.Property(e => e.BrandId)
                    .HasColumnName("BrandID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("品牌名称");

                entity.Property(e => e.BrandNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("品牌编码");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Memo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasComment("备注");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<BasePackageDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Base_ScombXDish");

                entity.HasComment("套餐菜品");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品ID");

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品名称");

                entity.Property(e => e.DishNumber)
                    .HasColumnType("numeric(8, 2)")
                    .HasDefaultValueSql("((1))")
                    .HasComment("菜品数量");

                entity.Property(e => e.DishTzs)
                    .HasColumnName("DishTZS")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("菜品的条只数");

                entity.Property(e => e.DisplayId)
                    .HasColumnName("DisplayID")
                    .HasComment("菜品顺序");

                entity.Property(e => e.IfSelect).HasComment("0:不可以选择  1:可以选择");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageId)
                    .IsRequired()
                    .HasColumnName("PackageID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("套餐Guid");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')")
                    .HasComment("菜谱ID");

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品的单位");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");

                entity.Property(e => e.ZuoFaId)
                    .HasColumnName("ZuoFaID")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZuoFaName)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<BasePackageNotUsed>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Base_Scomb");

                entity.ToTable("BasePackage_NotUsed");

                entity.HasComment("套餐");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("套餐状态 0：禁用 1：启用");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("套餐编码");

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("套餐名称");

                entity.Property(e => e.QuickCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("速查码");

                entity.Property(e => e.SalePrice)
                    .HasColumnType("money")
                    .HasComment("单价");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')")
                    .HasComment("菜谱ID");

                entity.Property(e => e.TotalMoney)
                    .HasColumnType("money")
                    .HasComment("套的原价");

                entity.Property(e => e.UintName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("单位");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");

                entity.Property(e => e.Vipprice)
                    .HasColumnName("VIPPrice")
                    .HasColumnType("money")
                    .HasComment("会员价");

                entity.Property(e => e.WebPrice).HasColumnType("money");
            });

            modelBuilder.Entity<BasePackageReplaceDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Base_ScombSelectDish");

                entity.HasComment("可选套餐的选择信息");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.DishNumber).HasDefaultValueSql("((1))");

                entity.Property(e => e.DishTzs)
                    .HasColumnName("DishTZS")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageDishId)
                    .IsRequired()
                    .HasColumnName("PackageDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("套餐菜品Guid");

                entity.Property(e => e.PackageId)
                    .IsRequired()
                    .HasColumnName("PackageID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("套餐ID");

                entity.Property(e => e.ReplaceDishId)
                    .IsRequired()
                    .HasColumnName("ReplaceDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("待选的菜品ID");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("菜谱ID");

                entity.Property(e => e.UnitId)
                    .HasColumnName("UnitID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnitName)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");

                entity.Property(e => e.ZuoFaId)
                    .HasColumnName("ZuoFaID")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZuoFaName)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<BasePrinter>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_KitchenDevice");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CaipinIds)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("如果是根据菜品类型选菜，那么这里放排除的菜品。否则，这里放选择的菜品");

                entity.Property(e => e.CaipinTypeIds)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("菜品编号");

                entity.Property(e => e.ComPort)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DanJuList)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("单据列表，逗号分隔。单据类型见相应的枚举");

                entity.Property(e => e.IfZhenDa).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LouCengIds)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PrinterType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("1-网络打印机 2-USB 3-串口 目前不支持串口");

                entity.Property(e => e.RelatedPrinter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SelectType).HasComment("根据什么规则来选菜，1-根据菜品类型 2-根据具体菜品，只针对切配台");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<BaseSystemConfig>(entity =>
            {
                entity.HasKey(e => e.SystemConfigId)
                    .HasName("PK_DanDan_QT_SystemConfig");

                entity.HasComment("系统配置表");

                entity.Property(e => e.SystemConfigId)
                    .HasColumnName("SystemConfigID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("菜谱ID");

                entity.Property(e => e.SystemConfigAlias)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("别名(中文的描述)");

                entity.Property(e => e.SystemConfigName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("配置参数名称");

                entity.Property(e => e.SystemConfigTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SystemConfigValue)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("('')")
                    .HasComment("配置参数值");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");
            });

            modelBuilder.Entity<BaseSystemConfigDefault>(entity =>
            {
                entity.HasKey(e => e.SystemConfigId)
                    .HasName("PK__BaseSyst__2B761A9D0B0F1D24");

                entity.Property(e => e.SystemConfigId)
                    .HasColumnName("SystemConfigID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsVisible)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SystemConfigAlias)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SystemConfigName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SystemConfigTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SystemConfigValue)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<BaseTingMianLouCeng>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("空间布局说明");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("厅面楼层 0：禁用 1：启用");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("菜谱ID");

                entity.Property(e => e.Tmlcname)
                    .IsRequired()
                    .HasColumnName("TMLCName")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("空间布局名称");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");
            });

            modelBuilder.Entity<BaseTmlcdish>(entity =>
            {
                entity.HasKey(e => new { e.DishId, e.Tmlcid });

                entity.ToTable("BaseTMLCDish");

                entity.Property(e => e.DishId)
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tmlcid)
                    .HasColumnName("TMLCID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishPrice).HasColumnType("money");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseUserDepartment>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseUser__C5B19602607C77FC");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasColumnName("DepartmentID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseUserJueSe>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseUser__C5B19602CED413C4");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JueSeUid)
                    .IsRequired()
                    .HasColumnName("JueSeUID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseUserRight>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RightId).HasColumnName("RightID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseWaiMaiManage>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseWaiM__C5B196024BBF0D61");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Parameters)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PlatName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");
            });

            modelBuilder.Entity<BaseWeiXinDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseWeiX__C5B196024928E5DF");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DishUid)
                    .IsRequired()
                    .HasColumnName("DishUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.IfisOnlyShow)
                    .HasColumnName("IFIsOnlyShow")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mealfee).HasColumnType("money");

                entity.Property(e => e.Memo1).HasColumnType("text");

                entity.Property(e => e.Memo2).HasColumnType("text");

                entity.Property(e => e.Memo3).HasColumnType("text");

                entity.Property(e => e.Memo4).HasColumnType("text");

                entity.Property(e => e.Memo5).HasColumnType("text");

                entity.Property(e => e.RelateDishUid)
                    .IsRequired()
                    .HasColumnName("RelateDishUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelatePsfdishUid)
                    .IsRequired()
                    .HasColumnName("RelatePSFDishUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalesCount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TongJiDate).HasColumnType("datetime");

                entity.Property(e => e.UpadteUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<BaseWeiXinDishType>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseWeiX__C5B196024CAE0CA8");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DishTypeUid)
                    .IsRequired()
                    .HasColumnName("DishTypeUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpadteUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WebName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<BaseXiaoFeiLeiXing>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseXiao__C5B19602F8442EFD");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DepositPrice).HasColumnType("money");

                entity.Property(e => e.DepositType).HasDefaultValueSql("((1))");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.IsEnable).HasDefaultValueSql("((1))");

                entity.Property(e => e.JiShiFeiYong)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.JiShiMoShi).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<BaseXiaoFeiLeiXingDetail>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__BaseXiao__C5B19602DE6A4859");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Xflxuid)
                    .IsRequired()
                    .HasColumnName("XFLXUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseZheKouCwkm>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("BaseZheKouCWKM");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Cwkmid)
                    .IsRequired()
                    .HasColumnName("CWKMID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZheKouId)
                    .IsRequired()
                    .HasColumnName("ZheKouID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseZheKouDetail>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Base_ZheKouInfo");

                entity.HasComment("打折关联信息表");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.DiscountPrice)
                    .HasColumnType("money")
                    .HasComment("打折以后的价格");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Parameters)
                    .HasColumnType("money")
                    .HasComment("打折率");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("菜谱ID");

                entity.Property(e => e.TemplateId)
                    .IsRequired()
                    .HasColumnName("TemplateID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("打折模板ID(必须)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");

                entity.Property(e => e.Xxid)
                    .IsRequired()
                    .HasColumnName("XXID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("信息ID");

                entity.Property(e => e.Xxtype)
                    .HasColumnName("XXType")
                    .HasComment("类型 0：菜品  1：制作方法  2：附加费 3：菜品类型");
            });

            modelBuilder.Entity<BaseZheKouRight>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZheKouId)
                    .IsRequired()
                    .HasColumnName("ZheKouID")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseZheKouTemplate>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Base_ZheKouMuBan");

                entity.HasComment("折扣模板");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.CaiPuIds)
                    .IsRequired()
                    .HasColumnName("CaiPuIDs")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CanBieId)
                    .IsRequired()
                    .HasColumnName("CanBieID")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("使用餐别  为空则全实用");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("模板状态：  0 禁用  1 启用");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MinMemberLevel)
                    .HasDefaultValueSql("((1))")
                    .HasComment("会员要求的最低等级");

                entity.Property(e => e.NeedMember).HasComment("是否必须是会员采用使用该模板");

                entity.Property(e => e.Parameters)
                    .HasColumnType("decimal(6, 2)")
                    .HasDefaultValueSql("((100))")
                    .HasComment("打折率（0：不控制   100：不打折）");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TempCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("折扣模板编码");

                entity.Property(e => e.TempName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("折扣模板名称");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");

                entity.Property(e => e.ZheKouLimit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ZongBuUid)
                    .HasColumnName("ZongBuUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseZhuoTai>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasComment("桌台ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.CanPreordain)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DisplayId).HasColumnName("DisplayID");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("桌台状态 0：禁用 1：启用");

                entity.Property(e => e.IsTemp).HasComment("临时创建的桌台，一台多单用的");

                entity.Property(e => e.MaxPeopleNum)
                    .HasDefaultValueSql("((10))")
                    .HasComment("最大人数");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MinMoney).HasColumnType("money");

                entity.Property(e => e.MinPeopleNum).HasComment("人数下限");

                entity.Property(e => e.ParentId)
                    .IsRequired()
                    .HasColumnName("ParentID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("一台多单的时候，关联的桌台");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')")
                    .HasComment("菜谱ID");

                entity.Property(e => e.Tmlcid)
                    .IsRequired()
                    .HasColumnName("TMLCID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("空间布局ID(必须)");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");

                entity.Property(e => e.ZhuoTaiType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ztcode)
                    .IsRequired()
                    .HasColumnName("ZTCode")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("编码");

                entity.Property(e => e.Ztname)
                    .IsRequired()
                    .HasColumnName("ZTName")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("桌台名称");

                entity.Property(e => e.ZtquickCode)
                    .HasColumnName("ZTQuickCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseZuoFa>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Base_ZuoFa");

                entity.HasComment("制作方法");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddMoneyPer).HasColumnType("money");

                entity.Property(e => e.AddPriceTypeId)
                    .HasColumnName("AddPriceTypeID")
                    .HasDefaultValueSql("((1000))");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("是否删除 0：禁用 1：启用");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.QuickCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("速查吗");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("门店ID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");

                entity.Property(e => e.ZongBuUid)
                    .HasColumnName("ZongBuUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZuoFaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("制作方法名称");

                entity.Property(e => e.ZuoFaTypeId)
                    .HasColumnName("ZuoFaTypeID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaseZuoFaType>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuickCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CccheckDish>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("CCCheckDish");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CccheckDishDetail>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("CCCheckDishDetail");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CccheckDishId)
                    .IsRequired()
                    .HasColumnName("CCCheckDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishNumOk).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishSignNum)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("品项对应签的根数");

                entity.Property(e => e.DishTypeId)
                    .IsRequired()
                    .HasColumnName("DishTypeID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SignType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("签的对应类型，备用字段，如：大签 小签等");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CcorderDish>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("CCOrderDish");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BatchCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("批次号：上货一天之中可多次，批次号用于区分");

                entity.Property(e => e.CctemplateDetailUid)
                    .IsRequired()
                    .HasColumnName("CCTemplateDetailUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CctemplateUid)
                    .IsRequired()
                    .HasColumnName("CCTemplateUID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Type 补货：对应UID 上货：对应模版ID");

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishNumOk)
                    .HasColumnName("DishNumOK")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishSignNum)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("品项对应签的根数");

                entity.Property(e => e.DishTypeId)
                    .IsRequired()
                    .HasColumnName("DishTypeID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OperateDate).HasColumnType("datetime");

                entity.Property(e => e.SignType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("签的对应类型，备用字段，如：大签 小签等");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("单据类型：补货 or 上货");

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CcreplenishRecord>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("CCReplenishRecord");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BatchCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("批次号，目的：区分每次补货的品项是哪些");

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishSignNum)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("品项对应签的根数");

                entity.Property(e => e.DishTypeId)
                    .IsRequired()
                    .HasColumnName("DishTypeID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OperateDate).HasColumnType("datetime");

                entity.Property(e => e.SignType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("签的对应类型，备用字段，如：大签 小签等");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cctemplate>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("CCTemplate");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CctemplateDetail>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("CCTemplateDetail");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CctemplateUid)
                    .IsRequired()
                    .HasColumnName("CCTemplateUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishSignNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishTypeId)
                    .IsRequired()
                    .HasColumnName("DishTypeID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SignType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContractManagement>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_DepositManagement");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SeqId).HasColumnName("SeqID");

                entity.Property(e => e.Sign)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DailyBalanceRecord>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.Bak1)
                    .IsRequired()
                    .HasColumnName("BAK1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .IsRequired()
                    .HasColumnName("BAK2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SettleDate)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SettleTime).HasColumnType("datetime");

                entity.Property(e => e.SettleUserId)
                    .IsRequired()
                    .HasColumnName("SettleUserID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SettleUserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<DishItemBg>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.BgColor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BmpPath)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ForeColor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .IsRequired()
                    .HasColumnName("ItemID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<HandlingWeiXinOrder>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasColumnName("MemberID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrderDetail)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.OrderMoney).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("ZhuoTaiID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ZhuoTaiName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HandlingWeiXinPreordainOrder>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .IsRequired()
                    .HasColumnName("bak1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .HasColumnName("bak2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .HasColumnName("bak3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CanBieName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CanBieUid)
                    .HasColumnName("CanBieUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.HisPreordainUid)
                    .HasColumnName("HisPreordainUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasColumnName("MemberID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MemberName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MemberTel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Reason).HasMaxLength(200);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.ReserveTime).HasColumnType("datetime");

                entity.Property(e => e.ReserveUid)
                    .HasColumnName("ReserveUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ztname)
                    .HasColumnName("ZTName")
                    .HasColumnType("text");

                entity.Property(e => e.Ztuid)
                    .HasColumnName("ZTUID")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<HisOrderBanCi>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.AddTime)
                    .HasName("Index_HisOrderBanCi_AddTime");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.BanCiHao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IfJiuShui).HasDefaultValueSql("((0))");

                entity.Property(e => e.JiaoZhangMoney).HasColumnType("money");

                entity.Property(e => e.Memo1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<HisOrderFanJieSuan>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.OrderId)
                    .HasName("Index_HisOrderFanJieSuan_OrderID");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FanJieSuanMoney).HasColumnType("money");

                entity.Property(e => e.JieSuanOrderId)
                    .IsRequired()
                    .HasColumnName("JieSuanOrderID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderFanJieSuanDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HisOrderGuQing>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.AddTime)
                    .HasName("Index_HisOrderGuQing_AddTime");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CanBieId)
                    .IsRequired()
                    .HasColumnName("CanBieID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishNumber).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.GqendTime)
                    .HasColumnName("GQEndTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.GqstartTime)
                    .HasColumnName("GQStartTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gqtype).HasColumnName("GQType");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<HisOrderHuaDan>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__HisOrder__C5B19602728B0CA0");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .HasColumnName("bak1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .HasColumnName("bak2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .HasColumnName("bak3")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.HuaDanNum).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.HuaDanTime).HasColumnType("datetime");

                entity.Property(e => e.QiangDanTime).HasColumnType("datetime");

                entity.Property(e => e.QiangDanUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TotalNum).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.XiaDanTime).HasColumnType("datetime");

                entity.Property(e => e.ZtdishUid)
                    .HasColumnName("ZTDishUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ztname)
                    .HasColumnName("ZTName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HisOrderInfo>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.AddTime)
                    .HasName("Index_HisOrderInfo_AddTime");

                entity.HasIndex(e => e.BanCiHaoId)
                    .HasName("Index_HisOrderInfo_BanCiHaoID");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak1)
                    .HasColumnName("BAK1")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak2)
                    .HasColumnName("BAK2")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak3)
                    .HasColumnName("BAK3")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak4)
                    .IsRequired()
                    .HasColumnName("BAK4")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak5)
                    .IsRequired()
                    .HasColumnName("BAK5")
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak6)
                    .HasColumnName("BAK6")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak7)
                    .HasColumnName("BAK7")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BanCiHaoId)
                    .IsRequired()
                    .HasColumnName("BanCiHaoID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeginTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FaPiaoMoney).HasColumnType("money");

                entity.Property(e => e.IsEnterPayQueue).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsWaiMai).HasDefaultValueSql("((0))");

                entity.Property(e => e.JieSuanTime).HasColumnType("datetime");

                entity.Property(e => e.JieSuanUserId)
                    .IsRequired()
                    .HasColumnName("JieSuanUserID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.JieSuanUserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LianTaiMark)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("ManagerID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasColumnName("MemberID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MergeTag)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderCostMoney).HasColumnType("money");

                entity.Property(e => e.OrderDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderFenTanShiShouMoney).HasColumnType("money");

                entity.Property(e => e.OrderMemberMoney).HasColumnType("money");

                entity.Property(e => e.OrderMoLingMoney).HasColumnType("money");

                entity.Property(e => e.OrderShiJiMoney).HasColumnType("money");

                entity.Property(e => e.OrderYouMianMoney).HasColumnType("money");

                entity.Property(e => e.OrderYuanShiMoney).HasColumnType("money");

                entity.Property(e => e.OrderZheKouMoney).HasColumnType("money");

                entity.Property(e => e.PreordainId)
                    .IsRequired()
                    .HasColumnName("PreordainID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PreordainTypeId)
                    .IsRequired()
                    .HasColumnName("PreordainTypeID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PriceType).HasDefaultValueSql("((1))");

                entity.Property(e => e.SongDanNum).HasDefaultValueSql("((0))");

                entity.Property(e => e.Source).HasDefaultValueSql("((0))");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaiKaHao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tmlcid)
                    .IsRequired()
                    .HasColumnName("TMLCID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TotalPeopleNum).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HisOrderJieSuan>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.AddTime)
                    .HasName("Index_HisOrderJieSuan_AddTime");

                entity.HasIndex(e => e.OrderId)
                    .HasName("Index_HisOrderJieSuan_OrderID");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cwkmid)
                    .IsRequired()
                    .HasColumnName("CWKMID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Cwkmname)
                    .IsRequired()
                    .HasColumnName("CWKMName")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsValid)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.JieSuanDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JieSuanOrder).HasDefaultValueSql("((1))");

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo3)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShiShouMoney).HasColumnType("money");

                entity.Property(e => e.ShouDaoMoney).HasColumnType("money");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ZhaoLingMoney).HasColumnType("money");
            });

            modelBuilder.Entity<HisOrderPackageDishDetail>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.OrderId)
                    .HasName("Index_HisOrderPackageDishDetail_OrderID");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishCostMoney).HasColumnType("money");

                entity.Property(e => e.DishDisplayOrder).HasDefaultValueSql("((1))");

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishNumOk)
                    .IsRequired()
                    .HasColumnName("DishNumOK")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DishPaidMoney).HasColumnType("money");

                entity.Property(e => e.DishPrice).HasColumnType("money");

                entity.Property(e => e.DishStatusDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'即')");

                entity.Property(e => e.DishStatusId).HasColumnName("DishStatusID");

                entity.Property(e => e.DishTiChengMoney).HasColumnType("money");

                entity.Property(e => e.DishTotalMoney).HasColumnType("money");

                entity.Property(e => e.DishTuiCaiNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishTypeId)
                    .IsRequired()
                    .HasColumnName("DishTypeID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishTzs)
                    .HasColumnName("DishTZS")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DishVipprice)
                    .HasColumnName("DishVIPPrice")
                    .HasColumnType("money");

                entity.Property(e => e.DishWebPrice).HasColumnType("money");

                entity.Property(e => e.DishZengSongNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishZheKouMoney).HasColumnType("money");

                entity.Property(e => e.FenTanDishPaidMoney).HasColumnType("money");

                entity.Property(e => e.FenTanDishPrice).HasColumnType("money");

                entity.Property(e => e.HuaCaiNum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KouWeiIds)
                    .IsRequired()
                    .HasColumnName("KouWeiIDS")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KouWeiNames)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo3)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo4)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo5)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo6)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.OrderZhuoTaiDishId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageId)
                    .IsRequired()
                    .HasColumnName("PackageID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShangCaiShiJian)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SongDanTime).HasColumnType("datetime");

                entity.Property(e => e.SongDanUserName)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Spec).HasMaxLength(20);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TuiCaiSum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WaiterId)
                    .IsRequired()
                    .HasColumnName("WaiterID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WaiterName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZuoFaIds)
                    .IsRequired()
                    .HasColumnName("ZuoFaIDs")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZuoFaNames)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<HisOrderShouQuanRecords>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddUserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ShouQuanContent)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShouQuanRight)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ShouQuanUserId)
                    .IsRequired()
                    .HasColumnName("ShouQuanUserID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ShouQuanUserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");
            });

            modelBuilder.Entity<HisOrderTuiCaiDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.OrderZhuoTaiDishId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageDishDetailId)
                    .IsRequired()
                    .HasColumnName("PackageDishDetailID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TuiCaiDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tzsnum)
                    .HasColumnName("TZSNum")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<HisOrderWaiMaiAddress>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.AddTime)
                    .HasName("Index_HisOrderWaiMaiAddress_AddTime");

                entity.HasIndex(e => e.OrderId)
                    .HasName("Index_HisOrderWaiMaiAddress_OrderID");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasComment("配送地址");

                entity.Property(e => e.ArriveTime)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak4)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak5)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak6)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak7)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak8)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HasAccept)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LinkName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("联系人姓名");

                entity.Property(e => e.LinkTel)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("联系电话");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Sender).HasMaxLength(50);
            });

            modelBuilder.Entity<HisOrderZengSongDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.OrderZhuoTaiDishId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageDishDetailId)
                    .IsRequired()
                    .HasColumnName("PackageDishDetailID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tzsnum)
                    .HasColumnName("TZSNum")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ZengSongDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<HisOrderZheKou>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.AddTime)
                    .HasName("Index_HisOrderZheKou_AddTime");

                entity.HasIndex(e => e.OrderId)
                    .HasName("Index_HisOrderZheKou_OrderID");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddUserName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AttachZheKouId)
                    .HasColumnName("AttachZheKouID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .IsRequired()
                    .HasColumnName("BAK1")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak2)
                    .IsRequired()
                    .HasColumnName("BAK2")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShouQuanRenId)
                    .IsRequired()
                    .HasColumnName("ShouQuanRenID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZheKouSource).HasDefaultValueSql("((1))");

                entity.Property(e => e.Zkid)
                    .IsRequired()
                    .HasColumnName("ZKID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zkname)
                    .IsRequired()
                    .HasColumnName("ZKName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZkziDingYi)
                    .HasColumnName("ZKZiDingYi")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<HisOrderZhuoTai>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.AddTime)
                    .HasName("Index_HisOrderZhuoTai_AddTime");

                entity.HasIndex(e => e.OrderId)
                    .HasName("Index_HisOrderZhuoTai_OrderID");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak1)
                    .IsRequired()
                    .HasColumnName("BAK1")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak2)
                    .IsRequired()
                    .HasColumnName("BAK2")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.WaiterId)
                    .HasColumnName("WaiterID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WaiterName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("ZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZhuoTaiName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZtpeopleNum)
                    .HasColumnName("ZTPeopleNum")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<HisOrderZhuoTaiDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.AddTime)
                    .HasName("Index_HisOrderZhuoTaiDish_AddTime");

                entity.HasIndex(e => e.OrderId)
                    .HasName("Index_HisOrderZhuoTaiDish_OrderID");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityMode).HasDefaultValueSql("((1))");

                entity.Property(e => e.ActivityParam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BatchId).HasColumnName("BatchID");

                entity.Property(e => e.DishCostMoney).HasColumnType("money");

                entity.Property(e => e.DishDisplayOrder).HasDefaultValueSql("((1))");

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishNumOk)
                    .IsRequired()
                    .HasColumnName("DishNumOK")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DishPaidMoney).HasColumnType("money");

                entity.Property(e => e.DishPrice).HasColumnType("money");

                entity.Property(e => e.DishStatusDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishStatusId).HasColumnName("DishStatusID");

                entity.Property(e => e.DishTiChengMoney).HasColumnType("money");

                entity.Property(e => e.DishTotalMoney).HasColumnType("money");

                entity.Property(e => e.DishTuiCaiNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishTypeId)
                    .IsRequired()
                    .HasColumnName("DishTypeID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishTzs)
                    .HasColumnName("DishTZS")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DishVipprice)
                    .HasColumnName("DishVIPPrice")
                    .HasColumnType("money");

                entity.Property(e => e.DishWebPrice).HasColumnType("money");

                entity.Property(e => e.DishZengSongNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishZheKouMoney).HasColumnType("money");

                entity.Property(e => e.DishZuoFaMoney).HasColumnType("money");

                entity.Property(e => e.FenTanDishPaidMoney).HasColumnType("money");

                entity.Property(e => e.FenTanDishPrice).HasColumnType("money");

                entity.Property(e => e.HuaCaiNum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KouWeiIds)
                    .IsRequired()
                    .HasColumnName("KouWeiIDS")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KouWeiNames)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo3)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo4)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo5)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo6)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo7)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo8)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OriginPrice).HasColumnType("money");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShangCaiShiJian)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiTeJiaParam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SongDanTime).HasColumnType("datetime");

                entity.Property(e => e.SongDanUserName)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Spec).HasMaxLength(20);

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WaiterId)
                    .IsRequired()
                    .HasColumnName("WaiterID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WaiterName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZheKouParam)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.ZuoFaIds)
                    .IsRequired()
                    .HasColumnName("ZuoFaIDs")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZuoFaNames)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<HisPreordain>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.AddTime)
                    .HasName("Index_HisPreordain_AddTime");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ArriveTime).HasColumnType("datetime");

                entity.Property(e => e.CanBieUid)
                    .HasColumnName("CanBieUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Contact).HasMaxLength(20);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.ManagerName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ManagerUid)
                    .IsRequired()
                    .HasColumnName("ManagerUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MemberName).HasMaxLength(50);

                entity.Property(e => e.MemberUid)
                    .HasColumnName("MemberUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Memo1).HasMaxLength(1000);

                entity.Property(e => e.Memo2).HasMaxLength(1000);

                entity.Property(e => e.Memo3).HasMaxLength(1000);

                entity.Property(e => e.PhoneCallRecordUid)
                    .HasColumnName("PhoneCallRecordUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PreordainCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreordainDate).HasColumnType("datetime");

                entity.Property(e => e.PreordainType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Tel1)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tel2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ZhuoTaiNames).HasMaxLength(2000);

                entity.Property(e => e.ZhuoTaiUids)
                    .HasColumnName("ZhuoTaiUIDs")
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HisPreordainBanquet>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BanquetUid)
                    .IsRequired()
                    .HasColumnName("BanquetUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerName1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerPhone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerPhone1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.PreOrdainUid)
                    .IsRequired()
                    .HasColumnName("PreOrdainUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ztnum).HasColumnName("ZTNum");

                entity.Property(e => e.ZtnumBeiXuan).HasColumnName("ZTNumBeiXuan");
            });

            modelBuilder.Entity<HisRefusedWaiMaiOrder>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.AddTime)
                    .HasName("Index_HisRefusedWaiMaiOrder_AddTime");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ArriveTime)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak4)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak5)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak6)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak7)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak8)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LinkName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LinkTel)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDetail)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.OrderShiJiMoney).HasColumnType("money");

                entity.Property(e => e.Sender).HasMaxLength(50);
            });

            modelBuilder.Entity<JiaoHaoRecord>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderZhuoTaiDishUid)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiDishUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ztname)
                    .IsRequired()
                    .HasColumnName("ZTName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KouBeiAfterPayOrders>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BatchNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BizProduct)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DinnerType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.KouBeiOrderId)
                    .IsRequired()
                    .HasColumnName("KouBeiOrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Memo3)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OrderStyle)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.OrderZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PayStyle)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptTimeout).HasColumnType("datetime");

                entity.Property(e => e.RelatedOrderId)
                    .IsRequired()
                    .HasColumnName("RelatedOrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TableNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KouBeiOrder>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ActionRemark)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BillAmount)
                    .HasColumnType("money")
                    .HasComment("应收");

                entity.Property(e => e.BusinessType)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Channel)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.DinnerType)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.DishDetail)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ExtInfo)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderState)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.OrderStyle)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.OrderTime)
                    .HasColumnType("datetime")
                    .HasComment("用户下单时间");

                entity.Property(e => e.OtherAmount)
                    .HasColumnType("money")
                    .HasComment("其他费用");

                entity.Property(e => e.PackingAmount).HasColumnType("money");

                entity.Property(e => e.PayAmount)
                    .HasColumnType("money")
                    .HasComment("实付");

                entity.Property(e => e.PayChannels)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PayState)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PayStyle)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptAmount)
                    .HasColumnType("money")
                    .HasComment("实收");

                entity.Property(e => e.RelatedOrderId)
                    .IsRequired()
                    .HasColumnName("RelatedOrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceAmount)
                    .HasColumnType("money")
                    .HasComment("服务费");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TableTime)
                    .HasColumnType("datetime")
                    .HasComment("预定开台时间");

                entity.Property(e => e.TakeNo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TakeStyle)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.TradeAmount)
                    .HasColumnType("money")
                    .HasComment("应付");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UserMobile)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasComment("用户手机号");
            });

            modelBuilder.Entity<LocalParams>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.LoginTime).HasColumnType("datetime");

                entity.Property(e => e.LogoutTime).HasColumnType("datetime");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Site)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MachineJiaoHaoRecord>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.JiaoHaoRecordUid)
                    .IsRequired()
                    .HasColumnName("JiaoHaoRecordUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasColumnName("MachineID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZhuoTaiName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderBanCi>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasComment("操作员开班结班表");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.BanCiHao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("班次号");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasComment("结班时间");

                entity.Property(e => e.IfJiaoZhang).HasComment("是否交帐");

                entity.Property(e => e.IfJieBan).HasComment("是否结班 0:未结班 1:已结班");

                entity.Property(e => e.IfJiuShui).HasDefaultValueSql("((0))");

                entity.Property(e => e.JiaoZhangMoney).HasColumnType("money");

                entity.Property(e => e.Memo1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("第一次结帐时间");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("门店ID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("操作员Guid");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<OrderFanJieSuan>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("反结算ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('')")
                    .HasComment("操作员姓名");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("操作员ID");

                entity.Property(e => e.FanJieSuanMoney).HasColumnType("money");

                entity.Property(e => e.FanJieSuanNum).HasComment("反结算次数");

                entity.Property(e => e.JieSuanOrderId)
                    .IsRequired()
                    .HasColumnName("JieSuanOrderID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("反结算定单ID");

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')")
                    .HasComment("定单编码");

                entity.Property(e => e.OrderFanJieSuanDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')")
                    .HasComment("反结算原因");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("定单ID");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("门店ID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderGuQing>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasComment("沽清ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("新增人员ID");

                entity.Property(e => e.CanBieId)
                    .IsRequired()
                    .HasColumnName("CanBieID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("沽清餐别");

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品ID");

                entity.Property(e => e.DishNumber)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("菜品数量");

                entity.Property(e => e.GqendTime)
                    .HasColumnName("GQEndTime")
                    .HasColumnType("datetime")
                    .HasComment("结束时间");

                entity.Property(e => e.GqstartTime)
                    .HasColumnName("GQStartTime")
                    .HasColumnType("datetime")
                    .HasComment("沽清时间");

                entity.Property(e => e.Gqtype)
                    .HasColumnName("GQType")
                    .HasComment("1-餐别 2-全天");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("修改人的ID");
            });

            modelBuilder.Entity<OrderHuaDan>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__OrderHua__C5B196025A6BD6D0");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .HasColumnName("bak1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .HasColumnName("bak2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .HasColumnName("bak3")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.HuaDanNum).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.HuaDanTime).HasColumnType("datetime");

                entity.Property(e => e.QiangDanTime).HasColumnType("datetime");

                entity.Property(e => e.QiangDanUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TotalNum).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.XiaDanTime).HasColumnType("datetime");

                entity.Property(e => e.ZtdishUid)
                    .HasColumnName("ZTDishUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ztname)
                    .HasColumnName("ZTName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderInfo>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasComment("定单信息");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasComment("定单ID");

                entity.Property(e => e.AddName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('')")
                    .HasComment("操作员名称");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasComment("下单时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("操作员ID");

                entity.Property(e => e.Bak1)
                    .HasColumnName("BAK1")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak2)
                    .HasColumnName("BAK2")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak3)
                    .HasColumnName("BAK3")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak4)
                    .IsRequired()
                    .HasColumnName("BAK4")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak5)
                    .IsRequired()
                    .HasColumnName("BAK5")
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak6)
                    .HasColumnName("BAK6")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak7)
                    .HasColumnName("BAK7")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BanCiHaoId)
                    .IsRequired()
                    .HasColumnName("BanCiHaoID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeginTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("下单时间");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("结算时间");

                entity.Property(e => e.FaPiaoMoney)
                    .HasColumnType("money")
                    .HasComment("发票金额");

                entity.Property(e => e.FanJieSuanNum).HasComment("反结算数");

                entity.Property(e => e.IsEnterPayQueue).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsFromWeb).HasComment("是否是网上自己下单");

                entity.Property(e => e.IsMerge).HasComment("0: 不包含其他的订单 1:合并帐单(子) 2:合并帐单(主)");

                entity.Property(e => e.IsWaiMai).HasDefaultValueSql("((0))");

                entity.Property(e => e.JieSuanTime).HasColumnType("datetime");

                entity.Property(e => e.JieSuanUserId)
                    .IsRequired()
                    .HasColumnName("JieSuanUserID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.JieSuanUserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LianTaiMark)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("连台标志");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("ManagerID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasColumnName("MemberID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("会员Guid");

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MergeTag)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("合并帐单标志A-Z");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("定单号");

                entity.Property(e => e.OrderCostMoney)
                    .HasColumnType("money")
                    .HasComment("成本金额");

                entity.Property(e => e.OrderDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')")
                    .HasComment("订单说明");

                entity.Property(e => e.OrderFenTanShiShouMoney).HasColumnType("money");

                entity.Property(e => e.OrderMemberMoney)
                    .HasColumnType("money")
                    .HasComment("会员优惠金额");

                entity.Property(e => e.OrderMoLingMoney)
                    .HasColumnType("money")
                    .HasComment("抹零金额");

                entity.Property(e => e.OrderShiJiMoney)
                    .HasColumnType("money")
                    .HasComment("定单中菜品的实际的金额(包含菜品的做法加价)");

                entity.Property(e => e.OrderStatus).HasComment("订单状态 0:开单  1:结算");

                entity.Property(e => e.OrderYouMianMoney)
                    .HasColumnType("money")
                    .HasComment("优免金额");

                entity.Property(e => e.OrderYuanShiMoney)
                    .HasColumnType("money")
                    .HasComment("订单的中菜品理论金额(包含菜品的做法加价)");

                entity.Property(e => e.OrderZheKouMoney)
                    .HasColumnType("money")
                    .HasComment("折扣金额");

                entity.Property(e => e.PreordainId)
                    .IsRequired()
                    .HasColumnName("PreordainID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("预订Guid");

                entity.Property(e => e.PreordainTypeId)
                    .IsRequired()
                    .HasColumnName("PreordainTypeID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("预定类型");

                entity.Property(e => e.PriceType)
                    .HasDefaultValueSql("((1))")
                    .HasComment("1-原价  2-会员价 3-网络价");

                entity.Property(e => e.SongDanNum).HasDefaultValueSql("((0))");

                entity.Property(e => e.Source).HasDefaultValueSql("((0))");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("门店Code");

                entity.Property(e => e.TaiKaHao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tmlcid)
                    .IsRequired()
                    .HasColumnName("TMLCID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("厅面ID");

                entity.Property(e => e.TotalPeopleNum).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderInfoForKouBei>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_OrderInfoForKouBel");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");
            });

            modelBuilder.Entity<OrderJieSuan>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasComment("结算单");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasComment("结算单ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('')")
                    .HasComment("操作员姓名");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("操作员ID");

                entity.Property(e => e.Cwkmid)
                    .IsRequired()
                    .HasColumnName("CWKMID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("结算方式");

                entity.Property(e => e.Cwkmname)
                    .IsRequired()
                    .HasColumnName("CWKMName")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("结算方式名称");

                entity.Property(e => e.IsValid)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.JieSuanDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')")
                    .HasComment("结算说明");

                entity.Property(e => e.JieSuanOrder)
                    .HasDefaultValueSql("((1))")
                    .HasComment("结算顺序");

                entity.Property(e => e.JieSuanType).HasComment("是否找零 0:不找零 1:找零 2：会员卡 3：签单 4：券");

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo3)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("定单号");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("定单ID");

                entity.Property(e => e.ShiShouMoney)
                    .HasColumnType("money")
                    .HasComment("实收结算金额");

                entity.Property(e => e.ShouDaoMoney)
                    .HasColumnType("money")
                    .HasComment("收到金额");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("门店Guid");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ZhaoLingMoney)
                    .HasColumnType("money")
                    .HasComment("找零");
            });

            modelBuilder.Entity<OrderPackageDishDetail>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasComment("套餐菜品的信息");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("套餐明细ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishCostMoney)
                    .HasColumnType("money")
                    .HasComment("菜品成本金额");

                entity.Property(e => e.DishDisplayOrder)
                    .HasDefaultValueSql("((1))")
                    .HasComment("套餐中的菜品顺序");

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品ID");

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品名称");

                entity.Property(e => e.DishNum)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("菜品数量");

                entity.Property(e => e.DishNumOk)
                    .IsRequired()
                    .HasColumnName("DishNumOK")
                    .HasDefaultValueSql("((1))")
                    .HasComment("数量是否确定 0：不确定  1：确定");

                entity.Property(e => e.DishPaidMoney)
                    .HasColumnType("money")
                    .HasComment("菜品做法加价[也已经包含数量]");

                entity.Property(e => e.DishPrice)
                    .HasColumnType("money")
                    .HasComment("菜品原始价格");

                entity.Property(e => e.DishStatusDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'即')")
                    .HasComment("菜品的出菜方式");

                entity.Property(e => e.DishStatusId)
                    .HasColumnName("DishStatusID")
                    .HasComment("菜品状态 0：已点，未送单 1： 已送单 2:赠送 3:退菜");

                entity.Property(e => e.DishTiChengMoney).HasColumnType("money");

                entity.Property(e => e.DishTotalMoney)
                    .HasColumnType("money")
                    .HasComment("菜品销售的金额(单价乘数量)");

                entity.Property(e => e.DishTuiCaiNum)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("退菜数量");

                entity.Property(e => e.DishTypeId)
                    .IsRequired()
                    .HasColumnName("DishTypeID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品类型");

                entity.Property(e => e.DishTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishTzs)
                    .HasColumnName("DishTZS")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("菜品的条只数");

                entity.Property(e => e.DishVipprice)
                    .HasColumnName("DishVIPPrice")
                    .HasColumnType("money")
                    .HasComment("会员价格");

                entity.Property(e => e.DishWebPrice).HasColumnType("money");

                entity.Property(e => e.DishZengSongNum)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("赠送数量");

                entity.Property(e => e.DishZheKouMoney)
                    .HasColumnType("money")
                    .HasComment("折扣的金额(折后的金额-菜品实际销售的价格)[已经包含数量]");

                entity.Property(e => e.FenTanDishPaidMoney).HasColumnType("money");

                entity.Property(e => e.FenTanDishPrice).HasColumnType("money");

                entity.Property(e => e.HuaCaiNum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IfHuaCai).HasComment("是否已经划菜  0：没有划菜   1：已经划菜");

                entity.Property(e => e.IsSelect).HasComment("是否可以换菜 0：不可以换  1：可以换");

                entity.Property(e => e.KouWeiIds)
                    .IsRequired()
                    .HasColumnName("KouWeiIDS")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KouWeiNames)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo3)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo4)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo5)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo6)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.OrderZhuoTaiDishId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("订单桌台关系ID");

                entity.Property(e => e.OrderZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageId)
                    .IsRequired()
                    .HasColumnName("PackageID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("套餐ID");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShangCaiShiJian)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("上菜时间");

                entity.Property(e => e.SongDanTime).HasColumnType("datetime");

                entity.Property(e => e.SongDanUserName)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Spec).HasMaxLength(20);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TuiCaiSum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品单位");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WaiterId)
                    .IsRequired()
                    .HasColumnName("WaiterID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("服务员ID");

                entity.Property(e => e.WaiterName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('')")
                    .HasComment("服务员名称");

                entity.Property(e => e.ZuoFaIds)
                    .IsRequired()
                    .HasColumnName("ZuoFaIDs")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZuoFaNames)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<OrderPayMethod>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasComment("支付方式");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("支付方式编号");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasComment("添加时间");

                entity.Property(e => e.AddUser)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("添加用户");

                entity.Property(e => e.FinancialAccountsId)
                    .IsRequired()
                    .HasColumnName("FinancialAccountsID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("财务科目编号，必须和财务系统一致");

                entity.Property(e => e.FinancialAccountsName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsRealPaid).HasComment("是否实收，有时候用优惠券之类的不算实收");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("支付方式名称");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderShouQuanRecords>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddUserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ShouQuanContent)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShouQuanRight)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ShouQuanUserId)
                    .IsRequired()
                    .HasColumnName("ShouQuanUserID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ShouQuanUserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");
            });

            modelBuilder.Entity<OrderTuiCaiDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasComment("订单退菜表");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishNum)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("数量");

                entity.Property(e => e.DishPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IsPackage).HasComment("是否是套餐0：不是套餐 1：套餐");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.OrderZhuoTaiDishId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("桌台菜品关系Guid");

                entity.Property(e => e.OrderZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("定单桌台Guid");

                entity.Property(e => e.PackageDishDetailId)
                    .IsRequired()
                    .HasColumnName("PackageDishDetailID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("套餐中的菜品明细Guid");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("门店Code");

                entity.Property(e => e.TuiCaiDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')")
                    .HasComment("退菜原因");

                entity.Property(e => e.Tzsnum)
                    .HasColumnName("TZSNum")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("条只数");
            });

            modelBuilder.Entity<OrderWaiMaiAddress>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasComment("配送地址");

                entity.Property(e => e.ArriveTime)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Bak4)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak5)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak6)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak7)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak8)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HasAccept)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LinkName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("联系人姓名");

                entity.Property(e => e.LinkTel)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("联系电话");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Sender).HasMaxLength(50);
            });

            modelBuilder.Entity<OrderZengSongDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasComment("订单赠送表");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("新增时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("操作人ID");

                entity.Property(e => e.DishNum)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("菜品数量");

                entity.Property(e => e.IsPackage).HasComment("是否是套餐 0：不是套餐 1：套餐");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.OrderZhuoTaiDishId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("桌台菜品关系Guid");

                entity.Property(e => e.OrderZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("定单桌台Guid");

                entity.Property(e => e.PackageDishDetailId)
                    .IsRequired()
                    .HasColumnName("PackageDishDetailID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("套餐中的菜品明细Guid");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("门店Code");

                entity.Property(e => e.Tzsnum)
                    .HasColumnName("TZSNum")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("条只数");

                entity.Property(e => e.ZengSongDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')")
                    .HasComment("赠送原因");
            });

            modelBuilder.Entity<OrderZheKou>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasComment("订单折扣模板");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasComment("订单折扣模板");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("操作人Guid");

                entity.Property(e => e.AddUserName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('')")
                    .HasComment("操作员名称");

                entity.Property(e => e.AttachZheKouId)
                    .HasColumnName("AttachZheKouID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .IsRequired()
                    .HasColumnName("BAK1")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak2)
                    .IsRequired()
                    .HasColumnName("BAK2")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("定单编码");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("订单Guid");

                entity.Property(e => e.ShouQuanRenId)
                    .IsRequired()
                    .HasColumnName("ShouQuanRenID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("授权人编码");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("门店Guid");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZheKouSource).HasDefaultValueSql("((1))");

                entity.Property(e => e.ZheKouType).HasComment("折扣类型 0：折扣模板  1：会员价  2：自定义折扣  3：");

                entity.Property(e => e.Zkid)
                    .IsRequired()
                    .HasColumnName("ZKID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("折扣模板ID");

                entity.Property(e => e.Zkname)
                    .IsRequired()
                    .HasColumnName("ZKName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("折扣名称");

                entity.Property(e => e.ZkziDingYi)
                    .HasColumnName("ZKZiDingYi")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("自定义折扣");
            });

            modelBuilder.Entity<OrderZhuoTai>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasComment("定单桌台关系");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("操作员姓名");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("操作员ID");

                entity.Property(e => e.Bak1)
                    .IsRequired()
                    .HasColumnName("BAK1")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bak2)
                    .IsRequired()
                    .HasColumnName("BAK2")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("定单Guid");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("门店Code");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.WaiterId)
                    .HasColumnName("WaiterID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WaiterName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZhuoTaiDishOrder).HasComment("桌台菜品顺序号");

                entity.Property(e => e.ZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("ZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("桌台ID");

                entity.Property(e => e.ZhuoTaiName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("桌台名称");

                entity.Property(e => e.ZtpeopleNum)
                    .HasColumnName("ZTPeopleNum")
                    .HasDefaultValueSql("((1))")
                    .HasComment("桌台人数");
            });

            modelBuilder.Entity<OrderZhuoTaiDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasComment("定单桌台菜品关系表");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasComment("订单桌台关系ID");

                entity.Property(e => e.ActivityMode).HasDefaultValueSql("((1))");

                entity.Property(e => e.ActivityParam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("时间");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BatchId).HasColumnName("BatchID");

                entity.Property(e => e.DishCostMoney)
                    .HasColumnType("money")
                    .HasComment("菜品成本金额");

                entity.Property(e => e.DishDisplayOrder)
                    .HasDefaultValueSql("((1))")
                    .HasComment("菜品显示顺序");

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品ID(如果是套餐，则是套餐ID)");

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品名称");

                entity.Property(e => e.DishNum)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("菜品数量");

                entity.Property(e => e.DishNumOk)
                    .IsRequired()
                    .HasColumnName("DishNumOK")
                    .HasDefaultValueSql("((1))")
                    .HasComment("数量是否确定 0：不确定  1：确定");

                entity.Property(e => e.DishPaidMoney)
                    .HasColumnType("money")
                    .HasComment("菜品做法加价[也已经包含数量]");

                entity.Property(e => e.DishPrice)
                    .HasColumnType("money")
                    .HasComment("菜品原始价格");

                entity.Property(e => e.DishStatusDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品说明");

                entity.Property(e => e.DishStatusId)
                    .HasColumnName("DishStatusID")
                    .HasComment("菜品状态 0：已点，未送单  1： 已送单");

                entity.Property(e => e.DishTiChengMoney).HasColumnType("money");

                entity.Property(e => e.DishTotalMoney)
                    .HasColumnType("money")
                    .HasComment("菜品销售的金额(单价乘数量)");

                entity.Property(e => e.DishTuiCaiNum)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("退菜数量");

                entity.Property(e => e.DishTypeId)
                    .IsRequired()
                    .HasColumnName("DishTypeID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品类型");

                entity.Property(e => e.DishTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishTzs)
                    .HasColumnName("DishTZS")
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("条只数 0:没有条只数");

                entity.Property(e => e.DishVipprice)
                    .HasColumnName("DishVIPPrice")
                    .HasColumnType("money")
                    .HasComment("会员价格");

                entity.Property(e => e.DishWebPrice).HasColumnType("money");

                entity.Property(e => e.DishZengSongNum)
                    .HasColumnType("decimal(18, 3)")
                    .HasComment("赠送数量");

                entity.Property(e => e.DishZheKouMoney)
                    .HasColumnType("money")
                    .HasComment("折扣的金额(折后的金额-菜品实际销售的价格)[已经包含数量]");

                entity.Property(e => e.DishZuoFaMoney)
                    .HasColumnType("money")
                    .HasComment("做法加价的金额");

                entity.Property(e => e.FenTanDishPaidMoney).HasColumnType("money");

                entity.Property(e => e.FenTanDishPrice).HasColumnType("money");

                entity.Property(e => e.HuaCaiNum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsHuaCai).HasComment("是否已经划菜  0：没有划菜   1：已经划菜");

                entity.Property(e => e.IsPackage).HasComment("是否是套餐 0：不是套餐  1：是套餐");

                entity.Property(e => e.KouWeiIds)
                    .IsRequired()
                    .HasColumnName("KouWeiIDS")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KouWeiNames)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo3)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo4)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo5)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo6)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo7)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Memo8)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("OrderZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("定单桌台关系Guid");

                entity.Property(e => e.OriginPrice).HasColumnType("money");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShangCaiShiJian)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("上菜时间");

                entity.Property(e => e.ShiTeJiaParam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SongDanTime).HasColumnType("datetime");

                entity.Property(e => e.SongDanUserName)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Spec).HasMaxLength(20);

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasComment("门店Code");

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("菜品单位");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WaiterId)
                    .IsRequired()
                    .HasColumnName("WaiterID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("服务员ID");

                entity.Property(e => e.WaiterName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("服务员名称");

                entity.Property(e => e.ZheKouParam)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.ZuoFaIds)
                    .IsRequired()
                    .HasColumnName("ZuoFaIDs")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZuoFaNames)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<PhoneCallRecord>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddUser).HasMaxLength(40);

                entity.Property(e => e.CallTime).HasColumnType("datetime");

                entity.Property(e => e.Contact).HasMaxLength(40);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<PreordainDishTmp>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasColumnName("MemberID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreordainUid)
                    .IsRequired()
                    .HasColumnName("PreordainUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreorderDishUid)
                    .IsRequired()
                    .HasColumnName("PreorderDishUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PreorderDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishPrice).HasColumnType("money");

                entity.Property(e => e.DishStatusDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishTotalMoney).HasColumnType("money");

                entity.Property(e => e.DishZuoFaMoney).HasColumnType("money");

                entity.Property(e => e.KouWeiIds)
                    .IsRequired()
                    .HasColumnName("KouWeiIDs")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.KouWeiNames)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Memo3)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PeiLiaoNames).HasMaxLength(500);

                entity.Property(e => e.PreorderId)
                    .IsRequired()
                    .HasColumnName("PreorderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.ZuoFaIds)
                    .IsRequired()
                    .HasColumnName("ZuoFaIDs")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ZuoFaNames)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<PreorderPackageDish>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishId)
                    .IsRequired()
                    .HasColumnName("DishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.DishPrice).HasColumnType("money");

                entity.Property(e => e.DishStatusDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DishTotalMoney).HasColumnType("money");

                entity.Property(e => e.KouWeiIds)
                    .IsRequired()
                    .HasColumnName("KouWeiIDs")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.KouWeiNames)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Memo1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Memo2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Memo3)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PackageId)
                    .IsRequired()
                    .HasColumnName("PackageID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreorderDishId)
                    .IsRequired()
                    .HasColumnName("PreorderDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreorderId)
                    .IsRequired()
                    .HasColumnName("PreorderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitId)
                    .IsRequired()
                    .HasColumnName("UnitID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.ZuoFaIds)
                    .IsRequired()
                    .HasColumnName("ZuoFaIDs")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ZuoFaNames)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrintHistory>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.Client)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastPrinter)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastPrinterName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrintContent)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.PrinterId)
                    .IsRequired()
                    .HasColumnName("PrinterID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrinterName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<PrintHistoryCount>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BanCiId)
                    .HasColumnName("BanCiID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZhuoTaiId)
                    .IsRequired()
                    .HasColumnName("ZhuoTaiID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysBiaoQian>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BiaoQianName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaperType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysBiaoQianDetail>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BiaoQianUid)
                    .IsRequired()
                    .HasColumnName("BiaoQianUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateFormat)
                    .HasColumnName("dateFormat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FiledName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Font)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShowTitleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysGroupInfo>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_GroupInfo");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AboutUs).HasColumnType("ntext");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AppId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppSecret)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BankAccountName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsSingleStore)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MchId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RegionId)
                    .IsRequired()
                    .HasColumnName("RegionID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.WelImageUrl)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wxid)
                    .HasColumnName("WXId")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysGroupUser>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_GroupUser");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AllStore)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CurrentToken)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.IsEnable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsGuestManager)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastCheckTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Macbind)
                    .IsRequired()
                    .HasColumnName("MACBind")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OtherAccountType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OtherPassWord)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OtherUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordBak)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qq)
                    .IsRequired()
                    .HasColumnName("QQ")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShouQuanCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.StoreList)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TrueName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(50);

                entity.Property(e => e.Wxid)
                    .IsRequired()
                    .HasColumnName("WXID")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.YouMian)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.YouMianBiLi).HasDefaultValueSql("((100))");

                entity.Property(e => e.ZheKouBiLi).HasDefaultValueSql("((100))");
            });

            modelBuilder.Entity<SysMedias>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__SysMedia__C5B19602245D67DE");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Memo).HasColumnType("text");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .IsRequired()
                    .HasColumnName("ParentID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");
            });

            modelBuilder.Entity<SysRight>(entity =>
            {
                entity.HasKey(e => e.RightId);

                entity.Property(e => e.RightId)
                    .HasColumnName("RightID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.PageName)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.RightName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<SysStoreInfo>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_StoreInfo");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.BankAccount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BankAccountName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BrandName).HasMaxLength(40);

                entity.Property(e => e.BrandUid)
                    .HasColumnName("BrandUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CaiPuName).HasMaxLength(40);

                entity.Property(e => e.CaiPuUid)
                    .HasColumnName("CaiPuUID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DistributionCenterId)
                    .HasColumnName("DistributionCenterID")
                    .HasComment("默认配送中心的UID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(150)
                    .HasComment("图片地址");

                entity.Property(e => e.IsSingleStore)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.JingDu)
                    .HasMaxLength(50)
                    .HasComment("经度");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RegionId)
                    .IsRequired()
                    .HasColumnName("RegionID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreType).HasComment("0-普通门店  1-加工中心");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.WeiDu)
                    .HasMaxLength(50)
                    .HasComment("纬度");

                entity.Property(e => e.WeiXinId)
                    .IsRequired()
                    .HasColumnName("WeiXinID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SysUnit>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_ERP_UNIT");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysWelcome>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CenterUid)
                    .IsRequired()
                    .HasColumnName("CenterUID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.KeyWord)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Welcome)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransferDishRecord>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_TranserDishRecord");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DishNum).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SourceOrderId)
                    .IsRequired()
                    .HasColumnName("SourceOrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SourceOrderZhuoTaiDishId)
                    .IsRequired()
                    .HasColumnName("SourceOrderZhuoTaiDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SourceZhuoTaiId)
                    .HasColumnName("SourceZhuoTaiID")
                    .HasColumnType("text");

                entity.Property(e => e.SourceZhuoTaiName)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TargetOrderId)
                    .IsRequired()
                    .HasColumnName("TargetOrderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TargetOrderZhuoTaiDishId)
                    .IsRequired()
                    .HasColumnName("TargetOrderZhuoTaiDishID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TargetZhuoTaiId)
                    .HasColumnName("TargetZhuoTaiID")
                    .HasColumnType("text");

                entity.Property(e => e.TargetZhuoTaiName)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UploadedData>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.HasIndex(e => e.AddTime)
                    .HasName("Index_UploadedData_AddTime");

                entity.HasIndex(e => e.Uid)
                    .HasName("Index_UploadedData_UID");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<UploadedDataTmp>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Client)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<WaiMaiDishMap>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.AddUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bak3)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishId1)
                    .IsRequired()
                    .HasColumnName("DishID1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishId2)
                    .IsRequired()
                    .HasColumnName("DishID2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishId3)
                    .IsRequired()
                    .HasColumnName("DishID3")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishId4)
                    .IsRequired()
                    .HasColumnName("DishID4")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DishId5)
                    .IsRequired()
                    .HasColumnName("DishID5")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WuXianLsh>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .IsClustered(false);

                entity.ToTable("WuXianLSH");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wxorder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .IsClustered(false);

                entity.ToTable("WXOrder");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
