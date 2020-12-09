#region

using System;
using Windows.UI.Xaml.Media.Imaging;
using TddShooter.Model;

#endregion

namespace TddShooter
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