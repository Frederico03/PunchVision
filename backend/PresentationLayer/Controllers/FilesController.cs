using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Interfaces;
using PresentationLayer.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Amazon.S3.Model;
using BusinessLogicLayer.Models;


namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : Controller
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IFileService _fileService;
        public FilesController(IAmazonS3 s3Client, IFileService fileService)
        {
            _s3Client = s3Client;
            _fileService = fileService; 
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFileAsync(FileRequestDTO fileRequest)
        {
            try
            {
                var result = await _fileService.UploadFileAsync(fileRequest.File, fileRequest.BucketName, fileRequest.Prefix);

                if (result)
                {
                    return Ok(new
                    {
                        Status = true,
                        Message = "File uploaded successfully"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Status = false,
                        Message = "Failed to upload file"
                    });
                }
            }
            catch (Exception ex) {

                return BadRequest(new
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllFilesAsync(string bucketName, string? prefix)
        {
            try
            {
                var result = await _fileService.GetAllFilesAsync(bucketName, prefix);

                return Ok(new
                {
                    Status = true,
                    Files = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }
    }
}
