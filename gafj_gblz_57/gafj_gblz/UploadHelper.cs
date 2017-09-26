using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace gafj_gblz
{
    public class UploadHelper
    {
        public string fileSaveAs(HttpPostedFile postedFile, string dirName)
        {
            try
            {
                string fileExt = Path.GetExtension(postedFile.FileName).ToLower();//文件扩展名，不含“.”
                int fileSize = postedFile.ContentLength; //获得文件大小，以字节为单位
                string fileName = Path.GetFileName(postedFile.FileName);//取得文件原名
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + fileExt;//随机生成新的文件名
                string upLoadPath = "/Content/Upload/" + dirName + "/"; //上传目录相对路径

                string fullUpLoadPath = HttpContext.Current.Server.MapPath(upLoadPath); //上传目录的物理路径
                string newFilePath = upLoadPath + newFileName; //上传后的路径

                //检查文件扩展名是否合法
                if (!CheckFileExt(dirName))
                {
                    return "{\"status\": 0, \"msg\": \"不允许上传" + fileExt + "类型的文件！\"}";
                }
                //检查文件大小是否合法
                if (!CheckFileSize(fileSize))
                {
                    return "{\"status\": 0, \"msg\": \"文件超过限制的大小啦！\"}";
                }
                //检查上传的物理路径是否存在，不存在则创建
                if (!Directory.Exists(fullUpLoadPath)) { Directory.CreateDirectory(fullUpLoadPath); }

                //保存文件
                postedFile.SaveAs(fullUpLoadPath + newFileName);

                //处理完毕，返回JOSN格式的文件信息
                return "{\"status\": 1, \"msg\": \"上传文件成功！\", \"name\": \""
                    + fileName + "\", \"path\": \"" + newFilePath + "\", \"size\": " + fileSize + ", \"ext\": \"" + fileExt + "\"}";
            }
            catch
            {
                return "{\"status\": 0, \"msg\": \"上传过程中发生意外错误！\"}";
            }
        }


        public string cameraSaveAs(string dirName)
        {
            string result = string.Empty;
            try
            {
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";//随机生成新的文件名
                string upLoadPath = "/Content/Upload/" + dirName + "/"; //上传目录相对路径

                string fullUpLoadPath = HttpContext.Current.Server.MapPath(upLoadPath); //上传目录的物理路径
                string newFilePath = upLoadPath + newFileName; //上传后的路径

                //检查上传的物理路径是否存在，不存在则创建
                if (!Directory.Exists(fullUpLoadPath)) { Directory.CreateDirectory(fullUpLoadPath); }

                Stream s = HttpContext.Current.Request.InputStream;
                byte[] buffer = new byte[s.Length];
                s.Read(buffer, 0, buffer.Length);
                MemoryStream ms = new MemoryStream(buffer);
                FileStream fs = new FileStream(fullUpLoadPath + newFileName, FileMode.Create, FileAccess.ReadWrite);
                ms.WriteTo(fs);

                fs.Close();
                ms.Close();
                s.Close();
                result = "fileurl=" + newFilePath;
            }
            catch
            {
                result = "fileurl=error";
            }
            return result;
        }


        public string fileDalete(string path)
        {
            try
            {
                string fullFilePath = HttpContext.Current.Server.MapPath(path);//物理完整路径
                //删除原文件
                if (File.Exists(fullFilePath))
                {
                    File.Delete(fullFilePath);
                }

                return "{\"status\": 1, \"msg\": \"文件删除成功！\"}";
            }
            catch
            {
                return "{\"status\": 0, \"msg\": \"删除过程中发生意外错误！\"}";
            }
        }

        #region 私有方法



        /// <summary>
        /// 检查是否为合法的上传文件
        /// </summary>
        private bool CheckFileExt(string _dirName)
        {
            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("image", "gif,jpg,jpeg,png,bmp");
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
            extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz");
            if (!extTable.ContainsKey(_dirName))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检查文件大小是否合法
        /// </summary>
        /// <param name="_fileSize">文件大小(B)</param>
        private bool CheckFileSize(int _fileSize)
        {
            int maxSize = 1000000;
            //判断是否为图片文件
            if (_fileSize > 0 && _fileSize > maxSize * 1024)
            {
                return false;
            }
            return true;
        }
        #endregion


        public bool cropSaveAs(string dirName, string fileName, string newFileName, int maxWidth, int maxHeight, int cropWidth, int cropHeight, int X, int Y)
        {
            string fileExt = Utils.GetFileExt(fileName); //文件扩展名，不含“.”
            if (!CheckFileExt(dirName))
            {
                return false;
            }
            string newFileDir = Utils.GetMapPath(newFileName.Substring(0, newFileName.LastIndexOf(@"/") + 1));
            //检查是否有该路径，没有则创建
            if (!Directory.Exists(newFileDir))
            {
                Directory.CreateDirectory(newFileDir);
            }
            try
            {
                string fileFullPath = Utils.GetMapPath(fileName);
                string toFileFullPath = Utils.GetMapPath(newFileName);
                return Utils.MakeThumbnailImage(fileFullPath, toFileFullPath, 180, 180, cropWidth, cropHeight, X, Y);
            }
            catch
            {
                return false;
            }
        }

    }
}