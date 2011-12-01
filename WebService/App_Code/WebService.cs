using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #region Usuário

    [WebMethod]
    public bool CriarUsuario() {

        return false;
    }

    [WebMethod]
    public int EfetuarLogin()
    {

        return 0;
    }

    [WebMethod]
    public bool RecuperarSenha()
    {

        return false;
    }

    [WebMethod]
    public bool TrocarSenha()
    {

        return false;
    }

    [WebMethod]
    public bool AtivarUsuario()
    {

        return false;
    }

    #endregion

    [WebMethod]
    public bool CriarCategoria()
    {

        return false;
    }

    [WebMethod]
    public bool CriarConta()
    {

        return false;
    }

    [WebMethod]
    public bool InserirTransacao()
    {

        return false;
    }

    [WebMethod]
    public bool InserirReceita()
    {

        return false;
    }


}
