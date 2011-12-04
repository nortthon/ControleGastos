<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receita.aspx.cs" Inherits="Web.Receita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#Content_txtValor').priceFormat({
                prefix: '+ R$ ',
                thousandsSeparator: '',
                centsSeparator: ',',
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h1>Receita</h1><br /><br />
    <div style="margin-left:80px">
        <form id="Form1" runat="server" method="post"> 
            <asp:ValidationSummary runat="server" ID="summary" />
            <asp:Label runat="server" ID="lblSuccess" />
            <label for="txtConta">Conta:
                <asp:RequiredFieldValidator runat="server" ID="rfvConta" ControlToValidate="ddlConta" Text="*" ErrorMessage="O campo Conta é obrigatório." />
            </label><br />
		    <asp:DropDownList runat="server" ID="ddlConta" />					
		    <br /><br />

            <label for="txtConta">Valor:
                <asp:RequiredFieldValidator runat="server" ID="rfvValor" ControlToValidate="txtValor" Text="*" ErrorMessage="O campo Valor é obrigatório." />
            </label><br />
		    <asp:TextBox runat="server"  ID="txtValor" />
            <br />
            <!--<span><strong>Saldo Atual:</strong> R$ 5198,00</span>-->
		    <br /><br />

		    <asp:Button runat="server" Text="Salvar" ID="btnEnviar" onclick="btnEnviar_Click" />
            <asp:Button ID="Button1" runat="server" Text="Cancelar" PostBackUrl="javascript:history.back();" CausesValidation="false" />
	    </form>
    </div>
    <br /><br />
</asp:Content>
