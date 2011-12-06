using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class CadastrarTransacao : System.Web.UI.Page
    {
        WebService.WebService ws = new WebService.WebService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlConta.Items.Add("");
                foreach (WebService.Conta conta in ws.ListarContas(Convert.ToInt32(Session["userId"])))
                {
                    this.ddlConta.Items.Add(new ListItem(conta.Cont_nome, conta.Cont_id.ToString()));
                }

                this.ddlCategoria.Items.Add("");
                foreach (WebService.Categoria categoria in ws.ListarCategorias(Convert.ToInt32(Session["userId"])))
                {
                    this.ddlCategoria.Items.Add(new ListItem(categoria.Cat_nome, categoria.Cat_id.ToString()));
                }
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Int32 tipo = Convert.ToInt32(this.rblTipo.Text);
                Int32 conta = Convert.ToInt32(this.ddlConta.Text);
                Int32 categoria = Convert.ToInt32(this.ddlCategoria.Text);
                string data = this.txtData.Text;
                decimal valor = Convert.ToDecimal(this.txtValor.Text.Replace("- R$ ", ""));
                string descricao = this.txtDescricao.Text;

                if (ws.CadastrarTransacao(tipo, conta, categoria, data, valor, descricao))
                {
                    this.rblTipo.SelectedValue = "";
                    this.ddlConta.SelectedValue = "";
                    this.ddlCategoria.SelectedValue = "";
                    this.txtData.Text = "";
                    this.txtValor.Text = "";
                    this.txtDescricao.Text = "";
                    this.lblSuccess.Text = "Transação salva com sucesso.";
                }
                else
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
        }
    }
}