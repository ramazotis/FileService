using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Metasite.File.Utility
{
    public interface IFileService
    {
        Task<Stream> GetFileStream(string path);
        string GetContentType(string path);
    }
}