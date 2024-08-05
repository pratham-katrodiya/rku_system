using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rku_system.Admission_portal
{
    public partial class Std_Login : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
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

                String em = tb_email.Text;
                String pass = Password.Text;
                /*Response.Write("select * from login where user_name='" + user_name + "' AND Password = '" + pass + "';");*/
                dbconn();
                cmd = new SqlCommand("select count(*) from Registration where Email ='" + em + "' AND Password = '" + pass + "';", conn);
                Response.Write("select count(*) from Registration where Email ='" + em + "' AND Password = '" + pass + "';");
                int dr = (int)cmd.ExecuteScalar();
                if (dr > 0)
                {
                    Session["std_em"] = em;
                    Session["student"] = true;
                    conn.Close();
                    Response.Redirect("~/Admission_portal/res_detail.aspx");
                    
                }
                else
                {
                    conn.Close();
                    Response.Write("<script LANGUAGE='JavaScript' > alert('Invalid User Name & Password.')</script>");
                    //Response.Redirect(Request.RawUrl);

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}