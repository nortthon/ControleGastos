<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarConta.aspx.cs" Inherits="Web.CadastrarConta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Content_txtData").datepicker({ dateFormat: 'dd/mm/yy', navigationAsDateFormat: true });

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
            <asp:Label runat="server" ID="lblSuccess" />
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

            <label for="txtData">Data:
                <asp:RequiredFieldValidator runat="server" ID="rfvData" ControlToValidate="txtData" Text="*" ErrorMessage="O campo Data é obrigatório." />
            </label><br />
		    <asp:TextBox runat="server" ID="txtData" />					
		    <br /><br />

            <label for="txtDescricao">Descrição:</label><br />
		    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtDescricao" />					
		    <br /><br />

		    <asp:Button runat="server" Text="Criar Conta" ID="btnEnviar" 
                onclick="btnEnviar_Click" />
            <asp:Button runat="server" Text="Cancelar" PostBackUrl="javascript:history.back();" CausesValidation="false" />
	    </form>
    </div>
    <br /><br />
</asp:Content>
