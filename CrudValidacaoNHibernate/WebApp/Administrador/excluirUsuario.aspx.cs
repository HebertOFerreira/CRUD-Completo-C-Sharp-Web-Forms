using CrudValidacaoNHibernate.Repositorios;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class excluirUsuario : System.Web.UI.Page
    {
        private Menu_RepositoryUsuario usuarioLista;
        protected void Page_Load(object sender, EventArgs e)
        {
            LerGw();
        }

        private void LerGw()
        {   //Select no banco passando os dados na gridView
            gwConsulta.Columns[1].HeaderText = "Usuários Cadastrados";
            usuarioLista = new Menu_RepositoryUsuario();
            gwConsulta.DataSource = usuarioLista.Lista();
            gwConsulta.DataBind();
        }

        protected void imgExcluir_Click(object sender, ImageClickEventArgs e)
        {
            //Pega o usuário clicado e passa a id via url para página excluirUsuario
            Response.Redirect("excluirUsuario_.aspx?cod=" + int.Parse(((ImageButton)sender).CommandArgument.ToString()));
        }
    }
}