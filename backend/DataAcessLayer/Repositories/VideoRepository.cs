using DataAcessLayer.Data;
using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly ApplicationDbContext _context;

        public VideoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task UploadVideoAsync(VideoEntity video)
        {
            await _context.tb_video.AddAsync(video);
            await _context.SaveChangesAsync();
        }
    }
}
