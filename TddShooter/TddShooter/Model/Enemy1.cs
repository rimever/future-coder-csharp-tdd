using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using TddShooter.Model;

namespace TddShooter
{
    internal class Enemy1:AbstractEnemy
    {
        internal Enemy1(double x, double y) : base(50, 50)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy1.png"));
            X = x;
            Y = y;
            SpeedY = 20;
        }

        public override void Tick()
        {
            SpeedY -= 0.5;
            Y += SpeedY;
        }

        internal override bool IsFire => SpeedY == 0;
    }
}
