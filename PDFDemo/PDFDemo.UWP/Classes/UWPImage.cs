using MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes;

using PDFDemo.Interfaces;
using PDFDemo.UWP.Classes;

[assembly: Xamarin.Forms.Dependency(typeof(UWPImage))]
namespace PDFDemo.UWP.Classes
{
    public class UWPImage : IImage
    {
        public string Prefix { get; set; }
        public ImageSource Implementation { get; set; }
        public bool Extension { get; set; }

        public UWPImage()
        {
            Implementation = new ImageSourceUWP();
            Prefix = "Assets/";
            Extension = true;
        }
    }
}
