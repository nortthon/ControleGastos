<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarCategoria.aspx.cs" Inherits="Web.CadastrarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h1>Nova Categoria</h1><br /><br />
    <div style="margin-left:80px">
        <form id="Form1" runat="server" method="post"> 
            <asp:ValidationSummary runat="server" ID="summary" />
            <label for="txtConta">Categoria:
                <asp:RequiredFieldValidator runat="server" ID="rfvCategoria" ControlToValidate="txtCategoria" Text="*" ErrorMessage="O campo Categoria é obrigatório." />
            </label><br />
		    <asp:TextBox runat="server"  ID="txtCategoria" />					
		    <br /><br />

		    <asp:Button runat="server" Text="Criar Categoria" ID="btnEnviar" />
            <asp:Button runat="server" Text="Cancelar" PostBackUrl="javascript:history.back();" CausesValidation="false" />
	    </form>
    </div>
    <br /><br />
</asp:Content>
