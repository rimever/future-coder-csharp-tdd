using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace TddShooter.Model
{
    class Ship : INotifyPropertyChanged
    {
        private double x, y;
        public double X
        {
            get => x;
            set
            {
                x = value;
                NotifyPropertyChange("X");
            }
        }
        public double Y
        {
            get => y;
            set
            {
                y = value;
                NotifyPropertyChange("Y");
            }
        }

        private void NotifyPropertyChange(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public double Width => 60d;
        public double Height => 60d;
        public event PropertyChangedEventHandler PropertyChanged;
        public BitmapImage Source { get; set; }
        public static readonly double Speed = 5;

        internal Ship()
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/ship.png"));
        }

        internal void Move(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

    }
}
