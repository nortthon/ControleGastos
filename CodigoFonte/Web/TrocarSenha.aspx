<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrocarSenha.aspx.cs" Inherits="Web.TrocarSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Trocar Senha
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <h1>Troca de Senha</h1><br /><br />
    <div style="margin-left:80px">
        <form runat="server" method="post"> 
            <asp:ValidationSummary runat="server" ID="summary" />
            <label for="txtSenhaAtual">Senha Atual:
                <asp:RequiredFieldValidator runat="server" ID="rfvSenhaAtual" ControlToValidate="txtSenhaAtual" Text="*" ErrorMessage="O campo Confirmar Senha Atual é obrigatório." />
            </label><br />
		    <asp:TextBox runat="server" TextMode="Password"  ID="txtSenhaAtual" />					
		    <br /><br />

            <label for="txtSenha">Nova Senha:
                <asp:RequiredFieldValidator runat="server" ID="rfvSenha" ControlToValidate="txtSenha" Text="*" ErrorMessage="O campo Nova Senha é obrigatório." />
            </label><br />
		    <asp:TextBox runat="server" TextMode="Password"  ID="txtSenha" />					

		    <br /><br />
            <label for="txtConfirmarSenha">Confirmar Nova Senha:
                <asp:RequiredFieldValidator runat="server" ID="rfvConfirmarSenha" ControlToValidate="txtConfirmarSenha" Text="*" ErrorMessage="O campo Confirmar Nova Senha é obrigatório." />
                <asp:CompareValidator runat="server" ID="cpvSenha" ControlToValidate="txtConfirmarSenha" ControlToCompare="txtSenha" Text="*" ErrorMessage="As senhas não estão iguais." /> 
            </label><br />
		    <asp:TextBox runat="server" TextMode="Password"  ID="txtConfirmarSenha" />					
		    <br /><br />

		    <asp:Button runat="server" Text="Enviar" ID="btnEnviar" />
            <asp:Button runat="server" Text="Cancelar" PostBackUrl="javascript:history.back();" CausesValidation="false" />
	    </form>
    </div>
    <br /><br />
</asp:Content>
