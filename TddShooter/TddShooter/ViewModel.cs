using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using TddShooter.Model;

namespace TddShooter
{
    class ViewModel
    {
        public Ship Ship { get; set; }
        private Dictionary<VirtualKey, bool> keyMap = new Dictionary<VirtualKey, bool>();

        internal ViewModel()
        {
            Ship = new Ship();
        }

        public void KeyDown(VirtualKey key)
        {
            keyMap[key] = true;
        }

        public void Tick(int frame)
        {
            for (int i = 0; i < frame; i++)
            {
                if (keyMap.ContainsKey(VirtualKey.Left) && keyMap[VirtualKey.Left])
                {
                    Ship.Move(-Ship.Speed, 0);
                }

                if (keyMap.ContainsKey(VirtualKey.Right) && keyMap[VirtualKey.Right])
                {
                    Ship.Move(+Ship.Speed, 0);
                }

                if (keyMap.ContainsKey(VirtualKey.Up) && keyMap[VirtualKey.Up])
                {
                    Ship.Move(0, -Ship.Speed);
                }

                if (keyMap.ContainsKey(VirtualKey.Down) && keyMap[VirtualKey.Down])
                {
                    Ship.Move(0, Ship.Speed);
                }
            }
        }

        public void KeyUp(VirtualKey key)
        {
            keyMap[key] = false;
        }
    }
}
