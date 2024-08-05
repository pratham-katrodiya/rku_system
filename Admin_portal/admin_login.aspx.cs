using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace University_Management_System.Admin_portal
{
    public partial class admin_login : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["admin"] = false;
        }
        protected void dbconn()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        protected void sub_Click(object sender, EventArgs e)
        {
            try
            {

                String user_name = u_name.Text;
                String pass = Password.Text;
                /*Response.Write("select * from login where user_name='" + user_name + "' AND Password = '" + pass + "';");*/
                dbconn();
                cmd = new SqlCommand("select count(*) from Admin_User where User_name='" + user_name + "' AND Password = '" + pass + "';", conn);
                int dr = (int) cmd.ExecuteScalar();
                if (dr>0)
                {
                    Session["user_name"] = user_name;  
                    Session["admin"] = true;
                    conn.Close();
                    Response.Redirect("Dashboard.aspx");   
                }
                else
                {
                    conn.Close();
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Invalid User Name & Password.')</script>");
                    //Response.Redirect(Request.RawUrl);

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}