using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.Text = Properties.Resources.FormHandle;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }

}
