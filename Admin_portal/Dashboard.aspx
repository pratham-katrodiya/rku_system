<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_portal/Desboard.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="rku_system.Admin_portal.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid py-4">
  <div class="row">
    <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
      <div class="card">
        <div class="card-header p-3 pt-2">
          <div class="icon icon-lg icon-shape bg-gradient-dark shadow-dark text-center border-radius-xl mt-n4 position-absolute">
            <i class="fa-solid fa-user-tie"></i>
          </div>
          <div class="text-end pt-1">
            <p class="text-sm mb-0 text-capitalize">Total Admin User</p>
            <h4 class="mb-0"><asp:Label ID="Label1" runat="server" Text="53k"></asp:Label></h4>
              
          </div>
        </div>
      </div>
    </div>
    <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
      <div class="card">
        <div class="card-header p-3 pt-2">
          <div class="icon icon-lg icon-shape bg-gradient-primary shadow-primary text-center border-radius-xl mt-n4 position-absolute">
            <i class="fa-solid fa-graduation-cap"></i>
          </div>
          <div class="text-end pt-1">
            <p class="text-sm mb-0 text-capitalize">Total Student</p>
            <h4 class="mb-0"><asp:Label ID="Label2" runat="server" Text="53"></asp:Label></h4>
          </div>
        </div>
       
      </div>
    </div>
    <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
      <div class="card">
        <div class="card-header p-3 pt-2">
          <div class="icon icon-lg icon-shape bg-gradient-success shadow-success text-center border-radius-xl mt-n4 position-absolute">
            <i class="fa-solid fa-chalkboard-user fa-lg"></i>
          </div>
          <div class="text-end pt-1">
            <p class="text-sm mb-0 text-capitalize">Total Faculty</p>
            <h4 class="mb-0"><asp:Label ID="Label3" runat="server" Text="53"></asp:Label></h4>
          </div>
        </div>
        
      </div>
    </div>
    <div class="col-xl-3 col-sm-6">
      <div class="card">
        <div class="card-header p-3 pt-2">
          <div class="icon icon-lg icon-shape bg-gradient-info shadow-info text-center border-radius-xl mt-n4 position-absolute">
            <i class="fa-solid fa-book fa-lg"></i>
          </div>
          <div class="text-end pt-1">
            <p class="text-sm mb-0 text-capitalize">Total Course</p>
            <h4 class="mb-0"><asp:Label ID="Label4" runat="server" Text="53"></asp:Label></h4>
          </div>
        </div>
      
      </div>
    </div>
  </div>
</div>
</asp:Content>
