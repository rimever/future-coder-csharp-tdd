using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using TddShooter.Model;

namespace TddShooter.Tests
{
    [TestClass]
    public class ShipTest
    {
        [UITestMethod]
        public void ShipPos()
        {
            Ship ship = new Ship {X = 100d, Y = 100d};
            Assert.AreEqual(100,ship.X);
            Assert.AreEqual(100,ship.Y);
        }
        [UITestMethod]
        public void ShipSize()
        {
            var ship = new Ship();
            Assert.AreEqual(60,ship.Width);
            Assert.AreEqual(60,ship.Height);
        }
        [UITestMethod]
        public void ShipImage()
        {
            var ship = new Ship();
            Assert.IsNotNull(ship.Source);
            Assert.IsInstanceOfType(ship.Source, typeof(BitmapImage));
        }

        [UITestMethod]
        public void ViewModelShip()
        {
            var viewModel = new ViewModel();
            Assert.AreEqual(60,viewModel.Ship.Width);
            Assert.AreEqual(60,viewModel.Ship.Height);
        }

    }
}
