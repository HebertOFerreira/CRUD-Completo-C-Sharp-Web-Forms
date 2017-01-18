using System.Collections.Generic;

namespace CrudValidacaoNHibernate.Entidades
{
    public class Administrador
    {
        public virtual int idAdmin { get; set; }
        public virtual string nomeAdmin { get; set; }
        public virtual string senhaAdmin { get; set; }

        public virtual IList<Usuario> usuarios { get; set; }

        public Administrador()
        {
            usuarios = new List<Usuario>();
        }


    }
}