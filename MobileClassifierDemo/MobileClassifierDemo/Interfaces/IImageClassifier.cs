using Plugin.Media.Abstractions;
using System.Threading.Tasks;

namespace MobileClassifierDemo.Interfaces
{
    public interface IImageClassifier
    {
        Task<string> AnalyzeImage(MediaFile image);
    }
}
