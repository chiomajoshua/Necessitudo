using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Necessitudo.ViewModels.Onbaording
{
    public class UploadPicturePageViewModel : BaseViewModel
    {
        private const string CamOption = "From Camera";
        private const string GalleryOption = "From Gallery";

        public UploadPicturePageViewModel()
        {
            PhotoSource = "sampleImage.png";
        }

        public ImageSource PhotoSource
        {
            get => GetValue<ImageSource>();
            set => SetValue(value);
        }

        public ICommand PhotographCommand => new Command(UploadPhotograph);

        private async void UploadPhotograph()
        {
            try
            {
                //string img;
                //var result = await AppInstance.MainPage.DisplayActionSheet("Please Select Passport", "Close", null, CamOption, GalleryOption);
                //if (result == CamOption) img = await DependencyService.Get<Services.IPicturePicker>().PickImageFromCameraAsync(300, 300);
                //else if (result == GalleryOption) img = await DependencyService.Get<Services.IPicturePicker>().PickImageFromLibrayAsync(300, 300);
                //else return;
                //if (string.IsNullOrEmpty(img)) return;

                //System.IO.MemoryStream stream = new System.IO.MemoryStream(Convert.FromBase64String(img));
                //PhotoSource = ImageSource.FromStream(() => stream);
            }
            catch (Exception ce)
            {

            }

        }
    }
}
