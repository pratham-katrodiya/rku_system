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

    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        public static int fs_id;
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
            
                fnDepartmentBind();
                dgv_data();
            Session["page_name"] = "Fee Structure";

        }

        protected void btn_sub_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                String inst = "INSERT INTO Fee_Structure(d_id,sem,year,fee_amount) Values('" + ddl_dep.SelectedValue + "','" + ddl_Sem.SelectedValue + "','" + txt_Year.Text + "','" + txt_Feeamount.Text + "');";
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
                ddl_dep.DataSource = ds;
                ddl_dep.DataTextField = "d_name";
                ddl_dep.DataValueField = "d_id";
                ddl_dep.DataBind();
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
                cmd = new SqlCommand("select f.FS_id,d.d_name as Department,f.sem,f.year,f.fee_amount from Fee_Structure f,Department d WHERE f.d_id = d.d_id;", conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dgv_fee_structure.DataSource = ds;
                dgv_fee_structure.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }



        protected void dgv_fee_structure_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rw = dgv_fee_structure.SelectedRow;
            fs_id = Convert.ToInt32(rw.Cells[1].Text);
            txt_Year.Text = rw.Cells[4].Text;
            txt_Feeamount.Text = rw.Cells[5].Text;
        }

        protected void btn_up_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                String update = "UPDATE Fee_Structure SET year = '" + txt_Year.Text + "',fee_amount='" + txt_Feeamount.Text + "' WHERE FS_Id = " + fs_id + ";";
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
        protected void dgv_fee_structure_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow r = dgv_fee_structure.Rows[e.RowIndex];
            del = Convert.ToInt32(r.Cells[1].Text);
            try
            {
                dbconn();
                String de = "DELETE FROM Fee_Structure WHERE FS_Id = " + del + ";";
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