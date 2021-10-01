using MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes;

using PDFDemo.Interfaces;
using PDFDemo.Droid.Classes;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidImage))]
namespace PDFDemo.Droid.Classes
{
    public class AndroidImage : IImage
    {
        public string Prefix { get; set; }
        public ImageSource Implementation { get; set; }
        public bool Extension { get; set; }

        public AndroidImage()
        {
            Implementation = new AndroidImageSource();
            Prefix = string.Empty;
            Extension = false;
        }
    }
}