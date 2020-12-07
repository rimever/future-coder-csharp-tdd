#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;

#endregion

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
            viewModel.Background.Tick();
            Assert.AreEqual(-2527, viewModel.Background.Y);
        }

        [UITestMethod]
        public void JustScrollWrap()
        {
            var viewModel = new ViewModel();
            for (int i = 0; i < 2528; i++)
            {
                viewModel.Background.Tick();
            }

            Assert.AreEqual(0, viewModel.Background.Y);
            viewModel.Background.Tick();
            Assert.AreEqual(-2528, viewModel.Background.Y);
        }

        [UITestMethod]
        public void CloudScroll()
        {
            var viewModel = new ViewModel();
            Assert.AreEqual(-2528, viewModel.Cloud.Y);
            viewModel.Cloud.Tick();
            Assert.AreEqual(-2526, viewModel.Cloud.Y);
        }

        [UITestMethod]
        public void CloudScrollWrap()
        {
            var viewModel = new ViewModel();
            for (int i = 0; i < 2528 / 2; i++)
            {
                viewModel.Cloud.Tick();
            }

            Assert.AreEqual(0, viewModel.Cloud.Y);
            viewModel.Cloud.Tick();
            Assert.AreEqual(-2528, viewModel.Cloud.Y);
        }
    }
}