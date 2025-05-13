using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms; // Required for Control in Erase method if used

namespace ProjektNr1Paczesny72541
{
    public abstract class Shape
    {
        public List<System.Drawing.Point> ControlPoints { get; protected set; }
        public Color PenColor { get; protected set; }
        public Color FillColor { get; protected set; }
        public DashStyle LineStyle { get; protected set; }
        public float LineWidth { get; protected set; }
        public bool Visible { get; set; }
        public bool IsFilled { get; protected set; }
        public bool IsBordered { get; protected set; }

        // Start and End points for simple two-point definition, common for many shapes
        public System.Drawing.Point StartPoint => ControlPoints.Count > 0 ? ControlPoints[0] : System.Drawing.Point.Empty;
        public System.Drawing.Point EndPoint => ControlPoints.Count > 1 ? ControlPoints[1] : System.Drawing.Point.Empty;


        protected Shape(System.Drawing.Point startPoint, Color penColor, DashStyle lineStyle, float lineWidth)
        {
            ControlPoints = new List<System.Drawing.Point> { startPoint };
            PenColor = penColor;
            LineStyle = lineStyle;
            LineWidth = lineWidth;
            Visible = false;
            FillColor = Color.LightGray; // Default fill color
            IsFilled = false;
            IsBordered = true;
        }

        public virtual void AddOrUpdateEndPoint(System.Drawing.Point point)
        {
            if (ControlPoints.Count < 2)
            {
                ControlPoints.Add(point);
            }
            else
            {
                ControlPoints[1] = point;
            }
        }

        public abstract void Draw(Graphics g);

        public virtual void Erase(Graphics g, Control drawingSurface)
        {
            // Generic erase by redrawing with background color is complex.
            // The main form will clear and redraw all, so this might not be strictly needed per shape.
            Visible = false;
        }

        public virtual void Move(int dx, int dy)
        {
            for (int i = 0; i < ControlPoints.Count; i++)
            {
                ControlPoints[i] = new System.Drawing.Point(ControlPoints[i].X + dx, ControlPoints[i].Y + dy);
            }
        }

        public virtual void SetAttributes(Color penColor, Color fillColor, DashStyle lineStyle, float lineWidth, bool isFilled, bool isBordered)
        {
            PenColor = penColor;
            FillColor = fillColor;
            LineStyle = lineStyle;
            LineWidth = lineWidth;
            IsFilled = isFilled;
            IsBordered = isBordered;
        }

        protected Rectangle GetBoundingRectangle()
        {
            if (ControlPoints.Count < 2) return Rectangle.Empty;
            return new Rectangle(
                Math.Min(StartPoint.X, EndPoint.X),
                Math.Min(StartPoint.Y, EndPoint.Y),
                Math.Abs(EndPoint.X - StartPoint.X),
                Math.Abs(EndPoint.Y - StartPoint.Y)
            );
        }
    }

    public class LineShape : Shape
    {
        public LineShape(System.Drawing.Point start, System.Drawing.Point end, Color penColor, DashStyle lineStyle, float lineWidth)
            : base(start, penColor, lineStyle, lineWidth)
        {
            AddOrUpdateEndPoint(end);
            IsFilled = false; // Lines cannot be filled
            IsBordered = true;
        }

        public override void Draw(Graphics g)
        {
            if (ControlPoints.Count < 2 || !Visible) return;
            using (Pen pen = new Pen(PenColor, LineWidth) { DashStyle = LineStyle })
            {
                g.DrawLine(pen, StartPoint, EndPoint);
            }
        }
    }

    public class RectangleShape : Shape
    {
        public RectangleShape(System.Drawing.Point start, System.Drawing.Point end, Color penColor, Color fillColor, DashStyle lineStyle, float lineWidth, bool isFilled, bool isBordered)
            : base(start, penColor, lineStyle, lineWidth)
        {
            AddOrUpdateEndPoint(end);
            FillColor = fillColor;
            IsFilled = isFilled;
            IsBordered = isBordered;
        }

        public override void Draw(Graphics g)
        {
            if (ControlPoints.Count < 2 || !Visible) return;
            Rectangle rect = GetBoundingRectangle();
            if (rect.Width == 0 || rect.Height == 0) return;

            if (IsFilled)
            {
                using (SolidBrush brush = new SolidBrush(FillColor))
                {
                    g.FillRectangle(brush, rect);
                }
            }
            if (IsBordered)
            {
                using (Pen pen = new Pen(PenColor, LineWidth) { DashStyle = LineStyle })
                {
                    g.DrawRectangle(pen, rect);
                }
            }
        }
    }

