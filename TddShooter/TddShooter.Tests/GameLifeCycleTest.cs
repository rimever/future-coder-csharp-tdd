using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using TddShooter.Model;

namespace TddShooter.Tests
{
    [TestClass]
    public class GameLifeCycleTest
    {
        private bool isGameOver;

        [UITestMethod]
        public void CollideEnemy()
        {
            isGameOver = false;
            var viewModel = new ViewModel();
            Assert.IsTrue(viewModel.Ship.IsValid);
            viewModel.Ship.X = 100;
            viewModel.Ship.Y = 100;
            viewModel.Ship.PropertyChanged += ShipOnPropertyChanged;
            var enemy = new Enemy0(100,100);
            viewModel.AddEnemy(enemy);
            viewModel.Tick(1);
            Assert.IsFalse(viewModel.Ship.IsValid);
            Assert.IsTrue(isGameOver);
            viewModel.Ship.PropertyChanged -= ShipOnPropertyChanged;
        }

        [UITestMethod]
        public void ShowMessage()
        {
            var viewModel = new ViewModel();
            viewModel.Message.Text = "PUSH SPACE TO START";
            Assert.AreEqual("PUSH SPACE TO START",viewModel.Message.Text);
            viewModel.Tick(10);

            viewModel.Message.Text = string.Empty;
            Assert.AreEqual(string.Empty,viewModel.Message.Text);

            viewModel.Ship.X = 100;
            viewModel.Ship.Y = 100;
            var enemy = new Enemy0(100,100);
            viewModel.AddEnemy(enemy);
            viewModel.Tick(1);
            Assert.AreEqual("GAME OVER",viewModel.Message.Text);
        }

        private void ShipOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsValid" && sender is Ship ship)
            {
                isGameOver = !ship.IsValid;
            }
        }
    }
}
