using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string login = this.txtLogin.Text;
            string senha = this.txtSenha.Text;

            WebService.WebService ws = new WebService.WebService();
            WebService.Usuario usuario = ws.EfetuarLogin(login, senha);

            if (usuario == null)
            {
                Response.Redirect("~/Usuario/UsuarioInvalido.aspx");
            }
            else
            {
                if (usuario.Usu_status == 1)
                {
                    Session["userId"] = usuario.Usu_id;
                    Session["userName"] = usuario.Usu_nome;
                    FormsAuthentication.RedirectFromLoginPage(login, true);
                }
                else
                {
                    Response.Redirect("~/Usuario/ContaNaoAtivada.aspx");
                }
            }
        }
    }
}