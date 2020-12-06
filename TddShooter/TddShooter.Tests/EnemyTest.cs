using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;

namespace TddShooter.Tests
{
    [TestClass]
    public class EnemyTest
    {
        [UITestMethod]
        public void CreateEnemy()
        {
            var viewModel = new ViewModel();
            Assert.AreEqual(viewModel.Enemies.Count , 0);

            var enemy = new Enemy(100,-50);
            viewModel.AddEnemy(enemy);
            Assert.AreEqual(viewModel.Enemies.Count,1);
            Assert.AreEqual(100,enemy.X);
            Assert.AreEqual(-50,enemy.Y);
            viewModel.Tick(1);
            Assert.AreEqual(100,enemy.X);
        }
    }
}
