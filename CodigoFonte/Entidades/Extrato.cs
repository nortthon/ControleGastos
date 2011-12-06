using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Extrato
    {
        private Int32 id;
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private string data;
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private string categoria;
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private string descricao;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private string valor;
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }
    }
}
