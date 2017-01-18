using CrudValidacaoNHibernate.mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.SqlAzure;
using System.Configuration;

namespace CrudValidacaoNHibernate.Conexao
{
    public class FluentySessionFactory
    {
        //string de conexão com o servidor
        private static string ConnectionString = @"Server=tcp:bdbase.database.windows.net,1433;Initial Catalog=bdbase;Persist Security Info=False;User ID={administrador};Password={hof123@456};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
       // private static string ConnectionString = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;

        private static ISessionFactory session; 

        public static ISessionFactory CriarSessao()
        {
            if (session != null) 
                return session;

            //Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).Driver<SqlAzureClientDriver>());

            IPersistenceConfigurer configDB = (MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).Driver<SqlAzureClientDriver>()); 

            var configMap = Fluently.Configure().Database(configDB).Mappings(c => c.FluentMappings.AddFromAssemblyOf<AdministradorMapping>());
          
            //Seta as configuração e automaticamente abre o bd
            session = configMap.BuildSessionFactory(); 

            return session;
        }
        
        //Metodo que abre a sessão
        public static ISession AbrirSessao() 
        {
            return CriarSessao().OpenSession(); 
        }
    }
}