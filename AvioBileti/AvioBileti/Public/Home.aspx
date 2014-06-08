<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="AvioBileti.Public.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentSpace" runat="server">
    <h2><asp:Label ID="Label1" runat="server" Text="Преглед на сите летови"></asp:Label></h2>
    <asp:GridView ID="gvLetovi" runat="server" CellPadding="5" 
    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
        CellSpacing="5" DataKeyNames="IDL" 
        onselectedindexchanged="gvLetovi_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="pojdovna" HeaderText="Тргнување од :" />
            <asp:BoundField DataField="krajna" HeaderText="Одење до :" />
            <asp:BoundField DataField="date" HeaderText="Датум :" />
            <asp:BoundField DataField="vremep" HeaderText="Време на поаѓање :" />
            <asp:BoundField DataField="vremes" HeaderText="Време на пристигање :" />
            <asp:BoundField DataField="price" HeaderText="Цена :" />
            <asp:CommandField SelectText="Резервирај" ShowSelectButton="True" />
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
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>
