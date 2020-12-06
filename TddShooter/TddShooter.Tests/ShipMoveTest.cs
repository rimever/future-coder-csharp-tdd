using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using TddShooter.Model;

namespace TddShooter.Tests
{
    [TestClass]
    public class ShipMoveTest
    {
        [UITestMethod]
        public void ShipKeyMove()
        {
            var viewModel = new ViewModel();
            viewModel.Ship.X = 100;
            viewModel.Ship.Y = 100;
            viewModel.KeyDown(VirtualKey.Left);
            viewModel.Tick(2);
            Assert.AreEqual(100 - Ship.Speed * 2, viewModel.Ship.X);
            viewModel.Tick(2);
            Assert.AreEqual(100 - Ship.Speed * 4, viewModel.Ship.X);
            viewModel.KeyUp(VirtualKey.Left);
            viewModel.Tick(2);
            Assert.AreEqual(100 - Ship.Speed * 4, viewModel.Ship.X);
        }
    }
}
