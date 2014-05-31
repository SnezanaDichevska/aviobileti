<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="MyProfile.aspx.cs" Inherits="AvioBileti.User.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentSpace" runat="server">
    <table class="profile">  
        <tr>
            <th>
                <h1>
                    <asp:Label ID="lblImePrezime" runat="server" Text="Ime Prezime"></asp:Label></h1>
            </th>
        </tr>
        <tr>
            <td>
                <h3>
                    <asp:Label ID="lblKorisnickoIme" runat="server" Text="(KorisnickoIme)"></asp:Label></h3>
            </td>
        </tr>
        <tr>
            <td>
                <i><p><asp:Label ID="lblAdresa" runat="server" Text="Adresa Adresa Adresa Adresa Adresa <br>Adresa Adresa Adresa"></asp:Label></p></i>
            </td>
        </tr>
        <tr>
           <td>
           <i><asp:Label ID="lblBroj" runat="server" Text="00123 456 789"></asp:Label></i>
           </td>
        </tr>
        <tr>
            <td>
                <h4><asp:Label ID="lblEmail" runat="server" Text="blabla@drndrn.com"></asp:Label></h4>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>
