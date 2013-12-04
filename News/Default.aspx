<%@ Page Title="Начало" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    </div>
    <div>
        <asp:Label ID="lblMsg" runat="server" Text="" Visible="false"></asp:Label><br />
        <asp:HyperLink ID="btnNew" runat="server" href="editNews.aspx?id=-1">Добави новина</asp:HyperLink>
    </div>
    <div class="row">

         <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" >
          <ItemTemplate>
              <div class="col-md-4">
                <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("Id") %>' />
                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>' CssClass="Title"></asp:Label><br />
                <asp:TextBox ID="lblTexts" runat="server" Text='<%# Eval("Texts") %>' TextMode="MultiLine" Width="350px" Height="80px" CssClass="userView" Enabled="false"></asp:TextBox><br />
                <asp:HyperLink ID="btnEdit" runat="server" href='<%# Eval("Id","editNews.aspx?id={0}") %>'>Редактирай</asp:HyperLink>
                <asp:HyperLink ID="btnMore" runat="server" href='<%# Eval("Id","editNews.aspx?id={0}&v=1") %>'>Още...</asp:HyperLink>
            </div>
          </ItemTemplate>
      </asp:Repeater>

    </div>

</asp:Content>
