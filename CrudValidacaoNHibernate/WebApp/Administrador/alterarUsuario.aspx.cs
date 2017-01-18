using CrudValidacaoNHibernate.Repositorios;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class alterarUsuario : System.Web.UI.Page
    {
        private Menu_RepositoryUsuario usuarioLista;
        protected void Page_Load(object sender, EventArgs e)
        {
            LerGw();
        }

        private void LerGw()
        {
            gwConsulta.Columns[1].HeaderText = "Usuários Cadastrados";
            usuarioLista = new Menu_RepositoryUsuario();
            gwConsulta.DataSource = usuarioLista.Lista();
            gwConsulta.DataBind();
        }

        protected void imgAlt_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("alterarUsuario_.aspx?cod=" + int.Parse(((ImageButton)sender).CommandArgument.ToString()));
        }
    }
}