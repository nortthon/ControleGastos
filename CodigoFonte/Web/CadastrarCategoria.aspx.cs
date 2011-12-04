using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class CadastrarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string categoria = this.txtCategoria.Text;
                Int32 usuario = Convert.ToInt32(Session["userId"]);

                WebService.WebService ws = new WebService.WebService();

                if (ws.CadastrarCategoria(categoria, usuario))
                {
                    this.txtCategoria.Text = "";
                    this.lblSuccess.Text = "Nova categoria criada com sucesso.";
                }
                else
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
        }
    }
}