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
    public partial class ListViewPage : ContentPage
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

        public ListViewPage()
        {
            InitializeComponent();

            People = DataFactory.GetPeople(20);

            FollowButtonTappedCommand = new Command(ExecuteFollowButtonTapped);
            BindingContext = this;
        }

        private void ExecuteFollowButtonTapped(object obj)
        {

        }

        public ICommand FollowButtonTappedCommand { get; }

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
            text = text == defaultText ? "Follow":defaultText;
            label.Text = text;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var s = sender as ListView;
            if (s == null)
                return;
            s.SelectedItem = null;
        }
    }
}