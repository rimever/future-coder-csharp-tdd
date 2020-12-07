#region

using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#endregion

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace TddShooter
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ViewModel _model;
        private readonly DispatcherTimer _timer;

        /// <summary>
        /// <see cref="MainPage"/>のコンストラクタです。
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            _model = new ViewModel();
            DataContext = _model;
            Window.Current.CoreWindow.KeyDown += CoreWindowOnKeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindowOnKeyUp;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(20);
            _timer.Tick += Tick;
            _timer.Start();
            _model.AddEnemy(new Enemy(200, 100));
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