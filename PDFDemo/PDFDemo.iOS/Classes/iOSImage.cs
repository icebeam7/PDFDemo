using MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes;

using PDFDemo.Interfaces;
using PDFDemo.iOS.Classes;

[assembly: Xamarin.Forms.Dependency(typeof(ImageniOS))]
namespace PDFDemo.iOS.Classes
{
    public class ImageniOS : IImage
    {
        public string Prefix { get; set; }
        public ImageSource Implementation { get; set; }
        public bool Extension { get; set; }

        public ImageniOS()
        {
            Implementation = new ImageSourceiOS();
            Prefix = string.Empty;
            Extension = false;
        }
    }
}