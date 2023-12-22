<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sources_Table_Of_Contents.aspx.cs" Inherits="Buldoc_Reader_Take_4.Sources_Table_Of_Contents" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <asp:Table ID="Sources_Table_of_Contents" runat="server" CssClass="contents_table" >
       <asp:TableRow runat="server" CssClass="table_title">
           <asp:TableCell runat="server" Text="Sources Directory" CssClass="title_cell" ColumnSpan="2" ></asp:TableCell>
       </asp:TableRow>
   </asp:Table>

     </asp:Content>