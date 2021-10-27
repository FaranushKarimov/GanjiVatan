using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace application.Services
{
    public interface IFileService
    {
        Task<string> AddFileAsync(IFormFile file, string folderName);
    }
}
