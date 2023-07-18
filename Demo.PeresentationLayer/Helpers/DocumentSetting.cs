using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Demo.PeresentationLayer.Helpers
{
    public static class DocumentSetting
    {
        public static string UploadFile(IFormFile file , string FolderName )
        {
            string folderpath = Path.Combine(Directory.GetCurrentDirectory(), "www.root//files", FolderName);
            string fileName = $"{Guid.NewGuid()}{file.FileName}";
            string filePath = Path.Combine(folderpath, fileName);
            using var fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);
            return fileName;



        }
    }
}
