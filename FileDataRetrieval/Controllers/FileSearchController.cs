using BenchmarkDotNet.Attributes;
using FileDataRetrieval.FileReader;
using FileDataRetrieval.Models;
using FileDataRetrieval.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FileDataRetrieval.Controllers
{
    public class FileSearchController : Controller
    {
        private readonly IFileHandler _fileHandler;
        private readonly IFileSearchService _fileSearchService;

        public FileSearchController(IFileHandler fileHandler, IFileSearchService fileSearchService)
        {
            _fileHandler = fileHandler;
            _fileSearchService = fileSearchService;
        }

        [Benchmark]
        [HttpGet("get-all-attributes")]
        public async Task<IActionResult> GetAllAttributes([FromQuery] string folderPath)
        {
            try
            {
                var getFileRes = await _fileSearchService.GetRootObjects(folderPath);
                if (getFileRes.Status != ResponseStatus.Succeeded)
                    return NotFound();

                var pdfRes = _fileHandler.StringToPDFFileConverter(getFileRes.Result, "Nawar");
                if (pdfRes.Status != ResponseStatus.Succeeded)
                    return NotFound();

                return Ok(pdfRes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [HttpGet("get-all-pages")]
        public async Task<IActionResult> GetAllPages([FromQuery] string folderPath, [FromQuery] string searchTerm)
        {
            try
            {
                var getFileRes = await _fileSearchService.GetCodeBySearchTerm(folderPath, searchTerm);
                if (getFileRes.Status != ResponseStatus.Succeeded)
                    return NotFound();

                var pdfRes = _fileHandler.StringToPDFFileConverter(getFileRes.Result, "Nawar");
                if (pdfRes.Status != ResponseStatus.Succeeded)
                    return NotFound();

                return Ok(pdfRes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest("Something went wrong.");
            }
        }
    }
}
