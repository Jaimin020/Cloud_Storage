using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Client.Views
{
    public partial class Register : System.Web.UI.Page
    {
        Cloud_CRUD_Service.OperationsClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new Cloud_CRUD_Service.OperationsClient();
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            client.Register(TextBox1.Text, TextBox3.Text, TextBox2.Text);
            Response.Redirect("Login.aspx");
        }
    }
}