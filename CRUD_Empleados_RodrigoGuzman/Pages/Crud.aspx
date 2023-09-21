<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Crud.aspx.cs" Inherits="CRUD_Empleados_RodrigoGuzman.Pages.Crud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            display: flex;
            justify-content: center;
            align-items: center;
        }
        form {
            border: 2px solid #ccc;
            border-radius: 5px;
            padding: 10px;
            width: 300px;
            box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.2);
            margin-top: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="container">   
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
        
            <asp:Button Text="Crear" 
                runat="server" 
                CssClass="btn form-control btn-info" 
                ID="BtnCreate" 
                Visible="false" 
                OnClick="BtnCreate_Click"
                OnClientClick="return validarInputs();"/>
            <asp:Button Text="Editar" 
                runat="server" 
                CssClass="btn form-control btn-info" 
                ID="BtnEdit" 
                Visible="false" 
                OnClick="BtnEdit_Click"
                OnClientClick="return validarInputs();"/>
            <asp:Button Text="Eliminar" 
                runat="server" 
                CssClass="btn form-control btn-info" 
                ID="BtnDelete" Visible="false" 
                OnClick="BtnDelete_Click"
                OnClientClick="return validarInputs();"/>    
            <button type="button" 
                class="btn form-control btn-dark" 
                OnClick="Cerrar()" 
                style="margin-top: 1em;">Volver</button>
        </div>
    </form>
   </div>
    <script>    
        function Cerrar() {
            window.close();
        }

        function validarCampo(input, mensaje) {
            var valor = input.value.trim();

            if (valor === '') {
                alert(mensaje);
                input.focus();
                input.select();
                return false;
            }

            return true;
        }

        function validarEmail(input) {
            var valor = input.value.trim();
            var emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

            if (!emailRegex.test(valor)) {
                alert('El Email no tiene un formato válido.');
                input.focus();
                input.select();
                return false;
            }

            return true;
        }

        function validarInputs() {
            var campos = [
                { input: document.getElementById('<%= tbNombre.ClientID %>'), mensaje: 'El Nombre no puede estar vacío.' },
                { input: document.getElementById('<%= tbApellido.ClientID %>'), mensaje: 'El Apellido no puede estar vacío.' },
                { input: document.getElementById('<%= tbEmail.ClientID %>'), mensaje: 'El Email no puede estar vacío.' },
                { input: document.getElementById('<%= tbSalario.ClientID %>'), mensaje: 'El Salario no puede estar vacío.' }
                ];

                for (var i = 0; i < campos.length; i++) {
                    if (!validarCampo(campos[i].input, campos[i].mensaje)) {
                        return false;
                    }
                }

            var emailInput = document.getElementById('<%= tbEmail.ClientID %>');
            if (!validarEmail(emailInput)) {
                return false;
            }

            return true;
        }

    </script>
</asp:Content>
