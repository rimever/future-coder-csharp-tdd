
using System;
using Windows.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddThermoConverter.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var model = new TemperatureModel();
            model.Celsius = 0;
            Assert.AreEqual(model.Fahrenheit, 32);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var model = new TemperatureModel();
            model.Celsius = 100;
            Assert.AreEqual(model.Fahrenheit, 212, 0.1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            var viewModel = new ViewModel();
            viewModel.KeyDown(VirtualKey.U);
            Assert.AreEqual(viewModel.TemperatureModel.Celsius,10);
            viewModel.KeyDown(VirtualKey.D);
            Assert.AreEqual(viewModel.TemperatureModel.Celsius,0);
        }
    }
}
