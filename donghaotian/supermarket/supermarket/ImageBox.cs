using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket
{
    class Imagebox
    {
        
        /// <summary>
        /// 显示由Graphics绘制的图像
        /// </summary>
        internal class ImageBox : ScrollableControl
        {
            private Color m_ColorCoordinate;
            private PointF[] m_Points;
            private float m_Scale;
            private SizeF m_ImageSize;
            float[] arrayx = new float[5];
            float[] arrayy = new float[5];
            int max;
            /// <summary>
                /// 构造函数
                /// </summary>
            public ImageBox(int x)
            {
                max = x;
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
                Array.Sort(arrayx);
                Array.Sort(arrayy);
                string a;
                if (max % 2 == 1)    
                a="x:"+ arrayx[max  / 2].ToString () +"\r\n"+"y:"+arrayy[max  / 2].ToString ();
                else a = "x:" + ((arrayx[(max -1)/ 2]+arrayx [(max+1)/2])/2).ToString() + "\r\n" + "y:" + ((arrayy[(max - 1) / 2] + arrayy[(max + 1) / 2])/2).ToString();
                MessageBox.Show(a);
            }
            /// <summary>
                /// 得到函数值坐标点
                /// </summary>
                /// <returns></returns>
            public void DrawSin()
            {
                List<PointF> list = new List<PointF>();

                m_Points = list.ToArray();
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
                // 建立坐标中点坐标
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

                    // 绘制坐标轴线
                    using (Pen pen = new Pen(this.m_ColorCoordinate, 1))
                    {
                        g.DrawLine(pen, -maxX, 0.0f, maxX, 0.0f);
                        g.DrawLine(pen, 0.0f, -maxY, 0.0f, maxY);

                        g.DrawLine(pen, maxX, 0.0f, maxX - 2.0f, 2.0f);
                        g.DrawLine(pen, maxX, 0.0f, maxX - 2.0f, -2.0f);

                        g.DrawLine(pen, 0.0f, maxY, 2.0f, maxY - 2.0f);
                        g.DrawLine(pen, 0.0f, maxY, -2.0f, maxY - 2.0f);
                    }
                    // 绘制函数图像
                    if (m_Points != null && m_Points.Length > 1)
                    {
                        g.DrawCurve(SystemPens.ControlText, m_Points);
                    }
                    // 绘制坐标点

                    Pen home = new Pen(Color .Blue,5);
                    Pen supermarket = new Pen(Color.Red, 5);
                    Random ra = new Random();
                    
                    
                    for (int i = 0; i < max; i++)
                    {
                        float x = (float)(ra.Next(0, 200) - 100 + ra.NextDouble());
                        arrayx[i] = x;
                        float y = (float)(ra.Next(0, 200) - 100 + ra.NextDouble());
                        arrayy[i] = y;
                        g.DrawRectangle (home, x, y, 5,5);
                }
                    float a,b;
                    if (max % 2 == 1)
                    {
                        a = arrayx[max / 2];
                        b = arrayy[max / 2];
                    }
                    else
                    {
                        a = (arrayx[(max - 1) / 2] + arrayx[(max + 1) / 2]) / 2;
                        b = (arrayy[(max - 1) / 2] + arrayy[(max + 1) / 2]) / 2;
                    }
                    g.DrawEllipse(supermarket, a, b, 5, 5);
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

                this.DrawSin();

            }

            private void ClearFunImage()
            {
                throw new NotImplementedException();
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
}
