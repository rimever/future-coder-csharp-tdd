#region

using System.ComponentModel;
using Windows.Foundation;
using Windows.UI.Xaml.Media.Imaging;

#endregion

namespace TddShooter
{
    public abstract class Drawable : INotifyPropertyChanged, IClock
    {
        private BitmapImage _source;

        internal Rect Rect;

        protected Drawable(double width, double height)
        {
            Rect.Width = width;
            Rect.Height = height;
            _isValid = true;
        }

        protected bool _isValid;

        internal virtual bool IsValid {
            set
            {
                _isValid = value;
                NotifyPropertyChange("IsValid");
            }
            get => _isValid;
        }

        public double X
        {
            get => Rect.X;
            set
            {
                Rect.X = value;
                NotifyPropertyChange("X");
            }
        }

        public double Y
        {
            get => Rect.Y;
            set
            {
                Rect.Y = value;
                NotifyPropertyChange("Y");
            }
        }

        public double Width => Rect.Width;
        public double Height => Rect.Height;
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }

        public BitmapImage Source
        {
            get => _source;
            protected set
            {
                _source = value;
                NotifyPropertyChange(nameof(Source));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChange(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private double theta = 0;

        public virtual double Theta
        {
            get => theta;
            set
            {
                theta = value;
                NotifyPropertyChange(nameof(Theta));
            }
        }

        public double CenterX => Width / 2;
        public double CenterY => Height / 2;

        public abstract void Tick();
    }
}