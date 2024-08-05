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
    public partial class res_detail : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Ad_page_name"] = "Student Detail";
            fn_data();
        }
        protected void dbconn()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        protected void fn_data()
        {
            try
            {
                dbconn();
                string sql = "SELECT Ssc_per,Hsc_per,First_name,Middle_name,Last_name,birth_date,Address,mobile_number,Email,Gender FROM Registration WHERE Email = '" + Session["std_em"] +"';";
                cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txt_ssc.Text = rdr[0].ToString();
                    txt_hsc.Text = rdr[1].ToString();
                    txt_fname.Text = rdr[2].ToString();
                    txt_mname.Text = rdr[3].ToString();
                    txt_lname.Text = rdr[4].ToString();
                    txt_birth.Text = rdr[5].ToString();
                    txt_add.Text = rdr[6].ToString();
                    txt_mobile.Text = rdr[7].ToString();
                    txt_email.Text = rdr[8].ToString();
                    txt_gender.Text = rdr[9].ToString();
                }
            }catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    
    }
}