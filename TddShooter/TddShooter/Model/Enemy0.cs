#region

using System;
using Windows.UI.Xaml.Media.Imaging;

#endregion

namespace TddShooter.Model
{
    internal class Enemy0 : AbstractEnemy
    {

        public Enemy0(double x, double y) : base(50, 50)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy0_0.png"));
            X = x;
            Y = y;
            SpeedY = 5;
        }

        internal override bool IsFire => ++count == 20;

        public override void Tick()
        {
            Y += SpeedY;
        }
    }
}