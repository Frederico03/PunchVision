using BusinessLogicLayer.Interfaces;
using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class VideoService : IVideoService 
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task UploadVideoAsync(string fileName, string URL, string size, int userId)
        {

            var entity = new VideoEntity
            {
                FileName = fileName,
                URL = URL,
                Size = size,
                UserId = userId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.MinValue
            };

            await _videoRepository.UploadVideoAsync(entity);

        }
    }
}
