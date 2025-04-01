using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProjektNr1Paczesny72541
{
    internal class GeometricShapes
    {
        public class Point
        {
            public int X { get; protected set; }
            public int Y { get; protected set; }
            public Color Color { get; protected set; }
            public bool Visible { get; protected set; }
            
            // Important attributes
            public int Radius { get; protected set; }
            public DashStyle DashStyle { get; protected set; }
            public float LineWidth { get; protected set; }
            
            public Point(int x, int y)
            {
                X = x;
                Y = y;
                Radius = 1;
                Color = Color.Red;
                Visible = false;
                DashStyle = DashStyle.Dash;
                LineWidth = 2;
            }

            public Point(int x, int y, Color color) : this(x, y)
            {
                Color = color;
            }

            public virtual void Draw(Graphics g)
            {
                if (Visible) return;
                
                using (SolidBrush brush = new SolidBrush(Color))
                {
                    g.FillEllipse(brush, X - Radius, Y - Radius, Radius, Radius);
                }
                
                Visible = true;
            }
            
            public virtual void Erase(Graphics g, Control c)
            {
                if (!Visible) return;
                
                using (SolidBrush brush = new SolidBrush(c.BackColor))
                {
                    g.FillEllipse(brush, X - Radius, Y - Radius, Radius, Radius);
                }
                
                Visible = false;
            }

            public virtual void Move(Graphics g, Control c, int x, int y)
            {
                Erase(g, c);

                X = x;
                Y = y;
                
                Draw(g);
            }
            
            // declaring public methods (accessible for other classes)
            public void SetAttributes(Color? lineColor, DashStyle? dashStyle, int? x, int? y, float? lineWidth) 
            {
                if (lineColor != null)
                {
                    Color = (Color)lineColor;
                }
                
                if (dashStyle != null)
                {
                    DashStyle = (DashStyle)dashStyle;
                }
                
                if (x != null)
                {
                    X = (int)x;
                }
                
                if (y != null)
                {
                    Y = (int)y;
                }
                
                if (lineWidth != null)
                {
                    LineWidth = (float)lineWidth;
                }
            }
        }
        
        public class Line : Point
        {
            public int Xk { get; protected set; }
            public int Yk { get; protected set; }
            
            public Line(int x1, int y1, int xk, int yk) : base(x1, y1)
            {
                Xk = xk;
                Yk = yk;
            }

            public Line(int x1, int y1, int xk, int yk, Color color) : this(x1, y1, xk, yk)
            {
                Color = color;
            }

            public override void Draw(Graphics g)
            {
                if (Visible) return;
                
                using (Pen pen = new Pen(Color, LineWidth) { DashStyle = DashStyle })
                {
                    g.DrawLine(pen, X, Y, Xk, Yk);
                }
                
                Visible = true;
            }
            
            public override void Erase(Graphics g, Control c)
            {
                if (!Visible) return;
                
                using (SolidBrush brush = new SolidBrush(c.BackColor))
                {
                    g.DrawLine(new Pen(brush, LineWidth) { DashStyle = DashStyle }, X, Y, Xk, Yk);
                }
                
                Visible = false;
            }

            public override void Move(Graphics g, Control c, int x, int y)
            {
                Erase(g, c);

                Xk = x;
                Yk = y;
                
                Draw(g);
            }
        }
    }
}