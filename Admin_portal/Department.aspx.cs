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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        public static int did;
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
           
                dgv_data();
            Session["page_name"] = "Department";

        }

        protected void btn_sub_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                String inst = "INSERT INTO Department(d_name,Stream,Yearly_fees) Values('" + tb_dept_name.Text + "','" + tb_stream.Text + "','" + tb_yearly_fees.Text + "');";
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
        protected void dgv_data()
        {
            try
            {
                dbconn();
                cmd = new SqlCommand("select * from Department;", conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dgv_department.DataSource = ds;
                dgv_department.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void dgv_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rw = dgv_department.SelectedRow;
            did = Convert.ToInt32(rw.Cells[1].Text);
            tb_dept_name.Text = rw.Cells[2].Text;
            tb_stream.Text = rw.Cells[3].Text;
            tb_yearly_fees.Text = rw.Cells[4].Text;
        }

        protected void btn_up_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                String update = "UPDATE Department SET d_name = '" + tb_dept_name.Text + "',Stream = '" + tb_stream.Text + "',Yearly_fees = '" + tb_yearly_fees.Text + "' WHERE d_id = " + did + ";";
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

        
        protected void dgv_user_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow r = dgv_department.Rows[e.RowIndex];
            del = Convert.ToInt32(r.Cells[1].Text);
            try
            {
                dbconn();
                String de = "DELETE FROM Department WHERE d_id = " + del + ";";
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