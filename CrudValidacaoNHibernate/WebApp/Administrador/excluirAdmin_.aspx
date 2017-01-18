<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="excluirAdmin_.aspx.cs" Inherits="CrudValidacaoNHibernate.WebApp.Administrador.excluirAdmin_" MasterPageFile="~/WebApp/Administrador/administradorMaster.Master" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="cphConteudo">

    <form id="form" runat="server">

        <div style="float: left; margin-left: 450px; position: absolute; align-content: center; margin-top: 130px; font-size: 20px;">
            <div style="float: left; width: 250px; margin-left: 190px;">
                <asp:Label ID="Label1" runat="server" Text="Excluír Administrador"></asp:Label>
            </div>
        </div>

        <div style="float: left; margin-left: 300px; position: absolute; align-content: center; margin-top: 200px">
            <div style="float: left; width: 180px; margin-left: 190px;">
                <asp:Label ID="Label4" runat="server" Text="Nome do Administrador"></asp:Label>
            </div>

            <div style="float: left; margin-left: 20px;">
                <asp:TextBox ID="txtNomeAdm" runat="server" ReadOnly="true" Height="18px" Width="200px" TextMode="SingleLine" ToolTip="Nome do Administrador"></asp:TextBox>
            </div>
        </div>

        <div style="float: left; margin-left: 300px; position: absolute; align-content: center; margin-top: 240px">
            <div style="float: left; width: 180px; margin-left: 190px;">
                <asp:Label ID="Label2" runat="server" Text="Senha do Administrador"></asp:Label>
            </div>

            <div style="float: left; margin-left: 20px;">
                <asp:TextBox ID="txtSenhaAdm" runat="server" ReadOnly="true" Height="18px" Width="200px" TextMode="SingleLine" ToolTip="Senha do Administrador"></asp:TextBox>
            </div>
        </div>

        <div style="float: left; margin-left: 300px; position: absolute; align-content: center; margin-top: 280px">
            <div style="float: left; width: 180px; margin-left: 190px;">
                <asp:Label ID="Label3" runat="server" Text="Repetir Senha"></asp:Label>
            </div>

            <div style="float: left; margin-left: 20px;">
                <asp:TextBox ID="txtRepetirSenha" runat="server" ReadOnly="true" Height="18px" Width="200px" TextMode="SingleLine" ToolTip="Repetir Senha"></asp:TextBox>
            </div>
        </div>

        <div style="float: right; width: 30px; margin-top: 320px; margin-right: 570px;">
            <asp:Button ID="Excluir" runat="server" ToolTip="Excluir" Text="Excluir" OnClientClick="return ConfirmaExclusao();" OnClick="Exluir_Click" />
        </div>

    </form>
    <!-- fim do form-->

</asp:Content>
