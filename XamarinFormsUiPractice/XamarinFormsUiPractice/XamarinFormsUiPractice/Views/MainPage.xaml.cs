using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsUiPractice.Models;
using XamarinFormsUiPractice.Views;

namespace XamarinFormsUiPractice
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<Person> SampleData { get; set; }

        public string Title2 { get; set; } = "カルーセルビュー";

        public ICommand NavigationCommand { get; set; }

        public MainPage()
        {
            InitializeComponent();

            SampleData = new List<Person>
            {
                new Person{FirstName="A",Age=10,AvatarUrl=$"https://robohash.org/A"},
                new Person{FirstName="B",Age=20,AvatarUrl=$"https://robohash.org/B"},
                new Person{FirstName="C",Age=10,AvatarUrl=$"https://robohash.org/C"},
                new Person{FirstName="D",Age=20,AvatarUrl=$"https://robohash.org/D"},
                new Person{FirstName="E",Age=10,AvatarUrl=$"https://robohash.org/E"},
                new Person{FirstName="F",Age=20,AvatarUrl=$"https://robohash.org/F"},
                new Person{FirstName="G",Age=10,AvatarUrl=$"https://robohash.org/G"},
                new Person{FirstName="H",Age=20,AvatarUrl=$"https://robohash.org/H"},
            };

            NavigationCommand = new Command<string>(async (pageName) => await NavigateAsync(pageName));
            this.BindingContext = this;
        }




        private async Task NavigateAsync(string pageName)
        {
            switch (pageName)
            {
                case "ImageCirclePage":
                    await Application.Current.MainPage.Navigation.PushAsync(new ImageCirclePage());
                    break;
                case "AnimationPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new AnimationPage());
                    break;
                case "GreatAnimationPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new GreatAnimationPage());
                    break;
                case "FontImageSourcePage":
                    await Application.Current.MainPage.Navigation.PushAsync(new FontImageSourcePage());
                    break;
                case "TimeLinePage":
                    await Application.Current.MainPage.Navigation.PushAsync(new TimeLinePage());
                    break;
                case "CollectionViewPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new CollectionViewPage());
                    break;
                case "ListViewPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new ListViewPage());
                    break;
                case "RefreshViewPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new RefreshViewPage());
                    break;
                case "ProfilePage":
                    await Application.Current.MainPage.Navigation.PushAsync(new ProfilePage());
                    break;
                case "BasicUiPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new BasicUiPage());
                    break;
            }
        }
    }
}
