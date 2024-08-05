using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace University_Management_System.Admin_portal
{
    public partial class Desboard : System.Web.UI.MasterPage
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["admin"])
            {

                String page_name= Session["page_name"].ToString();
                pn1.Text=pn2.Text = page_name;
                setimg();
                switch (page_name)
                {
                    case "User List":
                        d_active.Attributes["class"] = dep_active.Attributes["class"] =coll_active.Attributes["class"] =cou_active.Attributes["class"] =faculty_active.Attributes["class"] =fr_active.Attributes["class"] =fs_active.Attributes["class"] = "nav-link text-white";
                        ul_active.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                    case "Department":
                        d_active.Attributes["class"] = ul_active.Attributes["class"] = coll_active.Attributes["class"] = cou_active.Attributes["class"] = faculty_active.Attributes["class"] = fr_active.Attributes["class"] = fs_active.Attributes["class"] = "nav-link text-white";
                        dep_active.Attributes["class"] = "nav-link text-white active bg-gradient-info";   
                        break;
                    case "Colleges":
                        d_active.Attributes["class"] = dep_active.Attributes["class"] = ul_active.Attributes["class"] = cou_active.Attributes["class"] = faculty_active.Attributes["class"] = fr_active.Attributes["class"] = fs_active.Attributes["class"] = "nav-link text-white";
                        coll_active.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                    case "Faculty":
                        d_active.Attributes["class"] = dep_active.Attributes["class"] = coll_active.Attributes["class"] = cou_active.Attributes["class"] = ul_active.Attributes["class"] = fr_active.Attributes["class"] = fs_active.Attributes["class"] = "nav-link text-white";
                        faculty_active.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                    case "Course":
                        d_active.Attributes["class"] = dep_active.Attributes["class"] = coll_active.Attributes["class"] = ul_active.Attributes["class"] = faculty_active.Attributes["class"] = fr_active.Attributes["class"] = fs_active.Attributes["class"] = "nav-link text-white";
                        cou_active.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                    case "Fee Structure":
                        d_active.Attributes["class"] = dep_active.Attributes["class"] = coll_active.Attributes["class"] = cou_active.Attributes["class"] = faculty_active.Attributes["class"] = fr_active.Attributes["class"] = ul_active.Attributes["class"] = "nav-link text-white";
                        fs_active.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                    case "Fee Details":
                        d_active.Attributes["class"] = dep_active.Attributes["class"] = coll_active.Attributes["class"] = cou_active.Attributes["class"] = faculty_active.Attributes["class"] = ul_active.Attributes["class"] = fs_active.Attributes["class"] = "nav-link text-white";
                        fr_active.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                    default:
                        ul_active.Attributes["class"] = dep_active.Attributes["class"] = coll_active.Attributes["class"] = cou_active.Attributes["class"] = faculty_active.Attributes["class"] = fr_active.Attributes["class"] = fs_active.Attributes["class"] = "nav-link text-white";
                        d_active.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                }
                
                
            }
            else {
                Response.Redirect("~/Admin_portal/admin_login.aspx");
            }
            
        }
        protected void logout_btn_Click(object sender, EventArgs e)
        {
            Session["role"] = "";
            Response.Redirect("~/Admin_portal/admin_login.aspx");
        }
        protected void setimg()
        {
            try
            {
                dbconn();
                cmd = new SqlCommand("select img from Admin_User WHERE User_name = '" + Session["user_name"].ToString() +"';", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    user_img.ImageUrl = sdr[0].ToString();
                }
                                
                
                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}