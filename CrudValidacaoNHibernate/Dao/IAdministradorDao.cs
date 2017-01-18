namespace CrudValidacaoNHibernate.Dao
{
    public interface IAdministradorDao<T>
    {
        void Inserir(T entidade);
        void Alterar(T entidade);
        void Excluir(T entidade);
        T RetornarPorId(int idAdmin);
        

    }
}