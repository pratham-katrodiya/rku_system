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

namespace University_Management_System.Admin_portal
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        public static int cid;
        public static int del;
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
            }
                dgv_data();
            Session["page_name"] = "Colleges";
        }

        protected void btn_sub_Click(object sender, EventArgs e)
        {
            //Response.Write(ddl_dep.SelectedValue);
            try
            {
                dbconn();
                String inst = "INSERT INTO Colleges_list(Colleges_name,d_id) Values('" + tb_college_name.Text + "'," + ddl_dep.SelectedValue + ");";
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
        protected void dgv_data()
        {
            try
            {
                dbconn();
                cmd = new SqlCommand("select c.c_id as College_Id,c.Colleges_name,d.d_name as Department  from Colleges_list c,Department d WHERE c.d_id=d.d_id;", conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dgv_Colleges.DataSource = ds;
                dgv_Colleges.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void dgv_college_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rw = dgv_Colleges.SelectedRow;
            cid = Convert.ToInt32(rw.Cells[1].Text);
            tb_college_name.Text = rw.Cells[2].Text;
        }


        protected void btn_up_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                String update = "UPDATE Colleges_list SET Colleges_name = '" + tb_college_name.Text + "' WHERE c_id = " + cid + ";";
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

        protected void dgv_college_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow r = dgv_Colleges.Rows[e.RowIndex];
            del = Convert.ToInt32(r.Cells[1].Text);
            try
            {
                dbconn();
                String de = "DELETE FROM Colleges_list WHERE c_id = " + del + ";";
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