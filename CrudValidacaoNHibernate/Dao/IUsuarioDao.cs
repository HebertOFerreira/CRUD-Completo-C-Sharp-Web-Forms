namespace CrudValidacaoNHibernate.Dao
{
    public interface IusuarioDao<T>
    {
        void Inserir(T entidade);
        void Alterar(T entidade);
        void Excluir(T entidade);
        T RetornarPorId(int idUsuario);


    }
}