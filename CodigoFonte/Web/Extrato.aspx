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
		<label for="txtDescricao">Contas: </label>
        <br />
        <asp:DropDownList runat="server" ID="rblConta" />
        <br />
        <label>Mês: &nbsp;&nbsp; </label><br />
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
        <asp:Button runat="server" Text="Aplicar Filtro" ID="btnAplicar" 
            onclick="btnAplicar_Click" />
        
        
	
    <br />
    <hr />
    <br />
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
   <asp:UpdatePanel ID="uplResult" runat="server" Visible="false">
        <ContentTemplate>
            <fieldset>
		        <legend><asp:Literal ID="ltlConta" runat="server" /></legend>
		        <asp:GridView runat="server" ID="grdExtrato" Width="100%"
                    AutoGenerateColumns="false" OnRowCommand="grdExtrato_RowCommand" >
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="18">  
                            <ItemTemplate>  
                                <asp:ImageButton runat="server" ID="imgDeletar" BorderWidth="0" ImageUrl="~/Images/icone_excluir.gif"
                                CommandArgument='<%# Eval("Id").ToString() %>' CommandName='<%# Eval("Valor").ToString() %>' CausesValidation="false" />  
                            </ItemTemplate>  
                        </asp:TemplateField>   
                        <asp:BoundField DataField="Data" HeaderText="Data" />  
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />  
                        <asp:BoundField DataField="Categoria" HeaderText="Categoria" />  
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" />  
                        <asp:BoundField DataField="Valor" HeaderText="Valor" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblValorTotal" runat="server" CssClass="bold alignright p5" />
	        </fieldset> 
         </ContentTemplate>
    </asp:UpdatePanel>  
    </form>
</asp:Content>
