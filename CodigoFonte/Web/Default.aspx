    <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="Scripts/highcharts.js"></script>
    <script type="text/javascript">
    var chart;
    $(document).ready(function () {
        chart = new Highcharts.Chart({
            chart: {
                renderTo: 'container',
                defaultSeriesType: 'column'
            },
            title: {
                text: 'Gráfico consolidado de gastos mensais'
            },
            subtitle: {
                text: 'ControleDeGastos.com'
            },
            xAxis: {
                categories: [
						'Jan',
						'Feb',
						'Mar',
						'Apr',
						'May',
						'Jun',
						'Jul',
						'Aug',
						'Sep',
						'Oct',
						'Nov',
						'Dec'
					]
            },
            yAxis: {
                
                min: 0,
                title: {
                    text: 'Valor (R$)'
                }
            },
            legend: {
                enabled: false
            },
            tooltip: {
                formatter: function () {
                    return 'Mês: ' +
							this.x + ':  R$ ' + this.y;
                }
            },
            plotOptions: {
                column: {
                    pointPadding: 0.2,
                    borderWidth: 0,
                    
                }
            },
            series: [
            {
                data: <%= Session["receita"] %>
            }, {                
                data: <%= Session["custo"] %>
            }
            ]
        });


    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h1>Painel de Controle</h1>
	<hr /><br />
    <div id="container" style="width: 780; height: 400px; margin: 0 auto"></div>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
       <asp:UpdatePanel ID="uplResult" runat="server" Visible="false">
            <ContentTemplate>
                <fieldset>
		            <legend>Minhas Contas</legend>
		            <asp:GridView runat="server" ID="grdContas" Width="100%"
                        AutoGenerateColumns="false" >
                        <Columns>                  
                            <asp:BoundField DataField="Cont_nome" HeaderText="Conta" />  
                            <asp:BoundField DataField="Cont_descricao" HeaderText="Descrição" />  
                            <asp:BoundField DataField="Cont_saldo" HeaderText="Saldo Atual" />  
                        </Columns>
                    </asp:GridView>                
	            </fieldset>
	        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
 
</asp:Content>
