<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Crud.aspx.cs" Inherits="CRUD_Empleados_RodrigoGuzman.Pages.Crud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width:250px">
        <asp:Label runat="server" CssClass="h2" ID="lblTitulo"/>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
            <asp:Label Text="Nombre" runat="server" Class="form-label"/>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbNombre"/>
        </div>
        <div class="mb-3">
            <asp:Label Text="Apellido" runat="server" Class="form-label"/>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbApellido"/>
        </div>
        <div class="mb-3">
            <asp:Label Text="Email" runat="server" Class="form-label"/>
            <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="tbEmail"/>
        </div>
        <div class="mb-3">
            <asp:Label Text="Salario" runat="server" Class="form-label"/>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbSalario"/>
        </div>
        
        <asp:Button Text="Crear" runat="server" CssClass="btn form-control btn-info" ID="BtnCreate" Visible="false" OnClick="BtnCreate_Click"/>
        <asp:Button Text="Editar" runat="server" CssClass="btn form-control btn-info" ID="BtnEdit" Visible="false" OnClick="BtnEdit_Click"/>
        <asp:Button Text="Eliminar" runat="server" CssClass="btn form-control btn-info" ID="BtnDelete" Visible="false" OnClick="BtnDelete_Click"/>    
        <asp:Button Text="Volver" runat="server" CssClass="btn form-control btn-dark" ID="BtnVolver" Visible="true" OnClick="BtnVolver_Click"  style="margin-top: 1em;"/>  
        </div>
    </form>
</asp:Content>
