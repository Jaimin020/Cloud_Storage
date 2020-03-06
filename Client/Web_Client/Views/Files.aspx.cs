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
    public partial class Files : System.Web.UI.Page
    {
        Cloud_CRUD_Service.OperationsClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new Cloud_CRUD_Service.OperationsClient();
            var u = client.getUser((int)Session["id"]);
            Label2.Text = u.name;
            create_Table();
            
        }
        void create_Table()
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Name", typeof(string)),
                    new DataColumn("Extention", typeof(string)),
                    new DataColumn("Operation",typeof(string)) });

                var list = client.Fetch_All_Files((int)Session["Id"]);
                foreach (var i in list)
                {
                    dt.Rows.Add(i.Name, i.Extention, "<a onclick=Download(" + i.Id + ")>Download</ a >"+" | "+ "<a onclick=Remove(" + i.Id + ")>Remove</ a >");
                }

                StringBuilder sb = new StringBuilder();
                //Table start.
                sb.Append("<div id='t'><table align='center' style='width: 80%' cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:Arial'>");

                //Adding HeaderRow.
                sb.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + column.ColumnName + "</th>");
                }
                sb.Append("</tr>");


                //Adding DataRow.
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<td style='width:100px;border: 1px solid #ccc'>" + row[column.ColumnName].ToString() + "</td>");
                    }
                    sb.Append("</tr>");
                }

                //Table end.
                sb.Append("</table></div>");
                ltTable.Text = sb.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            byte[] d = FileUpload1.FileBytes;
            string fname = FileUpload1.FileName;
            if (d.Length < 20971520)
            {
                string name = "", etn = "";
                int f = 0;
                foreach (char i in fname)
                {
                    if (i == '.')
                    {
                        f = 1;
                        continue;
                    }
                    if (f == 0)
                    {
                        name += i;
                    }
                    else
                    {
                        etn += i;
                    }
                }

                client.Add_File(name, etn, d, (int)Session["Id"]);
                create_Table();
            }
            else
            {
                Label3.Text= "*Please Enter a File < 20MB";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}