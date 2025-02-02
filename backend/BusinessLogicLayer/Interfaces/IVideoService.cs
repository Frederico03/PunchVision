﻿using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IVideoService
    {
        Task UploadVideoAsync(string fileName, string URL, string size, int userId);
    }
}
