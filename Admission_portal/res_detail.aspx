<%@ Page Title="" Language="C#" MasterPageFile="~/Admission_portal/a_Dashbord.Master" AutoEventWireup="true" CodeBehind="res_detail.aspx.cs" Inherits="rku_system.Admission_portal.res_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 34px;
        }
        .auto-style2 {
            height: 34px;
            margin-bottom: 0px;
        }
        .auto-style3 {
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <table class="auto-style2">
            <tr>
                <td class="auto-style5" colspan="2">
                    <h1>Registration Details</h1>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Faculty For Addmistion</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="ddl_stream" runat="server" AutoPostBack="True" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Addmission Form</td>
                <td class="auto-style2">
                        <asp:DropDownList ID="ddl_dept" runat="server" Enabled="False">
                        </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td class="auto-style7">Last Qualifying S.S.C Exam Marks(%)</td>
                <td>
                        <asp:TextBox ID="txt_ssc" runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style7">Last Qualifying H.S.C Exam Marks(%)</td>
                <td>
                        <asp:TextBox ID="txt_hsc" runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style7">Surname</td>
                <td>
                        <asp:TextBox ID="txt_fname" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style7">Name</td>
                <td>
                        <asp:TextBox ID="txt_mname" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style7">Father/Husband/Mother<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name</td>
                <td>
                        <asp:TextBox ID="txt_lname" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style8">Birth Date</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txt_birth" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">Address</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txt_add" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Mobile No</td>
                <td class="auto-style1">
                        <asp:TextBox ID="txt_mobile" runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style3">Email</td>
                <td class="auto-style3">
                        <asp:TextBox ID="txt_email" runat="server" Width="152px" TextMode="Email" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lbl_category" runat="server" Text="Category"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="ddl_category" runat="server" Enabled="False">
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
                <td class="auto-style3">
                    <asp:Label ID="lbl_gender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txt_gender" runat="server" ReadOnly="True"></asp:TextBox>
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9" colspan="2">
                        &nbsp;</td>
            </tr>
        </table>
</asp:Content>
