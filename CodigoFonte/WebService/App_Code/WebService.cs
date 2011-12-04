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

    [WebMethod]
    public bool CadastrarCategoria(string categoria, Int32 usuario)
    {
        query = @"INSERT INTO tb_categoria (cat_nome, fk_usu_id)
                VALUES (@categoria, @usuario)";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@categoria", categoria);
            cmd.Parameters.AddWithValue("@usuario", usuario);            

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
    public bool CadastrarReceita(Int32 idConta, decimal valor)
    {
        query = @"UPDATE tb_conta SET cont_saldo = cont_saldo + @valor WHERE cont_id = @idConta";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@idConta", idConta);

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
    public List<Conta> ListarContas(Int32 usuario)
    {
        query = @"SELECT cont_id, cont_nome FROM tb_conta WHERE fk_usu_id = @usuario";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@usuario", usuario);

            SqlDataReader dr = cmd.ExecuteReader();

            List<Conta> contas = new List<Conta>();

            while (dr.Read())
            {
                Conta conta = new Conta();
                conta.Cont_id = Convert.ToInt32(dr[0]);
                conta.Cont_nome = dr[1].ToString();

                contas.Add(conta);
            }

            return contas;
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
    public bool AlterarSenha(Int32 usuario, string senhaAntiga, string senhaNova)
    {
        query = @"UPDATE tb_Usuario SET usu_senha = @senhaNova WHERE usu_id = @usuario AND usu_senha = @senhaAntiga";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@senhaNova", senhaNova);
            cmd.Parameters.AddWithValue("@senhaAntiga", senhaAntiga);
            cmd.Parameters.AddWithValue("@usuario", usuario);

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
    public List<Categoria> ListarCategorias(Int32 usuario)
    {
        query = @"SELECT cat_id, cat_nome FROM tb_categoria WHERE fk_usu_id = @usuario";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@usuario", usuario);

            SqlDataReader dr = cmd.ExecuteReader();

            List<Categoria> categorias = new List<Categoria>();

            while (dr.Read())
            {
                Categoria categoria = new Categoria();
                categoria.Cat_id = Convert.ToInt32(dr[0]);
                categoria.Cat_nome = dr[1].ToString();

                categorias.Add(categoria);
            }

            return categorias;
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
    public bool CadastrarTransacao(Int32 tipo, Int32 conta, Int32 categoria, string data, decimal valor, string descricao)
    {
        query = @"INSERT INTO tb_transacao(fk_tip_id, fk_cont_id, fk_cat_id, trans_dia, trans_mes, trans_ano, trans_valor, trans_descricao)
                VALUES (@tipo, @conta, @categoria, @dia, @mes, @ano, @valor, @descricao)";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            string[] arrayData = data.Split('/');

            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@conta", conta);
            cmd.Parameters.AddWithValue("@categoria", categoria);
            cmd.Parameters.AddWithValue("@dia", arrayData[0]);
            cmd.Parameters.AddWithValue("@mes", arrayData[1]);
            cmd.Parameters.AddWithValue("@ano", arrayData[2]);
            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@descricao", descricao);

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
