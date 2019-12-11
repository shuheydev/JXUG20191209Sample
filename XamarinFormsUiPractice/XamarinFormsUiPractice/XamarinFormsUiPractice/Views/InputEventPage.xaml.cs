using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsUiPractice.Models;
using System.Reflection;

namespace XamarinFormsUiPractice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputEventPage : ContentPage
    {
        public EventItem EventItem { get; set; } = new EventItem();

        public InputEventPage()
        {
            InitializeComponent();

            BindingContext = EventItem;
        }

        public InputEventPage(EventItem eventItem)
        {
            InitializeComponent();
            EventItem = eventItem;
            BindingContext = EventItem;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //読み込み
            var eventItems = DataFactory.ReadEventSaveFile();

            var modifyTarget = eventItems.FirstOrDefault(x => x.Id == EventItem.Id);

            if (modifyTarget is null)
            {
                //新規追加
                eventItems.Add(EventItem);
            }
            else
            {
                //更新
                modifyTarget.Title = EventItem.Title;
                modifyTarget.Description = EventItem.Description;
                modifyTarget.UpdateDateTime = DateTimeOffset.Now;
            }

            eventItems.ForEach(x => x.IsLast = false);
            eventItems.Last().IsLast = true;

            DataFactory.WriteEventSaveFile(eventItems);

            Navigation.PopModalAsync();
        }
    }
}