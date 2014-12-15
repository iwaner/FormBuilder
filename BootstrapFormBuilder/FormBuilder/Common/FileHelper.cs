using System.Configuration;
using System.IO;
using System.Web;

namespace FormBuilder.Common
{
    /// <summary>
    ///FileHelper 的摘要说明
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// 获取上传目录
        /// </summary>
        /// <returns></returns>
        public static string GetUploadPath()
        {
            string path = HttpContext.Current.Server.MapPath("~/");
            string dirname = GetDirName();
            string uploadDir = path + "\\" + dirname;
            CreateDir(uploadDir);
            return uploadDir;
        }
        /// <summary>
        /// 获取临时目录
        /// </summary>
        /// <returns></returns>
        public static string GetTempPath()
        {
            string path = HttpContext.Current.Server.MapPath("~/");
            string dirname = GetTempDirName();
            string uploadDir = path + "\\" + dirname;
            CreateDir(uploadDir);
            return uploadDir;
        }
        private static string GetDirName()
        {
            return ConfigurationManager.AppSettings["uploaddir"];
        }
        private static string GetTempDirName()
        {
            return ConfigurationManager.AppSettings["tempdir"];
        }

        private static void CreateDir(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}