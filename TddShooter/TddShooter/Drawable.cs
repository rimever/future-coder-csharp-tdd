using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace TddShooter
{
    public class Drawable:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChange(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private double _x, _y;

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                NotifyPropertyChange("X");
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                NotifyPropertyChange("Y");
            } }
        public double Width { get; }
        public double Height { get; }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }
        public BitmapImage Source { get; protected set; }

        protected Drawable(double width, double height)
        {
            Height = height;
            Width = width;
        }

        public void Move()
        {
            X += SpeedX;
            Y += SpeedY;
        }
    }
}
