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

        [UITestMethod]
        public void ShipOnScreen()
        {
            var viewModel = new ViewModel();
            viewModel.Ship.X = 100;
            viewModel.Ship.Y = 100;
            viewModel.KeyDown(VirtualKey.Left);
            viewModel.Tick(1000);
            Assert.IsTrue(viewModel.Ship.X >= 0);
            viewModel.KeyUp(VirtualKey.Left);

            viewModel.KeyDown(VirtualKey.Right);
            viewModel.Tick(1000);
            Assert.IsTrue(viewModel.Ship.X + viewModel.Ship.Width <= ViewModel.Field.Width);
            viewModel.KeyUp(VirtualKey.Right);

            viewModel.KeyDown(VirtualKey.Up);
            viewModel.Tick(1000);
            Assert.IsTrue(viewModel.Ship.Y >= 0);
            viewModel.KeyUp(VirtualKey.Up);

            viewModel.KeyDown(VirtualKey.Down);
            viewModel.Tick(1000);
            Assert.IsTrue(viewModel.Ship.Y + viewModel.Ship.Height <= ViewModel.Field.Height);
            viewModel.KeyUp(VirtualKey.Down);
        }
    }
}
