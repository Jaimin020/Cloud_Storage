using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Client.Views
{
    public partial class Download : System.Web.UI.Page
    {
        Cloud_CRUD_Service.OperationsClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new Cloud_CRUD_Service.OperationsClient();
            int id = int.Parse(Request.QueryString["id"].ToString());
            //int id = 4;
            var f = client.Read_File(id);
            Response.Buffer = true;
            //Response.Expires = 0;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Type", "application/octet-stream");
            //Response.AddHeader("Content-Length", btFile.Length.ToString);
            Response.AddHeader("Content-Disposition", "attachment;filename=" + f.Name+"."+f.Extention);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(f.d);
            Response.End();
        }
    }
}