using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    private SqlConnection conn;
    private SqlCommand cmd;

    public WebService () {

        String data = ConfigurationManager.ConnectionStrings["conexaoSQL"].ToString();
        conn = new SqlConnection(data);
        cmd = new SqlCommand();
    }

    [WebMethod]
    public bool CadastrarUsuario(string nome, string email, string login, string senha) 
    {
        string query = @"INSERT INTO tb_usuario(usu_nome, usu_email, usu_login, usu_senha) VALUES(@nome, @email, @login, @senha)";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            return (cmd.ExecuteNonQuery() > 0);
        }
        catch
        {
            return false;
        }
        finally
        {
            conn.Close();
        }        
    }
    
}
