using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PresentationLayer.DTOs;
using BusinessLogicLayer.Services;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost("UploadVideo")]
        public async Task<ActionResult> UploadVideo(VideoRequestDTO videoRequest)
        {
            try
            {
                await _videoService.UploadVideoAsync(videoRequest.FileName, videoRequest.URL, videoRequest.Size, videoRequest.IdUser);

                return Ok(
                    new
                    {
                        Status = true,
                        Message = "Sign up successful"
                    }
                );
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
