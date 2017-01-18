<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastroAdmin.aspx.cs" Inherits="CrudValidacaoNHibernate.WebApp.Administrador.cadastroAdmin" MasterPageFile="~/WebApp/Administrador/administradorMaster.Master" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="cphConteudo">

    <!-- Valida Cadastro Admin ao lado do Usuário -->
    <script type="text/javascript">

        function ValidarCadastro() {
            var nome = document.getElementById("<%=txtNomeAdm.ClientID%>").value;
            var senha = document.getElementById("<%=txtSenhaAdm.ClientID%>").value;
            var repetirSenha = document.getElementById("<%=txtRepetirSenha.ClientID%>").value;

            if (nome == "" || nome == null || nome.length == 0 || !nome.trim()) {
                alert("Digite um nome de Administrador!");

            } else if (nome.length < 8 || nome.length > 20) {
                alert("O campo nome deve conter no mínimo 8 caracteres e no máximo 20 caracteres!");

            } else if (senha == "" || senha == null || senha.length == 0 || !senha.trim()) {
                alert("Digite uma senha de Administrador!");

            } else if (senha.length < 8 || senha.length > 12) {
                alert("A senha deve conter no mínimo 8 caracteres e no máximo 12 caracteres!");

            } else if (repetirSenha == "" || repetirSenha == null || repetirSenha.length == 0) {
                alert("O campo repetir senha não pode ser vazio!");

            } else if (repetirSenha != senha) {
                alert("As senhas não coincidem!");
            }
        }

    </script>

    <form id="form" runat="server">

        <div style="float: right; margin-right: 490px; color: white; margin-top: 350px;">
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtSenhaAdm" ControlToValidate="txtRepetirSenha" ErrorMessage="As senhas não Coincidem!" ForeColor="red" SetFocusOnError="True"></asp:CompareValidator>
        </div>

        <div style="float: left; margin-left: 450px; position: absolute; align-content: center; margin-top: 130px; font-size: 20px;">
            <div style="float: left; width: 250px; margin-left: 190px;">
                <asp:Label ID="labelerro" runat="server" Visible="false" Text=""></asp:Label>
            </div>
        </div>

        <div style="float: left; margin-left: 450px; position: absolute; align-content: center; margin-top: 130px; font-size: 20px;">
            <div style="float: left; width: 250px; margin-left: 190px;">
                <asp:Label ID="Label1" runat="server" Text="Cadastro de Administrador"></asp:Label>
            </div>
        </div>

        <div style="float: left; margin-left: 300px; position: absolute; align-content: center; margin-top: 200px">
            <div style="float: left; width: 180px; margin-left: 190px;">
                <asp:Label ID="Label4" runat="server" Text="Nome do Administrador"></asp:Label>
            </div>

            <div style="float: left; margin-left: 20px;">
                <asp:TextBox ID="txtNomeAdm" runat="server" MaxLength="20" Height="18px" Width="200px" TextMode="SingleLine" ToolTip="Nome do Administrador"></asp:TextBox>
            </div>
        </div>

        <div style="float: left; margin-left: 300px; position: absolute; align-content: center; margin-top: 240px">
            <div style="float: left; width: 180px; margin-left: 190px;">
                <asp:Label ID="Label2" runat="server" Text="Senha do Administrador"></asp:Label>
            </div>

            <div style="float: left; margin-left: 20px;">
                <asp:TextBox ID="txtSenhaAdm" runat="server" Height="18px" MaxLength="12" Width="200px" TextMode="Password" ToolTip="Senha do Administrador"></asp:TextBox>
            </div>
        </div>

        <div style="float: left; margin-left: 300px; position: absolute; align-content: center; margin-top: 280px">
            <div style="float: left; width: 180px; margin-left: 190px;">
                <asp:Label ID="Label3" runat="server" Text="Repetir Senha"></asp:Label>
            </div>

            <div style="float: left; margin-left: 20px;">
                <asp:TextBox ID="txtRepetirSenha" runat="server" Height="18px" MaxLength="12" Width="200px" TextMode="Password" ToolTip="Repetir Senha"></asp:TextBox>
            </div>
        </div>

        <div style="float: left; margin-left: 450px; position: absolute; align-content: center; margin-top: 320px">
            <div style="float: left; margin-left: 140px;">
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" ToolTip="Cadastrar" OnClientClick="return ValidarCadastro();" OnClick="btnCadastrar_Click" />
            </div>

            <div style="float: left; margin-left: 10px;">
                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" ToolTip="Limpar Campos" OnClick="btnLimpar_Click" />
            </div>
        </div>

    </form>
    <!-- fim do form-->

</asp:Content>

