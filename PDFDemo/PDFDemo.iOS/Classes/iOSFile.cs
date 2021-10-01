using System;
using System.IO;
using System.Threading.Tasks;

using Xamarin.Forms;

using PDFDemo.Interfaces;
using PDFDemo.iOS.Classes;

[assembly: Dependency(typeof(iOSFile))]
namespace PDFDemo.iOS.Classes
{
    public class iOSFile : IFile
    {
        public async Task<string> GetLocalPath(string archivo)
        {
            var folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "..", "Library");

            return Path.Combine(folder, archivo);
        }
    }
}