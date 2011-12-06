using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        WebService.WebService ws = new WebService.WebService();

        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 userId = Convert.ToInt32(Session["userId"]);
            WebService.Conta[] contas =  ws.ListarContas(userId);

            this.grdContas.DataSource = contas;
            this.grdContas.DataBind();
            this.uplResult.Visible = (contas.Count() > 0);

            Int32 ano = Convert.ToInt32(DateTime.Today.Year);
            Int32 usuario = Convert.ToInt32(Session["userId"]);

            Session["receita"] = ws.SaldoGeralMesJson(ano, usuario);
            Session["custo"] = ws.CustoGeralMesJson(ano, usuario);
        }
    }
}