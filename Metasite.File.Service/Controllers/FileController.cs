using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metasite.File.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Metasite.File.Service.Controllers
{
    [ApiController]
    public class FileController : ControllerBase
    {
        protected readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("{fileName}")]
        public async Task<ActionResult> Get(string fileName)
        {
            var contentType = _fileService.GetContentType(fileName);

            var stream = await _fileService.GetFileStream(fileName);

            return File(stream, contentType, fileName);
        }

    }
}
