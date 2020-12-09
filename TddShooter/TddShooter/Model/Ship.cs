#region

using System;
using Windows.UI.Xaml.Media.Imaging;

#endregion

namespace TddShooter.Model
{
    class Ship : Drawable
    {
        internal static readonly double Speed = 10;

        internal Ship() : base(60, 60)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/ship.png"));
        }

        public override void Tick()
        {
            X += SpeedX;
            Y += SpeedY;
        }
    }
}