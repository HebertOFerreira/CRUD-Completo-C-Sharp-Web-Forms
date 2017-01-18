<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listarAdmin.aspx.cs" Inherits="CrudValidacaoNHibernate.WebApp.Administrador.listarAdmin" MasterPageFile="~/WebApp/Administrador/administradorMaster.Master" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="cphConteudo">

    <div style="margin-top: 170px; float: left; margin-left: 290px;">
        <form id="form1" runat="server">
            <asp:GridView ID="gwConsulta" runat="server" Height="139px" Width="500px" CellPadding="3" GridLines="Horizontal"
                BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" AllowPaging="True" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="#F7F7F7" />

                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="nome">
                        <ItemStyle ForeColor="Black" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </form>
    </div>

</asp:Content>
