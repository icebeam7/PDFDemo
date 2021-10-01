using MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes;

namespace PDFDemo.Interfaces
{
    public interface IImage
    {
        string Prefix { get; set; }
        ImageSource Implementation { get; set; }
        bool Extension { get; set; }
    }
}
