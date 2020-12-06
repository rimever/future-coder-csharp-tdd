using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;

namespace TddShooter.Tests
{
    [TestClass]
    class BackgroundTest
    {
        [UITestMethod]
        public void JustScroll()
        {
            var viewModel = new ViewModel();
            Assert.AreEqual(-2528, viewModel.Background.Y);
            viewModel.Background.Scroll(1);
            Assert.AreEqual(-2527, viewModel.Background.Y);
        }
        [UITestMethod]
        public void JustScrollWrap()
        {
            var viewModel = new ViewModel();
            for (int i = 0; i < 2528; i++)
            {
                viewModel.Background.Scroll(1);
            }
            Assert.AreEqual(0, viewModel.Background.Y);
            viewModel.Background.Scroll(1);
            Assert.AreEqual(-2528, viewModel.Background.Y);
        }
        [UITestMethod]
        public void CloudScroll()
        {
            var viewModel = new ViewModel();
            Assert.AreEqual(-2528,viewModel.Cloud.Y);
            viewModel.Cloud.Scroll(2);
            Assert.AreEqual(-2526,viewModel.Cloud.Y);
        }
        [UITestMethod]
        public void CloudScrollWrap()
        {
            var viewModel = new ViewModel();
            for (int i = 0; i < 2528/2; i++)
            {
                viewModel.Cloud.Scroll(2);
            }
            Assert.AreEqual(0,viewModel.Cloud.Y);
            viewModel.Cloud.Scroll(2);
            Assert.AreEqual(-2528,viewModel.Cloud.Y);
        }
    }
}
