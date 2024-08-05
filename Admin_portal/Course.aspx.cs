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
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        public static string c_code;
        public static string del;
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
                fnDepartmentBind();
            }
            
            dgv_data();
            Session["page_name"] = "Course";
        }

        protected void btn_sub_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                String inst = "INSERT INTO Course(course_code,Course_Name,d_id) Values('"+tb_code.Text+"','" + tb_course_name.Text + "','" + ddl_did.SelectedValue + "');";
                //Response.Write(inst);
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
                ddl_did.DataSource = ds;
                ddl_did.DataTextField = "d_name";
                ddl_did.DataValueField = "d_id";
                ddl_did.DataBind();
                ddl_did.Items.Insert(0, "-- Select Department --");
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
                cmd = new SqlCommand("select c.course_code,c.Course_Name,d.d_name as Department from Course c,Department d WHERE c.d_id = d.d_id;", conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dgv_course.DataSource = ds;
                dgv_course.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void dgv_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rw = dgv_course.SelectedRow;
            c_code = rw.Cells[1].Text;
            tb_course_name.Text = rw.Cells[2].Text;
            
        }

        protected void btn_up_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                String update = "UPDATE Course SET Course_Name = '" + tb_course_name.Text + "' WHERE course_code = " + c_code + ";";
                //Response.Write(update);
                cmd = new SqlCommand(update, conn);
                int isupdate = cmd.ExecuteNonQuery();
                if (isupdate > 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Updated Successfully.')</script>");
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Update Failed.')</script>");
                }
                dgv_data();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void dgv_course_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow r = dgv_course.Rows[e.RowIndex];
            del = r.Cells[1].Text;
            try
            {
                dbconn();
                String de = "DELETE FROM Course WHERE course_code = " + del + ";";
                cmd = new SqlCommand(de, conn);
                int isDel = cmd.ExecuteNonQuery();
                if (isDel > 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Deleted Successfully.')</script>");
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Delete Failed.')</script>");
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