    public class SquareShape : RectangleShape // Square is a special Rectangle
    {
        public SquareShape(System.Drawing.Point start, System.Drawing.Point end, Color penColor, Color fillColor, DashStyle lineStyle, float lineWidth, bool isFilled, bool isBordered)
            : base(start, end, penColor, fillColor, lineStyle, lineWidth, isFilled, isBordered)
        {
            // Adjust to make it a square
            Rectangle rect = base.GetBoundingRectangle();
            int side = Math.Min(rect.Width, rect.Height);
            System.Drawing.Point adjustedEnd = new System.Drawing.Point(StartPoint.X + (EndPoint.X > StartPoint.X ? side : -side), StartPoint.Y + (EndPoint.Y > StartPoint.Y ? side : -side));
            ControlPoints[1] = adjustedEnd;
        }
        // Draw method is inherited from RectangleShape
    }


    public class EllipseShape : Shape
    {
        public EllipseShape(System.Drawing.Point start, System.Drawing.Point end, Color penColor, Color fillColor, DashStyle lineStyle, float lineWidth, bool isFilled, bool isBordered)
            : base(start, penColor, lineStyle, lineWidth)
        {
            AddOrUpdateEndPoint(end);
            FillColor = fillColor;
            IsFilled = isFilled;
            IsBordered = isBordered;
        }

        public override void Draw(Graphics g)
        {
            if (ControlPoints.Count < 2 || !Visible) return;
            Rectangle rect = GetBoundingRectangle();
            if (rect.Width == 0 || rect.Height == 0) return;

            if (IsFilled)
            {
                using (SolidBrush brush = new SolidBrush(FillColor))
                {
                    g.FillEllipse(brush, rect);
                }
            }
            if (IsBordered)
            {
                using (Pen pen = new Pen(PenColor, LineWidth) { DashStyle = LineStyle })
                {
                    g.DrawEllipse(pen, rect);
                }
            }
        }
    }

    public class CircleShape : EllipseShape // Circle is a special Ellipse
    {
        public CircleShape(System.Drawing.Point start, System.Drawing.Point end, Color penColor, Color fillColor, DashStyle lineStyle, float lineWidth, bool isFilled, bool isBordered)
            : base(start, end, penColor, fillColor, lineStyle, lineWidth, isFilled, isBordered)
        {
            Rectangle rect = base.GetBoundingRectangle();
            int diameter = Math.Min(rect.Width, rect.Height);
            System.Drawing.Point adjustedEnd = new System.Drawing.Point(StartPoint.X + (EndPoint.X > StartPoint.X ? diameter : -diameter), StartPoint.Y + (EndPoint.Y > StartPoint.Y ? diameter : -diameter));
            ControlPoints[1] = adjustedEnd;
        }
        // Draw method is inherited from EllipseShape
    }

    public class BezierCurveShape : Shape
    {
        // For a simple Bezier with 2 clicks: P0, P1 (calculated), P2 (calculated), P3
        public BezierCurveShape(System.Drawing.Point p0, System.Drawing.Point p3, Color penColor, DashStyle lineStyle, float lineWidth)
            : base(p0, penColor, lineStyle, lineWidth)
        {
            // Calculate P1 and P2 for a smooth curve based on P0 and P3
            System.Drawing.Point p1 = new System.Drawing.Point(p0.X + (p3.X - p0.X) / 3, p0.Y + (p3.Y - p0.Y) / 2); // Example control point
            System.Drawing.Point p2 = new System.Drawing.Point(p3.X - (p3.X - p0.X) / 3, p3.Y - (p3.Y - p0.Y) / 2); // Example control point

            ControlPoints.Add(p1); // Index 1
            ControlPoints.Add(p2); // Index 2
            ControlPoints.Add(p3); // Index 3 (EndPoint effectively)
            IsFilled = false;
        }

        public override void Draw(Graphics g)
        {
            if (ControlPoints.Count < 4 || !Visible) return;
            using (Pen pen = new Pen(PenColor, LineWidth) { DashStyle = LineStyle })
            {
                g.DrawBezier(pen, ControlPoints[0], ControlPoints[1], ControlPoints[2], ControlPoints[3]);
            }
        }
    }

    public class CardinalCurveShape : Shape
    {
        // Needs at least 2 points for DrawCurve, more for a "curvy" appearance.
        // For simplicity with 2 clicks, we'll treat it like a line, or user needs to add more points.
        // This implementation assumes ControlPoints will be populated (e.g., multiple clicks).
        // For a 2-click scenario, it will just draw a line between StartPoint and EndPoint.
        public CardinalCurveShape(List<System.Drawing.Point> points, Color penColor, DashStyle lineStyle, float lineWidth, bool isClosed, bool isFilled, bool isBordered, Color fillColor)
            : base(points.Count > 0 ? points[0] : System.Drawing.Point.Empty, penColor, lineStyle, lineWidth)
        {
            if (points.Count > 0)
            {
                ControlPoints = new List<System.Drawing.Point>(points);
            }
            IsFilled = isFilled;
            IsBordered = isBordered; // For DrawClosedCurve, border is implicit. For Fill, border can be added.
            FillColor = fillColor;
            // Note: 'isClosed' is used to decide between DrawCurve and DrawClosedCurve
        }

