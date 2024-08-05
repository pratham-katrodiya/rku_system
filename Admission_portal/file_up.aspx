<%@ Page Title="" Language="C#" MasterPageFile="~/Admission_portal/a_Dashbord.Master" AutoEventWireup="true" CodeBehind="file_up.aspx.cs" Inherits="rku_system.Admission_portal.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2">
                Upload File
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_pi" runat="server" Text="Profile Image"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="fu_pi" runat="server" />
            </td>
        </tr>
         <tr>
     <td>
         <asp:Label ID="lbl_sign" runat="server" Text="Signature"></asp:Label>
     </td>
     <td>
         <asp:FileUpload ID="fu_sign" runat="server" />
     </td>
 </tr>
         <tr>
     <td>
         <asp:Label ID="lbl_ssc" runat="server" Text="S.S.C Marksheet"></asp:Label>
     </td>
     <td>
         <asp:FileUpload ID="fu_ssc" runat="server" />
     </td>
 </tr>
         <tr>
     <td>
         <asp:Label ID="lbl_hsc" runat="server" Text="H.S.C Marksheet"></asp:Label>
     </td>
     <td>
         <asp:FileUpload ID="fu_hsc" runat="server" />
     </td>
 </tr>
        <tr>
            <td>
                <asp:Button ID="btn_up" runat="server" Text="Upload" OnClick="btn_up_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
