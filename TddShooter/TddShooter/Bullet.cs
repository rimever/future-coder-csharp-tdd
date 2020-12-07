#region

using System;
using Windows.UI.Xaml.Media.Imaging;

#endregion

namespace TddShooter
{
    public class Bullet : Drawable
    {
        internal const double Speed = 10;

        internal Bullet(double x, double y, double dx = 0, double dy = -Speed, bool isEnemy = false) : base(10, 10)
        {
            IsEnemy = isEnemy;
            var file = IsEnemy ? "bullet1.png" : "bullet0.png";
            Source = new BitmapImage(new Uri($"ms-appx:///Images/{file}"));
            X = x;
            Y = y;
            SpeedX = dx;
            SpeedY = dy;
        }

        internal bool IsEnemy { set; get; }

        internal override void Tick()
        {
            X += SpeedX;
            Y += SpeedY;
            var rect = Rect;
            rect.Intersect(ViewModel.Field);
            if (rect.IsEmpty)
            {
                IsValid = false;
            }
        }
    }
}