using CrudValidacaoNHibernate.Repositorios;
using System;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class listarAdmin : System.Web.UI.Page
    {
        private Menu_RepositoryAdministrador adminLista;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Select no banco passando os dados na gridView
            gwConsulta.Columns[1].HeaderText = "Administradores Cadastrados";
            adminLista = new Menu_RepositoryAdministrador();
            gwConsulta.DataSource = adminLista.Lista();
            gwConsulta.DataBind();

        }
    }
}