<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CRUD_Empleados_RodrigoGuzman.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />  
        <div class="mx-auto" style="width: 300px">
            <h2>Listado de Registros</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:Button ID="BtnCreate" CssClass="btn btn-success form-control-sm" Text="Nuevo" runat="server" OnClick="BtnCreate_Click"/>
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvusuarios" class="table table-hover">
                    <columns>
                        <asp:TemplateField HeaderText="Opciones CRUD">
                            <ItemTemplate>
                                <asp:Button Text="Editar" runat="server" CssClass="btn form-control-sm btn-info" ID="BtnEdit" OnClick="BtnEdit_Click"/>
                                <asp:Button Text="Eliminar" runat="server" CssClass="btn form-control-sm btn-warning" ID="BtnDelete" OnClick="BtnDelete_Click"/>
                                <asp:Button Text="Buscar" runat="server" CssClass="btn form-control-sm btn-danger" ID="BtnRead" OnClick="BtnRead_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </columns>     
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
