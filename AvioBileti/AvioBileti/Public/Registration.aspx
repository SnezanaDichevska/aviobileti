<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="AvioBileti.Public.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style10
    {
        width: 100%;
        background-color: #FFFFCC;
    }
    .style11
    {
        height: 33px;
    }
    .style12
    {
        height: 33px;
        width: 30px;
    }
    .style13
    {
        width: 30px;
    }
    .style14
    {
        height: 26px;
        width: 30px;
    }
    .style15
    {
        height: 26px;
    }
    .style16
    {
        height: 23px;
        width: 120px;
    }
    .style17
    {
        height: 23px;
        width: 357px;
    }
    .style18
    {
        height: 28px;
        width: 30px;
    }
    .style19
    {
        height: 28px;
    }
    .style20
    {
        height: 23px;
        width: 343px;
    }
    .style21
    {
        height: 26px;
        width: 343px;
    }
    .style22
    {
        width: 343px;
    }
    .style23
    {
        height: 28px;
        width: 343px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FlightSearchSpace" runat="server">
    <table class="style10" id="registrationTable">
    <tr>
        <td class="style16">
            </td>
        <td class="style17" colspan="2">
            <strong>Внесете ги личните податоци:</strong></td>
        <td class="style20">
            </td>
    </tr>
    <tr>
        <td class="style14">
            </td>
        <td class="style15" colspan="2">
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </td>
        <td class="style21">
            </td>
    </tr>
    <tr>
        <td class="style13">
            <asp:Panel ID="Panel2" runat="server" Width="29px">
            </asp:Panel>
        </td>
        <td>
            Корисничко име:</td>
        <td>
            <asp:TextBox ID="tbKorisnichkoIme" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            <asp:Panel ID="Panel1" runat="server" Width="143px">
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td>
            Име:</td>
        <td>
            <asp:TextBox ID="tbIme" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td>
            Презиме:</td>
        <td>
            <asp:TextBox ID="tbPrezime" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td>
            Пол:</td>
        <td>
            <asp:RadioButtonList ID="rbPol" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="m">машки</asp:ListItem>
                <asp:ListItem Value="f">женски</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td>
            Адреса:</td>
        <td>
            <asp:TextBox ID="tbAdresa" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td>
            Град:</td>
        <td>
            <asp:TextBox ID="tbGrad" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td>
            Држава:</td>
        <td>
            <asp:TextBox ID="tbDrzava" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td>
            Мобилен тел.:</td>
        <td>
            <asp:TextBox ID="tbMobTel" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td>
            Е-адреса:</td>
        <td>
            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td>
            Лозинка:</td>
        <td>
            <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td>
            Лозинка за потврда:</td>
        <td>
            <asp:TextBox ID="tbPasswordCheck" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style18">
            </td>
        <td colspan="2" class="style19">
            <asp:Button ID="btnSaveRegistration" runat="server" Font-Bold="False" 
                onclick="btnSaveRegistration_Click" Text="Зачувај" />
        </td>
        <td class="style23">
            </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LoginSpace" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentSpace" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>
