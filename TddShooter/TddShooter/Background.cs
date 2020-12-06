using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml.Media.Imaging;

namespace TddShooter
{
    class Background : Drawable
    {
        internal Background(string source) : base(632, 3328)
        {
            Source = new BitmapImage(new Uri(source));
            Y = -2528;
        }

        internal void Scroll(double dy)
        {
            Y += dy;
            if (Y > 0)
            {
                Y = -2528;
            }
        }

    }
}
