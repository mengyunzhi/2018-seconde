using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace supermarket
{
    /// <summary>
    /// 显示由Graphics绘制的图像
    /// </summary>
    internal class ImageBox : ScrollableControl {
        private Color m_ColorCoordinate;
        private PointF[] m_Points;
        private PointF position;
        private float m_Scale;
        private SizeF m_ImageSize;
        private int num;
        /// <summary>
            /// 构造函数
            /// </summary>
        public ImageBox(int number)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            m_ColorCoordinate = Color.Red;
            this.m_Scale = 1;
            this.num = number;
        }
        /// <summary>
            /// 画布的大小
            /// </summary>
        public SizeF ImageSize
        {
            get {
                return m_ImageSize;
            }
            set {
                this.m_ImageSize = value;
                this.AutoScrollMinSize = Size.Ceiling(new SizeF(this.m_ImageSize.Width * this.m_Scale, this.m_ImageSize.Height * this.m_Scale));
            }
        }
        /// <summary>
            /// 坐标系的X,Y两轴的颜色
            /// </summary>
        public Color ColorCoordinate {
            get {
                return this.m_ColorCoordinate;
            }
            set {
                this.m_ColorCoordinate = value;
                this.Invalidate(this.ClientRectangle, false);
            }
        }
        /// <summary>
            /// 重写以进行绘制
            /// </summary>
            /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            this.drawMathImage(e.Graphics, this.getStartPoint(), this.m_Scale);
        }
        /// <summary>
            /// 得到Sin函数值坐标点
            /// </summary>
            /// <returns></returns>
        public void DrawSin() {
            List<PointF> list = new List<PointF>();      // 存放居民区的坐标
            List<float> xs = new List<float>();          // 存放居民区x的坐标
            List<float> ys = new List<float>();          // 存放居民区y的坐标

            // 随机生成居民区的位置
            Random ran = new Random();
            for (int i = 0; i < num; i++) {
                float x = ran.Next(-10, 10);
                float y = ran.Next(-10, 10);
                xs.Add(x * 10);
                ys.Add(y * 10);
                list.Add(new PointF(x * 10, y * 10));
            }
            // 计算超市的位置
            m_Points = list.ToArray();
            float px = Median(xs.ToArray());
            float py = Median(ys.ToArray());
            position = new PointF(px, py);

            this.Invalidate();
        }

        // 计算距离之和
        public float SumDistance() {
            float result = 0;
            if (m_Points != null && !position.IsEmpty) {
                foreach (PointF m_Point in m_Points) {
                    float x = System.Math.Abs(position.X - m_Point.X);
                    float y = System.Math.Abs(position.Y - m_Point.Y);
                    result += (float)Math.Sqrt(x * x + y * y);
                }
            }
            return result;
        }

        // 计算中位数
        private static float Median(float[] arr) {
            float mediaValue = 0;
            var getLengthItems = arr.Length;
            Array.Sort(arr);
            // 如果个数是偶数，则取中间的两个数的平均数作为中位数
            if (getLengthItems % 2 == 0) {
                float firstValue = arr[(arr.Length / 2) - 1];
                float secondValue = arr[(arr.Length / 2)];
                mediaValue = (firstValue + secondValue) / 2;
            }
            // 如果个数是奇数，则取中间的数作为中位数
            if (getLengthItems % 2 == 1) {
                mediaValue = arr[(arr.Length / 2)];
            }
            return mediaValue;
        }

        public void ClearFunImage() {
            this.m_Points = null;
            this.Invalidate();
        }
        /// <summary>
            /// 放大图像的倍数
            /// </summary>
            /// <param name="scale"></param>
        public void ScaleImage(float scale) {
            float tmp = scale;
            if (tmp > 0) {
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
        private PointF getStartPoint() {
            SizeF size = new SizeF(this.m_ImageSize.Width * this.m_Scale, this.m_ImageSize.Height * this.m_Scale);
            PointF point = this.AutoScrollPosition;

            if (size.Width > this.ClientRectangle.Width && size.Height < this.ClientRectangle.Height) {
                point.Y += (this.ClientRectangle.Height - size.Height) / 2.0f;
            }
            else if (size.Width < this.ClientRectangle.Width && size.Height > this.ClientRectangle.Height) {
                point.X += (this.ClientRectangle.Width - size.Width) / 2.0f;
            }
            else if (size.Width <= this.ClientRectangle.Width && size.Height <= this.ClientRectangle.Height) {
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
        private void drawMathImage(Graphics g, PointF start, float scale) {
            //建立坐标中点坐标
            float tmpOX = this.AutoScrollMinSize.Width / 2.0f;
            float tmpOY = this.AutoScrollMinSize.Height / 2.0f;

            GraphicsState state = g.Save();
            using (Matrix matrix = new Matrix(1, 0, 0, -1, 0, 0)) {
                g.Transform = matrix;
                g.PageUnit = GraphicsUnit.Pixel;
                g.TranslateTransform(tmpOX + start.X, -tmpOY - start.Y, MatrixOrder.Prepend);
                g.ScaleTransform(this.m_Scale, this.m_Scale, MatrixOrder.Prepend);

                float maxX = tmpOX / scale;
                float maxY = tmpOY / scale;

                //绘制坐标轴线
                using (Pen pen = new Pen(this.m_ColorCoordinate, 1)) {
                    g.DrawLine(pen, -maxX, 0.0f, maxX, 0.0f);
                    g.DrawLine(pen, 0.0f, -maxY, 0.0f, maxY);

                    g.DrawLine(pen, maxX, 0.0f, maxX - 2.0f, 2.0f);
                    g.DrawLine(pen, maxX, 0.0f, maxX - 2.0f, -2.0f);

                    g.DrawLine(pen, 0.0f, maxY, 2.0f, maxY - 2.0f);
                    g.DrawLine(pen, 0.0f, maxY, -2.0f, maxY - 2.0f);
                }
                // 绘制点的分布图
                Pen pointPen = new Pen(Color.Black, 5); // 绘制居民区的钢笔
                Pen superMarketPen = new Pen(Color.Red, 5); // 绘制超市的钢笔
                Size size = new Size(1, 1);                // 点的大小

                // 绘制居民区的分布图
                if (m_Points != null) {                   
                    List<RectangleF> rf = new List<RectangleF>();
                    foreach (PointF m_point in m_Points) {
                        rf.Add(new RectangleF(m_point, size));
                    }
                    g.DrawRectangles(pointPen, rf.ToArray());
                }

                // 绘制超市的分布图
                if (!position.IsEmpty) {
                    List<RectangleF> rf = new List<RectangleF>();
                    rf.Add(new RectangleF(position, size));
                    g.DrawRectangles(superMarketPen, rf.ToArray());
                }

            }
            g.Restore(state);
        }
        /// <summary>
            /// 重写以切换Sin函数图像进行绘图测试
            /// </summary>
            /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right) {
                this.ClearFunImage();
                return;
            }
            switch (e.Clicks)
            {
                case 1:
                    this.DrawSin();
                    ShowMessage();
                    break;
            }
        }
        // 显示点的坐标情况
        private void ShowMessage() {
            string message = "";
            foreach (PointF point in m_Points) {
                message += "居民区坐标：" + point.ToString() + "\r\n";
            }
            message += "超市坐标：" + position.ToString() + "\r\n";
            message += "最小距离和为：" + SumDistance().ToString();
            MessageBox.Show(message);
        }
        protected override bool ProcessDialogKey(Keys keyData) {
            if (keyData == Keys.Add) {
                this.ScaleImage(this.m_Scale + this.m_Scale * 0.02f);
            }
            else if (keyData == Keys.Subtract) {
                this.ScaleImage(this.m_Scale - this.m_Scale * 0.02f);
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
