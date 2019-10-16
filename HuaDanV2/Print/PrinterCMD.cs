using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaiMomoClient
{
    #region 枚举
    public enum E_PRINT_ALIGN { 
        左对齐 = 0,
        居中,
        右对齐
    }

    public enum E_PRINT_FONT
    {
        正常大小=0,两倍高=1,两倍宽=2,两倍大小=3,三倍高=4,三倍宽=5,三倍大小=6,四倍高=7,四倍宽=8,四倍大小=9,五倍高=10,五倍宽=11,五倍大小=12
    }
    #endregion

    public class PrinterCMD
    {
        /// <summary>
        /// 初始化打印机
        /// </summary>
        /// <returns></returns>
        public string cmdSetPos()
        {
            return ((Char)27).ToString() + ((Char)64).ToString();
        }

        /// <summary>
        /// 设置默认行间距
        /// </summary>
        /// <returns></returns>
        public string cmdNormalLineSpacing()
        {
            return ((Char)27).ToString() + ((Char)50).ToString();
        }

        /// <summary>
        /// 设置行间距
        /// </summary>
        /// <returns></returns>
        public string cmdSetLineSpacing(int spacing)
        {
            return ((Char)27).ToString() + ((Char)51).ToString() + ((Char)spacing).ToString();
        }

        /// <summary>
        /// 换行（回车）
        /// </summary>
        /// <returns></returns>
        public string cmdEnter()
        {
            return ((Char)10).ToString();
        }

        /// <summary>
        /// 对齐模式
        /// </summary>
        /// <param name="align">0:左对齐 1:中对齐 2:右对齐</param>
        /// <returns></returns>
        public string cmdTextAlign(int align)
        {
            return ((Char)27).ToString() + ((Char)97).ToString() + ((Char)align).ToString();
        }

        /// <summary>
        /// 选择/取消加粗模式
        /// </summary>
        /// <param name="align">0:取消加粗模式 1:选择加粗模式</param>
        /// <returns></returns>
        public string cmdTextBold(int bold)
        {
            return ((Char)27).ToString() + ((Char)69).ToString() + ((Char)bold).ToString();
        }

        /// <summary>
        /// 鸣叫(适用于GP-80xxx系列)
        /// </summary>
        /// <param name="count">鸣叫次数</param>
        /// <param name="leep">鸣叫间隔(leep*50毫秒)</param>
        /// <returns></returns>
        public string cmdBeep(int count, int leep)
        {
            return ((Char)27).ToString() + ((Char)66).ToString() + ((Char)count).ToString() + ((Char)leep).ToString();
        }

        //产生声音指令   莹浦通
        //指令:		GS   	BELL   	n	m1	m2
        //十进制码：	29	07	n	m1	m2
        //十六进制码：	1D	07	n	m1	m2
        // 1= < n = < 255             ；声音次数
        // 1= < m1 = < 255            ；声音开启时间  =  m1 x 0.1秒
        // 1 = < m2 = < 255           ；声音关闭时间  =  m1 x 0.1秒  
        public string cmdBeepForYPT(int count, int leep)
        {
            return ((Char)29).ToString() + ((Char)7).ToString() + ((Char)count).ToString() + ((Char)1).ToString() + ((Char)1).ToString();
        }

        //ESC BS n 设置蜂鸣器鸣叫模式                                                                 
        //[功能描述]                 设置蜂鸣器鸣叫模式
        //[数据格式]           ASCII                 ESC         BS        n
        //Hex                                 1B        08        n
        //Decimal                                 27        8        n
        //[取值范围]                 0 ≤ n ≤ 25，n=32
        //[应用注释]               * 设置蜂鸣器鸣叫模式和鸣叫时间
        //                  * 1 ≤ n ≤ 25，设置蜂鸣器鸣叫时间，时间计算公式如下：
        //鸣叫时间 = 200ms × n
        //* n = 0，打印机按照设定的鸣叫时间进行长鸣
        //* n= 32, 打印机按照设定的鸣叫时间鸣叫多次
        //* 如果没有设置鸣叫时间，n = 0或32时蜂鸣器不鸣叫。
        public string cmdBeepForXBY(int count)
        {
            return ((Char)27).ToString() + ((Char)7).ToString() + ((Char)5).ToString() + ((Char)27).ToString() + ((Char)7).ToString() + ((Char)0).ToString();
        }

        ///<summary>
        ///Epson TM 220 Select Color
        ///</summary>
        ///<param name="color">48:Black 49:Red</param>
        ///<returns></returns>
        public string cmdColor(int color)
        {
            return ((Char)27).ToString() + ((Char)114).ToString() + ((Char)color).ToString();
        }

        /// <summary>
        /// 字体的大小
        /// </summary>
        /// <param name="nfontsize">0:正常大小 1:两倍高 2:两倍宽 3:两倍大小 4:三倍高 5:三倍宽 6:三倍大小 7:四倍高 8:四倍宽 9:四倍大小 10:五倍高 11:五倍宽 12:五倍大小</param>
        /// <returns></returns>
        public string cmdFontSize(int nfontsize)
        {
            string _cmdstr = "";

            //设置字体大小
            switch (nfontsize)
            {
                case -1:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)0).ToString();//29 33
                    break;

                case 0:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)0).ToString();//29 33
                    break;

                case 1:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)1).ToString();
                    break;

                case 2:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)16).ToString();
                    break;

                case 3:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)17).ToString();
                    break;

                case 4:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)2).ToString();
                    break;

                case 5:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)32).ToString();
                    break;

                case 6:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)34).ToString();
                    break;

                case 7:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)3).ToString();
                    break;

                case 8:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)48).ToString();
                    break;

                case 9:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)51).ToString();
                    break;

                case 10:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)4).ToString();
                    break;

                case 11:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)64).ToString();
                    break;

                case 12:
                    _cmdstr = ((Char)29).ToString() + ((Char)33).ToString() + ((Char)68).ToString();
                    break;

            }
            return _cmdstr;
        }

        /// <summary>
        /// BTP-M280(针打) 倍宽倍高
        /// </summary>
        /// <param name="size">0:取消倍宽倍高模式  1:倍高模式 2:倍宽模式 3:两倍大小</param>
        /// <param name="style">0:无下划线 128：有下划线</param>
        /// <returns></returns>
        public string cmdFontSizeBTPM280(int size)
        {
            string _cmdstr = "";
            //只有0和1两种模式
            int fontsize = size;

            switch (fontsize)
            {
                case 1:
                    _cmdstr = ((Char)28).ToString() + ((Char)33).ToString() + ((Char)(8)).ToString();
                    break;
                case 2:
                    _cmdstr = ((Char)28).ToString() + ((Char)33).ToString() + ((Char)(4)).ToString();
                    break;
                case 3:
                    //_cmdstr = ((Char)28).ToString() + ((Char)87).ToString() + ((Char)1).ToString();
                    _cmdstr = ((Char)28).ToString() + ((Char)33).ToString() + ((Char)(12)).ToString();
                    break;
                default:
                    //_cmdstr = ((Char)28).ToString() + ((Char)87).ToString() + ((Char)0).ToString();
                    _cmdstr = ((Char)28).ToString() + ((Char)33).ToString() + ((Char)0).ToString();
                    break;
            }

            return _cmdstr;
        }

        /// <summary>
        /// BTP-M280(针打) 倍宽倍高
        /// </summary>
        /// <param name="size">0:取消倍宽倍高模式  1:倍高模式 2:倍宽模式 3:两倍大小</param>
        /// <param name="style">0:无下划线 128：有下划线</param>
        /// <returns></returns>
        public string cmdFontSizeBTPM2801(int size)
        {
            string _cmdstr = "";
            //只有0和1两种模式
            int fontsize = size;

            switch (fontsize)
            {
                case 1:
                    _cmdstr = ((Char)27).ToString() + ((Char)33).ToString() + ((Char)(17)).ToString();
                    break;
                case 2:
                    _cmdstr = ((Char)27).ToString() + ((Char)33).ToString() + ((Char)(33)).ToString();
                    break;
                case 3:
                    _cmdstr = ((Char)27).ToString() + ((Char)33).ToString() + ((Char)(49)).ToString();
                    break;
                default:
                    _cmdstr = ((Char)27).ToString() + ((Char)33).ToString() + ((Char)(1)).ToString();
                    break;
            }

            return _cmdstr;
        }

        /// <summary>
        /// 走纸
        /// </summary>
        /// <param name="line">走纸的行数</param>
        /// <returns></returns>
        public string cmdPageGO(int line)
        {
            return ((Char)27).ToString() + ((Char)100).ToString() + ((Char)line).ToString();
        }

        /// <summary>
        /// 切割
        /// </summary>
        /// <returns></returns>
        public string cmdCutPage()
        {
            return ((Char)27).ToString() + ((Char)109).ToString();
        }

        /// <summary>
        /// 选择切纸模式并切纸
        /// </summary>
        /// <returns></returns>
        public string cmdHalfCutPage()
        {
            return ((Char)29).ToString() + ((Char)86).ToString() + ((Char)1).ToString();
        }

        /// <summary>
        /// 返回状态(返回8位的二进制)
        /// </summary>
        /// <param name="num">1:打印机状态 2:脱机状态 3:错误状态 4:传送纸状态</param>
        /// 返回打印机状态如下：
        /// 第一位：固定为0
        /// 第二位：固定为1
        /// 第三位：0:一个或两个钱箱打开  1:两个钱箱都关闭
        /// 第四位：0:联机  1:脱机
        /// 第五位：固定为1
        /// 第六位：未定义
        /// 第七位：未定义
        /// 第八位：固定为0
        /// 
        /// 返回脱机状态如下：
        /// 第一位：固定为0
        /// 第二位：固定为1
        /// 第三位：0:上盖关  1:上盖开
        /// 第四位：0:未按走纸键  1:按下走纸键
        /// 第五位：固定为1
        /// 第六位：0:打印机不缺纸  1: 打印机缺纸
        /// 第七位：0:没有出错情况  1:有错误情况
        /// 第八位：固定为0
        /// 
        /// 返回错误状态如下：
        /// 第一位：固定为0
        /// 第二位：固定为1
        /// 第三位：未定义
        /// 第四位：0:切刀无错误  1:切刀有错误
        /// 第五位：固定为1
        /// 第六位：0:无不可恢复错误  1: 有不可恢复错误
        /// 第七位：0:打印头温度和电压正常  1:打印头温度或电压超出范围
        /// 第八位：固定为0
        /// 
        /// 返回传送纸状态如下：
        /// 第一位：固定为0
        /// 第二位：固定为1
        /// 第三位：0:有纸  1:纸将尽
        /// 第四位：0:有纸  1:纸将尽
        /// 第五位：固定为1
        /// 第六位：0:有纸  1:纸尽
        /// 第七位：0:有纸  1:纸尽
        /// 第八位：固定为0
        /// <returns></returns>
        public string cmdReturnStatus(int num)
        {
            return ((Char)16).ToString() + ((Char)4).ToString() + ((Char)num).ToString();
        }

        public string cmdReturnStatus()
        {
            return ((Char)16).ToString() + ((Char)9).ToString();
        }

        /// <summary>
        /// 条码高宽
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string cmdTiaoMaHeight(int num)
        {
            //return ((Char)29).ToString() + "h" + ((Char)num).ToString();
            return ((Char)29).ToString() + ((Char)104).ToString() + ((Char)num).ToString();
        }

        /// <summary>
        /// 条码宽度
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string cmdTiaoMaWidth(int num)
        {
            //return ((Char)29).ToString() + "w" + ((Char)num).ToString();   
            //return ((Char)29).ToString() + ((Char)119).ToString() + ((Char)num).ToString();//之前
            return ((Char)29).ToString() + ((Char)119).ToString() + ((Char)2).ToString();
        }

        /// <summary>
        /// 条码数字打印的位置
        /// </summary>
        /// <param name="num">1:上方  2:下方  0:不打印数字</param>
        /// <returns></returns>
        public string cmdTiaoMaWeiZi(int num)
        {
            return ((Char)29).ToString() + "H" + ((Char)num).ToString();
        }

        /// <summary>
        /// 开始打印(条码类型为CODE39)
        /// </summary>
        /// <param name="numstr"></param>
        /// <returns></returns>
        public string cmdTiaoMaPrint(string numstr)
        {
            //return ((Char)29).ToString() + "k" + ((Char)4).ToString() + numstr + ((Char)0).ToString();
            //string txm = ((Char)29).ToString() + ((Char)107).ToString() + ((Char)4).ToString();

            //char[] numslist = numstr.ToCharArray();
            //if (numslist != null && numslist.Length > 0)
            //{
            //    int charint = 0;
            //    foreach (char nums in numslist)
            //    {
            //        if (int.TryParse(nums.ToString(), out charint))
            //        {
            //            txm += ((Char)(charint + 48)).ToString();
            //        }
            //    }
            //}

            //return ((Char)29).ToString() + ((Char)107).ToString() + ((Char)4).ToString() + numstr + ((Char)0).ToString();
            //return ((Char)29).ToString() + ((Char)107).ToString() + ((Char)73).ToString() + ((Char)numstr.Length).ToString() + numstr;//====之前
            return ((Char)29).ToString() + ((Char)107).ToString() + ((Char)4).ToString() + numstr + ((Char)0).ToString();
            //return txm + ((Char)0).ToString();
        }

        /// <summary>
        /// 打开钱箱
        /// </summary>
        /// <returns></returns>
        public string cmdQianXiang()
        {
            return ((Char)27).ToString() + ((Char)112).ToString() + ((Char)0).ToString() + ((Char)60).ToString() + ((Char)255).ToString();
        }
    }
}
