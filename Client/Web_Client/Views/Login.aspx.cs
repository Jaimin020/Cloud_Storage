using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Client.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Cloud_CRUD_Service.OperationsClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new Cloud_CRUD_Service.OperationsClient();
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id;
            id=client.Login(TextBox1.Text,TextBox2.Text);
            if(id!=-1)
            {
                Session["id"] = id;
                Response.Redirect("Files.aspx");
            }
            else
            {
                Label4.Text = "* Please Enter Correct Email and Password";
            }
        }
    }
}