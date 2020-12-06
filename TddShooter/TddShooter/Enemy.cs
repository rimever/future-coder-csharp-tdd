using System;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Imaging;

namespace TddShooter
{
    public class Enemy:INotifyPropertyChanged
    {
        public Enemy(double x, double y)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy0_0.png"));
            X = x;
            Y = y;
        }

        public BitmapImage Source { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
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
        public double Speed => 5;

        internal void Move()
        {
            Y += Speed;
        }
    }
}