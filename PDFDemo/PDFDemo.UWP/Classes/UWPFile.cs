using System.IO;
using System.Threading.Tasks;

using Xamarin.Forms;
using Windows.Storage;

using PDFDemo.Interfaces;
using PDFDemo.UWP.Classes;

[assembly: Dependency(typeof(UWPFile))]
namespace PDFDemo.UWP.Classes
{
    public class UWPFile : IFile
    {
        public async Task<string> GetLocalPath(string file)
        {
            var folder = ApplicationData.Current.LocalFolder.Path;
            return Path.Combine(folder, file);
        }
    }
}