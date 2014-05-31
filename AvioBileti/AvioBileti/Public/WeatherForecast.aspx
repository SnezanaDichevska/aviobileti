<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="WeatherForecast.aspx.cs" Inherits="AvioBileti.Public.Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentSpace" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="col-xs-push-2">
                <h2>
                    Тука некој веб сервис</h2>
            </td>
        </tr>
    </table>
    <div>
        <asp:Image ID="Image1" runat="server" />
        <br />
        <div class="dropdown">
            <asp:DropDownList ID="ddlDrzavi" runat="server" CssClass="dropdown-toggle" OnSelectedIndexChanged="ddlDrzavi_SelectedIndexChanged"
                AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <br />
        <asp:DropDownList ID="ddlGradovi" runat="server">
        </asp:DropDownList>
        <br />
        <span class="style2">
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </span>
        <br />
        <br />
        <asp:Button ID="btnProveriVreme" runat="server" OnClick="btnProveriVreme_Click" Text="Провери" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>
