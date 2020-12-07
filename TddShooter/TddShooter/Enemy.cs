#region

using System;
using Windows.UI.Xaml.Media.Imaging;

#endregion

namespace TddShooter
{
    public class Enemy : Drawable
    {
        private int _count;

        public Enemy(double x, double y) : base(50, 50)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy0_0.png"));
            X = x;
            Y = y;
            SpeedY = 5;
        }

        internal bool IsFire => ++_count == 20;

        internal override void Tick()
        {
            Y += SpeedY;
        }
    }
}