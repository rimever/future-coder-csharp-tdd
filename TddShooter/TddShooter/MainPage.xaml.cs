#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using TddShooter.Model;

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
        private int _count;
        private Dictionary<int, List<AbstractEnemy>> story;

        /// <summary>
        /// <see cref="MainPage"/>のコンストラクタです。
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            ReadScenarioAsync();
            _model = new ViewModel();
            DataContext = _model;
            DataContext = _model;
            Window.Current.CoreWindow.KeyDown += CoreWindowOnKeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindowOnKeyUp;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(20);
            _timer.Tick += Tick;
            _timer.Start();
            _model.Message.Text = "GET READY...";
            _model.Ship.X = 300;
            _model.Ship.Y = 700;
        }

        private async Task ReadScenarioAsync()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Settings/scenario.json"));
            string text = await FileIO.ReadTextAsync(file);
            story = ScenarioReader.Read(text);
        }

        private void Tick(object sender, object e)
        {
            if (story.ContainsKey(_count))
            {
                var enemies = story[_count];
                foreach (var enemy in enemies)
                {
                    _model.AddEnemy(enemy);
                }

                story.Remove(_count);
            }
            if (++_count == 50)
            {
                _model.Message.Text = string.Empty;
            }
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