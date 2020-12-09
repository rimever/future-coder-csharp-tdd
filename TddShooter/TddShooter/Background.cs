#region

using System;
using Windows.UI.Xaml.Media.Imaging;

#endregion

namespace TddShooter
{
    class Background : Drawable
    {
        internal Background(string source) : base(632, 3328)
        {
            Source = new BitmapImage(new Uri(source));
            Y = -2528;
        }

        public override void Tick()
        {
            Y += SpeedY;
            if (Y > 0)
            {
                Y = -2528;
            }
        }
    }
}