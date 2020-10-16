using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Landeta_Cameta
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            TakePhoto.Clicked += TakePhoto_Clicked;
        }

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            var cameraOptions =
                new Plugin.Media.Abstractions.StoreCameraMediaOptions();
            cameraOptions.SaveToAlbum= true;
            var photo =
                await Plugin.Media.CrossMedia.Current
                .TakePhotoAsync(cameraOptions);

            if (photo != null)
            {
                Photo.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });

            }

        }
    }
}
