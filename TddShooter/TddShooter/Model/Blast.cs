#region

using System;
using Windows.UI.Xaml.Media.Imaging;

#endregion

namespace TddShooter.Model
{
    class Blast : Drawable
    {
        private static readonly BitmapImage[] images = new BitmapImage[8];
        private int counter;

        static Blast()
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = new BitmapImage(new Uri($"ms-appx:///Images/explode_{i}.png"));
            }
        }

        internal Blast(double x, double y) : base(96, 96)
        {
            X = x - Width / 2;
            Y = y - Height / 2;
            Source = images[Math.Min(7, counter)];
        }

        internal override bool IsValid => counter < 8;


        public override void Tick()
        {
            counter++;
            Source = images[Math.Min(7, counter)];
        }
    }
}