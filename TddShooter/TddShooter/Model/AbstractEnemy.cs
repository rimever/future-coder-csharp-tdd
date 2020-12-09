using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddShooter.Model
{
    abstract class AbstractEnemy : Drawable
    {
        protected int count = 0;
        internal AbstractEnemy(double x,double y, double width = 50,double height = 50):base(width, height) {}

        abstract internal bool IsFire { get; }
    }
}
