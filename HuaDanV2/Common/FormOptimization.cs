using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace HuaDan
{
    public class FormOptimization
    {  /// <summary>
        /// 界面优化-圆角
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Region SetWindowRegion(int width, int height)
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            //抗锯齿
            Rectangle rect = new Rectangle(0, 0, width, height);
            FormPath = GetRoundedRectPath(rect, 10);
            return new Region(FormPath);
        }

        /// <summary>  
        ///   
        /// </summary>  
        /// <param name="rect">窗体大小</param>  
        /// <param name="radius">圆角大小</param>  
        /// <returns></returns>  
        private static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arcRect, 180, 90);//左上角  

            arcRect.X = rect.Right - diameter;//右上角  
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rect.Bottom - diameter;// 右下角  
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rect.Left;// 左下角  
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
