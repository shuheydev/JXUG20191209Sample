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
    public partial class DescriptionPane : ContentView
    {
        public DescriptionPane()
        {
            InitializeComponent();
        }

        public string Text
        {
            get
            {
                return Description.Text;
            }
            set
            {
                Description.Text = value;
            }
        }
    }
}