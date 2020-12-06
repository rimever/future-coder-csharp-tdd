using System;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Imaging;

namespace TddShooter
{
    public class Enemy:Drawable
    {
        public Enemy(double x, double y):base(50,50)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy0_0.png"));
            X = x;
            Y = y;
            SpeedY = 5;
        }
    }
}