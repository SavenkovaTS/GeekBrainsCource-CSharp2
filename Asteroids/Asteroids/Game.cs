using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        private const int coefficient = 42;
        private const int starSize = 3;

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        static Image background = Image.FromFile("Images\\background.jpg");

        public static BaseObject[] _objs;

        static Game()
        {
        }

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();

        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
            }
        }

        public static void Load()
        {
            var randomNumber = new Random();

            _objs = new BaseObject[70];

            for (int i = 0; i < 20; i++)
            {
                var xy = new Point(randomNumber.Next(0, coefficient * i), randomNumber.Next(0, coefficient * i + coefficient));
                var dir = new Point(coefficient / 2 - i, coefficient / 2 - i + 1);
                var size = new Size(starSize, starSize);

                _objs[i] = new Star(xy, dir, size);
            }

            for (int i = 20; i < 40; i++)
            {
                var randomSize = randomNumber.Next(0, coefficient);
                var xy = new Point(randomNumber.Next(0, Width), randomNumber.Next(0, Height));
                var dir = new Point(coefficient / 2 + i, coefficient / 2 + i + 1);
                var size = new Size(randomSize, randomSize);

                _objs[i] = new BaseObject(xy, dir, size);
            }

            for (int i = 40; i < 60; i++)
            {
                var randomSize = randomNumber.Next(0, coefficient);
                var xy = new Point(randomNumber.Next(coefficient + i , Width), randomNumber.Next(coefficient + i, Height));
                var dir = new Point( coefficient / 2 + i, coefficient / 2 + i + 1);
                var size = new Size(randomSize, randomSize);

                _objs[i] = new Asteroid(xy, dir, size);
            }

            for (int i = 60; i < 70; i++)
            {
                var randomSize = randomNumber.Next(0, coefficient);

                var xy = new Point(randomNumber.Next(Width/2, Width), randomNumber.Next(Height/2, Height));
                var dir = new Point(coefficient / 2 + i, coefficient / 2 + i + 1);
                var size = new Size(randomSize, randomSize);

                _objs[i] = new Comet(xy, dir, size);
            }

        }

        public static void Draw()
        {
            Buffer.Graphics.DrawImage(background, 0, 0, Width, Height);

            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }

            Buffer.Render();
        }

    }

}
