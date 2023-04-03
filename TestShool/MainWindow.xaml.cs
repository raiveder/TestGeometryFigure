using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace TestShool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _timer.Tick += Time_Tick;
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            _timer.Start();
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            ShowFigures(CreateFigures(), cnvFigure);
            ShowFigures(CreateFiguresFromNumbers(), cnvNumbers);
        }

        /// <summary>
        /// Создаёт фигуры.
        /// </summary>
        /// <returns>Коллекция фигур</returns>
        private List<Geometry> CreateFigures()
        {
            Figures figures = new Figures(40, cnvFigure.Height, cnvFigure.Width); // Размер фигур, высота и ширина контейнера.

            List<CreateFiguresDelegate> createFiguresMethods = new List<CreateFiguresDelegate> // Сюда добавляем фигуры, которые нам надо.
            {
                figures.CreateTriangle,
                figures.CreateSquare,
                figures.CreateEllipse,
                figures.CreateRhomb,
                figures.CreateFlame,
                figures.CreatePentagon,
                figures.CreatePentagon,
                figures.CreatePentagon,
                figures.CreatePentagon,
                figures.CreateStar
            };

            Figures.ShuffleMethods(createFiguresMethods); // Перемешиваем фигуры для рандомного расположения их в контейнере.

            List<Geometry> listFigures = new List<Geometry>();
            int offset = figures.GetOffset(createFiguresMethods.Count); // Отступы между фигурами (высчитывается автоматически на основании ширины контейнера,
            int x = 0;                                                  // при желании можно вручную указать.

            for (int i = 0; i < createFiguresMethods.Count; i++)
            {
                if (i % 2 == 0)
                {
                    listFigures.Add(createFiguresMethods[i](x, true)); // Положение фигуры по вертикали вверху.
                }
                else
                {
                    listFigures.Add(createFiguresMethods[i](x, false)); // Положение фигуры по вертикали внизу.
                    x += offset;
                }
            }

            return listFigures;
        }

        private List<Geometry> CreateFiguresFromNumbers()
        {
            Figures figures = new Figures(40, cnvFigure.Height, cnvFigure.Width);

            List<Geometry> listFigures = new List<Geometry>();
            int offset = figures.GetOffset(10);
            int x = 0;

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    listFigures.Add(figures.GetGeometryFromText(i.ToString(), x, true));
                }
                else
                {
                    listFigures.Add(figures.GetGeometryFromText(i.ToString(), x, false));
                    x += offset;
                }
            }

            return listFigures;
        }

        /// <summary>
        /// Добавляет созданные фигуры в элемент управления "Canvas"
        /// </summary>
        /// <param name="figures">коллекция фигур</param>
        /// <param name="canvas">элемент управления "Canvas"</param>
        private void ShowFigures(List<Geometry> figures, Canvas canvas)
        {
            canvas.Children.Clear();

            foreach (Geometry item in figures)
            {
                canvas.Children.Add(new Path()
                {
                    StrokeThickness = 3,
                    Stroke = (Brush)new BrushConverter().ConvertFrom("#F14C18"),
                    Data = item
                });
            }
        }
    }
}