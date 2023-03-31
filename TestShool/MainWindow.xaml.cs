using System;
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

            ShowFigure();
        }

        private void ShowFigure()
        {
            int size = 40;
            int widthContainer = 150;
            int heightContainer = 150;

            Path triangle = CreateTriangle(size, widthContainer, heightContainer);
            Path triangle1 = CreateTriangle(size, widthContainer, heightContainer);
            Path triangle2 = CreateTriangle(size, widthContainer, heightContainer);
            //Path square = CreateSquare(size, widthContainer, heightContainer);
            //Path ellipse = CreateEllipse(size, widthContainer, heightContainer);
            //Path rhomb = CreateRhomb(size, widthContainer, heightContainer);
            //Path flame = CreateFlame(size, widthContainer, heightContainer);
            //Path pentagon = CreatePentagon(size, widthContainer, heightContainer);
            //Path star = CreateStar(size, widthContainer, heightContainer);

            cnvAnswerFirst.Children.Add(triangle);
            cnvAnswerFirst.Children.Add(triangle1);
            cnvAnswerFirst.Children.Add(triangle2);
            //cnvAnswerFirst.Children.Add(square);
            //cnvAnswerFirst.Children.Add(ellipse);
            //cnvAnswerFirst.Children.Add(rhomb);
            //cnvAnswerFirst.Children.Add(flame);
            //cnvAnswerFirst.Children.Add(pentagon);
            //cnvAnswerFirst.Children.Add(star);
        }

        private Path CreateTriangle(int size, int widthContainer, int heightContainer)
        {
            Point pointStart = new Point(Rnd.Next(1, widthContainer - size), Rnd.Next(size, heightContainer - size));
            Point[] points = new Point[] { new Point(pointStart.X + size / 2, pointStart.Y - size), new Point(pointStart.X + size, pointStart.Y) };

            Geometry g = new StreamGeometry();
            using (StreamGeometryContext ctx = ((StreamGeometry)g).Open())
            {
                ctx.BeginFigure(pointStart, true, true);
                ctx.PolyLineTo(points, true, false);
            }

            return new Path()
            {
                StrokeThickness = 3,
                Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                Data = g
            };
        }

        private Polygon CreateSquare(ref int x, int size, int sizeContainer, bool IsUp)
        {
            return new Polygon();
            //{
            //    Points = new PointCollection()
            //    {
            //        new Point(x, y),
            //        new Point(x, y -= size),
            //        new Point(x += size, y),
            //        new Point(x, y + size),
            //    },
            //    StrokeThickness = 3,
            //    Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18")
            //};
        }

        private Ellipse CreateEllipse(ref int x, int size, int sizeContainer, bool IsUp)
        {
            int marginY;
            if (IsUp)
            {
                marginY = Rnd.Next(sizeContainer / 2 - size);
            }
            else
            {
                marginY = Rnd.Next(sizeContainer / 2, sizeContainer - size);
            }

            x += size;

            Geometry g = new EllipseGeometry(new Point(100, 100), 50, 50);

            return new Ellipse()
            {
                Width = size,
                Height = size,
                StrokeThickness = 3,
                Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                Margin = new Thickness(x - size, marginY, 0, 0)
            };
        }

        private Polygon CreateRhomb(ref int x, int size, int sizeContainer, bool IsUp)
        {
            return new Polygon();
            //{
            //    Points = new PointCollection()
            //    {
            //        new Point(x + size / 2, y),
            //        new Point(x, y -= size / 2),
            //        new Point(x += size / 2, y - size / 2),
            //        new Point(x += size / 2, y),
            //    },
            //    StrokeThickness = 3,
            //    Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18")
            //};
        }

        private Polygon CreateFlame(ref int x, int size, int sizeContainer, bool IsUp)
        {
            return new Polygon();
            //{
            //    Points = new PointCollection()
            //    {
            //        new Point(x + size / 6, y),
            //        new Point(x, y - size / 4),
            //        new Point(x += size / 2, y - size),
            //        new Point(x += size / 2, y - size / 4),
            //        new Point(x - size / 6, y)
            //    },
            //    StrokeThickness = 3,
            //    Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18")
            //};
        }

        private Polygon CreatePentagon(ref int x, int size, int sizeContainer, bool IsUp)
        {
            return new Polygon();
            //{
            //    Points = new PointCollection()
            //    {
            //        new Point(x + size / 6, y),
            //        new Point(x, y - size + size / 4),
            //        new Point(x += size / 2, y - size),
            //        new Point(x += size / 2, y - size + size / 4),
            //        new Point(x - size / 6, y)
            //    },
            //    StrokeThickness = 3,
            //    Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18")
            //};
        }

        private Polygon CreateStar(ref int x, int size, int sizeContainer, bool IsUp)
        {
            x += size / 2;

            int count = 5;
            int outerRadius = size / 2;
            int innerRadius = outerRadius / 2;
            double alpha = 0;
            PointCollection points = new PointCollection();

            //for (int i = 0; i < 2 * count + 1; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        points.Add(new Point(x + innerRadius * Math.Cos(alpha), y + innerRadius * Math.Sin(alpha)));
            //    }
            //    else
            //    {
            //        points.Add(new Point(x + outerRadius * Math.Cos(alpha), y + outerRadius * Math.Sin(alpha)));
            //    }
            //    alpha += Math.PI / count;
            //}

            x += size / 2;

            return new Polygon()
            {
                Points = points,
                StrokeThickness = 3,
                Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18")
            };
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