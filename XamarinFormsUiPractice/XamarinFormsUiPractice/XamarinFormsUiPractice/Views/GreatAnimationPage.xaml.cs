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
    public partial class GreatAnimationPage : ContentPage
    {
        public GreatAnimationPage()
        {
            InitializeComponent();
        }

        bool isExpanded = true;
        Rectangle expandedRectangle; 
        Rectangle detailsRectangle;  

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            if (isExpanded)
                AnimateIn();
            else
                AnimateOut();
            isExpanded = !isExpanded;
        }

        private void AnimateIn()
        {
            MainImage.LayoutTo(detailsRectangle, 600, Easing.SpringOut);
            BottomFrame.TranslateTo(0, 0, 600, Easing.SpringOut);
            Title.TranslateTo(0, 0, 600, Easing.SpringOut);
            ExpandBar.FadeTo(.01, 250, Easing.SinInOut);
        }

        private void AnimateOut()
        {
            MainImage.LayoutTo(expandedRectangle, 600, Easing.SpringOut);
            BottomFrame.TranslateTo(0, BottomFrame.Height, 1200, Easing.SpringOut);
            Title.TranslateTo(-Title.Width-10, 0, 600, Easing.SpringOut);
            ExpandBar.FadeTo(1, 250, Easing.SinInOut);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            detailsRectangle = new Rectangle(0, 0, width, BottomFrame.Bounds.Top +20);//アイテム表示時にメイン画像をこのRectangleにフィットさせる
            expandedRectangle = new Rectangle(0, 0, width, height);//アイテム非表示時.メイン画像をこのRectangleにフィットさせる

            if (isExpanded)
            {
                MainImage.Layout(expandedRectangle);
                BottomFrame.TranslationY = BottomFrame.Height;
                Title.TranslationX = -Title.Width-10;
            }
            else
            {
                MainImage.Layout(detailsRectangle);
                BottomFrame.TranslationY = 0;
                Title.TranslationX = 0;
            }
        }
    }
}