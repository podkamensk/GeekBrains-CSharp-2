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
    class Planet : Star
    //Background decoration planet
    {

        public Planet(Point coords, Point vels, Point accs, double ang, double ang_vel, double ang_acc, double scale) : base(coords, vels, accs, ang, ang_vel, ang_acc, scale) { }
        public Planet(Point coords) : base(coords) { }

        public override void Pics_update()
        //Checks if Images array is ok, fills with images if not
        {
            if (Images_array != null)   //Fill Images Array with meters pics  //LOOKS LIKE ALL 3 CLASSES USE THE SAME Image_array... Why?
            {
                Array.Resize(ref Images_array, 1);
                Images_array[0] = ResImages.planet_00;
            }
        }








    }

}
