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

            var enemy = new Enemy0(100, -50);
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

            var enemy = new Enemy0(300, 0);
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
        [UITestMethod]
        public void Enemy1Movement()
        {
            var viewModel = new ViewModel();
            var enemy = new Enemy1(200, 0);
            viewModel.AddEnemy(enemy);

            Assert.AreEqual(viewModel.Enemies.Count,1);
            Assert.AreEqual(200,enemy.X);
            Assert.AreEqual(0, enemy.Y);
            Assert.AreEqual(viewModel.Bullets.Count,0);

            double previewX = enemy.X, previewY = enemy.Y, previewSpeed = enemy.SpeedY;
            for (int i = 0; i < 40; i++)
            {
                viewModel.Tick(1);
                Assert.AreEqual(previewX,enemy.X);
                Assert.IsTrue(previewY <= enemy.Y);
                Assert.AreEqual(previewSpeed - 0.5,enemy.SpeedY);
                previewX = enemy.X;
                previewY = enemy.Y;
                previewSpeed = enemy.SpeedY;
            }
            Assert.AreEqual(viewModel.Bullets.Count,1);
            for (int i = 0; i < 40; i++)
            {
                viewModel.Tick(1);
                Assert.AreEqual(previewX,enemy.X);
                Assert.IsTrue(previewY > enemy.Y);
                Assert.AreEqual(previewSpeed -0.5,enemy.SpeedY);
                previewX = enemy.X;
                previewY = enemy.Y;
                previewSpeed = enemy.SpeedY;
            }
        }
        [UITestMethod]
        public void Enemy2Movement()
        {
            var viewModel = new ViewModel();
            double speedX = 3, speedY = 10, theta = -1;
            var enemy = new Enemy2(300, 0, speedX, speedY, theta);
            Assert.AreEqual("ms-appx:///Images/enemy2.png",enemy.Source.UriSource.AbsoluteUri);
            viewModel.AddEnemy(enemy);
            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual(300 + speedX * i ,enemy.X);
                Assert.AreEqual(speedY * i, enemy.Y);
                Assert.AreEqual(theta * i , enemy.Theta);
                viewModel.Tick(1);
            }
            viewModel.Tick(50);
            Assert.AreEqual(0, viewModel.Enemies.Count);
        }
    }
}