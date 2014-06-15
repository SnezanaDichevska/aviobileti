<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="AvioBileti.Admin.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 611px;
        }
        .style5
        {
            width: 132px;
        }
        .style7
        {
            width: 153px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentSpace" runat="server">
    <table class="nav-justified">
        <tr>
            <td class="style4">
        <asp:GridView ID="gwDestinacii" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="idd" 
                    onrowcancelingedit="gwDestinacii_RowCancelingEdit" 
                    onrowediting="gwDestinacii_RowEditing" onrowupdating="gwDestinacii_RowUpdating" 
                    onselectedindexchanged="gwDestinacii_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:ButtonField CommandName="select" DataTextField="idd" HeaderText="ID" />
                <asp:BoundField DataField="aerodrom" HeaderText="Аеродром" />
                <asp:BoundField DataField="gradd" HeaderText="Град" />
                <asp:CommandField CancelText="Откажи" DeleteText="Избриши" EditText="Уреди" 
                    ShowEditButton="True" UpdateText="Уреди" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
            </td>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style7">
                            ID</td>
                        <td class="style5">
                            <asp:TextBox ID="txtID" runat="server" Width="129px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtID" ErrorMessage="Внесете ID!" ForeColor="Red">Внесете ID!</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Град</td>
                        <td class="style5">
                            <asp:TextBox ID="txtGrad" runat="server" Width="129px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtGrad" ErrorMessage="Внесете град!" ForeColor="Red">Внесете град!</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Аеродром</td>
                        <td class="style5">
                            <asp:TextBox ID="txtAerodrom" runat="server" Width="129px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtAerodrom" ErrorMessage="Внесете аеродром!" 
                                ForeColor="Red">Внесете аеродром!</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                        </td>
                        <td class="style5">
                            <asp:Button ID="btnDodadi" runat="server" onclick="btnDodadi_Click" 
                                Text="Додади" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:GridView ID="gwLetovi" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="idl" onrowcancelingedit="gwLetovi_RowCancelingEdit" 
                    onrowediting="gwLetovi_RowEditing" onrowupdating="gwLetovi_RowUpdating" 
                    onselectedindexchanged="gwLetovi_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonField CommandName="select" DataTextField="idl" HeaderText="IDL" 
                            Text="Button" />
                        <asp:BoundField DataField="datum" HeaderText="Датум" />
                        <asp:BoundField DataField="vremep" HeaderText="Време на полетување" />
                        <asp:BoundField DataField="vremes" HeaderText="Време на слетување" />
                        <asp:BoundField DataField="vremetraenje" HeaderText="Времетраење" />
                        <asp:BoundField DataField="tipAvion" HeaderText="Тип на авион" />
                        <asp:BoundField DataField="cenafix" HeaderText="Цена" />
                        <asp:CommandField CancelText="Откажи" DeleteText="Избриши" EditText="Уреди" 
                            ShowEditButton="True" UpdateText="Уреди" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                <table class="nav-justified">
                    <tr>
                        <td class="style7">
                            IDL</td>
                        <td>
                            <asp:TextBox ID="txtIDL" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Датум</td>
                        <td>
                            <asp:TextBox ID="txtDatum" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Време на полетување</td>
                        <td>
                            <asp:TextBox ID="txtVremeP" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Време на слетување</td>
                        <td>
                            <asp:TextBox ID="txtVremeS" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Времетраење</td>
                        <td>
                            <asp:TextBox ID="txtVremetraenje" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Тип на авион</td>
                        <td>
                            <asp:TextBox ID="txtTipAvion" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Цена</td>
                        <td>
                            <asp:TextBox ID="txtCena" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnDodadiLet" runat="server" onclick="btnDodadiLet_Click" 
                                Text="Додади" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FlightSearchSpace" runat="server">
    <p>
        <br />
    </p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>
