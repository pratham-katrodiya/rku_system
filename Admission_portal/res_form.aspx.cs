using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rku_system.Admission_portal
{
    public partial class res_form : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        public static Boolean ath = false;
        Sender s = new Sender();

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
            if (!IsPostBack)
            {
                fnStreamBind();
            }
            
        }

        protected void btn_otp_Click(object sender, EventArgs e)
        {
           
            s.sendotp(txt_email.Text);
            Response.Write(txt_email.Text);
            Response.Write("<script>alert('Otp send.');</script>");
            lbl_otp.Visible = true;
            txt_otp.Visible = true;
            lbl_category.Visible = true;
            ddl_category.Visible = true;
            lbl_gender.Visible = true;
            rdl_gender.Visible = true;
            lbl_pass.Visible = true;
            txt_pass.Visible = true;
            btn_submit.Visible = true;
            btn_otp.Text = "ReSend OTP";
        }

        protected void fnDepartmentBind()
        {
            try
            {
                dbconn();
                String sql = "SELECT d_id,d_name FROM Department WHERE Stream='" + ddl_stream.SelectedValue + "'";
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ddl_dept.DataSource = ds;
                ddl_dept.DataTextField = "d_name";
                ddl_dept.DataValueField = "d_id";
                ddl_dept.DataBind();
                ddl_dept.Items.Insert(0, "-- Select Department --");
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void fnStreamBind()
        {
            try
            {
                dbconn();
                String sql = "SELECT Stream FROM Department GROUP BY Stream";
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ddl_stream.DataSource = ds;
                ddl_stream.DataValueField = "Stream";
                ddl_stream.DataBind();
                ddl_stream.Items.Insert(0, "-- Select Stream --");
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (txt_otp.Text == s.get_otp())
            {
                ath = true;
                Response.Write("verify Successfuly");
            }
            else
            {
                Response.Write("otp is incorrect");
            }
            if (ath)
            {
                try
                {
                    dbconn();
                    string today = DateTime.Now.ToString("MM/dd/yyyy");
                    String inst = "INSERT INTO Registration(R_date,stream,d_id,First_name,Middle_name,Last_name,birth_date,Category,Gender,mobile_number,Email,Ssc_per,Hsc_per,Address,Password,Status) Values('"+today+"','" + ddl_stream.SelectedValue + "'," + ddl_dept.SelectedValue + ",'" + txt_fname.Text + "','" + txt_mname.Text + "','" + txt_lname.Text + "','" + txt_birth.Text + "','" + ddl_category.SelectedValue + "','" + rdl_gender.SelectedValue + "'," + txt_mobile.Text + ",'" + txt_email.Text + "'," + txt_ssc.Text + "," + txt_hsc.Text + ",'" + txt_add.Text + "','"+txt_pass.Text+"','Pending');";
                    //Response.Write(inst);
                    cmd = new SqlCommand(inst, conn);
                    int isint = cmd.ExecuteNonQuery();
                    
                    if (isint > 0)
                    {
                        string path = "~/Admission_portal/Uploades/" + txt_mobile.Text;
                        //System.IO.Directory.CreateDirectory(MapPath(path));
                        
                        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Inserted'); ", true);
                        Response.Redirect("S_login.aspx");

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('Insert'); ", true);
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
            {
                Response.Write("fail to ath");
            }
        }

        protected void btn_verify_Click(object sender, EventArgs e)
        {
            
        }

        protected void ddl_stream_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnDepartmentBind();
        }
    }
}