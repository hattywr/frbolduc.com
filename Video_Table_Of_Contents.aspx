<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Video_Table_Of_Contents.aspx.cs" Inherits="Buldoc_Reader_Take_4.Video_Table_Of_Contents" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <asp:Table ID="Video_Table_of_Contents" runat="server" CssClass="contents_table" >
       <asp:TableRow runat="server" CssClass="table_title">
           <asp:TableCell runat="server" Text="Video Directory" CssClass="title_cell" ColumnSpan="2" ></asp:TableCell>
       </asp:TableRow>
   </asp:Table>

 </asp:Content>
