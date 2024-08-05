using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace rku_system.Admission_portal
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;

        protected void dbconn()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Ad_page_name"] = "Upload Files";
        }

        protected void btn_up_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                string path = "~/Admission_portal/Uploads/";
                string p_image = path + fu_pi.FileName;
                string signature = path+ fu_sign.FileName;
                string ssc = path+ fu_ssc.FileName;
                string hsc = path+ fu_hsc.FileName;
                String update = "UPDATE Registration SET p_img = '" + p_image + "',sign='"+ signature +"',Ssc_res_file='"+ssc+ "',Hsc_res_file='"+hsc+"' WHERE Email = '" + Session["std_em"] + "';";
                //Response.Write(update);
                cmd = new SqlCommand(update, conn);
                int isupdate = cmd.ExecuteNonQuery();
                fu_pi.SaveAs(Server.MapPath(p_image));
                fu_sign.SaveAs(Server.MapPath(signature));
                fu_ssc.SaveAs(Server.MapPath(ssc));
                fu_hsc.SaveAs(Server.MapPath(hsc));
                if (isupdate > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('File Uploaded'); ", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('File Upload'); ", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}