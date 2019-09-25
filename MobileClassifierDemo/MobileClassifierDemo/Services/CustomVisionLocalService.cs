using System;
using System.Linq;
using System.Threading.Tasks;

using Plugin.Media.Abstractions;
using Xam.Plugins.OnDeviceCustomVision;

namespace MobileClassifierDemo.Services
{
    public static class CustomVisionLocalService
    {
        public async static Task<string> ClassifyImage(MediaFile picture)
        {
            var predictions = await CrossImageClassifier.Current.ClassifyImage(picture.GetStreamWithImageRotatedForExternalStorage());
            var topPrediction = predictions.OrderByDescending(t => t.Probability).First();
            return $"{topPrediction.Tag} ({Math.Round(topPrediction.Probability * 100, 2):0.##} %) --local--";
        }
    }
}
