using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Entidades;

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
    private String query = string.Empty;

    public WebService () {

        String data = ConfigurationManager.ConnectionStrings["conexaoSQL"].ToString();
        conn = new SqlConnection(data);
        cmd = new SqlCommand();
    }

    [WebMethod]
    public bool CadastrarUsuario(string nome, string email, string login, string senha) 
    {
        query = @"INSERT INTO tb_usuario(usu_nome, usu_email, usu_login, usu_senha) VALUES(@nome, @email, @login, @senha)";
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

    [WebMethod]
    public Usuario EfetuarLogin(string login, string senha)
    {
        query = @"SELECT usu_id, usu_nome, usu_status FROM tb_usuario WHERE usu_login LIKE @login AND usu_senha LIKE @senha";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader dr = cmd.ExecuteReader();

            Usuario usuario = null;

            while (dr.Read())
            {
                usuario = new Usuario();
                usuario.Usu_id = Convert.ToInt32(dr[0]);
                usuario.Usu_nome = dr[1].ToString();
                usuario.Usu_status = Convert.ToInt32(dr[2]);
            }

            return usuario;                
        }
        catch
        { 
            return null;
        }
        finally
        {
            conn.Close();
        }
    }

    [WebMethod]
    public bool CadastrarConta(string nome, decimal saldo, string descricao, Int32 fk_usu_id)
    {
        query = @"INSERT INTO tb_conta (cont_nome, cont_saldo, cont_descricao, fk_usu_id)
                VALUES (@nome, @saldo, @descricao, @usuario)";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@saldo", saldo);
            cmd.Parameters.AddWithValue("@descricao", descricao);
            cmd.Parameters.AddWithValue("@usuario", fk_usu_id);

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
