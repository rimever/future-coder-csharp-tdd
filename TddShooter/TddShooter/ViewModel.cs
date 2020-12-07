#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Foundation;
using Windows.System;
using TddShooter.Model;

#endregion

namespace TddShooter
{
    class ViewModel
    {
        public static readonly Rect Field = new Rect(0, 0, 643, 800);
        private readonly Dictionary<VirtualKey, bool> _keyMap = new Dictionary<VirtualKey, bool>();
        public ObservableCollection<Drawable> drawables = new ObservableCollection<Drawable>();

        internal ViewModel()
        {
            Ship = new Ship();
            Background = new Background("ms-appx:///Images/back.png");
            Background.SpeedY = 1;
            Cloud = new Background("ms-appx:///Images/back_cloud.png");
            Cloud.SpeedY = 2;
            drawables.Add(Background);
            drawables.Add(Cloud);
            drawables.Add(Ship);
        }

        public Ship Ship { get; set; }
        public Background Background { get; set; }
        public Background Cloud { get; set; }
        public double Width => Field.Width;
        public double Height => Field.Height;
        public ObservableCollection<Drawable> Drawables => drawables;

        public List<Drawable> Enemies => Filter<Enemy>();

        public List<Drawable> Bullets => Filter<Bullet>();

        public List<Drawable> Blasts => Filter<Blast>();

        private List<Drawable> Filter<T>()
        {
            return Drawables.Where(e => e is T).ToList();
        }

        public void KeyDown(VirtualKey key)
        {
            _keyMap[key] = true;
        }

        public void Tick(int frame)
        {
            for (int i = 0; i < frame; i++)
            {
                Background.Tick();
                Cloud.Tick();

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
                    var bullet = new Bullet(Ship.X + Ship.Width / 2, Ship.Y + Ship.Height / 2);
                    AddBullet(bullet);
                    _keyMap[VirtualKey.Space] = false;
                }

                foreach (var drawable in Drawables.ToArray())
                {
                    drawable.Tick();
                    var rect = drawable.Rect;
                    rect.Intersect(Field);
                    if (!drawable.IsValid || rect.IsEmpty)
                    {
                        Drawables.Remove(drawable);
                    }

                    if (drawable is Enemy enemy)
                    {
                        if (enemy.IsFire)
                        {
                            CreateEnemyBullet(enemy);
                        }

                        if (Crash(enemy, Ship))
                        {
                            Ship.IsValid = false;
                        }
                    }
                }

                foreach (var bullet in Bullets.Select(b => b as Bullet).ToArray())
                {
                    if (bullet.IsEnemy)
                    {
                        if (Crash(bullet, Ship))
                        {
                            Ship.IsValid = false;
                        }

                        continue;
                    }

                    foreach (var enemy in Enemies.Select(e => e as Enemy).ToArray())
                    {
                        if (Crash(bullet, enemy) && bullet.IsValid && enemy.IsValid)
                        {
                            enemy.IsValid = false;
                            bullet.IsValid = false;
                            var blast = new Blast(bullet.X + bullet.Width / 2, bullet.Y + bullet.Height / 2);
                            Drawables.Add(blast);
                        }
                    }
                }

                Ship.Y = Math.Max(0, Math.Min(Field.Height - Ship.Height, Ship.Y));
                Ship.X = Math.Max(0, Math.Min(Field.Width - Ship.Width, Ship.X));
            }
        }

        private void CreateEnemyBullet(Enemy enemy)
        {
            var sX = enemy.X + enemy.Width / 2;
            var sY = enemy.Y + enemy.Height / 2;
            var eX = Ship.X + Ship.Width / 2;
            var eY = Ship.Y + Ship.Height / 2;
            var theta = Math.Atan2(eY - sY, eX - sX);
            var dx = Math.Cos(theta) * Bullet.Speed;
            var dy = Math.Sin(theta) * Bullet.Speed;
            var bullet = new Bullet(sX, sY, dx, dy, true);
            AddBullet(bullet);
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

        internal static bool Crash(Drawable d0, Drawable d1)
        {
            var rect = d0.Rect;
            rect.Intersect(d1.Rect);
            return !rect.IsEmpty;
        }
    }
}