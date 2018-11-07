using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace WindowsFormsApp1
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
        /// <summary>
            /// 构造函数
            /// </summary>
        public ImageBox()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            m_ColorCoordinate = Color.Red;
            this.m_Scale = 1;
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
        public void DrawSin()
        {
            List<PointF> list = new List<PointF>();
            for (int i = -100 * (int)Math.PI; i < 100 * (int)Math.PI; i++)
            {
                float x = i / 100.0f;
                float y = (float)Math.Sin((double)x);
                list.Add(new PointF(x * 100, y * 100));
            }
            m_Points = list.ToArray();
            this.Invalidate();
        }
        /// <summary>
            /// 得到抛物线函数值坐标点
            /// </summary>
            /// <returns></returns>
        public void DrawPow()
        {
            List<PointF> list = new List<PointF>();
            for (int i = -100; i < (int)100; i++)
            {
                float x = i / 100f;
                float y = (float)Math.Pow((double)x, 2);
                list.Add(new PointF(x * 100, y * 100));
            }
            m_Points = list.ToArray();
            this.Invalidate();
        }
        public void ClearFunImage()
        {
            this.m_Points = null;
            this.Invalidate();
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
                if (m_Points != null && m_Points.Length > 1)
                {
                    g.DrawCurve(SystemPens.ControlText, m_Points);
                }
            }
            g.Restore(state);
        }
        /// <summary>
            /// 重写以切换Sin,Pow函数图像进行绘图测试
            /// </summary>
            /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right)
            {
                this.ClearFunImage();
                return;
            }
            switch (e.Clicks)
            {
                case 1:
                    this.DrawSin();
                    break;
                case 2:
                    this.DrawPow();
                    break;
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Add)
            {
                this.ScaleImage(this.m_Scale + this.m_Scale * 0.02f);
            }
            else if (keyData == Keys.Subtract)
            {
                this.ScaleImage(this.m_Scale - this.m_Scale * 0.02f);
            }
            return base.ProcessDialogKey(keyData);
        }
    }
 

    
       
    

}

