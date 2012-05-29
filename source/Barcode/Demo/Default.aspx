<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Demo._Default" %>
<%@ Register Assembly="WebControls" Namespace="WebControls" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Exemplos
    </h2>
    <p>Código: 7898357417892</p>

    <p>Code 39</p>
    <asp:Barcode runat="server" Type="Code39" Code="7898357417892" ID="barcode1" />
    <br />

    <p>Code 128</p>
    <asp:Barcode runat="server" Type="Code128" Code="7898357417892" ID="barcode2" />
    <br />

    <p>EAN</p>
    <asp:Barcode runat="server" Type="EAN" Height="30" Code="7898357417892" ID="barcode3" />
</asp:Content>