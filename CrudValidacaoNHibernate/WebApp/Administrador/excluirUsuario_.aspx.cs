using CrudValidacaoNHibernate.Repositorios;
using System;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class excluirUsuario_ : System.Web.UI.Page
    {
        private Menu_RepositoryUsuario menuLista;
        string codigoUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {   /*codigoUsuario recebe uma string passada pela URL na escolha
             em excluirUsuario.aspx */
            codigoUsuario = Request.QueryString["COD"];
            menuLista = new Menu_RepositoryUsuario();
            CarregaUsuario(codigoUsuario);
        }

        private void CarregaUsuario(string codigoUsuario)
        {
            var lista = menuLista.Lista();

            foreach (var item in lista)
            {
                if (item.ID.ToString() == codigoUsuario)
                {
                    txtNomeUsu.Text = item.nome;
                    txtSenhaUsu.Text = item.senha;
                    txtRepetirSenha.Text = txtSenhaUsu.Text;
                    return;
                }
            }
        }

        protected void Excluir_Click(object sender, EventArgs e)
        {   //Validação vinda do Javascript
            validaExclusão();
        }

        private void validaExclusão()
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                ExcluirContato(codigoUsuario, txtNomeUsu.Text, txtSenhaUsu.Text);
            }
        }

        //Metodo de exclusão
        private void ExcluirContato(string codigoAdmin, string nome, string senha)
        {
            Entidades.Usuario entidade = new Entidades.Usuario();
            entidade.idUsuario = int.Parse(codigoAdmin);
            entidade.nomeUsuario = nome;
            entidade.senhaUsuario = senha;

            menuLista.Excluir(entidade);
            Response.Redirect("menuAdministrador.aspx");
        }
    }
}