using CrudValidacaoNHibernate.Repositorios;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class alterarAdmin : System.Web.UI.Page
    {
        private Menu_RepositoryAdministrador adminLista;
        protected void Page_Load(object sender, EventArgs e)
        {
            LerGw();
        }

        private void LerGw()
        {
            gwConsulta.Columns[1].HeaderText = "Administradores Cadastrados";
            adminLista = new Menu_RepositoryAdministrador();
            gwConsulta.DataSource = adminLista.Lista();
            gwConsulta.DataBind();
        }

        protected void imgAlt_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("alterarAdmin_.aspx?cod=" + int.Parse(((ImageButton)sender).CommandArgument.ToString()));
        }
    }
}



