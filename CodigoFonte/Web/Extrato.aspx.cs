using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Extrato : System.Web.UI.Page
    {
        WebService.WebService ws = new WebService.WebService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rblConta.Items.Add("");
                foreach (WebService.Conta conta in ws.ListarContas(Convert.ToInt32(Session["userId"])))
                {
                    this.rblConta.Items.Add(new ListItem(conta.Cont_nome, conta.Cont_id.ToString()));
                }                
            }
        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {            
            Int32 conta = Convert.ToInt32(this.rblConta.Text);
            string mes = this.ddlMes.Text;
            string ano = this.txtAno.Text;

            WebService.Extrato[] extrato = ws.ListarExtrato(mes, ano, conta);
            this.grdExtrato.DataSource = extrato;
            this.grdExtrato.DataBind();
            this.uplResult.Visible = true;
            this.ltlConta.Text = this.rblConta.SelectedItem.Text;

            string saldoTotal = ws.ExibirSaldoConta(conta);
            this.lblValorTotal.Text = "Saldo Atual: R$ " + saldoTotal;
        }

        protected void grdExtrato_RowCommand(object sender, GridViewCommandEventArgs e)
        {            
            Int32 id = Convert.ToInt32(e.CommandArgument.ToString());
            decimal valor = Convert.ToDecimal(e.CommandName.Replace("R$ ", ""));
            Int32 conta = Convert.ToInt32(this.rblConta.Text);

            if (ws.ExcluirTransacao(id))
            {
                if (ws.CadastrarReceita(conta, valor))
                {
                    this.btnAplicar_Click(null, null);
                }
            }
        }        
    }
}