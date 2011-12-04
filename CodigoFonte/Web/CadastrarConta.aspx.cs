using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class CadastrarConta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string nomeConta = this.txtConta.Text;
            string descricao = this.txtDescricao.Text;
            decimal saldo = Convert.ToDecimal(this.txtValor.Text);
            Int32 usuario = Convert.ToInt32(Session["userId"]);

            WebService.WebService ws = new WebService.WebService();
            
            if (ws.CadastrarConta(nomeConta, saldo, descricao, usuario))
            {

            }

        }
    }
}