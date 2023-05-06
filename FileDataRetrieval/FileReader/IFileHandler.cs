using FileDataRetrieval.Models;

namespace FileDataRetrieval.FileReader
{
    public interface IFileHandler
    {
        Task<Response<List<string>>> GetFilesFromPath(string path);
        Response StringToPDFFileConverter(List<string> data, string fileName);
    }
}
