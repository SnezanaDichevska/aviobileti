<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="AvioBileti.Public.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentSpace" runat="server">
    <table class="style10" id="registrationTable">
    <tr>
        <td class="style16">
            </td>
        <td class="style17" colspan="2">
            <strong>Внесете ги вашите лични податоци:</strong></td>
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
        <td class="style24">
            Корисничко име:</td>
        <td class="style25">
            <asp:TextBox ID="tbKorisnichkoIme" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            <asp:Panel ID="Panel1" runat="server" Width="337px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    CssClass="error"  ErrorMessage="Внесете корисничко име!" 
                    ControlToValidate="tbKorisnichkoIme" Display="Dynamic"></asp:RequiredFieldValidator>
                <br>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                     CssClass="error" ControlToValidate="tbKorisnichkoIme" Display="Dynamic" 
                    ErrorMessage="За корисничко име можете да внесете само : a-z,  A-Z , @,  * ,  -  ,  _" 
                    ValidationExpression="^[a-zA-Z0-9_\-@\*]*$"></asp:RegularExpressionValidator>
                <br></br>
                </br>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td class="style24">
            Име:</td>
        <td class="style25">
            <asp:TextBox ID="tbIme" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                 CssClass="error" ControlToValidate="tbIme" ErrorMessage="Внесете име!"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td class="style24">
            Презиме:</td>
        <td class="style25">
            <asp:TextBox ID="tbPrezime" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                 CssClass="error" ControlToValidate="tbPrezime" ErrorMessage="Внесете презиме!"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td class="style24">
            Пол:</td>
        <td class="style25">
            <asp:RadioButtonList ID="rbPol" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="m">машки</asp:ListItem>
                <asp:ListItem Value="f">женски</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td class="style22">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                 CssClass="error" ControlToValidate="rbPol" ErrorMessage="Одберете пол!"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td class="style24">
            Адреса:</td>
        <td class="style25">
            <asp:TextBox ID="tbAdresa" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                 CssClass="error" ControlToValidate="tbAdresa" ErrorMessage="Внесете адреса!"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td class="style24">
            Град:</td>
        <td class="style25">
            <asp:TextBox ID="tbGrad" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                 CssClass="error" ControlToValidate="tbGrad" ErrorMessage="Внесете град"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td class="style24">
            Држава:</td>
        <td class="style25">
            <asp:TextBox ID="tbDrzava" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                 CssClass="error" ControlToValidate="tbDrzava" ErrorMessage="Внесете држава!"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td class="style24">
            Мобилен тел.:</td>
        <td class="style25">
            <asp:TextBox ID="tbMobTel" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                 CssClass="error" ControlToValidate="tbMobTel" ErrorMessage="Внесете телефон!"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td class="style24">
            Е-адреса:</td>
        <td class="style25">
            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                 CssClass="error" ControlToValidate="tbEmail" ErrorMessage="Внесете e-mail адреса!"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td class="style24">
            Лозинка:</td>
        <td class="style25">
            <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                CssClass="error"  ControlToValidate="tbPassword" ErrorMessage="Внесете лозинка!"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                CssClass="error"  ControlToValidate="tbPassword" Display="Dynamic" 
                ErrorMessage="За лозинка можете да внесете само : a-z,  A-Z , @,  * ,  -  ,  _" 
                ValidationExpression=" ^[a-zA-Z0-9_\-@\*]*$ "></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style13">
            &nbsp;</td>
        <td class="style24">
            Лозинка за потврда:</td>
        <td class="style25">
            <asp:TextBox ID="tbPasswordCheck" runat="server"></asp:TextBox>
        </td>
        <td class="style22">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                CssClass="error"  ControlToValidate="tbPasswordCheck" ErrorMessage="Потврдете ја лозинката!"></asp:RequiredFieldValidator>
        </td>
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
<asp:Content ID="Content5" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>
