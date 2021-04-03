using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    static class Program
    {
        static void Main(string[] args)
        {
            var form = new Form()
            {
                MinimumSize = new Size(800, 500),
                MaximumSize = new Size(800, 500),
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Asteroids"
            };

            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
