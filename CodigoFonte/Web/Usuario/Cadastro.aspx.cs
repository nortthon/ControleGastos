using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Usuario
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string nome = this.txtNome.Text;
                string email = this.txtEmail.Text;
                string login = this.txtLogin.Text;
                string senha = this.txtSenha.Text;

                WebService.WebService ws = new WebService.WebService();

                bool result = ws.CadastrarUsuario(nome, email, login, senha);

                if (result)
                {   
                    string from = "noreplay@controledegastos.com";
                    string assunto = "Cadastro de Usuário - Controle de Gastos.";
                    string body = "Seu Cadastro no Controle de gastos foi realizado com sucesso. Acesse sua conta e comece a asar. http://controledegastos.com";
                    string smtp = "";
                    int porta = 0;
                    string usuario = "";
                    string senhaEmail = "";
                    
                    Email.EnvioDeEmail EnvMail = new Email.EnvioDeEmail();
                    EnvMail.dispararEmail(email, string.Empty, string.Empty, from, assunto, body, 1, true, true, smtp, porta, usuario, senhaEmail);
                    
                    Response.Redirect("~/Usuario/CadastroSucesso.aspx");
                }
            }
        }
    }
}