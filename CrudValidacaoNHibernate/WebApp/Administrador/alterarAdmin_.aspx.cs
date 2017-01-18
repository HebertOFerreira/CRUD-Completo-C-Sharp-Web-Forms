using CrudValidacaoNHibernate.Repositorios;
using System;
using System.Web.UI;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class alterarAdmin_ : System.Web.UI.Page
    {
        private Menu_RepositoryAdministrador adminLista;
        string codigoAdmin;

        protected void Page_Load(object sender, EventArgs e)
        {   /*codigoAdmin recebe uma string passada pela URL na escolha
             em excluirAdmin.aspx */
            codigoAdmin = Request.QueryString["COD"];
            adminLista = new Menu_RepositoryAdministrador();

            if (!Page.IsPostBack)
            {
                CarregaAdmin(codigoAdmin);
            }

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

        protected void Alterar_Click(object sender, EventArgs e)
        {
            string nome = txtNomeAdm.Text;
            string senha = txtSenhaAdm.Text;
            string repetirSenha = txtRepetirSenha.Text;
            ValidarAlteracao(nome, senha, repetirSenha);

        }

        //Valida Admin ao lado do Servidor
        private void ValidarAlteracao(string nome, string senha, string repetirSenha)
        {
            if (nome == "" || nome == null || nome.Trim().Length == 0)
            {
                labelerro.Text = "Nome não pode ser vazio ou nulo";
            }
            else if (senha == "" || senha == null || senha.Trim().Length == 0)
            {
                labelerro.Text = "A senha não pode ser vazia ou nulo";
            }
            else if (repetirSenha == "" || repetirSenha == null || repetirSenha.Trim().Length == 0)
            {
                labelerro.Text = "Repetir senha não pode ser vazio ou nulo";
            }
            else if (nome.Length < 8 || nome.Length > 20)
            {
                labelerro.Text = "O nome deve possuir no minimo 8 caracteres e no máximo 20 caracteres!";
            }
            else if (senha.Length < 8 || senha.Length > 20)
            {
                labelerro.Text = "A senha deve possuir no minimo 8 caracteres e no máximo 12 caracteres!";
            }
            else if (senha != repetirSenha)
            {
                labelerro.Text = "As senhas não coincidem!";
            }
            else
            { //Validação vinda do Javascript
                ConfirmaAlteracao();
            }
        }

        private void ConfirmaAlteracao()
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                AlterarContato(codigoAdmin, txtNomeAdm.Text, txtSenhaAdm.Text);
            }
        }

        private void AlterarContato(string codigoAdmin, string nome, string senha)
        {
            Entidades.Administrador entidade = new Entidades.Administrador();
            entidade.idAdmin = int.Parse(codigoAdmin);
            entidade.nomeAdmin = nome;
            entidade.senhaAdmin = senha;

            adminLista.Alterar(entidade);
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "sucesso", "alert('Cadastro alterado com Sucesso!')", true);

        }
    }
}