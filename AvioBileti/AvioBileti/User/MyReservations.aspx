<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyReservations.aspx.cs" Inherits="AvioBileti.User.MyReservations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentSpace" runat="server">
    <h2><asp:Label ID="lblKorisnikLista" runat="server" Text="Листа на резервации за корисникот Име Презиме"></asp:Label></h2>
    <asp:GridView ID="gvRezervacii" runat="server" CellPadding="5" 
        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
        CellSpacing="5">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="IDB" HeaderText="Број на билет" />
            <asp:BoundField DataField="name" HeaderText="Име" />
            <asp:BoundField DataField="surname" HeaderText="Презиме" />
            <asp:BoundField DataField="pojdovna" HeaderText="Од" />
            <asp:BoundField DataField="krajna" HeaderText="До" />
            <asp:BoundField DataField="date" HeaderText="Датум" />
            <asp:BoundField DataField="price" HeaderText="Цена" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>
