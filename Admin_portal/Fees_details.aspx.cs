using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace University_Management_System.Admin_portal
{
    public partial class Fees_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page_name"] = "Fee Details";
        }
    }
}