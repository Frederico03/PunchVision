using System.Threading.Tasks;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Interfaces
{
    public interface IFileService
    {
        Task<bool>UploadFileAsync(IFormFile file, string bucketName, string? prefix);
        Task<IEnumerable<S3ObjectModel>> GetAllFilesAsync(string bucketName, string? prefix);
    }
}
