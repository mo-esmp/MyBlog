using System;
using System.IO;

namespace MyBlog.Infrastructure.Helpers
{
    public class FileHelper
    {
        public static string GetFilePathFromConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static string GetFilePath(string fileName, string filePath)
        {
            var targetFolder = System.Web.Hosting.HostingEnvironment.MapPath(filePath);
            if (targetFolder == null)
                throw new DirectoryNotFoundException();

            var targetPath = Path.Combine(targetFolder, fileName);
            if (!File.Exists(targetPath))
                return targetPath;

            var name = Path.GetFileNameWithoutExtension(fileName);
            name = name + "-" + (new Random()).Next();
            var extension = Path.GetExtension(fileName);
            name = name + extension;
            targetPath = GetFilePath(name, filePath);

            return targetPath;
        }
    }
}