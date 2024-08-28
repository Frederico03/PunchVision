using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Amazon.Runtime.SharedInterfaces;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class FileService: IFileService
    {
        private readonly IAmazonS3 _s3Client;

        public FileService(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }
        
        public async Task<bool> UploadFileAsync(IFormFile file, string bucketName, string? prefix)
        {
            var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);
            if (!bucketExists) return false;
        var request = new PutObjectRequest()
        {
            BucketName = bucketName,
            Key = string.IsNullOrEmpty(prefix) ? file.FileName : $"{prefix?.TrimEnd('/')}/{file.FileName}",
            InputStream = file.OpenReadStream()
        };
            request.Metadata.Add("Content-Type", file.ContentType);
            await _s3Client.PutObjectAsync(request);
            return true;
        }

        public async Task<IEnumerable<S3ObjectModel>> GetAllFilesAsync(string bucketName, string? prefix)
        {
            var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);
            if (!bucketExists) throw new Exception($"Bucket {bucketName} does not exist.");
            var request = new ListObjectsV2Request()
            {
                BucketName = bucketName,
                Prefix = prefix
            };
            var result = await _s3Client.ListObjectsV2Async(request);
            var s3Objects = result.S3Objects.Select(s =>
            {
                var urlRequest = new GetPreSignedUrlRequest()
                {
                    BucketName = bucketName,
                    Key = s.Key,
                    Expires = DateTime.UtcNow.AddMinutes(1)
                };
                return new S3ObjectModel()
                {
                    Name = s.Key.ToString(),
                    PresignedUrl = _s3Client.GetPreSignedURL(urlRequest),
                };
            }).ToList();
            return s3Objects;
        }
    }
}
