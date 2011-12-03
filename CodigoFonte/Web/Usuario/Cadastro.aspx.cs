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
                    Response.Redirect("~/Usuario/CadastroSucesso.aspx");
                }
            }
        }
    }
}