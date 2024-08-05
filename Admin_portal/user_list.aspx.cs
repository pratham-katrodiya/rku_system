using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace University_Management_System.Admin_portal
{
    public partial class user_list : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        public static int a_id;
        public static int del;
        protected void dbconn()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        protected void dgv_data()
        {
            try
            {
                dbconn();
                cmd = new SqlCommand("select * from Admin_User;", conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dgv_user.DataSource = ds;
                dgv_user.DataBind();
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            dgv_data();
            Session["page_name"] = "User List";

        }
        

        protected void dgv_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rw = dgv_user.SelectedRow;
            a_id = Convert.ToInt32(rw.Cells[1].Text);
            tb_user_name.Text = rw.Cells[2].Text;
            u_f.Attributes["class"] = "input-group input-group-outline mb-3 focused is-focused";
        }

        protected void btn_sub_Click(object sender, EventArgs e)
        {

            if (tb_user_name.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Fill user'); ", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('go to insert'); ", true);
            }
            int Flag = 1;
            foreach (GridViewRow rw in dgv_user.Rows)
            {
                if (rw.Cells[2].Text == tb_user_name.Text)
                {
                    Flag = 0;

                    break;
                }

                //Response.Write(rw.Cells[2].Text);
            }


            if (Flag == 1)
            {
                try
                {
                    dbconn();
                    String inst = "INSERT INTO Admin_User(User_name,Password,Role) Values('" + tb_user_name.Text + "','" + tb_pass.Text + "','admin');";
                    //Response.Write(inst);
                    cmd = new SqlCommand(inst, conn);
                    int isint = cmd.ExecuteNonQuery();
                    if (isint > 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Inserted'); ", true);
                        //Response.Write("<script>success_msg('Inserted')</script>");
                        //Response.Write("<script LANGUAGE='JavaScript' >alert('Inserted Successfully.')</script>");


                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('Insert'); ", true);
                        //Response.Write("<script LANGUAGE='JavaScript' >alert('Insert Failed.')</script>");
                    }
                    tb_user_name.Text = "";
                    dgv_data();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:user_alert('User Already Exists,Try Again'); ", true);

                //Response.Write("<script LANGUAGE='JavaScript' >alert('User Already Exists,Try Again')</script>");
                tb_user_name.Text = "";
            }

        }

        protected void btn_up_Click(object sender, EventArgs e)
        {
            try
            {
                dbconn();
                String update = "UPDATE Admin_User SET User_name = '" + tb_user_name.Text + "',Password='" + tb_pass.Text + "' WHERE Admin_id = " + a_id + ";";
                //Response.Write(update);
                cmd = new SqlCommand(update, conn);
                int isupdate = cmd.ExecuteNonQuery();
                if (isupdate > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Updated'); ", true);
                    //Response.Write("<scr" + "ipt language=javascript>success_msg('Updated');</scr" + "ipt>");
                    //Response.Write("<script LANGUAGE='JavaScript' >alert('Updated Successfully.')</script>");

                }
                else
                {
                    
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('Update'); ", true);
                    //Response.Write("<script LANGUAGE='JavaScript' >alert('Update Failed.')</script>");
                }
                tb_user_name.Text = "";
                dgv_data();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void dgv_user_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow r = dgv_user.Rows[e.RowIndex];
            del = Convert.ToInt32(r.Cells[1].Text);
            try
            {
                dbconn();
                String de = "DELETE FROM Admin_User WHERE Admin_id = " + del + ";";
                cmd = new SqlCommand(de, conn);
                int isDel = cmd.ExecuteNonQuery();
                if (isDel > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Deleted'); ", true);
                    //Response.Write("<script LANGUAGE='JavaScript' >alert('Deleted Successfully.')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fail_msg('Delete'); ", true);
                    //Response.Write("<script LANGUAGE='JavaScript' >alert('Delete Failed.')</script>");
                }

                dgv_data();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
            //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:success_msg('Inserted'); ", true);

        //}
    }
}