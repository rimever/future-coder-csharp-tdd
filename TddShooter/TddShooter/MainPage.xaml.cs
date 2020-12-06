using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace TddShooter
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ViewModel _model;
        private DispatcherTimer _timer;

        /// <summary>
        /// <see cref="MainPage"/>のコンストラクタです。
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new ViewModel();
            _model = new ViewModel();
            DataContext = _model;
            Window.Current.CoreWindow.KeyDown += CoreWindowOnKeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindowOnKeyUp;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(20);
            _timer.Tick += Tick;
            _timer.Start();
        }

        private void Tick(object sender, object e)
        {
            _model.Tick(1);
        }

        private void CoreWindowOnKeyUp(CoreWindow sender, KeyEventArgs args)
        {
            _model.KeyUp(args.VirtualKey);
        }

        private void CoreWindowOnKeyDown(CoreWindow sender, KeyEventArgs args)
        {
            _model.KeyDown(args.VirtualKey);
        }
    }
}
