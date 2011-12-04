﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Receita : System.Web.UI.Page
    {
        WebService.WebService ws = new WebService.WebService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlConta.Items.Add("");
                foreach (WebService.Conta conta in  ws.ListarContas(Convert.ToInt32(Session["userId"])))
                {
                    this.ddlConta.Items.Add(new ListItem(conta.Cont_nome, conta.Cont_id.ToString()));
                }
            }
        }        

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Int32 usuario = Convert.ToInt32(Session["userId"]);
                decimal valor = Convert.ToDecimal(this.txtValor.Text.Replace("+ R$ ", ""));

                if (ws.CadastrarReceita(usuario, valor))
                {
                    this.txtValor.Text = "";
                    this.ddlConta.SelectedValue = "";
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