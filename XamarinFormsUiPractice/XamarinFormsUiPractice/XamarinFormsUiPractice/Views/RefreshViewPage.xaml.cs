using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsUiPractice.Extensions;
using XamarinFormsUiPractice.Models;

namespace XamarinFormsUiPractice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RefreshViewPage : ContentPage
    {
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

        private bool _isAvatarRefreshing;
        public bool IsAvatarRefreshing
        {
            get => _isAvatarRefreshing;
            set
            {
                _isAvatarRefreshing = value;
                OnPropertyChanged(nameof(IsAvatarRefreshing));
            }
        }

        private string _avatarUri="myIcon";
        public string AvatarUri
        {
            get => _avatarUri;
            set
            {
                _avatarUri = value;
                OnPropertyChanged(nameof(AvatarUri));
            }
        }

        public ICommand RefreshCommand { get; }

        public ICommand AvatarRefreshCommand { get; }

        public RefreshViewPage()
        {
            InitializeComponent();
            RefreshCommand = new Command(async (o) => await ExecuteRefreshCommand(o));
            AvatarRefreshCommand = new Command(async (o) => await ExecuteAvatarRefreshCommand(o));
            this.BindingContext = this;
        }

        private async Task ExecuteAvatarRefreshCommand(object obj)
        {
            await Task.Delay(2000);

            var newAvatarUri = DataFactory.GetPeople(30).Random().Take(1).First().AvatarUrl;

            AvatarUri = newAvatarUri;

            IsAvatarRefreshing = false;
        }

        private async Task ExecuteRefreshCommand(object obj)
        {
            await Task.Delay(2000);

            People.Clear();

            People = DataFactory.GetPeople(20).Random();

            IsRefreshing = false;
        }


        private Color defaultColor = Color.FromHex("55acee");
        private string defaultText = "Following";
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;

            var bgColor = frame.BackgroundColor;
            //Switch Color
            bgColor = bgColor == defaultColor ? Color.White : defaultColor;
            frame.BackgroundColor = bgColor;


            var label = (Label)frame.Children[0];
            //Switch text color;
            var textColor = label.TextColor;
            textColor = textColor == defaultColor ? Color.White : defaultColor;
            label.TextColor = textColor;

            //Switch text
            var text = label.Text;
            text = text == defaultText ? "Follow" : defaultText;
            label.Text = text;
        }

    }
}