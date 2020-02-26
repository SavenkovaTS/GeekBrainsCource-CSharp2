using System.Drawing;

namespace Asteroids
{
    class Asteroid : BaseObject
    {
        static Image image = Image.FromFile("Images\\asteroid.png");

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}
