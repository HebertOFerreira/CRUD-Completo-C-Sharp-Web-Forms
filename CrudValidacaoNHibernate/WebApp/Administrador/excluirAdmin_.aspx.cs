using CrudValidacaoNHibernate.Repositorios;
using System;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class excluirAdmin_ : System.Web.UI.Page
    {
        private Menu_RepositoryAdministrador adminLista;
        string codigoAdmin;

        protected void Page_Load(object sender, EventArgs e)
        {   /*codigoAdmin recebe uma string passada pela URL na escolha
             em excluirAdmin.aspx */
            codigoAdmin = Request.QueryString["COD"];
            adminLista = new Menu_RepositoryAdministrador();
            CarregaAdmin(codigoAdmin);
        }

        private void CarregaAdmin(string codigoAdmin)
        {
            var lista = adminLista.Lista();

            foreach (var item in lista)
            {
                if (item.ID.ToString() == codigoAdmin)
                {
                    txtNomeAdm.Text = item.nome;
                    txtSenhaAdm.Text = item.senha;
                    txtRepetirSenha.Text = txtSenhaAdm.Text;
                    return;
                }
            }
        }

        protected void Exluir_Click(object sender, EventArgs e)
        {   //Validação vinda do Javascript MasterPage
            ConfirmaExclusao();
        }

        private void ConfirmaExclusao()
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                ExcluirContato(codigoAdmin, txtNomeAdm.Text, txtSenhaAdm.Text);
            }
        }

        //Metodo de exclusão
        private void ExcluirContato(string codigoAdmin, string nome, string senha)
        {
            Entidades.Administrador entidade = new Entidades.Administrador();
            entidade.idAdmin = int.Parse(codigoAdmin);
            entidade.nomeAdmin = nome;
            entidade.senhaAdmin = senha;

            adminLista.Excluir(entidade);
            Response.Redirect("menuAdministrador.aspx");
        }
    }
}