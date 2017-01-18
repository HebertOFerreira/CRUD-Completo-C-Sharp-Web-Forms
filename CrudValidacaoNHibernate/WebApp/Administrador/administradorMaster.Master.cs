using System;
using System.Web;
using System.Web.Security;
using static CrudValidacaoNHibernate.WebApp.login;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class administradorMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LabelAdm.Text = "Seja bem vindo: ";

            //Recebe a classe mostrar Logado da tela de login, pegando o valor do administrador logado
            LabelID.Text = mostrarLogado.nomeUsuario;
            GravandoDadosCookie(LabelID.Text);

        }

        private void GravandoDadosCookie(string nomeCookie)
        {
            // Verificando se já existe o cookie na máquina do usuário
            HttpCookie cookie = Request.Cookies[nomeCookie];
            if (cookie == null)
            {
                // Criando a Instância do cookie
                cookie = new HttpCookie(nomeCookie);
                //Adicionando a propriedade "Nome" no cookie
                cookie.Values.Add("valorNome", LabelID.Text);
                cookie.Expires = DateTime.Now.AddHours(1);
                // Definindo a segurança do nosso cookie
                cookie.HttpOnly = true;
                // Registrando cookie
                this.Page.Response.AppendCookie(cookie);

            }
        }

        protected void button_ServerClick(object sender, EventArgs e)
        {

            RemoverCookie(LabelID.Text);

        }

        private void RemoverCookie(string nomeCookie)
        {
            Response.Cookies[nomeCookie].Expires = DateTime.Now.AddHours(-1);

            FormsAuthentication.SignOut();
            Response.Redirect("../login.aspx");
        }
    }
}




