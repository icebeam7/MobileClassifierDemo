using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

using MobileClassifierDemo.Models;
using MobileClassifierDemo.Helpers;

using Newtonsoft.Json;
using Plugin.Media.Abstractions;

namespace MobileClassifierDemo.Services
{
    public static class CustomVisionService
    {
        private static readonly HttpClient client = CreateHttpClient();

        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Constants.PredictionBaseURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Prediction-Key", Constants.PredictionKey);
            return client;
        }

        public async static Task<string> ClassifyImage(MediaFile picture)
        {
            try
            {
                var stream = picture.GetStreamWithImageRotatedForExternalStorage();
                var ms = new MemoryStream();
                stream.CopyTo(ms);

                using (var content = new ByteArrayContent(ms.ToArray()))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    var post = await client.PostAsync(Constants.PredictionProjectRequest, content);
                    var predictionResult = await post.Content.ReadAsStringAsync();
                    var customVisionResult = JsonConvert.DeserializeObject<CustomVisionResult>(predictionResult);

                    if (customVisionResult.Predictions.Count > 0)
                    {
                        var topPrediction = customVisionResult.Predictions.OrderByDescending(x => x.Probability).First();
                        return topPrediction.Probability > 0.5
                            ? $"{topPrediction.TagName} ({Math.Round(topPrediction.Probability * 100, 2):0.##} %) --API--"
                            : "N/A";
                        //return $"{topPrediction.Tag} ({Math.Round(prediccion.Probability * 100, 2):0.##} %)";
                    }
                    else
                    {
                        return "There was an error. Try again.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"There was an exception: {ex.Message}";
            }
        }
    }
}
