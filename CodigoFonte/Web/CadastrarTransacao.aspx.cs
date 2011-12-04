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

        }
    }
}