namespace CrudValidacaoNHibernate.Entidades
{
    public class Usuario
    {
        public virtual int idUsuario { get; set; }
        // public virtual int idAdmin { get; set; }
        public virtual string nomeUsuario { get; set; }
        public virtual string senhaUsuario { get; set; }
        public virtual Administrador administrador { get; set; }

    }
}