<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="res_form.aspx.cs" Inherits="rku_system.Admission_portal.res_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Admission Form</title>
    
  <%--<link href="../css/st.css" rel="stylesheet" />--%>
  <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png">
<link rel="icon" type="image/png" href="../assets/img/favicon.png">
  <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900|Roboto+Slab:400,700" />
<!-- Nucleo Icons -->
<link href="../assets/css/nucleo-icons.css" rel="stylesheet" />
<link href="../assets/css/nucleo-svg.css" rel="stylesheet" />
<!-- Font Awesome Icons -->

<!-- Material Icons -->
<link href="https://fonts.googleapis.com/icon?family=Material+Icons+Round" rel="stylesheet">
<!-- CSS Files -->
<link id="pagestyle" href="../assets/css/material-dashboard.css?v=3.0.0" rel="stylesheet" />
  <script src="../assets/js/alert.js"></script>
  <script src="../assets/js/fn_msg.js"></script>
  <script src="https://kit.fontawesome.com/48c360923b.js" crossorigin="anonymous"></script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            height: 29px;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            height: 26px;
            width: 721px;
            text-align: right;
        }
        .auto-style8 {
            height: 29px;
            width: 721px;
            text-align: right;
        }
        .auto-style9 {
            width: 721px;
            text-align: center;
        }
        .auto-style10 {
            width: 721px;
            text-align: right;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style5" colspan="2">
                    <h1>Registration</h1>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Faculty For Addmistion</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="ddl_stream" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_stream_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Addmission Form</td>
                <td class="auto-style2">
                        <asp:DropDownList ID="ddl_dept" runat="server">
                        </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td class="auto-style10">Last Qualifying S.S.C Exam Marks(%)</td>
                <td>
                        <asp:TextBox ID="txt_ssc" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style10">Last Qualifying H.S.C Exam Marks(%)</td>
                <td>
                        <asp:TextBox ID="txt_hsc" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style10">Surname</td>
                <td>
                        <asp:TextBox ID="txt_fname" runat="server"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style10">Name</td>
                <td>
                        <asp:TextBox ID="txt_mname" runat="server"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style10">Father/Husband/Mother<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name</td>
                <td>
                        <asp:TextBox ID="txt_lname" runat="server"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style8">Birth Date</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txt_birth" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">Address</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txt_add" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Mobile No</td>
                <td>
                        <asp:TextBox ID="txt_mobile" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style8">Email</td>
                <td class="auto-style3">
                        <asp:TextBox ID="txt_email" runat="server" Width="152px" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lbl_otp" runat="server" Text="Enter Mobile OTP" Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_otp" runat="server" TextMode="Number" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">
                        <asp:Button ID="btn_otp" runat="server" Text="Send OTP" OnClick="btn_otp_Click" />
                    </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">
                        &nbsp;</td>
            </tr>
           
            
            
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lbl_category" runat="server" Text="Category" Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="ddl_category" runat="server" Visible="False">
                        <asp:ListItem>--Please Select--</asp:ListItem>
                        <asp:ListItem>SC</asp:ListItem>
                        <asp:ListItem>ST</asp:ListItem>
                        <asp:ListItem>SEBC</asp:ListItem>
                        <asp:ListItem>General</asp:ListItem>
                        <asp:ListItem Value="EWS">EWS</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="lbl_gender" runat="server" Text="Gender" Visible="False"></asp:Label>
                </td>
                <td>
                        <asp:RadioButtonList ID="rdl_gender" runat="server" RepeatDirection="Horizontal" Visible="False">
                            <asp:ListItem>male</asp:ListItem>
                            <asp:ListItem>female</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="lbl_pass" runat="server" Text="Password" Visible="False"></asp:Label>
                </td>
                <td>
                        <asp:TextBox ID="txt_pass" runat="server" TextMode="Password" Visible="False"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style9" colspan="2">
                        <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" Visible="False" />
                    </td>
            </tr>
        </table>
    </form>


</body>
</html>