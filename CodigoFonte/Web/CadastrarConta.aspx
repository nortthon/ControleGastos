<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarConta.aspx.cs" Inherits="Web.CadastrarConta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#Content_txtValor').priceFormat({
                prefix: 'R$ ',
                thousandsSeparator: '',
                centsSeparator: ',',
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h1>Nova Conta</h1><br /><br />
    <div style="margin-left:80px">
        <form runat="server" method="post"> 
            <asp:ValidationSummary runat="server" ID="summary" />
            <label for="txtConta">Conta:
                <asp:RequiredFieldValidator runat="server" ID="rfvConta" ControlToValidate="txtConta" Text="*" ErrorMessage="O campo Conta é obrigatório." />
            </label><br />
		    <asp:TextBox runat="server"  ID="txtConta" />					
		    <br /><br />

            <label for="txtConta">Saldo Inicial:
                <asp:RequiredFieldValidator runat="server" ID="rfvValor" ControlToValidate="txtValor" Text="*" ErrorMessage="O campo Saldo Inicial é obrigatório." />
            </label><br />
		    <asp:TextBox runat="server"  ID="txtValor" />					
		    <br /><br />

            <label for="txtDescricao">Descrição:</label><br />
		    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtDescricao" />					
		    <br /><br />

		    <asp:Button runat="server" Text="Criar Conta" ID="btnEnviar" />
            <asp:Button runat="server" Text="Cancelar" PostBackUrl="javascript:history.back();" CausesValidation="false" />
	    </form>
    </div>
    <br /><br />
</asp:Content>
