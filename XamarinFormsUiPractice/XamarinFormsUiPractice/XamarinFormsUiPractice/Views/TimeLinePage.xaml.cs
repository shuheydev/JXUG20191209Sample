using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsUiPractice.Models;

namespace XamarinFormsUiPractice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeLinePage : ContentPage
    {
        public DateTimeOffset Today { get; set; }

        ObservableCollection<EventItem> _eventList;
        public ObservableCollection<EventItem> EventList
        {
            get => _eventList;
            set
            {
                _eventList = value;
                OnPropertyChanged(nameof(EventList));
            }
        }

        public TimeLinePage()
        {
            InitializeComponent();

            //タイムラインに表示するデータはJSONファイル読み書きでとりあえず
            EventList = new ObservableCollection<EventItem>(DataFactory.ReadEventSaveFile());

            Today = DateTimeOffset.Now;

            BindingContext = this;
        }

        private void timelineListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var s = sender as ListView;
            if (s == null)
            {
                return;
            }
            s.SelectedItem = null;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new InputEventPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            EventList = new ObservableCollection<EventItem>(DataFactory.ReadEventSaveFile());
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;

            try
            {
                var removeTarget = EventList.First(x => x.Id == mi.CommandParameter.ToString());
                EventList.Remove(removeTarget);

                if(EventList.Any())
                {
                    EventList.First(x => x.IsLast = true).IsLast = false;
                    EventList.Last().IsLast = true;
                }

                DataFactory.WriteEventSaveFile(EventList);
            }
            catch
            {

            }
        }

        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;

            //CommandParameterに長押しされた項目にバインディングされたオブジェクトのIdが渡されてくるので
            //それを使って編集対象を取得
            var modifyTarget = EventList.First(x => x.Id == mi.CommandParameter.ToString());

            Navigation.PushModalAsync(new InputEventPage(modifyTarget));
        }
    }
}