using System.Threading.Tasks;

namespace PDFDemo.Interfaces
{
    public interface IFile
    {
        Task<string> GetLocalPath(string archivo);
    }
}
