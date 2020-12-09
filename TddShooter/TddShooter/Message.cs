using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddShooter
{
    public class Message : INotifyPropertyChanged, IClock
    {
        private string _text;
        private double _theta;
        public double Alpha => (Math.Sin(_theta) + 1) /2;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChange(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                NotifyPropertyChange(nameof(Text));
            }
        }

        public void Tick()
        {
            _theta += 0.1d;
            NotifyPropertyChange(nameof(Alpha));
        }
    }
}
