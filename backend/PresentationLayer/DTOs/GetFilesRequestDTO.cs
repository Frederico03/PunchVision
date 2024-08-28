using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace PresentationLayer.DTOs
{
    public class GetFileRequestDTO
    {
        public string BucketName { get; set; }
        public string? Prefix { get; set; }
    }
}

