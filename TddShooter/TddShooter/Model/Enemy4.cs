using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace TddShooter.Model
{
    internal class Enemy4:AbstractEnemy
    {
        private Random random;
        private int hitCount = 0;

        internal Enemy4(double x, double y, int seed = 0) : base(x, y, 150, 150)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy4.png"));
            X = x;
            Y = y;
            random = new Random(seed == 0 ? DateTime.Now.Millisecond:seed);
        }

        public override void Tick()
        {
            if (count++ % 50 == 0)
            {
                var rx = random.Next(0, (int) (ViewModel.Field.Width - Width));
                var ry = random.Next(0, (int)(ViewModel.Field.Height - Height));
                SpeedX = (rx - X) / 50d;
                SpeedY = (ry - Y) / 50d;
            }

            X += SpeedX;
            Y += SpeedY;
            Theta += 1;
        }

        internal override bool IsFire => count % 25 == 0 && count > 0;

        internal override bool IsValid
        {
            get => hitCount < 20;
            set
            {
                if (value == false)
                {
                    hitCount++;
                }
            } }
    }
}
