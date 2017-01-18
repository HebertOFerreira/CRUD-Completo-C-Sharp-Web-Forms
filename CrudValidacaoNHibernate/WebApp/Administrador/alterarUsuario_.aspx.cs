using CrudValidacaoNHibernate.Repositorios;
using System;
using System.Web.UI;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class alterarUsuario_ : System.Web.UI.Page
    {
        private Menu_RepositoryUsuario usuarioLista;
        string codigoUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {   /*codigoUsuario recebe uma string passada pela URL na escolha
             em excluirAdmin.aspx */
            codigoUsuario = Request.QueryString["COD"];
            usuarioLista = new Menu_RepositoryUsuario();

            if (!Page.IsPostBack)
            {
                CarregaUsuario(codigoUsuario);
            }

        }

        private void CarregaUsuario(string codigoUsuario)
        {
            var lista = usuarioLista.Lista();

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

        protected void Alterar_Click(object sender, EventArgs e)
        {
            string nome = txtNomeUsu.Text;
            string senha = txtSenhaUsu.Text;
            string repetirSenha = txtRepetirSenha.Text;
            ValidarAlteracao(txtNomeUsu.Text, txtSenhaUsu.Text,txtRepetirSenha.Text);
        }

        //Valida Admin ao lado do Cliente
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
            else if (repetirSenha == "" || repetirSenha == null || repetirSenha.Length == 0)
            {
                labelerro.Text = "Repetir senha não pode ser vazio ou nulo";
            }
            if (nome.Length < 8 || nome.Length > 20)
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
            {
                //Validação vinda do Javascript
                ConfirmaAlteracao();
            }
        }


        private void ConfirmaAlteracao()
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                AlterarContato(codigoUsuario, txtNomeUsu.Text, txtSenhaUsu.Text);
            }
        }

        private void AlterarContato(string codigoAdmin, string nome, string senha)
        {
            Entidades.Usuario entidade = new Entidades.Usuario();
            entidade.idUsuario = int.Parse(codigoUsuario);
            entidade.nomeUsuario = nome;
            entidade.senhaUsuario = senha;

            usuarioLista.Alterar(entidade);
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "sucesso", "alert('Cadastro alterado com Sucesso!')", true);
        }
    }
}
