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
    class Background:INotifyPropertyChanged
    {
        private double y;
        public static readonly double SpeedY = 5;
        public event PropertyChangedEventHandler PropertyChanged;

        public double X => 0;

        public double Y
        {
            set
            {
                y = value;
                NotifyPropertyChange("Y");
            }
            get => y;
        }

        public double Width => 632;
        public double Height => 3328;
        public BitmapImage Source { get; set; }

        internal Background(string source)
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

        private void NotifyPropertyChange(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }    }
}
