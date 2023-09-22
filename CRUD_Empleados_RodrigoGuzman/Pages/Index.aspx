<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CRUD_Empleados_RodrigoGuzman.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        form {
            border: 2px solid #ccc;
            border-radius: 5px;
            padding: 10px;
            box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.2);
            margin-top: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <form runat="server">
        <br />  
        <div class="container row">
            <div class="mx-auto text-center" ">
                <h2>Empleados</h2>
            </div>
            <div class="table small">
                        <br />
                        <div class="container  text-center">
                            <div class="row">
                                <div class="col align-self-end">
                                    <asp:Button ID="BtnCreate" 
                                        CssClass="btn btn-success form-control-sm" 
                                        Text="Crear Nuevo Empleado" 
                                        runat="server" 
                                        OnClick="BtnCreate_Click"/>
                                </div>
                                <div class="form-group  text-center" style="display:flex">
                                    <asp:TextBox runat="server" 
                                        ID="txtSearch" 
                                        CssClass="form-control" 
                                        ClientIDMode="Static" 
                                        placeholder="Escribe tu búsqueda aquí"/>
                                    <asp:Button Text="Buscar" 
                                        runat="server" 
                                        CssClass="btn form-control-sm btn-danger" 
                                        ID="Button1" 
                                        OnClick="BtnSearch_Click"
                                        style="margin-left: 0.5em;"/>
                                </div>
                            </div>
                        </div>
                        <br />

                <asp:GridView runat="server" ID="gvempleados" class="table table-hover">
                    <columns>
                        <asp:TemplateField HeaderText="Opciones CRUD">
                            <ItemTemplate>
                                <asp:Button Text="Editar" runat="server" CssClass="btn form-control-sm btn-info" ID="BtnEdit" OnClick="BtnEdit_Click"/>
                                <asp:Button Text="Eliminar" runat="server" CssClass="btn form-control-sm btn-warning" ID="BtnDelete" OnClick="BtnDelete_Click"  style="margin-left: 0.3em;"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </columns>     
                </asp:GridView>
            </div>
        </div>
    </form>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var textbox = document.getElementById('<%= txtSearch.ClientID %>');
            textbox.focus();
            textbox.selectionStart = textbox.selectionEnd = textbox.value.length;
        });
    </script>
</asp:Content>
