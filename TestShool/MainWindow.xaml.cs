using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestShool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random Rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();

            CreateFigure();
        }

        private void CreateFigure()
        {
            int size = 40;
            int widthContainer = 150;
            int heightContainer = 150;

            List<Geometry> figures;

            while (CheckIntersections())
            {
                figures = new List<Geometry>
                {
                    CreateTriangle(size, widthContainer, heightContainer),
                    CreateSquare(size, widthContainer, heightContainer),
                    CreateEllipse(size, widthContainer, heightContainer),
                    CreateRhomb(size, widthContainer, heightContainer),
                    CreateFlame(size, widthContainer, heightContainer),
                    CreatePentagon(size, widthContainer, heightContainer),
                    CreateStar(size, widthContainer, heightContainer)
                };

            }

            cnvAnswerFirst.Children.Clear();

            foreach (Geometry item in figures)
            {
                cnvAnswerFirst.Children.Add(new Path()
                {
                    StrokeThickness = 3,
                    Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                    Data = item
                });
            }
        }

        private bool CheckIntersections()
        {
            return true;
        }

        private Geometry CreateTriangle(int size, int widthContainer, int heightContainer)
        {
            Point pointStart = new Point(Rnd.Next(1, widthContainer - size), Rnd.Next(size, heightContainer - 1));
            Point[] points = new Point[] {
                new Point(pointStart.X + size / 2, pointStart.Y - size),
                new Point(pointStart.X + size, pointStart.Y)
            };

            Geometry g = new StreamGeometry();
            using (StreamGeometryContext ctx = ((StreamGeometry)g).Open())
            {
                ctx.BeginFigure(pointStart, true, true);
                ctx.PolyLineTo(points, true, false);
            }

            return g;
        }

        private Geometry CreateSquare(int size, int widthContainer, int heightContainer)
        {
            Geometry g = new RectangleGeometry(new Rect
                (
                new Point(Rnd.Next(widthContainer), Rnd.Next(heightContainer - size)),
                new Size(size, size)
                ));

            return g;
        }

        private Geometry CreateEllipse(int size, int widthContainer, int heightContainer)
        {
            Geometry g = new EllipseGeometry
                (
                new Point(
                    Rnd.Next(size + 1, widthContainer - size),
                    Rnd.Next(size + 1, heightContainer - size)
                    ),
                size / 2,
                size / 2
                );

            return g;
        }

        private Geometry CreateRhomb(int size, int widthContainer, int heightContainer)
        {
            Point pointStart = new Point(Rnd.Next(size / 2 + 1, widthContainer - size / 2), Rnd.Next(size + 1, heightContainer - 1));
            Point[] points = new Point[]
            {
                new Point(pointStart.X - size / 2, pointStart.Y - size / 2),
                new Point(pointStart.X, pointStart.Y - size),
                new Point(pointStart.X + size / 2, pointStart.Y - size / 2)
            };

            Geometry g = new StreamGeometry();
            using (StreamGeometryContext ctx = ((StreamGeometry)g).Open())
            {
                ctx.BeginFigure(pointStart, true, true);
                ctx.PolyLineTo(points, true, false);
            }

            return g;
        }

        private Geometry CreateFlame(int size, int widthContainer, int heightContainer)
        {
            Point pointStart = new Point(Rnd.Next(1, widthContainer - size), Rnd.Next(size - size / 4 + 1, heightContainer - size / 4));
            Point[] points = new Point[]
            {
                new Point(pointStart.X + size / 2, pointStart.Y - size + size / 4),
                new Point(pointStart.X + size, pointStart.Y),
                new Point(pointStart.X + 5 * size / 6, pointStart.Y + size / 4),
                new Point(pointStart.X + size / 6, pointStart.Y + size / 4)
            };

            Geometry g = new StreamGeometry();
            using (StreamGeometryContext ctx = ((StreamGeometry)g).Open())
            {
                ctx.BeginFigure(pointStart, true, true);
                ctx.PolyLineTo(points, true, false);
            }

            return g;
        }

        private Geometry CreatePentagon(int size, int widthContainer, int heightContainer)
        {
            Point pointStart = new Point(Rnd.Next(1, widthContainer - size), Rnd.Next(size - size / 4 + 1, heightContainer - size / 4));
            Point[] points = new Point[]
            {
                new Point(pointStart.X + size / 2, pointStart.Y - size / 4),
                new Point(pointStart.X + size, pointStart.Y),
                new Point(pointStart.X + size - size / 6, pointStart.Y + size - size / 4),
                new Point(pointStart.X + size / 6, pointStart.Y + size - size / 4)
            };

            Geometry g = new StreamGeometry();
            using (StreamGeometryContext ctx = ((StreamGeometry)g).Open())
            {
                ctx.BeginFigure(pointStart, true, true);
                ctx.PolyLineTo(points, true, false);
            }

            return g;
        }

        private Geometry CreateStar(int size, int widthContainer, int heightContainer)
        {
            int count = 5;
            int outerRadius = size / 2;
            int innerRadius = outerRadius / 2;
            double alpha = 0;
            PointCollection points = new PointCollection()
            {
                new Point(Rnd.Next(size / 2 + 1, widthContainer - size / 2),
                Rnd.Next(size + 1, heightContainer - 1))
            };

            for (int i = 0; i < 2 * count + 1; i++)
            {
                if (i % 2 == 0)
                {
                    points.Add(new Point(points[0].X + innerRadius * Math.Cos(alpha), points[0].Y + innerRadius * Math.Sin(alpha)));
                }
                else
                {
                    points.Add(new Point(points[0].X + outerRadius * Math.Cos(alpha), points[0].Y + outerRadius * Math.Sin(alpha)));
                }
                alpha += Math.PI / count;
            }

            Geometry g = new StreamGeometry();
            using (StreamGeometryContext ctx = ((StreamGeometry)g).Open())
            {
                ctx.BeginFigure(points[0], true, true);
                ctx.PolyLineTo(points, true, false);
            }

            return g;
        }

        //private int GetCoordinateY(int size, int sizeContainer, bool IsUp)
        //{
        //    if (IsUp)
        //    {
        //        return Rnd.Next(size + 1, sizeContainer / 2);
        //    }
        //    else
        //    {
        //        return Rnd.Next(sizeContainer / 2 + size + 1, sizeContainer);
        //    }
        //}

        //private static bool HasIntersection(Geometry g1, Geometry g2)
        //{
        //    return g1.FillContainsWithDetail(g2) != IntersectionDetail.Empty;
        //}

        //private static Transform GetFullTransform(UIElement e)
        //{
        //    var transforms = new TransformGroup();

        //    if (e.RenderTransform != null)
        //        transforms.Children.Add(e.RenderTransform);

        //    var xTranslate = (double)e.GetValue(Canvas.LeftProperty);
        //    if (double.IsNaN(xTranslate))
        //        xTranslate = 0D;

        //    var yTranslate = (double)e.GetValue(Canvas.TopProperty);
        //    if (double.IsNaN(yTranslate))
        //        yTranslate = 0D;

        //    var translateTransform = new TranslateTransform(xTranslate, yTranslate);
        //    transforms.Children.Add(translateTransform);

        //    return transforms;
        //}

        //private Geometry RenderedIntersect(Visual ctx, Polygon s)
        //{
        //    var t = s.TransformToAncestor(ctx) as Transform;
        //    var g = s.RenderedGeometry;
        //    g.Transform = t;
        //    return g;
        //}




        //private Polygon CreateSquare(ref int x, int size, int sizeContainer, bool IsUp)
        //{
        //    int y = GetCoordinateY(size, sizeContainer, IsUp);

        //    return new Polygon()
        //    {
        //        Points = new PointCollection()
        //        {
        //            new Point(x, y),
        //            new Point(x, y -= size),
        //            new Point(x += size, y),
        //            new Point(x, y + size),
        //        },
        //        StrokeThickness = 3,
        //        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18")
        //    };
        //}

        //private Ellipse CreateEllipse(ref int x, int size, int sizeContainer, bool IsUp)
        //{
        //    int marginY;
        //    if (IsUp)
        //    {
        //        marginY = Rnd.Next(sizeContainer / 2 - size);
        //    }
        //    else
        //    {
        //        marginY = Rnd.Next(sizeContainer / 2, sizeContainer - size);
        //    }

        //    x += size;

        //    Geometry g = new EllipseGeometry(new Point(100, 100), 50, 50);

        //    return new Ellipse()
        //    {
        //        Width = size,
        //        Height = size,
        //        StrokeThickness = 3,
        //        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
        //        Margin = new Thickness(x - size, marginY, 0, 0)
        //    };
        //}

        //private Polygon CreateRhomb(ref int x, int size, int sizeContainer, bool IsUp)
        //{
        //    int y = GetCoordinateY(size, sizeContainer, IsUp);

        //    return new Polygon()
        //    {
        //        Points = new PointCollection()
        //        {
        //            new Point(x + size / 2, y),
        //            new Point(x, y -= size / 2),
        //            new Point(x += size / 2, y - size / 2),
        //            new Point(x += size / 2, y),
        //        },
        //        StrokeThickness = 3,
        //        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18")
        //    };
        //}

        //private Polygon CreateFlame(ref int x, int size, int sizeContainer, bool IsUp)
        //{
        //    int y = GetCoordinateY(size, sizeContainer, IsUp);

        //    return new Polygon()
        //    {
        //        Points = new PointCollection()
        //        {
        //            new Point(x + size / 6, y),
        //            new Point(x, y - size / 4),
        //            new Point(x += size / 2, y - size),
        //            new Point(x += size / 2, y - size / 4),
        //            new Point(x - size / 6, y)
        //        },
        //        StrokeThickness = 3,
        //        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18")
        //    };
        //}

        //private Polygon CreatePentagon(ref int x, int size, int sizeContainer, bool IsUp)
        //{
        //    int y = GetCoordinateY(size, sizeContainer, IsUp);

        //    return new Polygon()
        //    {
        //        Points = new PointCollection()
        //        {
        //            new Point(x + size / 6, y),
        //            new Point(x, y - size + size / 4),
        //            new Point(x += size / 2, y - size),
        //            new Point(x += size / 2, y - size + size / 4),
        //            new Point(x - size / 6, y)
        //        },
        //        StrokeThickness = 3,
        //        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18")
        //    };
        //}

        //private Polygon CreateStar(ref int x, int size, int sizeContainer, bool IsUp)
        //{
        //    int y = GetCoordinateY(size, sizeContainer, IsUp);
        //    x += size / 2;

        //    int count = 5;
        //    int outerRadius = size / 2;
        //    int innerRadius = outerRadius / 2;
        //    double alpha = 0;
        //    PointCollection points = new PointCollection();

        //    for (int i = 0; i < 2 * count + 1; i++)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            points.Add(new Point(x + innerRadius * Math.Cos(alpha), y + innerRadius * Math.Sin(alpha)));
        //        }
        //        else
        //        {
        //            points.Add(new Point(x + outerRadius * Math.Cos(alpha), y + outerRadius * Math.Sin(alpha)));
        //        }
        //        alpha += Math.PI / count;
        //    }

        //    x += size / 2;

        //    return new Polygon()
        //    {
        //        Points = points,
        //        StrokeThickness = 3,
        //        Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18")
        //    };
        //}
    }
}