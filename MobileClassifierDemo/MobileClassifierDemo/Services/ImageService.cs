using System;
using System.Threading.Tasks;

using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MobileClassifierDemo.Services
{
    public static class ImageService
    {
        public static async Task<MediaFile> TakePhoto()
        {
            MediaFile picture = null;

            try
            {
                //picture = await CrossMedia.Current.PickPhotoAsync();

                if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
                {
                    picture = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        Directory = "Pictures",
                        Name = "photo.jpg"
                    });
                }
            }
            catch (Exception ex)
            {

            }

            return picture;
        }
    }
}
