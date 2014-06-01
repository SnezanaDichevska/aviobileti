<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Weather.aspx.cs" Inherits="AvioBileti.Public.Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentSpace" runat="server">
    <div>
        <h2>
            Моментална состојба на времето:</h2>
    </div>
    <table style="width: 100%;">
        <tr>
            <td class="col-lg-6">
                <div>
                    <h3>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <br />
                    </h3>
                </div>
                <br />
                <div class="col-xs-offset-x">
                
                    <asp:Image ID="weatherImage" runat="server" ImageUrl="~/Images/Weather/Status-weather-clouds-icon.png" />
                    <br />
                  
                </div>
                <div class="dropdown">
                    <asp:DropDownList ID="ddlDrzavi" runat="server" OnSelectedIndexChanged="ddlDrzavi_SelectedIndexChanged"
                        CssClass="ddl" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <br />
                <div>
                    <asp:DropDownList ID="ddlGradovi" runat="server"  CssClass="ddl">
                    </asp:DropDownList>
                </div>
                <div>
                    <br />
                    <asp:Button ID="btnProveriVreme" runat="server" OnClick="btnProveriVreme_Click" Text="Провери"
                        CssClass="btn btn-info" />
                </div>
            </td>
            <td class="col-lg-6">
                <div class="well well-lg">
                    <div>
                        <h4>                       
                            Локација:
                        </h4>
                        <p>
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                            <br />
                        </p>
                    </div>
                    <br />
                    <div>
                        <div>
                            <h4>
                                Време:
                            </h4>
                            <p>
                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                <br />
                            </p>
                        </div>
                        <br />
                        <div>
                            <h4>
                                Температура:
                            </h4>
                            <p>
                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                <br />
                            </p>
                        </div>
                        <br />
                        <div>
                            <h4>
                                Влажност на воздухот:
                            </h4>
                            <p>
                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                <br />
                            </p>
                        </div>
                        <br />
                        <div>
                            <h4>
                                Притисок:</h4>
                            <p>
                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                <br />
                            </p>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>
