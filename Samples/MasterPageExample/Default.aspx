<%@ Page Title="" Language="VB" MasterPageFile="~/Samples/MasterPageExample/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Samples_MasterPageExample_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    

    <%
        'Included FusionCharts.js to embed FusionCharts easily in web pages
        'The following code will generate a chart from code behind file Default.aspx.vb
    %>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
