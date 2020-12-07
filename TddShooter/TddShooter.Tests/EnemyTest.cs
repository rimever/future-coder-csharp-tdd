#region

using System.Linq;
using Windows.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using TddShooter.Model;

#endregion

namespace TddShooter.Tests
{
    [TestClass]
    public class EnemyTest
    {
        [UITestMethod]
        public void CreateEnemy()
        {
            var viewModel = new ViewModel();
            Assert.AreEqual(viewModel.Enemies.Count, 0);

            var enemy = new Enemy(100, -50);
            viewModel.AddEnemy(enemy);
            Assert.AreEqual(viewModel.Enemies.Count, 1);
            Assert.AreEqual(100, enemy.X);
            Assert.AreEqual(-50, enemy.Y);
            viewModel.Tick(1);
            Assert.AreEqual(100, enemy.X);
            Assert.AreEqual(-50 + enemy.SpeedY, enemy.Y);
            Assert.AreEqual(viewModel.Enemies.Count, 1);
            int frame = (int) (ViewModel.Field.Height / enemy.SpeedY) + 10;
            viewModel.Tick(frame);
            Assert.AreEqual(viewModel.Enemies.Count, 0);
        }

        [UITestMethod]
        public void HitEnemy()
        {
            var viewModel = new ViewModel();
            viewModel.Ship.X = 300;
            viewModel.Ship.Y = 300;

            var enemy = new Enemy(300, 0);
            viewModel.AddEnemy(enemy);

            viewModel.KeyDown(VirtualKey.Space);
            viewModel.Tick(1);
            var bullet = viewModel.Bullets.FirstOrDefault() as Bullet;
            int nFrame = (int) ((bullet.Y - (enemy.Y + enemy.Height)) / (enemy.SpeedY - bullet.SpeedY));
            viewModel.Tick(nFrame + 1);

            Assert.IsFalse(enemy.IsValid);
            Assert.IsFalse(bullet.IsValid);
            Assert.AreEqual(1, viewModel.Blasts.Count);

            var blast = viewModel.Blasts.FirstOrDefault() as Blast;
            Assert.AreEqual(bullet.X + bullet.Width / 2, blast.X + blast.Width / 2);
            Assert.AreEqual(bullet.Y + bullet.Height / 2, blast.Y + blast.Height / 2);

            viewModel.Tick(10);
            Assert.AreEqual(0, viewModel.Blasts.Count);
        }
    }
}