using System;
using System.Configuration;
using System.IO;

namespace MyBlog.Common.Helpers
{
    public class FileHelper
    {
        public static string GetFileUploadPath
        {
            get { return ConfigurationManager.AppSettings["UploadPath"]; }
        }

        public static string GetFilePath(string fileName)
        {
            var targetFolder = System.Web.Hosting.HostingEnvironment.MapPath(GetFileUploadPath);
            var targetPath = Path.Combine(targetFolder, fileName);
            if (!File.Exists(targetPath))
                return targetPath;

            var name = Path.GetFileNameWithoutExtension(fileName);
            name = name + "-" + (new Random()).Next();
            var extension = Path.GetExtension(fileName);
            name = name + extension;
            targetPath = GetFilePath(name);

            return targetPath;
        }
    }
}