using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class RecuperarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string email = this.txtEmail.Text;

            WebService.WebService ws = new WebService.WebService();
            
            string senhaRecuperada = ws.RecuperarSenha(email);

            string from = "noreplay@controledegastos.com";
            string assunto = "Recuperação de senha - Controle de Gastos.";
            string body = "Sua senha foi recuperada com sucesso. <br /><strong>Senha: </strong>" + senhaRecuperada;
            string smtp = "";
            int porta = 0;
            string usuario = "";
            string senha = "";

            if (senhaRecuperada != string.Empty)
            {
                Email.EnvioDeEmail EnvMail = new Email.EnvioDeEmail();
                if (EnvMail.dispararEmail(email, string.Empty, string.Empty, from, assunto, body, 1, true, true, smtp, porta, usuario, senha))
                {
                    Response.Redirect("~/Usuario/SenhaSucesso.aspx");
                }
                else
                {
                    Response.Redirect("~/Usuario/Error.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Usuario/Error.aspx");
            }

        }
    }
}