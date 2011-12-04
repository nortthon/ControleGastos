using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Web
{
    public partial class TrocarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string senhaAtual = this.txtSenhaAtual.Text;
                string senhaNova = this.txtSenha.Text;
                Int32 usuario = Convert.ToInt32(Session["userId"]);

                WebService.WebService ws = new WebService.WebService();

                if (ws.AlterarSenha(usuario, senhaAtual, senhaNova))
                {
                    this.txtSenhaAtual.Text = "";
                    this.txtSenha.Text = "";
                    this.txtConfirmarSenha.Text = "";
                    this.lblSuccess.Text = "Sua senha foi alterada com sucesso. Acesse novamente com sua nova senha.";
                    FormsAuthentication.SignOut();
                }
                else
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
        }
    }
}