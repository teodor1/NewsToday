<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="editNews.aspx.cs" Inherits="editNews" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="center">
        <br />
        <br />
        <br />
        <asp:Label ID="lblMsg" runat="server" Text="" Visible="false"></asp:Label><br />
        <asp:HiddenField ID="hfId" runat="server" />
        <asp:TextBox ID="tbTitle" runat="server" Width="500px"></asp:TextBox><br />
        <asp:TextBox ID="tbTexts" runat="server" TextMode="MultiLine" Width="500px" Height="250px"></asp:TextBox><br />
        <asp:Button ID="btnDelete" runat="server" Text="Изтрий" OnClick="btnDelete_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Запази" OnClick="btnSave_Click" />
    </div>
</asp:Content>

