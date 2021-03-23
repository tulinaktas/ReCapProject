using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var tempPath = Path.GetTempFileName();
            if (file.Length>0)
            {
                using (FileStream fileStream = new FileStream(tempPath,FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            var fileNewPath = newPath(file);
            File.Move(tempPath, fileNewPath);
            return fileNewPath;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
            
            return new SuccessResult();
        }
        public static string Update(string updatedPath, IFormFile file)
        {
            var path = newPath(file).ToString(); 
            if (updatedPath.Length >0)
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            File.Delete(updatedPath);
            return path;
        }

        public static string newPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            var fileExtension = fileInfo.Extension;

            var currentLocation = Environment.CurrentDirectory + @"\CarImages\";
            var path = Guid.NewGuid().ToString() + fileExtension;
            return currentLocation + path;
        } 

    }
}
