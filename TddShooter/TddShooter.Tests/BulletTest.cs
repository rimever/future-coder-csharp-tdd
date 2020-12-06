using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;

namespace TddShooter.Tests
{
    [TestClass]
    public class BulletTest
    {
        [UITestMethod]
        public void CreateBullet()
        {
            var viewModel = new ViewModel();
            Assert.AreEqual(0,viewModel.Bullets.Count);
            var bullet = new Bullet(100,-50);
            viewModel.AddBullet(bullet);

            Assert.AreEqual(1,viewModel.Bullets.Count);
            viewModel.Tick(200);
            Assert.AreEqual(0,viewModel.Bullets.Count);
        }

        [UITestMethod]
        public void ShootBullet()
        {
            var viewModel = new ViewModel();
            viewModel.KeyDown(VirtualKey.Space);
            viewModel.Tick(1);
            Assert.AreEqual(1,viewModel.Bullets.Count);
            var bullet = viewModel.Bullets[0];
            var xPrev = bullet.X;
            var yPrev = bullet.Y;
            viewModel.Tick(1);
            Assert.AreEqual(xPrev,bullet.X);
            Assert.AreEqual(yPrev + bullet.SpeedY,bullet.Y);
        }

        [UITestMethod]
        public void BulletKeyRepeat()
        {
            var viewModel = new ViewModel();
            viewModel.Ship.Y = ViewModel.Field.Height - viewModel.Ship.Height;
            viewModel.Ship.X = ViewModel.Field.Width / 2;
            Assert.AreEqual(0,viewModel.Bullets.Count);

            viewModel.KeyDown(VirtualKey.Space);
            viewModel.Tick(1);
            Assert.AreEqual(1,viewModel.Bullets.Count);
            viewModel.Tick(5);
            Assert.AreEqual(1,viewModel.Bullets.Count);
            viewModel.KeyUp(VirtualKey.Space);
            Assert.AreEqual(1,viewModel.Bullets.Count);

            viewModel.Tick(1);
            viewModel.KeyDown(VirtualKey.Space);
            viewModel.Tick(1);
            Assert.AreEqual(2,viewModel.Bullets.Count);

            viewModel.Tick(100);
            Assert.AreEqual(0,viewModel.Bullets.Count);
        }
    }
}
