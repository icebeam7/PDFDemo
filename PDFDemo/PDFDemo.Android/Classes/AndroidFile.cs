using System.IO;
using System.Threading.Tasks;

using Android.OS;
using Android.App;

using Xamarin.Essentials;

using PDFDemo.Interfaces;
using PDFDemo.Droid.Classes;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidFile))]
namespace PDFDemo.Droid.Classes
{
    public class AndroidFile : IFile
    {
        public async Task<string> GetLocalPath(string file)
        {
            var status = await Permissions.RequestAsync<Permissions.StorageWrite>();

            if (status == PermissionStatus.Granted)
            {
                var folder = Path.Combine(
                    Application.Context.GetExternalFilesDir(
                        Environment.DirectoryDocuments).AbsolutePath, "reports");

                Directory.CreateDirectory(folder);
                return Path.Combine(folder, file);
            }

            return string.Empty;
        }
    }
}