using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eWebEditor9x
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fname = Request.Form["UserName"];

            if (Request.Files.Count > 0)
            {
                HttpPostedFile file = Request.Files.Get(0);
                string folder = Server.MapPath("/upload");
                //自动创建文件夹
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                //防止用户上传非图片文件
                string ext = Path.GetExtension(file.FileName).ToLower();
                if (ext == ".gif"
                    || ext == ".bmp"
                    || ext == ".png"
                    || ext == ".jpg"
                    || ext == ".jpeg")
                {
                    string filePath = Path.Combine(folder, file.FileName);

                    //
                    if(!Directory.Exists(filePath)) file.SaveAs(filePath);
                    //最后将新生成的文件名称发给客户端
                    Response.Write("/upload/" + file.FileName);
                }
            }
        }
    }
}