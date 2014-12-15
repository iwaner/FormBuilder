using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;

namespace FormBuilder.Common
{
    /// <summary>
    /// uploadFiles 的摘要说明
    /// </summary>
    public class UploadFiles : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string companyName = string.Empty;
            if (context.Request["uploadType"] != null && !string.IsNullOrWhiteSpace(context.Request["uploadType"]))
            {
                companyName = ConfigurationManager.AppSettings["CompanyName"];
            }
            context.Response.Charset = Encoding.UTF8.ToString();
            context.Response.ContentType = "text/html";
            UploadFile(context, companyName);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void UploadFile(HttpContext context,string strCompanyName)
        {
            context.Response.CacheControl = "no-cache";
            string sRpath = FileHelper.GetUploadPath();//@"E:\My Documents\Visual Studio 2008\WebSites\SWFUpload\demos\applicationdemo.net";
            string errorMsg = string.Empty;

            string datedir = DateTime.Now.ToString("yy-MM-dd");
            string updir = sRpath + "\\" + datedir;
            var fileList = new List<string>();
            if (context.Request.Files.Count > 0)
            {
                try
                {

                    for (int j = 0; j < context.Request.Files.Count; j++)
                    {

                        HttpPostedFile uploadFile = context.Request.Files[j];
                        if (context.Request["uploadType"] != null && !string.IsNullOrWhiteSpace(context.Request["uploadType"]))
                        {
                            string strDir = "\\Upload\\Files";
                            string strServcePath = HttpContext.Current.Server.MapPath(strDir);
                            if (!Directory.Exists(strServcePath))
                            {
                                Directory.CreateDirectory(strServcePath);
                            }
                            string fullName = string.Format("{0}\\{1}", strServcePath, uploadFile.FileName);
                            uploadFile.SaveAs(fullName);

                            string msg = "http://" + HttpContext.Current.Request.Url.Authority + "/EventWebsite/" + "/Upload/Files/" + uploadFile.FileName;
                            string res = "{error:'" + errorMsg + "', msg:'" + msg + "'}";
                            context.Response.Write(res);
                            //HttpContext.Current.ApplicationInstance.CompleteRequest();
                        }
                        else
                        {
                            int offset = Convert.ToInt32(context.Request["chunk"]);
                            int total = Convert.ToInt32(context.Request["chunks"]);
                            //文件没有分块
                            string fullname;
                            if (total == 1)
                            {

                                if (uploadFile.ContentLength > 0)
                                {
                                    if (!Directory.Exists(updir))
                                    {
                                        Directory.CreateDirectory(updir);
                                    }
                                    string filename = uploadFile.FileName;
                                    uploadFile.SaveAs(string.Format("{0}\\{1}", updir, filename));
                                    fileList.Add(string.Format("{0}\\{1}", updir, filename));
                                }
                            }
                            else
                            {
                                //文件 分成多块上传
                                fullname = WriteTempFile(uploadFile, offset);
                                if (total - offset == 1)
                                {
                                    //如果是最后一个分块文件 ，则把文件从临时文件夹中移到上传文件 夹中
                                    var fi = new FileInfo(fullname);
                                    string oldFullName = string.Format("{0}\\{1}", updir, uploadFile.FileName);
                                    FileInfo oldFi = new FileInfo(oldFullName);
                                    if (oldFi.Exists)
                                    {
                                        //文件名存在则删除旧文件 
                                        oldFi.Delete();
                                    }
                                    fi.MoveTo(oldFullName);
                                    fileList.Add(oldFullName);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    const string res = "{error:'error',msg:'failed'}";
                    context.Response.Write(res);
                }
                HttpContext.Current.Application.Add("FileList", fileList);
            }
        }
        /// <summary>
        /// 保存临时文件 
        /// </summary>
        /// <param name="uploadFile"></param>
        /// <param name="chunk"></param>
        /// <returns></returns>
        private string WriteTempFile(HttpPostedFile uploadFile, int chunk)
        {

            string tempDir = FileHelper.GetTempPath();
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            string fullName = string.Format("{0}\\{1}.part", tempDir, uploadFile.FileName);
            if (chunk == 0)
            {
                //如果是第一个分块，则直接保存
                uploadFile.SaveAs(fullName);
            }
            else
            {
                //如果是其他分块文件 ，则原来的分块文件，读取流，然后文件最后写入相应的字节
                var fs = new FileStream(fullName, FileMode.Append);
                if (uploadFile.ContentLength > 0)
                {
                    int fileLen = uploadFile.ContentLength;
                    byte[] input = new byte[fileLen];

                    // Initialize the stream.
                    Stream myStream = uploadFile.InputStream;

                    // Read the file into the byte array.
                    myStream.Read(input, 0, fileLen);

                    fs.Write(input, 0, fileLen);
                    fs.Close();
                }
            }
            return fullName;
        }
    }
}