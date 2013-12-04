<%@ Page Title="Контакти" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>За контакти.</h3>
    <address>
        Пловдив<br />
        бул. "Васил Априлов" Nо38<br />
        <abbr title="Phone">P:</abbr>
        0898765456
    </address>

    <address>
        <strong>Подръжка:</strong>   <a href="mailto:Support@gmail.com">Support@gmail.com</a><br />
        <strong>Маркетинг:</strong> <a href="mailto:Marketing@gmail.com">Marketing@gmail.com</a>
    </address>
</asp:Content>
