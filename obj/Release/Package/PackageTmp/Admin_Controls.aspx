<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Controls.aspx.cs" Inherits="Buldoc_Reader_Take_4.Admin_Controls" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" Text="Restricted Contents Directory" Style="margin:auto; font-size:x-large; font-weight:800; display:table"></asp:Label>

    <asp:Table ID="Audio_Content" runat="server" CssClass="contents_table">

       <asp:TableRow runat="server" CssClass="table_title">
           <asp:TableCell runat="server" Text="Restricted Content" ColumnSpan="2" CssClass="title_cell">
        </asp:TableCell>

       </asp:TableRow>

     </asp:Table>

    <asp:Table ID="Administrator_Controls" runat="server" CssClass="contents_table">

       <asp:TableRow runat="server" CssClass="table_title">
           <asp:TableCell runat="server" Text="Admin Controls" ColumnSpan="2" CssClass="title_cell">
           </asp:TableCell>
        </asp:TableRow>


    </asp:Table>

</asp:Content>