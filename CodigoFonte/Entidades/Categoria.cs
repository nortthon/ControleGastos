using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Categoria
    {
        private Int32 cat_id;
        public Int32 Cat_id
        {
            get { return cat_id; }
            set { cat_id = value; }
        }

        private string cat_nome;
        public string Cat_nome
        {
            get { return cat_nome; }
            set { cat_nome = value; }
        }

        private Int32 fk_usu_id;
        public Int32 Fk_usu_id
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
