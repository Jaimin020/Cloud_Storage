using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Client.Views
{
    public partial class Remove : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cloud_CRUD_Service.OperationsClient client;
            client = new Cloud_CRUD_Service.OperationsClient();
            int id = int.Parse(Request.QueryString["id"].ToString());
            int c=client.Remove_File(id);
            if(c!=1)
            {
                Response.Redirect("Error.aspx");
            }
            Response.Redirect("Files.aspx");
        }
    }
}