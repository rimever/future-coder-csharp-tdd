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
        public ObservableCollection<Enemy> enemies = new ObservableCollection<Enemy>();
        public ObservableCollection<Enemy> Enemies => enemies;

        public static readonly Rect Field = new Rect(0,0,643,800);
        private readonly Dictionary<VirtualKey, bool> _keyMap = new Dictionary<VirtualKey, bool>();

        internal ViewModel()
        {
            Ship = new Ship();
            Background = new Background("ms-appx:///Images/back.png");
            Cloud = new Background("ms-appx:///Images/back_cloud.png");
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
                foreach (var enemy in Enemies.ToArray())
                {
                    enemy.Move();
                    if (enemy.Y > Field.Height)
                    {
                        Enemies.Remove(enemy);
                    }
                }

                if (_keyMap.ContainsKey(VirtualKey.Left) && _keyMap[VirtualKey.Left])
                {
                    Ship.Move(-Ship.Speed, 0);
                }

                if (_keyMap.ContainsKey(VirtualKey.Right) && _keyMap[VirtualKey.Right])
                {
                    Ship.Move(+Ship.Speed, 0);
                }

                if (_keyMap.ContainsKey(VirtualKey.Up) && _keyMap[VirtualKey.Up])
                {
                    Ship.Move(0, -Ship.Speed);
                }

                if (_keyMap.ContainsKey(VirtualKey.Down) && _keyMap[VirtualKey.Down])
                {
                    Ship.Move(0, Ship.Speed);
                }
            }
        }

        public void KeyUp(VirtualKey key)
        {
            _keyMap[key] = false;
        }

        public void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
        }
    }
}
