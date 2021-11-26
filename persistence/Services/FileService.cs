using application.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace persistence.Services
{
    public class FileService : IFileService
    {
        public async Task<string> AddFileAsync(IFormFile file, string folderName)
        {
            var path = Path.GetFullPath($"wwwroot/" + folderName);
        //    string imgext = Path.GetExtension()
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var filePath = $"/{DateTime.Now.Ticks}_{file.FileName}";
            await using var fs = new FileStream(path + filePath, FileMode.Create);
            //var result = CheckFormatFile(file.FileName);
            //if (result == false) return null;
            await file.CopyToAsync(fs);
            return $"/{folderName}{filePath}";
        }

        //public bool CheckFormatFile(string filename)
        //{
        //    if(!filename.Contains(".png") || !filename.Contains(".jpg"))
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public void DeleteFile(string folderName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/" + folderName);
            if(File.Exists(path))
                File.Delete(path);
           // throw new NotImplementedException();
        }
    }
}
