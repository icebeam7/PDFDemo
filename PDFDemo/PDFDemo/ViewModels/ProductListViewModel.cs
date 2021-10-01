using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

using PDFDemo.Models;
using PDFDemo.Services;

namespace PDFDemo.ViewModels
{
    public class ProductListViewModel : BaseViewModel
    {
        private List<Product> products;

        public ObservableCollection<Product> ProductCollection { get; }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { SetProperty(ref selectedProduct, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand PrintPdfCommand { get; private set; }

        private async Task LoadData()
        {
            if (ProductCollection.Count == 0)
            {
                IsBusy = true;

                await Task.Delay(4000);
                products = ProductService.GetProducts();
                SetProductCollection(products);

                IsBusy = false;
            }
        }

        private async Task PrintPdf()
        {
            var pdfReport = new PDFReports.ProductsReport(products);
            await pdfReport.CreateReport();
        }

        private void SetProductCollection(List<Product> products)
        {
            while (ProductCollection.Count > 0)
                ProductCollection.RemoveAt(0);

            foreach (var item in products)
                ProductCollection.Add(item);
        }

        public ProductListViewModel()
        {
            SelectedProduct = null;
            ProductCollection = new ObservableCollection<Product>();
            LoadDataCommand = new Command(async () => await LoadData());
            PrintPdfCommand = new Command(async () => await PrintPdf());
        }
    }
}
