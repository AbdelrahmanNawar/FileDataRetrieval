using FileDataRetrieval.Models;

namespace FileDataRetrieval.Services
{
    public interface IFileSearchService
    {
        Task<Response<List<string>>> GetRootObjects(string folderPath);
        Task<Response<List<string>>> GetCodeBySearchTerm(string folderPath, string searchTerm);
    }
}
