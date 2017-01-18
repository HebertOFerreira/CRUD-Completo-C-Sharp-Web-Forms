using CrudValidacaoNHibernate.Repositorios;
using System;
using System.Web.UI;
using static CrudValidacaoNHibernate.WebApp.login;

namespace CrudValidacaoNHibernate.WebApp.Administrador
{
    public partial class cadastroUsuario : System.Web.UI.Page
    {
        Entidades.Usuario entidade;
        Menu_RepositoryUsuario rpu;

        //Como a entidade usuário possui uma idAdmin e está sendo mapeada
        //é preciso chamar a classe admin, passando a id dessa classe o login da tela principal
        Menu_RepositoryAdministrador rpa;

        protected void Page_Load(object sender, EventArgs e)
        {
            entidade = new Entidades.Usuario();
            entidade.administrador = new Entidades.Administrador();

            try
            {
                rpa = new Menu_RepositoryAdministrador();
                rpu = new Menu_RepositoryUsuario();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro, informe ao Administrador do site" + ex.Message);
            }

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNomeUsu.Text;
            string senha = txtSenhaUsu.Text;
            string repetirSenha = txtRepetirSenha.Text;

            validarCadastro(nome, senha, repetirSenha);
        }

        //Valida Admin ao lado do Servidor
        private void validarCadastro(string nome, string senha, string repetirSenha)
        {
            if (nome == "" || nome == null)
            {
                labelerro.Text = "Nome não pode ser vazio ou nulo";
            }
            else if (senha == "" || senha == null)
            {
                labelerro.Text = "A senha não pode ser vazia ou nulo";
            }
            else if (repetirSenha == "" || repetirSenha == null)
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
                CadastrarUsuarios();
            }
        }

        private void CadastrarUsuarios()
        {
            //idLogin recebe a classe mostrarlogado da tela de login
            int idLogin = mostrarLogado.ID;

            var idAdministrador = rpa.Lista();

            //Aqui a entidade administrador idLogin recebe o administrador validado na tela de login
            foreach (var item in idAdministrador)
            {
                if (idLogin == item.ID)
                {
                    entidade.administrador.idAdmin = idLogin;
                    entidade.nomeUsuario = txtNomeUsu.Text;
                    entidade.senhaUsuario = txtSenhaUsu.Text;
                    rpu.Inserir(entidade);

                    //Alerta o cadastro com sucesso
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "sucesso", "alert('Usuário Cadastrado com Sucesso!')", true);
                    Limpar();
                    return;
                }
            }
        }

        //limpa os campos
        private void Limpar()
        {
            txtNomeUsu.Text = string.Empty;
            txtSenhaUsu.Text = string.Empty;
            txtRepetirSenha.Text = string.Empty;

        }
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}




