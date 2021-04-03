using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace Asteroids
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static Asteroid[] _asteroids;
        static Asteroid[] _stars_bg;
        static Asteroid[] _planets_bg;
        public static int game_speed;
        private static double bg_velocity;
        public static Image background;

        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game() { }

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            game_speed = 1000 / 60;     //msec per tick
            bg_velocity = 20 / game_speed;
            background = ResImages.background_00;


            Load();

            Timer timer = new Timer { Interval = game_speed };
            timer.Tick += OnTick;
            timer.Start();

        }

        private static void OnTick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            Buffer.Graphics.DrawImage(background, new Point(0,0));

            foreach (var star in _stars_bg)
                star.Draw();
            foreach (var planet in _planets_bg)
                planet.Draw();
            foreach (var asteroid in _asteroids)
                asteroid.Draw();

            Buffer.Render();
        }

        public static void Update()
        {
            foreach (var asteroid in _asteroids)
                asteroid.Update();

            foreach (var star in _stars_bg)
            {
                star.x -= bg_velocity/3;
                star.Update();
            }

            foreach (var planet in _planets_bg)
            {
                planet.x -= bg_velocity;
                planet.Update();
            }

        }

        public static void Load()
        {

            Random rnd = new Random();
            _asteroids = new Asteroid[10];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                _asteroids[i] = new Asteroid(new Point(rnd.Next(100, Game.Width - 100), rnd.Next(60, Game.Height - 60)));
            }

            _stars_bg = new Asteroid[17];
            for (int i = 0; i < _stars_bg.Length; i++)
            {
                _stars_bg[i] = new Star(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(0, 0), new Point(0, 0), 0, 0, 0, 1);
            }

            _planets_bg = new Asteroid[1];
            for (int i = 0; i < _planets_bg.Length; i++)
            {
                _planets_bg[i] = new Planet(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(0, 0), new Point(0, 0), 0, 0, 0, 1);
            }


            
        }







    }

}
    