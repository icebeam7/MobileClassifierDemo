using Xamarin.Forms;

namespace MobileClassifierDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.CustomVisionView());
        }
    }
}
