using FileDataRetrieval.FileReader;
using FileDataRetrieval.Models;
using Newtonsoft.Json;

namespace FileDataRetrieval.Services
{
    public class FileSearchService : IFileSearchService
    {
        private readonly IFileHandler _fileHandler;

        public FileSearchService(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public async Task<Response<List<string>>> GetRootObjects(string folderPath)
        {
            var res = await _fileHandler.GetFilesFromPath(folderPath);
            if (res.Status != ResponseStatus.Succeeded)
                return res;

            var files = res.Result;
            if (files is not null && files.Any())
            {
                var values = new List<string>();
                foreach (var file in files)
                {
                    var root = JsonConvert.DeserializeObject<Root>(file);
                    values.AddRange(root?.DomainSourceBindings?.Select(d => d.Entity?.Attributes?.Select(a => a.Name) ?? new List<string>())?
                                 .SelectMany(x => x).ToList() ?? new List<string>());
                }
                return new Response<List<string>>(values.Where(v => !string.IsNullOrEmpty(v)).Distinct().ToList());
            }
            return new Response<List<string>>(null, ResponseStatus.Faild, "Soomething went wrong.");
        }

        public async Task<Response<List<string>>> GetCodeBySearchTerm(string folderPath, string searchTerm)
        {
            var res = await _fileHandler.GetFilesFromPath(folderPath);
            if (res.Status != ResponseStatus.Succeeded)
                return res;

            var files = res.Result;
            if (files is not null && files.Any())
            {
                var codes = files.Select(f => JsonConvert.DeserializeObject<Page>(f))?.Where(p => p.Title.ToLower().Contains(searchTerm.ToLower())).Select(p => p.Code);
                return new Response<List<string>>(codes.Where(v => !string.IsNullOrEmpty(v)).Distinct().ToList());
            }
            return new Response<List<string>>(null, ResponseStatus.Faild, "Soomething went wrong.");
        }
    }
}
