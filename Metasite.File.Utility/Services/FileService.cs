using Metasite.File.Utility.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Metasite.File.Utility
{
    public class FileService : IFileService
    {
        protected readonly AppSettings _appSettings;

        public FileService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<Stream> GetFileStream(string fileName)
        {
            var path = $"{_appSettings.FilesLocation}{fileName}";
            var stream = new MemoryStream();
            var sourceStream = new FileStream(path,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true);
            await sourceStream.CopyToAsync(stream);
            stream.Position = 0;
            return stream;
        }

        public string GetContentType(string fileName)
        {
            var types = _appSettings.MimeTypes;
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            if (types.ContainsKey(extension))
            {
                return types[extension];
            }
            else
            {
                throw new Exception("Content type is not supported!");
            }
        }
    }
}
