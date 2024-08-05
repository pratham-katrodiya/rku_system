using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using static System.Net.WebRequestMethods;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Net;
using System.Web.UI;


namespace rku_system
{
    public class Sender
    {
        static Random generator = new Random();
        static string otp;
        public string get_otp() => otp;
        public void set_otp()
        {
            otp = generator.Next(0, 1000000).ToString();
        }
        public void sendotp(string to_em)
        {
            set_otp();
            MailMessage mail = new MailMessage();
            mail.To.Add(to_em);
            mail.From = new MailAddress("techocean13@gmail.com");
            mail.Subject = "Email Verification";

            mail.IsBodyHtml = true;
            //string body = "<html xmlns = \"http://www.w3.org/1999/xhtml\" >" +

            //    "<head>"+
            //      "<meta http - equiv = \"Content-Type\" content = \"text/html; charset=utf-8\" >"+
            //      "<meta name = \"viewport\" content = \"width=device-width, initial-scale=1.0\" > "+
            //      "<title> Verify your login<title>"+

            //    "</head>"+

            //    "<body style = \"font-family: Helvetica, Arial, sans-serif; margin: 0px; padding: 0px; background-color: #ffffff;\" >"+
            //      "<table role = \"presentation\" style = \"width: 100%; border-collapse: collapse; border: 0px; border-spacing: 0px; font-family: Arial, Helvetica, sans-serif; background-color: rgb(239, 239, 239);\" >"+
            //       " <tbody >" +
            //         " < tr >"+
            //            "< td align = \"center\" style = \"padding: 1rem 2rem; vertical-align: top; width: 100%;\" >"+
            //              "< table role = \"presentation\" style = \"max-width: 600px; border-collapse: collapse; border: 0px; border-spacing: 0px; text-align: left;\" >" +
            //               " < tbody >"+
            //                "  < tr >"+
            //                  "  < td style = \"padding: 40px 0px 0px;\" >" +
            //                     " < div style = \"text-align: left;\" >"+
            //                     "   < div style = \"padding-bottom: 20px;\" >< img src = \"https://i.ibb.co/Qbnj4mz/logo.png\" alt = \"Company\" style = \"width: 56px;\" ></ div >"+
            //                   "   </ div >"+
            //                    "  < div style = \"padding: 20px; background-color: rgb(255, 255, 255); \" >"+
            //                    "    <div style = \"color: rgb(0, 0, 0); text-align: left;\" >"+
            //                      "    <h1 style = \"margin: 1rem 0\" > Verification code </ h1 >"+
            //                       "   <p style = \"padding -bottom: 16px\" > Please use the verification code below to sign in.</ p >"+
            //                       "   <p style = \"padding -bottom: 16px\">< strong style = \"font -size: 130% \" >" + otp + @"</ strong ></ p >"+
            //                        "  <p style = \"padding -bottom: 16px\" > If you didn’t request this, you can ignore this email.</ p >"+
            //                       "   <p style = \"padding -bottom: 16px\" > Thanks,< br > Sarthak Patel </ p >"+
            //                       " </ div > " +
            //                    "  </ div >"+
            //                    "  < div style = \"padding -top: 20px; color: rgb(153, 153, 153); text-align: center; \">"+
            //                      "  < p style = \"padding -bottom: 16px\" > Made with ♥ in Surat </ p >"+
            //                    "  </ div >"+
            //                  "  </ td >"+
            //                "</ tbody >"+
            //            "  </ table >"+
            //        "    </ td >"+
            //        "  </ tr >"+
            //      "  </ tbody >"+
            //   "   </ table >" +
            //    "</ body >" +
            //  "  </ html >";
            ////mail.Body = body;
            string htmlBody = @"
                    <!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
                    <html xmlns=""http://www.w3.org/1999/xhtml"">
                    <head>
                      <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
                      <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                      <title>Verify your login</title>
                      <!--[if mso]><style type=""text/css"">body, table, td, a { font-family: Arial, Helvetica, sans-serif !important; }</style><![endif]-->
                    </head>
                    <body style=""font-family: Helvetica, Arial, sans-serif; margin: 0px; padding: 0px; background-color: #ffffff;"">
                      <table role=""presentation""
                        style=""width: 100%; border-collapse: collapse; border: 0px; border-spacing: 0px; font-family: Arial, Helvetica, sans-serif; background-color: rgb(239, 239, 239);"">
                        <tbody>
                          <tr>
                            <td align=""center"" style=""padding: 1rem 2rem; vertical-align: top; width: 100%;"">
                              <table role=""presentation"" style=""max-width: 600px; border-collapse: collapse; border: 0px; border-spacing: 0px; text-align: left;"">
                                <tbody>
                                  <tr>
                                    <td style=""padding: 5px 0px 0px;"">
                                      <div style=""text-align: center; font-size:large;"">
                                        <div style=""padding-bottom: 20px;""><a href=""#"" style=""text-decoration: none; color: #000;""><h1>RAMKRISHNA UNIVERCITY</h1></a>
                                        </div>
                                      </div>
                                      <div style=""padding: 20px; background-color: rgb(255, 255, 255);"">
                                        <div style=""color: rgb(0, 0, 0); text-align: left;"">
                                          <h1 style=""margin: 1rem 0"">Verification code</h1>
                                          <p style=""padding-bottom: 16px"">Please use the verification code below to sign in.</p>
                                          <center><strong style=""font-size: 220%"">" + otp + @"</strong></center>
                                          <p style=""padding-bottom: 16px"">If you didn’t request this, you can ignore this email.</p>
                                          <p style=""padding-bottom: 16px"">Thanks,<br>Sarthak Patel</p>
                                        </div>
                                      </div>
                                      <div style=""padding-top: 20px; color: rgb(153, 153, 153); text-align: center;"">
                                        <p style=""padding-bottom: 16px"">Made By Sarthak Patel</p>
                                      </div>
                                    </td>
                                  </tr>
                                </tbody>
                              </table>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </body>
                    </html>";

            mail.Body = htmlBody;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("techocean13@gmail.com", "oqmettkmfxvylgzn");
            //smtp.Credentials = new System.Net.NetworkCredential("techocean13@gmail.com", "$@rth@k1315");
            try
            {
                smtp.Send(mail);
                Console.WriteLine("succ");
                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('email sent.');", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


        }
    }
}