using CrudValidacaoNHibernate.Repositorios;
using System;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class listarUsuario : System.Web.UI.Page
    {
        private Menu_RepositoryUsuario usuarioLista;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Select no banco passando os dados na gridView
            gwConsulta.Columns[1].HeaderText = "Usuários Cadastrados";
            usuarioLista = new Menu_RepositoryUsuario();
            gwConsulta.DataSource = usuarioLista.Lista();
            gwConsulta.DataBind();
        }
    }
}