        public bool IsClosed { get; set; } // Specific to CardinalCurve

        public override void Draw(Graphics g)
        {
            if (ControlPoints.Count < 2 || !Visible) return;

            System.Drawing.Point[] pointsArray = ControlPoints.ToArray();

            if (IsFilled && IsClosed && ControlPoints.Count >=3)
            {
                using (SolidBrush brush = new SolidBrush(FillColor))
                {
                    g.FillClosedCurve(brush, pointsArray);
                }
            }

            if (IsBordered) // This will draw the curve line itself, or border for filled shape
            {
                using (Pen pen = new Pen(PenColor, LineWidth) { DashStyle = LineStyle })
                {
                    if (IsClosed && ControlPoints.Count >=3)
                    {
                        g.DrawClosedCurve(pen, pointsArray);
                    }
                    else if (ControlPoints.Count >=2) // Open curve or line
                    {
                        g.DrawCurve(pen, pointsArray);
                    }
                }
            }
        }
    }

    public class ArcShape : Shape
    {
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }

        public ArcShape(System.Drawing.Point start, System.Drawing.Point end, Color penColor, DashStyle lineStyle, float lineWidth, float startAngle, float sweepAngle)
            : base(start, penColor, lineStyle, lineWidth)
        {
            AddOrUpdateEndPoint(end);
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
            IsFilled = false; // Arcs are not filled
        }

        public override void Draw(Graphics g)
        {
            if (ControlPoints.Count < 2 || !Visible) return;
            Rectangle rect = GetBoundingRectangle();
            if (rect.Width == 0 || rect.Height == 0) return;

            using (Pen pen = new Pen(PenColor, LineWidth) { DashStyle = LineStyle })
            {
                g.DrawArc(pen, rect, StartAngle, SweepAngle);
            }
        }
    }

    public class PieShape : Shape
    {
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }

        public PieShape(System.Drawing.Point start, System.Drawing.Point end, Color penColor, Color fillColor, DashStyle lineStyle, float lineWidth, bool isFilled, bool isBordered, float startAngle, float sweepAngle)
            : base(start, penColor, lineStyle, lineWidth)
        {
            AddOrUpdateEndPoint(end);
            FillColor = fillColor;
            IsFilled = isFilled;
            IsBordered = isBordered;
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
        }

        public override void Draw(Graphics g)
        {
            if (ControlPoints.Count < 2 || !Visible) return;
            Rectangle rect = GetBoundingRectangle();
            if (rect.Width == 0 || rect.Height == 0) return;

            if (IsFilled)
            {
                using (SolidBrush brush = new SolidBrush(FillColor))
                {
                    g.FillPie(brush, rect, StartAngle, SweepAngle);
                }
            }
            if (IsBordered) // If only bordered (DrawPie) or if filled and also bordered
            {
                using (Pen pen = new Pen(PenColor, LineWidth) { DashStyle = LineStyle })
                {
                    g.DrawPie(pen, rect, StartAngle, SweepAngle);
                }
            }
        }
    }

    public class GluedBezierShape : Shape
    {
        private bool previewOnly;
        public GluedBezierShape(List<Point> points, Color penColor, DashStyle lineStyle, float lineWidth, bool previewOnly = false)
            : base(points.Count > 0 ? points[0] : Point.Empty, penColor, lineStyle, lineWidth)
        {
            this.ControlPoints = new List<Point>(points);
            this.previewOnly = previewOnly;
            this.Visible = !previewOnly;
        }

        public override void Draw(Graphics g)
        {
            if (ControlPoints.Count < 4) return;
            using (Pen pen = new Pen(PenColor, LineWidth) { DashStyle = LineStyle })
            {
                int n = (ControlPoints.Count - 1) / 3;
                for (int i = 0; i < n; i++)
                {
                    int idx = i * 3;
                    if (idx + 3 < ControlPoints.Count)
                    {
                        g.DrawBezier(pen,
                            ControlPoints[idx],
                            ControlPoints[idx + 1],
                            ControlPoints[idx + 2],
                            ControlPoints[idx + 3]);
                    }
                }
                // If previewOnly and not enough for a full segment, draw a line to the last point
                if (previewOnly && (ControlPoints.Count - 1) % 3 != 0)
                {
                    int last = ControlPoints.Count - 1;
                    g.DrawLine(pen, ControlPoints[last - 1], ControlPoints[last]);
                }
            }
        }
    }
}
