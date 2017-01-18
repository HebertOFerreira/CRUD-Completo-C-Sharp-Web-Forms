using CrudValidacaoNHibernate.Entidades;
using FluentNHibernate.Mapping;

namespace CrudValidacaoNHibernate.mapping
{
    public class UsuarioMapping : ClassMap<Usuario>
    {
        //Construtor
        public UsuarioMapping()
        {
            Id(x => x.idUsuario);
            Map(x => x.nomeUsuario).Not.Nullable().Length(20);
            Map(x => x.senhaUsuario).Not.Nullable().Length(12);

            //1 X N
            References(x => x.administrador).Columns("idAdmin").Class<Administrador>();
            Table("Usuario");
        }

    }
}



