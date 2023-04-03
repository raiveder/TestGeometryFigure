using System;
using System.Windows;
using System.Windows.Media;

namespace TestShool
{
    delegate Geometry CreateFiguresDelegate(int x, bool isUp); // Чтобы можно было сделать массив из функций для создания фигур.

    internal class Figures
    {
        private Random s_random = new Random();
        private int _heightContainer;
        private int _widthContainer;
        private int _sizeFigures;

        /// <summary>
        /// Инициализирует новый экземпляр класса Figures с заданными параметрами
        /// </summary>
        /// <param name="sizeFigures">размер фигур (длина и ширина)</param>
        /// <param name="heightContainer">высота контейнера</param>
        /// <param name="widthContainer">ширина контейнера</param>
        public Figures(int sizeFigures, int heightContainer, int widthContainer)
        {
            _heightContainer = heightContainer;
            _widthContainer = widthContainer;
            _sizeFigures = sizeFigures;
        }

        /// <summary>
        /// Создаёт треугольник с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Треугольник с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateTriangle(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x, y),
                new Point(x + _sizeFigures / 2, y - _sizeFigures),
                new Point(x + _sizeFigures, y)
            });
        }

        /// <summary>
        /// Создаёт квадрат с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Квадрат с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateSquare(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x, y),
                new Point(x, y - _sizeFigures),
                new Point(x + _sizeFigures, y - _sizeFigures),
                new Point(x + _sizeFigures, y)
            });
        }

        /// <summary>
        /// Создаёт круг с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Круг с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateEllipse(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return new EllipseGeometry
            (
                new Point
                (
                    x + _sizeFigures / 2,
                    y - _sizeFigures / 2
                ),
                _sizeFigures / 2,
                _sizeFigures / 2
            );
        }

        /// <summary>
        /// Создаёт ромб с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Ромб с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateRhomb(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x, y + _sizeFigures / 2),
                new Point(x + _sizeFigures / 2, y),
                new Point(x + _sizeFigures, y + _sizeFigures / 2),
                new Point(x + _sizeFigures / 2, y + _sizeFigures)
            });
        }

        /// <summary>
        /// Создаёт пламя с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Пламя с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateFlame(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x + _sizeFigures / 6, y),
                new Point(x, y - _sizeFigures / 4),
                new Point(x + _sizeFigures / 2, y - _sizeFigures),
                new Point(x + _sizeFigures, y - _sizeFigures / 4),
                new Point(x + 5* _sizeFigures / 6, y)
            });
        }

        /// <summary>
        /// Создаёт пятиугольник с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Пятиугольник с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreatePentagon(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            return GetGeometryFromPoints(new PointCollection()
            {
                new Point(x + _sizeFigures / 6, y),
                new Point(x, y - _sizeFigures + _sizeFigures / 4),
                new Point(x + _sizeFigures / 2, y - _sizeFigures),
                new Point(x + _sizeFigures, y - _sizeFigures + _sizeFigures / 4),
                new Point(x + 5 * _sizeFigures / 6, y)
            });
        }

        /// <summary>
        /// Создаёт звезду с заданными параметрами
        /// </summary>
        /// <param name="x">позиция по оси Х крайней левой точки фигуры</param>
        /// <param name="isUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Звезда с заданными начальной позицией и вертикальным положением</returns>
        public Geometry CreateStar(int x, bool isUp)
        {
            int y = GetCoordinateY(isUp);

            int count = 5;
            int outerRadius = _sizeFigures / 2;
            int innerRadius = outerRadius / 2;
            double alpha = 0;

            PointCollection points = new PointCollection() { new Point(x, y) };

            for (int i = 0; i < 2 * count + 1; i++)
            {
                if (i % 2 == 0)
                {
                    points.Add(new Point(x + innerRadius * Math.Cos(alpha), y + innerRadius * Math.Sin(alpha)));
                }
                else
                {
                    points.Add(new Point(x + outerRadius * Math.Cos(alpha), y + outerRadius * Math.Sin(alpha)));
                }
                alpha += Math.PI / count;
            }

            return GetGeometryFromPoints(points);
        }

        /// <summary>
        /// Генерирует случайную координату Y для фигуры в зависимости от её вертикального расположения
        /// </summary>
        /// <param name="IsUp">true - фигура располагается в верхней половине контейнера, false - в нижней</param>
        /// <returns>Координата Y крайней нижней точки фигуры</returns>
        private int GetCoordinateY(bool IsUp)
        {
            if (IsUp)
            {
                return s_random.Next(_sizeFigures + 1, _heightContainer / 2);
            }
            else
            {
                return s_random.Next(_heightContainer / 2 + _sizeFigures + 1, _heightContainer);
            }
        }

        /// <summary>
        /// Создаёт фигуру на основании её точек
        /// </summary>
        /// <param name="points">коллекция точек для отрисовки фигуры</param>
        /// <returns>Фигура, созданная по заданным точкам</returns>
        private Geometry GetGeometryFromPoints(PointCollection points)
        {
            Geometry geometry = new StreamGeometry();

            using (StreamGeometryContext ctx = ((StreamGeometry)geometry).Open())
            {
                ctx.BeginFigure(points[0], true, true);
                ctx.PolyLineTo(points, true, false);
            }

            return geometry;
        }

        /// <summary>
        /// Вычисляет отступы между фигурами (с учётом размеров самой фигуры)
        /// </summary>
        /// <param name="countFigures">количество фигур</param>
        /// <returns></returns>
        public int GetOffset(int countFigures)
        {
            int offset = (_widthContainer - countFigures * _sizeFigures) / (countFigures / 2);

            if (countFigures % 2 == 0)
            {
                offset--;
            }

            return offset + _sizeFigures;
        }

        public static 
    }
}