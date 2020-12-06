using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace TddShooter.Model
{
    class Ship : Drawable
    {
        internal static readonly double Speed = 10;

        internal Ship():base(60,60)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/ship.png"));
        }
    }
}
