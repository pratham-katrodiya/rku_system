using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;


namespace rku_system
{
    public partial class otp_check : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void s_Click(object sender, EventArgs e)
        {
            string em = email.Text;
            //using (MailMessage mm = new MailMessage("techocean13@gmail.com", em))
            //{
            //    mm.Subject = "Email Verification";
            //    string ms = "Your Otp is " + otp;
            //    mm.Body =ms.ToString();
            //    mm.IsBodyHtml = true;
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.EnableSsl = true;
            //    NetworkCredential n = new NetworkCredential("techocean13@gmail.com", "yilckxxietfiggpd");
            //    smtp.UseDefaultCredentials = true;
            //    smtp.Credentials = n;
            //    smtp.Port = 587;
            //    smtp.Send(mm);
            //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email send..');", true);

            //}
            Sender s = new Sender();
            s.sendotp(em);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email send..');", true);
            String get_otp = s.get_otp();
            Response.Write(get_otp);
            //Response.Write(em);


        }
       
    }
}