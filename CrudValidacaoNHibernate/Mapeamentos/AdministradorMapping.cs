using CrudValidacaoNHibernate.Entidades;
using FluentNHibernate.Mapping;

namespace CrudValidacaoNHibernate.mapping
{
    //Criando os mapeamentos da entidade Administrador com FluentNHibernate
    public class AdministradorMapping : ClassMap<Administrador>
    {
        //Construtor
        public AdministradorMapping()
        {
            Id(x => x.idAdmin).Not.Nullable();
            Map(x => x.nomeAdmin).Not.Nullable().Length(20);
            Map(x => x.senhaAdmin).Not.Nullable().Length(12);
            HasMany(x => x.usuarios);
            Table("Administrador");
        }
    }
}