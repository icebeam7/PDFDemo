using Xamarin.Forms;

namespace PDFDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.ProductListView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
