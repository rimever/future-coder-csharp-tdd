using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddThermoConverter
{
    class TemperatureModel : INotifyPropertyChanged
    {
        private double fahrenheit, celsius;

        public double Fahrenheit
        {
            set
            {
                fahrenheit = value;
                celsius = (fahrenheit - 32) / 1.8f;
                NotifyPropertyChanged(nameof(Fahrenheit));
                NotifyPropertyChanged(nameof(Celsius));
            }
            get => fahrenheit;
        }

        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public double Celsius
        {
            set
            {
                celsius = Math.Max(0, Math.Min(100, value));
                fahrenheit = (celsius * 1.8f) + 32;
                NotifyPropertyChanged(nameof(Fahrenheit));
                NotifyPropertyChanged(nameof(Celsius));
            }
            get => celsius;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
