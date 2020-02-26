using System.Drawing;

namespace Asteroids
{
    class Comet : BaseObject
    {
        static Image image = Image.FromFile("Images\\comet.png");

        public Comet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}
