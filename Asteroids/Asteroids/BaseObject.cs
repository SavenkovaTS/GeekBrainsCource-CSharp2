using System.Drawing;

namespace Asteroids
{

    class BaseObject
    {
        static Image asteroid_base = Image.FromFile("Images\\asteroid_base.png");

        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public BaseObject(int x, int y, int dx, int dy, int width, int height)
        {
            Pos = new Point(x, y);
            Dir = new Point(dx, dy);
            Size = new Size(width, height);
        }


        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(asteroid_base, Pos.X, Pos.Y, Size.Width, Size.Height);
        }


        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;

            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;

            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}

