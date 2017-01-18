using CrudValidacaoNHibernate.Conexao;
using CrudValidacaoNHibernate.Dao;
using CrudValidacaoNHibernate.Entidades;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;

namespace CrudValidacaoNHibernate.Repositorios
{

    public class MenuItem
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
    }

    //Fases do CRUD
    public class RepositoryAdministradorDao<T> : IAdministradorDao<T> where T : class
    {

        public void Alterar(T entidade)
        {
            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }

                        throw new Exception("Erro ao atualizar" + e.Message);
                    }
                }
            }
        }

        public void Excluir(T entidade)
        {
            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entidade);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }

                        throw new Exception("Erro ao Deletarr" + e.Message);
                    }
                }
            }
        }

        public void Inserir(T entidade)
        {
            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }

                        throw new Exception("Erro ao Inserir" + e.Message);
                    }
                }
            }
        }

        public T RetornarPorId(int idAdmin)
        {
            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                return session.Get<T>(idAdmin);
            }
        }

        public MenuItem[] Lista() //Array para receber a quantidade de entradas de cadastros no banco
        {
            using (var session = FluentySessionFactory.AbrirSessao())
            {
                var query = session.Query<Administrador>().Select(x => new MenuItem
                {
                    ID = x.idAdmin,
                    nome = x.nomeAdmin,
                    senha = x.senhaAdmin

                }); //select no banco repassando para a array

                return query.ToArray();
            }
        }
    }
}