using ShellSampleXamarin.Extensions;
using ShellSampleXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellSampleXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private int _likeCount = 0;
        public int LikeCount
        {
            get => _likeCount;
            set
            {
                _likeCount = value;
                OnPropertyChanged(nameof(LikeCount));
            }
        }

        private ObservableCollection<Person> _people = new ObservableCollection<Person>();
        public ObservableCollection<Person> People
        {
            get => _people;
            set
            {
                _people = value;
                OnPropertyChanged(nameof(People));
            }
        }

        private ObservableCollection<Photo> _photos = new ObservableCollection<Photo>();
        public ObservableCollection<Photo> Photos
        {
            get => _photos;
            set
            {
                _photos = value;
                OnPropertyChanged(nameof(Photos));
            }
        }

        private int _remainingItemsThreshold;
        public int RemainingItemsThreshold
        {
            get => _remainingItemsThreshold;
            set
            {
                _remainingItemsThreshold = value;
                OnPropertyChanged(nameof(RemainingItemsThreshold));
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public HomePage()
        {
            InitializeComponent();

            People = DataFactory.GetPeople(15);
            Photos = DataFactory.GetPhotos(10);

            RefreshCommand = new Command(async (o) => await ExecuteRefreshCommand(o));
            RemainingItemsThreshold = 1;
            RemainingItemsThresholdReachedCommand = new Command(ExecuteRemainingItemsThresholdReachedCommand);

            BindingContext = this;
        }

        private async void TapGestureRecognizer_Tapped_heartImage(object sender, EventArgs e)
        {
            var likeIcon = sender as Image;

            //一旦縮みつつフェードアウトさせる.
            //若干速く
            uint duration = 50;
            await Task.WhenAll(
                     likeIcon.ScaleTo(0.2, duration),
                     likeIcon.FadeTo(0.2, duration)
                );

            //Sourceにセットされている画像ファイル名に応じて,
            //2つの画像を交互に切り替える
            string imageSource = Regex.Match(likeIcon.Source.ToString(), @"(?<=:).+").Value.Trim();
            if (imageSource == "heart_white")
            {
                likeIcon.Source = "heart_full";
                LikeCount++;
            }
            else
            {
                likeIcon.Source = "heart_white";
            }

            //少し遅めの速度で元のサイズ,透明度に戻す
            //SpringOutをつけてピョコン感をだしている
            uint duration2 = 300;
            await Task.WhenAll(
                     likeIcon.ScaleTo(1, duration2, Easing.SpringOut),
                     likeIcon.FadeTo(1, duration2, Easing.SpringOut)
                );
        }


        public ICommand RemainingItemsThresholdReachedCommand { get; set; }
        private void ExecuteRemainingItemsThresholdReachedCommand(object obj)
        {
            int currentCount = Photos.Count;
            int increaseCount = 20;
            for (int i = currentCount + 1; i < currentCount + increaseCount; i++)
            {
                //指定した個数に達したらそれ以上は増やさない
                if (i > 30)
                {
                    //増分読み込みを無効にする.
                    RemainingItemsThreshold = 0;
                    return;
                }

                Photos.Add(new Photo
                {
                    PhotoUri = $"photo_{i}",
                    Title = $"Title{i}",
                    Description = $"サンプルです",
                });
            }
        }

        public ICommand RefreshCommand { get; }
        private async Task ExecuteRefreshCommand(object obj)
        {
            await Task.Delay(2000);

            People.Clear();

            People = DataFactory.GetPeople(15).Random();
            Photos = DataFactory.GetPhotos(10).Random();

            IsRefreshing = false;
        }
    }
}