using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsUiPractice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private int _likes = 5231;
        public int Likes
        {
            get => _likes;
            set
            {
                _likes = value;
                OnPropertyChanged(nameof(Likes));
            }
        }

        private int _following = 87;
        public int Following
        {
            get => _following;
            set
            {
                _following = value;
                OnPropertyChanged(nameof(Following));
            }
        }

        private int _followers = 612;
        public int Followers
        {
            get => _followers;
            set
            {
                _followers = value;
                OnPropertyChanged(nameof(Followers));
            }
        }


        Random _rand = new Random();
        public ProfilePage()
        {
            InitializeComponent();

            BindingContext = this;


            Device.StartTimer(TimeSpan.FromSeconds(2), () => TimerTick());
        }

        private bool TimerTick()
        {
            //Judge increment Likes
            int oracle = _rand.Next(1, 3);
            if (oracle == 2)
            {
                Likes++;
                //animation
                AnimateFlip(label_Likes);
            }

            oracle = _rand.Next(1, 5);
            if (oracle == 4)
            {
                Followers++;
                AnimateFlip(label_Followers);
            }

            return true;
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


            if (text == "Follow")
            {
                Followers--;
                AnimateFlip(label_Followers);
            }
            else
            {
                Followers++;
                AnimateFlip(label_Followers);
            }
        }


        private async Task AnimateFlip(View ui)
        {
            await ui.RotateXTo(360, 1000, Easing.SpringOut);
            ui.RotationX = 0;
        }
    }
}