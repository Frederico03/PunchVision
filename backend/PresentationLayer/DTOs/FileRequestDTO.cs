using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace PresentationLayer.DTOs
{
    public class FileRequestDTO
    {
        public IFormFile File { get; set; }
        public string BucketName { get; set; }
        public string? Prefix { get; set; }
    }
}

