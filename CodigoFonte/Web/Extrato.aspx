<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Extrato.aspx.cs" Inherits="Web.Extrato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Content_txtAno").mask("9999", { placeholder: " " });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h1>Extrato</h1>
    <br />
    <form runat="server" method="post">
        <asp:ValidationSummary runat="server" ID="summary" />
		<label>Mês: &nbsp;&nbsp; </label>
		<asp:DropDownList runat="server" ID="ddlMes" Width="100px">
            <asp:ListItem Text="Janeiro" Value="01" />
            <asp:ListItem Text="Fevereiro" Value="02" />
            <asp:ListItem Text="Março" Value="03" />
            <asp:ListItem Text="Abril" Value="04" />
            <asp:ListItem Text="Maio" Value="05" />
            <asp:ListItem Text="Junho" Value="06" />
            <asp:ListItem Text="Julho" Value="07" />
            <asp:ListItem Text="Agosto" Value="08" />
            <asp:ListItem Text="Setembro" Value="09" />
            <asp:ListItem Text="Outubro" Value="10" />
            <asp:ListItem Text="Novembro" Value="11" />
            <asp:ListItem Text="Dezenbro" Value="12" />
		</asp:DropDownList>
        &nbsp;&nbsp;
        <asp:TextBox Width="70px" MaxLength="4" runat="server" ID="txtAno" />
        &nbsp;&nbsp;
        <asp:Button runat="server" Text="Aplicar Filtro" ID="btnAplicar" />
        <br />
        <label for="txtDescricao">Contas: </label>
        <br />
        <asp:CheckBoxList runat="server" ID="rblConta" CssClass="bkbranco" BorderStyle="None" RepeatColumns="4">
            <asp:ListItem Text="Conta Corrente" Value="1" />
            <asp:ListItem Text="Poupança" Value="2" />
        </asp:CheckBoxList>
	</form>
    <hr />
    <br />
    <fieldset>
		<legend>Conta Corrente</legend>
		<table width="100%">
		    <thead>
		        <tr>
			        <th>Data</th>
			        <th>Tipo</th>
			        <th>Categoria</th>
                    <th>Descrição</th>
			        <th>Valor</th>
                    <th>Ações</th>
		        </tr>
		    </thead>
		    <tfoot>
		        <tr>
			        <td></td>
			        <td></td>
                    <td></td>
                    <td></td>
			        <td>Total: R$ 18000,00</td>
                    <td></td>
		        </tr>
		    </tfoot>
		    <tbody>
		        <tr>
			        <td>10/10/2011</td>
			        <td>Crédito</td>
			        <td>Refeição</td>
                    <td>Almoço de negócios com o presidente da Google.</td>
                    <td>R$ 2180,00</td>
                    <td><a href="">Excluir</a></td>
		        </tr>
		        <tr>
			        <td>12/10/2011</td>
			        <td>Débito</td>
			        <td>Refeição</td>
                    <td>Almoço com os filhos na Disney. Dia das crianças</td>
                    <td>R$ 2480,00</td>
                    <td><a href="">Excluir</a></td>
		        </tr>
		    </tbody>
	    </table>
	</fieldset>
    <br />
    <fieldset>
		<legend>Poupança</legend>
	    <table width="100%">
		    <thead>
		        <tr>
			        <th>Data</th>
			        <th>Tipo</th>
			        <th>Categoria</th>
                    <th>Descrição</th>
			        <th>Valor</th>
                    <th>Ações</th>
		        </tr>
		    </thead>
		    <tfoot>
		        <tr>
			        <td></td>
			        <td></td>
                    <td></td>
                    <td></td>
			        <td>Total: R$ 41800,90</td>
                    <td></td>
		        </tr>
		    </tfoot>
		    <tbody>
		        <tr>
			        <td>10/10/2011</td>
			        <td>Crédito</td>
			        <td>Refeição</td>
                    <td>Almoço de negócios com o presidente da Google.</td>
                    <td>R$ 2180,00</td>
                    <td><a href="">Excluir</a></td>
		        </tr>
		        <tr>
			        <td>12/10/2011</td>
			        <td>Débito</td>
			        <td>Refeição</td>
                    <td>Almoço com os filhos na Disney. Dia das crianças</td>
                    <td>R$ 2480,00</td>
                    <td><a href="">Excluir</a></td>
		        </tr>
		    </tbody>
	    </table>
	</fieldset>
</asp:Content>
