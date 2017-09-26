using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
 

namespace gafj_gblz.Utility
{
    /// <summary>
    /// Summary description for Upload_Ajax
    /// </summary>
    public class Upload_Ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            //取得处事类型
            string action = context.Request.QueryString["Action"];

            switch (action)
            {
                case "ManagerFile": //管理文件
                    ManagerFile(context);
                    break;
                //case "EditorFile": //编辑器文件
                //    EditorFile(context);
                //    break;
                case "DeleteFile": //删除文件
                    DeleteFile(context);
                    break;
                case "CameraFile": //摄像头文件
                    CameraFile(context);
                    break;
                case "UpFilePath":
                    UpFilePath(context);
                    break;
                default: //普通上传
                    UpLoadFile(context);
                    break;
            }
        }
        private void UpFilePath(HttpContext context)
        {
            string _upfilepath = context.Request.QueryString["UploadFile"]; //取得上传的对象名称
            HttpPostedFile _upfile = null;
            try
            {
                _upfile = context.Request.Files[_upfilepath];
            }
            catch (HttpException)
            {
                context.Response.Write("{msg: 0, msbox: \"文件超过限制的大小啦！\"}");
                return;
            }
            if (_upfile == null)
            {
                context.Response.Write("{msg: 0, msbox: \"请选择要上传文件！\"}");
                return;
            }

            UploadHelper upload = new UploadHelper();
            //string msg = upload.fileSaveAs(_upfile, _isthumbnail, _iswater);
            string msg = upload.fileSaveAs(_upfile, "image");//Images
            //删除已存在的旧文件
            //if (!string.IsNullOrEmpty(_delfile))
            //{
            //    upload.fileDalete(_delfile);
            //}
            //返回成功信息
            context.Response.Write(msg);
            context.Response.End();

            //UploadHelper upload = new UploadHelper();
            //string msgandmsbox = upload.fileSaveAs(_upfile, "file");
            //string msg = msgandmsbox.Split(',')[0].Split(':')[1];
            //if (msg.Trim() == "1")
            //{
            //    string resultdata = "";
            //    string filePath = GetMapPath(msgandmsbox.Split(',')[3].Split(':')[1].Replace("\\", "").Replace("\"", "").Replace("}", "").Trim());
            //    DataSet PersonData = ImportExcel(filePath, ref resultdata);
            //    if (_upfilepath == "FileUpload1")
            //    {
            //        //resultdata = new CarController().Importanjian(PersonData, filePath);
            //        resultdata = new PropertyController().Into(PersonData, filePath);
            //    }
            //    //else if (_upfilepath == "FileUpload2")
            //    //{
            //    //    resultdata = new InsuranceController().Importanjian(PersonData, filePath);
            //    //}
            //    //else if (_upfilepath == "FileUpload3")
            //    //{
            //    //    resultdata = new AccidentController().Importanjian(PersonData, filePath);
            //    //}
            //    context.Response.Write(resultdata);
            //    return;
            //}

            //context.Response.Write(msgandmsbox);
            //context.Response.End();
        }

        public static string GetMapPath(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        #region 浏览文件处理=====================================
        private void ManagerFile(HttpContext context)
        {
            String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);

            //根目录路径，相对路径
            String rootPath = "../upload/";
            //根目录URL，可以指定绝对路径，比如 http://www.yoursite.com/attached/
            String rootUrl = aspxUrl + "../upload/";
            //图片扩展名
            String fileTypes = "gif,jpg,jpeg,png,bmp";

            String currentPath = "";
            String currentUrl = "";
            String currentDirPath = "";
            String moveupDirPath = "";

            String dirPath = context.Server.MapPath(rootPath);
            String dirName = context.Request.QueryString["dir"];

            //根据path参数，设置各路径和URL
            String path = context.Request.QueryString["path"];
            path = String.IsNullOrEmpty(path) ? "" : path;
            if (path == "")
            {
                currentPath = dirPath;
                currentUrl = rootUrl;
                currentDirPath = "";
                moveupDirPath = "";
            }
            else
            {
                currentPath = dirPath + path;
                currentUrl = rootUrl + path;
                currentDirPath = path;
                moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
            }

            //排序形式，name or size or type
            String order = context.Request.QueryString["order"];
            order = String.IsNullOrEmpty(order) ? "" : order.ToLower();

            //不允许使用..移动到上一级目录
            if (Regex.IsMatch(path, @"\.\."))
            {
                context.Response.Write("Access is not allowed.");
                context.Response.End();
            }
            //最后一个字符不是/
            if (path != "" && !path.EndsWith("/"))
            {
                context.Response.Write("Parameter is not valid.");
                context.Response.End();
            }
            //目录不存在或不是目录
            if (!Directory.Exists(currentPath))
            {
                context.Response.Write("Directory does not exist.");
                context.Response.End();
            }

            //遍历目录取得文件信息
            string[] dirList = Directory.GetDirectories(currentPath);
            string[] fileList = Directory.GetFiles(currentPath);

            switch (order)
            {
                case "size":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new SizeSorter());
                    break;
                case "type":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new TypeSorter());
                    break;
                case "name":
                default:
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new NameSorter());
                    break;
            }

            Hashtable result = new Hashtable();
            result["moveup_dir_path"] = moveupDirPath;
            result["current_dir_path"] = currentDirPath;
            result["current_url"] = currentUrl;
            result["total_count"] = dirList.Length + fileList.Length;
            List<Hashtable> dirFileList = new List<Hashtable>();
            result["file_list"] = dirFileList;
            for (int i = 0; i < dirList.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(dirList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = true;
                hash["has_file"] = (dir.GetFileSystemInfos().Length > 0);
                hash["filesize"] = 0;
                hash["is_photo"] = false;
                hash["filetype"] = "";
                hash["filename"] = dir.Name;
                hash["datetime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            for (int i = 0; i < fileList.Length; i++)
            {
                FileInfo file = new FileInfo(fileList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = false;
                hash["has_file"] = false;
                hash["filesize"] = file.Length;
                hash["is_photo"] = (Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0);
                hash["filetype"] = file.Extension.Substring(1);
                hash["filename"] = file.Name;
                hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            context.Response.AddHeader("Content-Type", "application/json; charset=UTF-8");
          //  context.Response.Write(JsonMapper.ToJson(result));
            context.Response.End();
        }

        #region Helper
        public class NameSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.FullName.CompareTo(yInfo.FullName);
            }
        }

        public class SizeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.Length.CompareTo(yInfo.Length);
            }
        }

        public class TypeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.Extension.CompareTo(yInfo.Extension);
            }
        }
        #endregion
        #endregion

      
        #region 删除文件处理===================================
        private void DeleteFile(HttpContext context)
        {
            string _refilepath = context.Request.QueryString["ReFilePath"]; //取得返回的对象名称
            string _delfile = context.Request.Form[_refilepath];

            UploadHelper upload = new UploadHelper();
            string remsg = upload.fileDalete(_delfile);
            //返回成功信息
            context.Response.Write(remsg);
            context.Response.End();
        }
        #endregion

        #region 摄像头文件处理===================================
        private void CameraFile(HttpContext context)
        {
            UploadHelper upload = new UploadHelper();
            string remsg = upload.cameraSaveAs("Images");
            context.Response.Write(remsg);
            context.Response.End();
        }
        #endregion

        #region 上传文件处理===================================
        //private void UpLoadFile(HttpContext context)
        //{
        //    string _refilepath = context.Request.QueryString["ReFilePath"]; //取得返回的对象名称
        //    string _upfilepath = context.Request.QueryString["UpFilePath"]; //取得上传的对象名称
        //    string _delfile = context.Request.Form[_refilepath];
        //    HttpPostedFile _upfile = context.Request.Files[_upfilepath];

        //    UploadHelper upload = new UploadHelper();
        //    string remsg = upload.fileSaveAs(_upfile, "image");
        //    //删除已存在的旧文件
        //    upload.fileDalete(_delfile);
        //    //返回成功信息
        //    context.Response.Write(remsg);
        //    context.Response.End();
        //}
        #endregion

        private void UpLoadFile(HttpContext context)
        {
            string _delfile = context.Request.QueryString["DelFilePath"];
            HttpPostedFile _upfile = context.Request.Files["Filedata"];
            bool _iswater = false; //默认不打水印
            bool _isthumbnail = false; //默认不生成缩略图

            if (context.Request.QueryString["IsWater"] == "1")
                _iswater = true;
            if (context.Request.QueryString["IsThumbnail"] == "1")
                _isthumbnail = true;
            if (_upfile == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"请选择要上传文件！\"}");
                return;
            }
            UploadHelper upload = new UploadHelper();
            //string msg = upload.fileSaveAs(_upfile, _isthumbnail, _iswater);
            string msg = upload.fileSaveAs(_upfile, "Images");
            //删除已存在的旧文件
            if (!string.IsNullOrEmpty(_delfile))
            {
                upload.fileDalete(_delfile);
            }
            //返回成功信息
            context.Response.Write(msg);
            context.Response.End();
        }







        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}