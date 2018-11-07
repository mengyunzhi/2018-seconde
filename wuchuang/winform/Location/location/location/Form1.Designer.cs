using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace location
{
    /*
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    }
    */

    /// <summary>
    /// 显示由Graphics绘制的图像
    /// </summary>
    internal class ImageBox : ScrollableControl
    {
        private Color m_ColorCoordinate;
        private PointF[] m_Points;
        private float m_Scale;
        private SizeF m_ImageSize;
        private int num;
        private int[] location_x = new int[4];
        private int[] location_y = new int[4];
        private int loc_x;
        private int loc_y;
        /// <summary>
            /// 构造函数
            /// </summary>
        public ImageBox(int i)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            m_ColorCoordinate = Color.Red;
            this.m_Scale = 1;
            num = i;
            setRandom();
            
        }
        /// <summary>
            /// 画布的大小
            /// </summary>
        public SizeF ImageSize
        {
            get
            {
                return m_ImageSize;
            }
            set
            {
                this.m_ImageSize = value;
                this.AutoScrollMinSize = Size.Ceiling(new SizeF(this.m_ImageSize.Width * this.m_Scale, this.m_ImageSize.Height * this.m_Scale));
            }
        }
        /// <summary>
            /// 坐标系的X,Y两轴的颜色
            /// </summary>
        public Color ColorCoordinate
        {
            get
            {
                return this.m_ColorCoordinate;
            }
            set
            {
                this.m_ColorCoordinate = value;
                this.Invalidate(this.ClientRectangle, false);
            }
        }
        /// <summary>
            /// 重写以进行绘制
            /// </summary>
            /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.drawMathImage(e.Graphics, this.getStartPoint(), this.m_Scale);
        }
        /// <summary>
            /// 得到Sin函数值坐标点
            /// </summary>
            /// <returns></returns>
        
       public void setRandom()
        {
            int total = 100;
            int count = 2*num;
            int[] index = new int[total];
            for (int i = 0,j = -50; i < total; i++, j++)
            {
                index[i] = j;
            }
            Random r = new Random();
            //用来保存随机生成的不重复的10个数  
            int[] result = new int[count];
            //int site = total;//设置下限  
            int id;
            for (int j = 0; j < count; j++)
            {
                if (j < num)
                {
                    id = r.Next(0, total - 1);
                    //在随机位置取出一个数，保存到结果数组  
                    location_x[j] = index[id];
                    //最后一个数复制到当前位置  
                    index[id] = index[total - 1];
                    //位置的下限减少一  
                    total--;
                }
                else
                {
                    id = r.Next(0, total - 1);
                    //在随机位置取出一个数，保存到结果数组  
                    location_y[j - 4] = index[id];
                    //最后一个数复制到当前位置  
                    index[id] = index[total - 1];
                    //位置的下限减少一  
                    total--;
                }
            }
        }

        public void DrawSin()
        {
            

           
        }
        public void order_x()
        {
            int[] array = new int[num];
            for (int i = 0; i < num; i++)
                array[i] = location_x[i];
            int t;
            bool tag = true;

            for (int i = num - 1; i >= 1 && tag; i--)
            {
                
                tag = false;
                for (int j = 0; j < i; j++) //for循环进行冒泡排序
                {
                    if (array [j] < array [j + 1])
                    {

                        t = array [j];
                        array [j] = array [j + 1];
                        array [j + 1] = t;
                        tag = true;
                    }
                }
            }
            if (num % 2 == 0)
            {
                loc_x = (array[num/2] + array[num/2 - 1]) / 2;
            }
            else
            {
                loc_x = array[(num - 1) / 2];
            }

        }
        public void order_y()
        {
            int[] array = new int[num];
            for (int i = 0; i < num; i++)
                array[i] = location_y[i];
            int t;
            bool tag = true;

            for (int i = num - 1; i >= 1 && tag; i--)
            {
                tag = false;
                for (int j = 0; j < i; j++) //for循环进行冒泡排序
                {
                    if (array[j] < array[j + 1])
                    {

                        t = array[j];
                        array [j] = array[j + 1];
                        array[j + 1] = t;
                        tag = true;
                    }
                }
            }
            if (num % 2 == 0)
            {
                loc_y = (array[num / 2] + array[num / 2 - 1]) / 2;
            }
            else
            {
                loc_y = array[(num - 1) / 2];
            }

        }
        

        /// <summary>
            /// 放大图像的倍数
            /// </summary>
            /// <param name="scale"></param>
        public void ScaleImage(float scale)
        {
            float tmp = scale;
            if (tmp > 0)
            {
                this.m_Scale = tmp;
                SizeF size = new SizeF(this.m_ImageSize.Width * this.m_Scale, this.m_ImageSize.Height * this.m_Scale);

                base.AutoScrollMinSize = Size.Ceiling(size);
                this.Invalidate();
            }
        }
        /// <summary>
            /// 由当前的滚动信息得到开始点以用来计算绘图原点信息
            /// </summary>
            /// <returns></returns>
        private PointF getStartPoint()
        {
            SizeF size = new SizeF(this.m_ImageSize.Width * this.m_Scale, this.m_ImageSize.Height * this.m_Scale);
            PointF point = this.AutoScrollPosition;

            if (size.Width > this.ClientRectangle.Width && size.Height < this.ClientRectangle.Height)
            {
                point.Y += (this.ClientRectangle.Height - size.Height) / 2.0f;
            }
            else if (size.Width < this.ClientRectangle.Width && size.Height > this.ClientRectangle.Height)
            {
                point.X += (this.ClientRectangle.Width - size.Width) / 2.0f;
            }
            else if (size.Width <= this.ClientRectangle.Width && size.Height <= this.ClientRectangle.Height)
            {
                point.Y += (this.ClientRectangle.Height - size.Height) / 2.0f;
                point.X += (this.ClientRectangle.Width - size.Width) / 2.0f;
            }
            return point;
        }
        /// <summary>
            /// 使用指定的Graphics对象进行绘图
            /// </summary>
            /// <param name="g">用来绘图的Graphics对象</param>
            /// <param name="startPoint">绘图的时候坐标的偏移量</param>
        private void drawMathImage(Graphics g, PointF start, float scale)
        {
            //建立坐标中点坐标
            order_x();
            order_y();
            float tmpOX = this.AutoScrollMinSize.Width / 2.0f;
            float tmpOY = this.AutoScrollMinSize.Height / 2.0f;

            GraphicsState state = g.Save();
            using (Matrix matrix = new Matrix(1, 0, 0, -1, 0, 0))
            {
                g.Transform = matrix;
                g.PageUnit = GraphicsUnit.Pixel;
                g.TranslateTransform(tmpOX + start.X, -tmpOY - start.Y, MatrixOrder.Prepend);
                g.ScaleTransform(this.m_Scale, this.m_Scale, MatrixOrder.Prepend);

                float maxX = tmpOX / scale;
                float maxY = tmpOY / scale;

                //绘制坐标轴线
                using (Pen pen = new Pen(this.m_ColorCoordinate, 1))
                {
                    g.DrawLine(pen, -maxX, 0.0f, maxX, 0.0f);
                    g.DrawLine(pen, 0.0f, -maxY, 0.0f, maxY);

                    g.DrawLine(pen, maxX, 0.0f, maxX - 2.0f, 2.0f);
                    g.DrawLine(pen, maxX, 0.0f, maxX - 2.0f, -2.0f);

                    g.DrawLine(pen, 0.0f, maxY, 2.0f, maxY - 2.0f);
                    g.DrawLine(pen, 0.0f, maxY, -2.0f, maxY - 2.0f);
                }
                //绘制函数图像
                
                for (int i = 0; i < num; i++)
                {
                    Pen pointPen = new Pen(Color.Black, 5);
                    Point location = new Point(location_x[i], location_y[i]);
                    Size size = new Size(5, 5);
                    Rectangle r = new Rectangle(location, size);
                    g.DrawRectangle(pointPen, r);
                }
                
                Pen pointPen_shop = new Pen(Color.Red, 5);
                Point location_shop = new Point(loc_x, loc_y);
                Size size_shop = new Size(5, 5);
                Rectangle r_shop = new Rectangle(location_shop, size_shop);
                g.DrawRectangle(pointPen_shop, r_shop);

            }
            g.Restore(state);
        }
 
       
        
    }
}

