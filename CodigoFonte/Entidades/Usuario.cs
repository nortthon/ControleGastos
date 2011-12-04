using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Usuario
    {
        private Int32 usu_id;
        public Int32 Usu_id
        {
            get { return usu_id; }
            set { usu_id = value; }
        }

        private string usu_nome;
        public string Usu_nome
        {
            get { return usu_nome; }
            set { usu_nome = value; }
        }

        private string usu_email;
        public string Usu_email
        {
            get { return usu_email; }
            set { usu_email = value; }
        }

        private string usu_login;
        public string Usu_login
        {
            get { return usu_login; }
            set { usu_login = value; }
        }

        private string usu_senha;
        public string Usu_senha
        {
            get { return usu_senha; }
            set { usu_senha = value; }
        }

        private Int32 usu_status;
        public Int32 Usu_status
        {
            get { return usu_status; }
            set { usu_status = value; }
        }


    }
}
