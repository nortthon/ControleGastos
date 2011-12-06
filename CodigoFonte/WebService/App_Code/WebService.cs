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
    public Int32 CadastrarConta(string nome, decimal saldo, string descricao, Int32 fk_usu_id)
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

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select @@Identity";
 
            Int32 id = Convert.ToInt32(cmd.ExecuteScalar());
 
            cmd.Dispose();
            cmd = null;
            
            return id;
        }
        catch
        {
            return 0;
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
        query = @"UPDATE tb_conta SET cont_saldo += @valor WHERE cont_id = @idConta";
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
        query = @"SELECT cont_id, cont_nome, cont_saldo, cont_descricao FROM tb_conta WHERE fk_usu_id = @usuario";
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
                conta.Cont_saldo = "R$ " + dr[2].ToString();
                conta.Cont_descricao = dr[3].ToString();

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

            if (tipo == 4)
            {
                return (cmd.ExecuteNonQuery() > 0);
            }
            else
            {
                return (ReduzirNaConta(conta, valor)) ? (cmd.ExecuteNonQuery() > 0) : false;
            }
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
    public List<Extrato> ListarExtrato(string mes, string ano, Int32 conta)
    {
        query = @"SELECT    tb_transacao.trans_id, 
                            tb_transacao.trans_dia, 
                            tb_transacao.trans_mes, 
                            tb_transacao.trans_ano, 
                            tb_tipo.tip_nome, 
                            tb_categoria.cat_nome,
                            tb_transacao.trans_descricao, 
                            tb_transacao.trans_valor, 
                            tb_conta.cont_nome, 
                            tb_conta.cont_saldo
                  FROM      tb_conta INNER JOIN
                            tb_transacao ON tb_conta.cont_id = tb_transacao.fk_cont_id INNER JOIN
                            tb_categoria ON tb_transacao.fk_cat_id = tb_categoria.cat_id INNER JOIN
                            tb_tipo ON tb_transacao.fk_tip_id = tb_tipo.tip_id
                  WHERE     tb_transacao.fk_tip_id <> 4
                  AND       tb_transacao.trans_mes = @mes
                  AND       tb_transacao.trans_ano = @ano
                  AND       tb_transacao.fk_cont_id = @conta
                  ORDER BY  tb_transacao.trans_dia ASC";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@mes", mes);
            cmd.Parameters.AddWithValue("@ano", ano);
            cmd.Parameters.AddWithValue("@conta", conta);

            SqlDataReader dr = cmd.ExecuteReader();

            List<Extrato> extratos = new List<Extrato>();

            while (dr.Read())
            {
                Extrato extrato = new Extrato();
                extrato.Id = Convert.ToInt32(dr[0]);
                extrato.Data = dr[1].ToString() + "/" + dr[2].ToString() + "/" + dr[3].ToString();
                extrato.Tipo = dr[4].ToString();
                extrato.Categoria = dr[5].ToString();
                extrato.Descricao = dr[6].ToString();
                extrato.Valor = "R$ " + dr[7].ToString().Replace(".", ",");

                extratos.Add(extrato);
            }

            return extratos;
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
    public bool ExcluirTransacao(Int32 transacao)
    {
        query = @"DELETE FROM tb_transacao WHERE trans_id = @transacao";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@transacao", transacao);

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
    public string ExibirSaldoConta(Int32 conta)
    {
        query = @"SELECT cont_saldo FROM tb_conta WHERE cont_id = @conta";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@conta", conta);

            return cmd.ExecuteScalar().ToString();
        }
        catch
        {
            return string.Empty;
        }
        finally
        {
            conn.Close();
        }
    }

    [WebMethod]
    public string RecuperarSenha(string email)
    {
        query = @"SELECT usu_senha FROM tb_usuario WHERE usu_email LIKE @email";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@email", email);

            return cmd.ExecuteScalar().ToString();
        }
        catch
        {
            return string.Empty;
        }
        finally
        {
            conn.Close();
        }
    }

    [WebMethod]
    public string SaldoGeralMesJson(Int32 ano, Int32 usuario)
    {
        query = @"SELECT        tb_transacao.trans_mes, SUM(tb_transacao.trans_valor) AS trans_valor
                    FROM            tb_transacao INNER JOIN
                         tb_conta ON tb_transacao.fk_cont_id = tb_conta.cont_id
                    WHERE        (tb_conta.fk_usu_id = @usuario) AND (tb_transacao.trans_ano = @ano) AND (tb_transacao.fk_tip_id = 4)
                    GROUP BY tb_transacao.trans_mes";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@ano", ano);
            cmd.Parameters.AddWithValue("@usuario", usuario);            
            
            string[] mes = new string[13];
            
            mes[1] = "0";
            mes[2] = "0";
            mes[3] = "0";
            mes[4] = "0";
            mes[5] = "0";
            mes[6] = "0";
            mes[7] = "0";
            mes[8] = "0";
            mes[9] = "0";
            mes[10] = "0";
            mes[11] = "0";
            mes[12] = "0";
            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                mes[Convert.ToInt32(dr[0].ToString())] = dr[1].ToString().Replace(",", ".");
            }
            return "[" + mes[1] + "," + mes[2] + "," + mes[3] + "," + mes[4] + "," + mes[5] + "," + mes[6] + "," + mes[7] + "," + mes[8] + "," + mes[9] + "," + mes[10] + "," + mes[11] + "," + mes[12] + "]";
        }
        catch
        {
            return string.Empty;
        }
        finally
        {
            conn.Close();
        }
    }

    [WebMethod]
    public string CustoGeralMesJson(Int32 ano, Int32 usuario)
    {
        query = @"SELECT        tb_transacao.trans_mes, SUM(tb_transacao.trans_valor) AS trans_valor
                    FROM            tb_transacao INNER JOIN
                         tb_conta ON tb_transacao.fk_cont_id = tb_conta.cont_id
                    WHERE        (tb_conta.fk_usu_id = @usuario) AND (tb_transacao.trans_ano = @ano) AND (tb_transacao.fk_tip_id <> 4)
                    GROUP BY tb_transacao.trans_mes";
        try
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@ano", ano);
            cmd.Parameters.AddWithValue("@usuario", usuario);

            string[] mes = new string[13];

            mes[1] = "0";
            mes[2] = "0";
            mes[3] = "0";
            mes[4] = "0";
            mes[5] = "0";
            mes[6] = "0";
            mes[7] = "0";
            mes[8] = "0";
            mes[9] = "0";
            mes[10] = "0";
            mes[11] = "0";
            mes[12] = "0";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                mes[Convert.ToInt32(dr[0].ToString())] = dr[1].ToString().Replace(",", ".");
            }
            return "[" + mes[1] + "," + mes[2] + "," + mes[3] + "," + mes[4] + "," + mes[5] + "," + mes[6] + "," + mes[7] + "," + mes[8] + "," + mes[9] + "," + mes[10] + "," + mes[11] + "," + mes[12] + "]";
        }
        catch
        {
            return string.Empty;
        }
        finally
        {
            conn.Close();
        }
    }

    private bool ReduzirNaConta(Int32 conta, decimal valor)
    {
        query = @"UPDATE tb_conta SET cont_saldo = (cont_saldo - @valor) WHERE cont_id = @idConta";
        try
        {
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = query;

            cmd2.Parameters.AddWithValue("@valor", valor);
            cmd2.Parameters.AddWithValue("@idConta", conta);

            return (cmd2.ExecuteNonQuery() > 0);
        }
        catch
        {
            return false;
        }        
    }
}
