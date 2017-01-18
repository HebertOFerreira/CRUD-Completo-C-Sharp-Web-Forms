using CrudValidacaoNHibernate.Repositorios;
using System;
using System.Web.Security;

namespace CrudValidacaoNHibernate.WebApp
{
    public partial class login : System.Web.UI.Page
    {
        Menu_RepositoryAdministrador rpa;

        protected void Page_Load(object sender, EventArgs e)
        {
            rpa = new Menu_RepositoryAdministrador();
        }

        //Classe que repassa o ID e nome do Usuário quando logado
        public static class mostrarLogado
        {
            public static int ID { get; set; }
            public static string nomeUsuario { get; set; }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            ValidarLogin();

        }

        private void ValidarLogin()
        {
            var listar = rpa.Lista();

            foreach (var item in listar)
            {
                if ((item.nome.TrimEnd() == txtNomeUsuario.Text) && (item.senha.TrimEnd() == txtSenhaUsuario.Text))
                {
                    mostrarLogado.ID = item.ID;
                    mostrarLogado.nomeUsuario = item.nome;

                    //Autenticação da página pelo WebConfig
                    FormsAuthentication.RedirectFromLoginPage(mostrarLogado.nomeUsuario, true);

                    //MenuAdministrador Recebe o ID e o nome do Usuário Validado
                    Response.Redirect("Administrador/menuAdministrador.aspx");
                    return;
                }
                else
                {
                    //Válida ao Lado do Servidor
                    ErroLogin();
                }
            }
        }

        private void ErroLogin()
        {
            try
            {
                Label3.Text = "Usuário ou senha inválido(s)";

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}