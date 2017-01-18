using CrudValidacaoNHibernate.Repositorios;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class excluirAdmin : System.Web.UI.Page
    {
        private Menu_RepositoryAdministrador adminLista;
        protected void Page_Load(object sender, EventArgs e)
        {
            LerGw();

        }

        private void LerGw()
        {    //Select no banco passando os dados na gridView
            gwConsulta.Columns[1].HeaderText = "Administradores Cadastrados";
            adminLista = new Menu_RepositoryAdministrador();
            gwConsulta.DataSource = adminLista.Lista();
            gwConsulta.DataBind();

        }

        protected void imgExcluir_Click(object sender, ImageClickEventArgs e)

        {   //Pega o usuário clicado e passa a id via url para página excluirAdmin
            Response.Redirect("excluirAdmin_.aspx?cod=" + int.Parse(((ImageButton)sender).CommandArgument.ToString()));
        }
    }
}