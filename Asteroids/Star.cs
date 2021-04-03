using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Resources;


namespace Asteroids
{
    class Star : Asteroid
    //Background decoration stars
    {

        public Star(Point coords, Point vels, Point accs, double ang, double ang_vel, double ang_acc, double scale) : base(coords, vels, accs, ang, ang_vel, ang_acc, scale) { }
        public Star(Point coords) : base(coords) { }





        public override void Pics_update()
        //Checks if Images array is ok, fills with images if not
        {
            if (Images_array != null)   //Fill Images Array with meters pics   //LOOKS LIKE ALL 3 CLASSES USE THE SAME Image_array... Why?
            {
                Array.Resize(ref Images_array, 3);
                Images_array[0] = ResImages.star_00;
                Images_array[1] = ResImages.star_01;
                Images_array[2] = ResImages.star_02;
            }
        }

        public override void Update()
        {
            //Updates Coords, Velocities, (Rotation in the future) and other params of a Star instance by overriding Asteroid class's method 
            {
                //Vels.X += Accs.X;
                //Vels.Y += Accs.Y;

                x += Vels.X;
                y += Vels.Y;

                Coords.X = Convert.ToInt32(x);
                Coords.Y = Convert.ToInt32(y);

                DrawCoords.X = Coords.X - Size.Width / 2;
                DrawCoords.Y = Coords.Y - Size.Height / 2;


                // Stars reappear on the other side of the screen
                if (DrawCoords.X < 0 - Size.Width) x += Game.Width + Size.Width;
                if (DrawCoords.X > Game.Width) x -= Game.Width + Size.Width;
                if (DrawCoords.Y < 0 - Size.Height) y += Game.Height + Size.Height;
                if (DrawCoords.Y > Game.Height) y -= Game.Height + Size.Height;
            }
        }

    }
}
