using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsUiPractice.Models;

namespace XamarinFormsUiPractice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionViewPage : ContentPage
    {
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


        public CollectionViewPage()
        {
            InitializeComponent();
            var a = new CollectionView();

            Photos = DataFactory.GetPhotos(20);

            RemainingItemsThreshold = 1;
            RemainingItemsThresholdReachedCommand = new Command(ExecuteRemainingItemsThresholdReachedCommand);

            this.BindingContext = this;
        }

        public ICommand RemainingItemsThresholdReachedCommand { get; set; }

        private void ExecuteRemainingItemsThresholdReachedCommand(object obj)
        {
            int currentCount = Photos.Count;
            int increaseCount = 20;
            for (int i = currentCount + 1; i < currentCount + increaseCount; i++)
            {
                //指定した個数に達したらそれ以上は増やさない
                if (i > 500)
                {
                    //増分読み込みを無効にする.
                    RemainingItemsThreshold = 0;
                    return;
                }

                Photos.Add(new Photo
                {
                    PhotoUri = $"photo_{i}",
                    Title=$"Title{i}",
                    Description=$"サンプルです",
                });
            }
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var prev = e.PreviousSelection;
            var typePrev = prev.GetType();
            var current = e.CurrentSelection;
            var typeCurrent = current.GetType();
        }
    }
}