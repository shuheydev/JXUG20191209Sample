using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsUiPractice
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppDirectoryPath= Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            EventSaveFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EventSaveFile.json");

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


        public static string AppDirectoryPath;
        public static string EventSaveFilePath;
    }
}
