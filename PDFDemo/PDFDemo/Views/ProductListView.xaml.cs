using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PDFDemo.ViewModels;

namespace PDFDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductListView : ContentPage
    {
        public ProductListView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var vm = (ProductListViewModel)BindingContext;

            await Task.Run(() => vm.LoadDataCommand.Execute(null));
            vm.SelectedProduct = null;
        }
    }
}