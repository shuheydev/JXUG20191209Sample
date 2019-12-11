using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsUiPractice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageCirclePage : ContentPage
    { 
        public ImageCirclePage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            double opacity = circleImage.Opacity == 1 ? 0.0 : 1.0;

            circleImage.FadeTo(opacity, 500, Easing.SinIn);
        }
    }
}