using CrudValidacaoNHibernate.Repositorios;
using System;
using System.Web.UI;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class cadastroAdmin : System.Web.UI.Page
    {
        Entidades.Administrador entidade;
        Menu_RepositoryAdministrador rpa;

        protected void Page_Load(object sender, EventArgs e)
        {
            entidade = new Entidades.Administrador();
            try
            {
                rpa = new Menu_RepositoryAdministrador();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro, informe ao Administrador do site" + ex.Message);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNomeAdm.Text;
            string senha = txtSenhaAdm.Text;
            string repetirSenha = txtRepetirSenha.Text;

            validarCadastro(nome, senha, repetirSenha);
        }

        //Valida Admin ao lado do Servidor
        private void validarCadastro(string nome, string senha, string repetirSenha)
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
            {
                CadastrarAdminitrador();
            }
        }

        //Cadastra o administrador no banco de dados caso as validações estejam de acordo
        private void CadastrarAdminitrador()
        {
            entidade.nomeAdmin = txtNomeAdm.Text;
            entidade.senhaAdmin = txtSenhaAdm.Text;
            rpa.Inserir(entidade);

            //Alerta o cadastro com sucesso
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "sucesso", "alert('Administrador Cadastrado com Sucesso!')", true);
            Limpar();

        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        //limpa os campos
        private void Limpar()
        {
            txtNomeAdm.Text = string.Empty;
            txtSenhaAdm.Text = string.Empty;
            txtRepetirSenha.Text = string.Empty;
        }
    }
}