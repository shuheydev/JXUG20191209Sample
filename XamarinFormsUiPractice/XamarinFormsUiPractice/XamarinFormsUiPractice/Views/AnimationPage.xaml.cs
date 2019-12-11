using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsUiPractice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimationPage : ContentPage
    {
        private int _likeCount = 0;
        public int LikeCount {
            get => _likeCount;
            set
            {
                _likeCount = value;
                OnPropertyChanged(nameof(LikeCount));
            }
        }

        public AnimationPage()
        {
            InitializeComponent();

            this.BindingContext = this;
        }

        private async void TapGestureRecognizer_Tapped_myIconImage(object sender, EventArgs e)
        {
            uint duration = 100;
            await Task.WhenAll(
                     myIconImage.ScaleTo(0.2, duration),
                     myIconImage.FadeTo(0.2, duration)
                );

            uint duration2 = 300;
            await Task.WhenAll(
                     myIconImage.ScaleTo(1, duration2, Easing.SpringOut),
                     myIconImage.FadeTo(1, duration2, Easing.SpringOut)
                );
        }

        private async void TapGestureRecognizer_Tapped_heartImage(object sender, EventArgs e)
        {
            //一旦縮みつつフェードアウトさせる.
            //若干速く
            uint duration = 50;
            await Task.WhenAll(
                     heartImage.ScaleTo(0.2, duration),
                     heartImage.FadeTo(0.2, duration)
                );

            //Sourceにセットされている画像ファイル名に応じて,
            //2つの画像を交互に切り替える
            string imageSource = Regex.Match(heartImage.Source.ToString(), @"(?<=:).+").Value.Trim();
            if (imageSource == "heart")
            {
                heartImage.Source = "heart_full";
                LikeCount++;
            }
            else
            {
                heartImage.Source = "heart";
            }

            //少し遅めの速度で元のサイズ,透明度に戻す
            //SpringOutをつけてピョコン感をだしている
            uint duration2 = 300;
            await Task.WhenAll(
                     heartImage.ScaleTo(1, duration2, Easing.SpringOut),
                     heartImage.FadeTo(1, duration2, Easing.SpringOut)
                );
        }
    }
}