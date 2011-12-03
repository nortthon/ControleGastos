using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Conta
    {
        private int cont_id;
        public int Cont_id
        {
            get { return cont_id; }
            set { cont_id = value; }
        }

        private string cont_nome;
        public string Cont_nome
        {
            get { return cont_nome; }
            set { cont_nome = value; }
        }

        private decimal cont_saldo;
        public decimal Cont_saldo
        {
            get { return cont_saldo; }
            set { cont_saldo = value; }
        }

        private string cont_descricao;
        public string Cont_descricao
        {
            get { return cont_descricao; }
            set { cont_descricao = value; }
        }

        private int fk_usu_id;
        public int Fk_usu_id
        {
            get { return fk_usu_id; }
            set { fk_usu_id = value; }
        }

        private Usuario usuario;
        internal Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
    }
}
