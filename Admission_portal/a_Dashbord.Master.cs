using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rku_system.Admission_portal
{
    public partial class a_Dashbord : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["student"])
            {

                String page_name = Session["Ad_page_name"].ToString();
                pn1.Text = pn2.Text = page_name;
                
                switch (page_name)
                {
                    case "Upload Files":
                        r_d.Attributes["class"] = st.Attributes["class"] = "nav-link text-white";
                        f_up.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                    case "Status":
                        r_d.Attributes["class"] = f_up.Attributes["class"]  = "nav-link text-white";
                        st.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                    default:
                        f_up.Attributes["class"] = st.Attributes["class"] = "nav-link text-white";
                        r_d.Attributes["class"] = "nav-link text-white active bg-gradient-info";
                        break;
                }


            }
            else
            {
                Response.Redirect("~/Admission_portal/S_login.aspx");
            }
        }
    }
}