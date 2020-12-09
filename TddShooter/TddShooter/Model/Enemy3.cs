using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace TddShooter.Model
{
    internal class Enemy3:AbstractEnemy
    {
        internal Enemy3(double x, double y) : base(x, y, 120, 120)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy3.png"));
            X = x;
            Y = y;
            SpeedX = 0;
            SpeedY = 1;
        }

        internal override bool IsFire => count % 100 == 0 && count > 0;

        public override void Tick()
        {
            count++;
            Y += SpeedY;
            X += SpeedX;
        }
    }
}
