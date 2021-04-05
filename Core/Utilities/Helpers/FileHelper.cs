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
            File.Move(tempPath, fileNewPath.path2);
            return fileNewPath.path;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(Environment.CurrentDirectory + @"\wwwroot\CarImages\" + path);
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
            
            return new SuccessResult();
        }
        public static string Update(string updatedPath, IFormFile file)
        {
            File.Delete(Environment.CurrentDirectory + @"\wwwroot\CarImages\" + updatedPath);
            var result = Add(file);
            return result;
        }

        public static (string path,string path2) newPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            var fileExtension = fileInfo.Extension;

            var currentLocation = Environment.CurrentDirectory + @"\wwwroot\CarImages\";
            var path = Guid.NewGuid().ToString() + fileExtension;
            var path2 = currentLocation + path;
            return (path,path2);
        } 

    }
}
