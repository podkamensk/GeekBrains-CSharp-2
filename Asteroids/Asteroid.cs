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
    class Asteroid
    //Base class for the Aseroids instances
    {

        public Point Coords;
        protected Point Vels;
        protected Point Accs;
        protected Point DrawCoords;               //to update sprite drawing coords (for center alignment)
        protected Size Size;
        public double x;
        public double y;
        protected double size_scale;
        protected double angle;
        protected double angle_vel;
        protected double angle_acc;
        protected Image sprite;

        protected static Image[] Images_array;      //To contain all images of the class
        private static Random rand = new Random();

        public Asteroid(Point coords, Point vels, Point accs, double ang, double ang_vel, double ang_acc, double scale)   //Rotation is included for future referrence
        {
            Coords = coords;
            x = coords.X;
            y = coords.Y;
            Vels = vels;
            Accs = accs;
            angle = ang;
            angle_vel = ang_vel;
            angle_acc = ang_acc;
            size_scale = scale;
           
            Pics_update(); 

            sprite = Images_array[rand.Next(0, Images_array.Length)];
            Size.Width = Convert.ToInt32(sprite.Width*size_scale);
            Size.Height = Convert.ToInt32(sprite.Height*size_scale);
            DrawCoords.X = Coords.X - Size.Width / 2;
            DrawCoords.Y = Coords.Y - Size.Height / 2;
        }

        public Asteroid(Point coords, Point vels, Point accs, double scale) : this(coords, vels, accs, 0, 0, 0, scale)
        {
            angle = Convert.ToDouble(rand.Next(0, 360));       // deg
            angle_vel = Convert.ToDouble( (rand.Next(0, 30) - 15) / Game.game_speed);   // deg/tick
        }

        public Asteroid(Point coords, Point vels, Point accs) : this(coords, vels, accs, Convert.ToDouble(rand.Next(40, 101)) / 100)
        {
        }

        public Asteroid(Point coords, Point vels) : this(coords, vels, new Point(0,0) )
        {
        }
        
        public Asteroid(Point coords) : this(coords, new Point(0, 0))
        {
            Vels.X = (rand.Next(0, 200) - 100) / Game.game_speed;
            Vels.Y = (rand.Next(0, 200) - 100) / Game.game_speed;
        }

        public virtual void Pics_update()
        //Checks if Images array is ok, fills with images if not
        {
            if (Images_array == null)   //Fill Images Array with meters pics
            {   
                Array.Resize(ref Images_array, 4);
                Images_array[0] = ResImages.meteor_00;
                Images_array[1] = ResImages.meteor_01;
                Images_array[2] = ResImages.meteor_02;
                Images_array[3] = ResImages.meteor_03;
            }
        }

        public virtual void Draw()
        //Draws Asteroids instance (With center alignment)
        {
            //Game.Buffer.Graphics.DrawRectangle(Pens.White, DrawCoords.X, DrawCoords.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(sprite, DrawCoords.X, DrawCoords.Y, Size.Width, Size.Height);
        }

        public virtual void Update()
        //Updates Coords, Velocities, (Rotation in the future) and other params of an Asteroids instance
        {
            Vels.X += Accs.X;
            Vels.Y += Accs.Y;

            x += Vels.X;
            y += Vels.Y;

            Coords.X = Convert.ToInt32(x);
            Coords.Y = Convert.ToInt32(y);

            DrawCoords.X = Coords.X - Size.Width / 2;
            DrawCoords.Y = Coords.Y - Size.Height / 2;

            // Asteroids bounce off the game boundaries
            if (DrawCoords.X < 0 || DrawCoords.X + Size.Width > Game.Width) Vels.X = - Vels.X;
            if (DrawCoords.Y < 0 || DrawCoords.Y + Size.Height > Game.Height) Vels.Y = -Vels.Y;
        }

    }
}
