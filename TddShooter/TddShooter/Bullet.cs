using System;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Imaging;

namespace TddShooter
{
    public class Bullet:Drawable
    {
        public Bullet(double x, double y):base(10,10)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/bullet0.png"));
            X = x - Width/2;
            Y = y - Height/2;
            SpeedY -= 10;
        }
    }
}