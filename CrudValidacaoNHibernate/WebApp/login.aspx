<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CrudValidacaoNHibernate.WebApp.login" MasterPageFile="~/WebApp/defaultMaster.Master" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="cphConteudo">
   
     <!-- Valida o Login -->
    <script type="text/javascript">
        function ValidarLogin() {
            var nome = document.getElementById("<%=txtNomeUsuario.ClientID%>").value;
            var senha = document.getElementById("<%=txtSenhaUsuario.ClientID%>").value;

            if (nome == "" || nome == null) {
                alert("Digite um nome de Usuário!")
            } else if (senha == "" || senha == null) {
                alert("Digite uma senha de Usuário!")
            }
        }
    </script>

    <form id="form" runat="server">

        <div style="float: left; margin-left: 200px; position: absolute; align-content: center; margin-top: 400px; font-size: 12px; color: red;">
            <div style="float: left; width: 200px; margin-left: 190px;">
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            </div>
        </div>

        <div style="float: left; margin-left: 215px; position: absolute; align-content: center; margin-top: 150px; font-size: 20px;">
            <div style="float: left; width: 150px; margin-left: 190px;">
                <asp:Label ID="Label1" runat="server" Text="Faça o Login"></asp:Label>
            </div>
        </div>

        <div style="float: left; margin-left: 220px; position: absolute; align-content: center; margin-top: 200px">
            <div style="float: left; width: 150px; margin-left: 190px;">
                <asp:Label ID="Label4" runat="server" Text="Nome do Usuário"></asp:Label>
            </div>
            <br />

            <div style="float: left; margin-left: 140px;">
                <asp:TextBox ID="txtNomeUsuario" ClientIDMode="Static" runat="server" Height="18px" Width="200px" TextMode="SingleLine" ToolTip="Nome do Usuário"></asp:TextBox>
            </div>
        </div>

        <div style="float: left; margin-left: 220px; position: absolute; align-content: center; margin-top: 270px">
            <div style="float: left; width: 150px; margin-left: 190px;">
                <asp:Label ID="Label2" runat="server" Text="Senha do Usuário"></asp:Label>
            </div>
            <br />

            <div style="float: left; margin-left: 140px;">
                <asp:TextBox ID="txtSenhaUsuario" runat="server" ClientIDMode="Static" Height="18px" Width="200px" TextMode="Password" ToolTip="Senha do Usuário"></asp:TextBox>
            </div>
        </div>

        <div style="float: left; margin-left: 300px; position: absolute; align-content: center; margin-top: 340px">
            <div style="float: left; margin-left: 140px;">
                <asp:Button ID="btnEntrar" runat="server" Text="Entrar" ToolTip="Entrar" OnClientClick="return ValidarLogin();" OnClick="btnEntrar_Click" />
            </div>
        </div>
        <ASP:CheckBox id="chkPersistCookie" runat="server" autopostback="false"  Visible="false"/>

    </form>
    <!-- fim do form -->

</asp:Content>
