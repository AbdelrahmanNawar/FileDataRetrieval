using Aspose.Html;
using Aspose.Pdf;
using BenchmarkDotNet.Attributes;
using FileDataRetrieval.Models;

namespace FileDataRetrieval.FileReader
{
    [MemoryDiagnoser]
    public class FileHandler : IFileHandler
    {
        private string GetPath(string path) => $"A:\\ToInterview\\Takaful{path}";

        public async Task<Response<List<string>>> GetFilesFromPath(string path)
        {
            var fullPath = GetPath(path);
            if (File.Exists(fullPath))
            {
                var res = await ProcessFile(fullPath);
                return res.Status != ResponseStatus.Succeeded
                    ? new Response<List<string>>(null, res.Status, res.Messages) :
                     new Response<List<string>>(new List<string> { res.Result });
            }
            else if (Directory.Exists(fullPath))
                return await ProcessDirectory(fullPath);
            else
                return new Response<List<string>>(null, ResponseStatus.NotFound, "Enter a valid path.");
        }

        [Benchmark]
        public Response StringToPDFFileConverter(List<string> data, string fileName)
        {
            if (data is null || !data.Any())
                return new Response();

            string documentPath = $"Resources\\{fileName}.html";

            using (var htmlDocument = new HTMLDocument())
            {
                data.ForEach(item =>
                {
                    var element = htmlDocument.CreateElement("dev");
                    element.TextContent = item.ToString();
                    htmlDocument.Body.AppendChild(element);
                    htmlDocument.Body.AppendChild(htmlDocument.CreateElement("hr"));
                });
                htmlDocument.Save(documentPath);
                htmlDocument.Dispose();
            }
            using (Document pdfDocument = new(documentPath, new HtmlLoadOptions()))
            {
                Aspose.Pdf.Page page = pdfDocument.Pages.Add();

                Table table = new Table();
                table.Border = new BorderInfo(BorderSide.All, .5f, Color.FromRgb(System.Drawing.Color.LightGray));

                table.DefaultCellBorder = new BorderInfo(BorderSide.All, .5f, Color.FromRgb(System.Drawing.Color.LightGray));
                data.ForEach(item=> table.Rows.Add().Cells.Add(item));
                page.Paragraphs.Add(table);
                pdfDocument.Save($"{fileName}.PDF");
                pdfDocument.Dispose();
            }
            return new Response();
        }

        [Benchmark]
        private async Task<Response<string>> ProcessFile(string path)
        {
            using (StreamReader reader = new(path))
            {
                var fileContent = await reader.ReadToEndAsync();
                if (string.IsNullOrEmpty(fileContent))
                    return new Response<string>(null);

                return new Response<string>(fileContent);
            }
        }

        private async Task<Response<List<string>>> ProcessDirectory(string targetDirectory)
        {
            var results = new List<string>();

            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                var res = await ProcessFile(fileName);
                if (res.Status != ResponseStatus.Succeeded)
                    return new Response<List<string>>(null, ResponseStatus.Faild, "Failed to read file {fileName}");
                results.Add(res.Result);
            }

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                await ProcessDirectory(subdirectory);

            return new Response<List<string>>(results.Where(r => !string.IsNullOrEmpty(r)).Distinct().ToList());
        }
    }
}
