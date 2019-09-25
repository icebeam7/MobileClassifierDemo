using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClassifierDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomVisionView : ContentPage
    {
        public CustomVisionView()
        {
            InitializeComponent();
            BindingContext = new ViewModels.CustomVisionViewModel();
        }
    }
}