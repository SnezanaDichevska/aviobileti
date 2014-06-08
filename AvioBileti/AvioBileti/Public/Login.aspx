<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="AvioBileti.Public.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentSpace" runat="server">
    <asp:Label ID="lblAccessMessage" runat="server" Font-Bold="True" 
        ForeColor="Red"></asp:Label>
    <br />
    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    <br />
    <asp:Label ID="lblUsername" runat="server" Text="Корисничко име:"></asp:Label>
    <br />
    <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Лозинка:"></asp:Label>
    <br />
    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Најава" />
    &nbsp;<br />
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>
