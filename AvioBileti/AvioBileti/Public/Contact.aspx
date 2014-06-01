<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Contact.aspx.cs" Inherits="AvioBileti.Public.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentSpace" runat="server">
<div class="well well-lg  col-sm-5 set-info">
    <table >        
        <tr>
            <td class="caption">
            <h4>Адреса:</h4>
                <i>Климент Охридски ББ, 1000 СКОПЈЕ</i>
            </td>
        </tr>
        <tr>
            
            <td>
            <h4>Е-mail adresa:</h4>
               contact@sistravel.com
            </td>
        </tr>
        <tr>
       
            <td>
             <h4>Телефон:</h4>
                00389 02 5472 148
            </td>
        </tr>
    </table>
    </div>
     <div class="set-map">
        <div id="map_canvas"></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>
