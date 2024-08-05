using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace University_Management_System.Admin_portal
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        public static int F_id;
        public static int fid;
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
            if (!Page.IsPostBack)
            {
                fnDepartmentBind();
                fnCourseBind();
            }
                dgv_data();
            Session["page_name"] = "Faculty";
        }

        protected void btn_sub_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                String inst = "INSERT INTO Faculty_detail(Faculty_Name,d_id,course_code) Values('" + tb_fac_name.Text + "'," + ddl_dep.SelectedValue + ",'" + ddl_course_code.SelectedValue + "');";
                Response.Write(inst);
                cmd = new SqlCommand(inst, conn);
                int isint = cmd.ExecuteNonQuery();
                if (isint > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Inserted'); ", true);

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('Insert'); ", true);
                }   

                dgv_data();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void fnDepartmentBind()
        {
            try
            {
                dbconn();
                String sql = "SELECT d_id,d_name FROM Department";
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ddl_dep.DataSource = ds;
                ddl_dep.DataTextField = "d_name";
                ddl_dep.DataValueField = "d_id";
                ddl_dep.DataBind();
                ddl_dep.Items.Insert(0, "--Select Department--");

                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void fnCourseBind()
        {
            try
            {
                dbconn();
                String sql = "SELECT course_code,Course_Name FROM Course";
                cmd = new SqlCommand(sql, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ddl_course_code.DataSource = ds;
                ddl_course_code.DataTextField = "Course_Name";
                ddl_course_code.DataValueField = "course_code";
                ddl_course_code.DataBind();
                ddl_course_code.Items.Insert(0, "--Select Course--");
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void dgv_data()
        {
            try
            {
                dbconn();
                cmd = new SqlCommand("select f.F_ID,f.Faculty_Name,d.d_name as Department,f.course_code from Faculty_detail f,Department d WHERE f.d_id  = d.d_id;", conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dgv_faculty.DataSource = ds;
                dgv_faculty.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void dgv_Faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
                GridViewRow rw = dgv_faculty.SelectedRow;
                F_id = Convert.ToInt32(rw.Cells[1].Text);
                tb_fac_name.Text = rw.Cells[2].Text;
            
        }

        protected void btn_up_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                String update = "UPDATE Faculty_detail SET Faculty_Name = '" + tb_fac_name.Text + "' WHERE F_id = " + F_id + ";";
                //Response.Write(update);
                cmd = new SqlCommand(update, conn);
                int isupdate = cmd.ExecuteNonQuery();
                if (isupdate > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Updated'); ", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('Update'); ", true);
                }
                dgv_data();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void dgv_faculty_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow r = dgv_faculty.Rows[e.RowIndex];
            fid = Convert.ToInt32(r.Cells[1].Text);
            try
            {
                dbconn();
                String de = "DELETE FROM Faculty_detail WHERE F_id = " + fid + ";";
                cmd = new SqlCommand(de, conn);
                int isDel = cmd.ExecuteNonQuery();
                if (isDel > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Deleted'); ", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('Delete'); ", true);
                }

                dgv_data();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}