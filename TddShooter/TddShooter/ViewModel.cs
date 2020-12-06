using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;
using TddShooter.Model;

namespace TddShooter
{
    class ViewModel
    {
        public Ship Ship { get; set; }
        public Background Background { get; set; }
        public Background Cloud { get; set; }
        public double Width => Field.Width;
        public double Height => Field.Height;
        public ObservableCollection<Drawable> drawables = new ObservableCollection<Drawable>();
        public ObservableCollection<Drawable> Drawables => drawables;

        public List<Drawable> Enemies
        {
            get
            {
                return Drawables.Where(e => e is Enemy).ToList();
            }
        }

        public List<Drawable> Bullets
        {
            get
            {
                return Drawables.Where(e => e is Bullet).ToList();
            }
        }

        public static readonly Rect Field = new Rect(0,0,643,800);
        private readonly Dictionary<VirtualKey, bool> _keyMap = new Dictionary<VirtualKey, bool>();

        internal ViewModel()
        {
            Ship = new Ship();
            Background = new Background("ms-appx:///Images/back.png");
            Cloud = new Background("ms-appx:///Images/back_cloud.png");
            drawables.Add(Background);
            drawables.Add(Cloud);
            drawables.Add(Ship);
        }

        public void KeyDown(VirtualKey key)
        {
            _keyMap[key] = true;
        }

        public void Tick(int frame)
        {
            for (int i = 0; i < frame; i++)
            {
                Background.Scroll(1);
                Cloud.Scroll(10);

                Ship.SpeedX = 0;
                Ship.SpeedY = 0;
                if (IsKeyDown(VirtualKey.Left))
                {
                    Ship.SpeedX = -Ship.Speed;
                }

                if (IsKeyDown(VirtualKey.Right))
                {
                    Ship.SpeedX = Ship.Speed;
                }

                if (IsKeyDown(VirtualKey.Up))
                {
                    Ship.SpeedY = -Ship.Speed;
                }

                if (IsKeyDown(VirtualKey.Down))
                {
                    Ship.SpeedY = Ship.Speed;
                }

                if (IsKeyDown(VirtualKey.Space))
                {
                    var bullet = new Bullet(Ship.X + Ship.Width /2,Ship.Y + Ship.Height/2);
                    AddBullet(bullet);
                    _keyMap[VirtualKey.Space] = false;
                }
                foreach (var drawable in Drawables.ToArray())
                {
                    drawable.Move();
                    if (drawable.Y > Field.Height 
                        || drawable.Y + drawable.Height < 0
                        || drawable.X > Field.Height
                        || drawable.X + drawable.Width < 0)
                    {
                        Drawables.Remove(drawable);
                    }
                }

                Ship.Y = Math.Max(0, Math.Min(Field.Height - Ship.Height, Ship.Y));
                Ship.X = Math.Max(0, Math.Min(Field.Width - Ship.Width, Ship.X));
            }
        }

        private bool IsKeyDown(VirtualKey virtualKey)
        {
            return _keyMap.ContainsKey(virtualKey) && _keyMap[virtualKey];
        }

        public void KeyUp(VirtualKey key)
        {
            _keyMap[key] = false;
        }

        public void AddEnemy(Enemy enemy)
        {
            Drawables.Add(enemy);
        }

        public void AddBullet(Bullet bullet)
        {
            Drawables.Add(bullet);
        }
    }
}
