<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarTransacao.aspx.cs" Inherits="Web.CadastrarTransacao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#Content_txtData").datepicker({ dateFormat: 'dd/mm/yy', navigationAsDateFormat: true });

        $('#Content_txtValor').priceFormat({
            prefix: '- R$ ',
            thousandsSeparator: '',
            centsSeparator: ','
        });
    });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h1>Nova Transação</h1><br /><br />
    <div style="margin-left:80px">  
        <form id="Form1" runat="server" method="post"> 
            <asp:ValidationSummary runat="server" ID="summary" />
            <label for="txtDescricao">Tipo:
                <asp:RequiredFieldValidator runat="server" ID="rfvTipo"  ControlToValidate="rblTipo" Text="*" ErrorMessage="O campo Tipo é obrigatório." />
            </label><br />
            <asp:RadioButtonList runat="server" ID="rblTipo" CssClass="bkbranco" BorderStyle="None" RepeatColumns="3">
                <asp:ListItem Text="Crédito" Value="1" />
                <asp:ListItem Text="Débito" Value="2" />
                <asp:ListItem Text="Transferência" Value="3" />
            </asp:RadioButtonList>
            
            <label for="txtConta">Conta:
                <asp:RequiredFieldValidator runat="server" ID="rfvConta" ControlToValidate="ddlConta" Text="*" ErrorMessage="O campo Conta é obrigatório." />
            </label><br />
		    <asp:DropDownList runat="server" ID="ddlConta" />					
		    <br /><br />
            
            <label for="txtCategoria">Categoria:
                <asp:RequiredFieldValidator runat="server" ID="rfvCategoria" ControlToValidate="ddlCategoria" Text="*" ErrorMessage="O campo Categoria é obrigatório." />
            </label><br />
		    <asp:DropDownList runat="server" ID="ddlCategoria" />					
		    <br /><br />

            <label for="txtData">Data:
                <asp:RequiredFieldValidator runat="server" ID="rfvData" ControlToValidate="txtData" Text="*" ErrorMessage="O campo Data é obrigatório." />
            </label><br />
		    <asp:TextBox runat="server" ID="txtData" />					
		    <br /><br />

            <label for="txtConta">Valor:
                <asp:RequiredFieldValidator runat="server" ID="rfvValor" ControlToValidate="txtValor" Text="*" ErrorMessage="O campo Valor é obrigatório." />
            </label><br />
		    <asp:TextBox runat="server"  ID="txtValor" />					
		    <br /><br />

            <label for="txtDescricao">Descrição:</label><br />
		    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtDescricao" />					
		    <br /><br />

		    <asp:Button runat="server" Text="Salvar Transação" ID="btnEnviar" 
                onclick="btnEnviar_Click" />
            <asp:Button runat="server" Text="Cancelar" PostBackUrl="javascript:history.back();" CausesValidation="false" />
	    </form>
    </div>
    <br /><br />
</asp:Content>
