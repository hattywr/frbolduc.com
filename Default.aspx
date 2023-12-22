<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Buldoc_Reader_Take_4._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <asp:Table ID="MAIN_Table_of_Contents" runat="server" CssClass="contents_table" >

       <asp:TableRow runat="server" CssClass="table_title">
           <asp:TableCell runat="server" Text="Table Of Contents" ColumnSpan="2" CssClass="title_cell"></asp:TableCell>
       </asp:TableRow>

       <asp:TableRow runat="server" CssClass="content_row">
           <asp:TableCell runat="server" Text="Audio Recordings" CssClass="content_cell">
           </asp:TableCell>

           <asp:TableCell runat="server" ID="audio_redirect_cell" CssClass="content_cell">
               <asp:Button runat="server" ID="audio_redirect_button" Text="GO" CssClass="button_style" OnClick="audio_redirect_button_Click" />
           </asp:TableCell>
           
       </asp:TableRow>



       <asp:TableRow runat="server" CssClass="content_row">
           <asp:TableCell runat="server" Text ="Video Recordings" CssClass="content_cell"></asp:TableCell>
           <asp:TableCell runat="server" ID="video_redirect_cell" CssClass="content_cell">
               <asp:Button runat="server" ID="video_redirect_button" Text="GO" CssClass="button_style" OnClick="video_redirect_button_Click" />
           </asp:TableCell>
       </asp:TableRow>

       <asp:TableRow runat="server" CssClass="content_row">
           <asp:TableCell runat="server" Text ="Pictures" CssClass="content_cell"></asp:TableCell>
           <asp:TableCell runat="server" ID="image_redirect_cell" CssClass="content_cell">
               <asp:Button runat="server" ID="image_redirect_button" Text="GO" CssClass="button_style" OnClick="image_redirect_button_Click" />
           </asp:TableCell>
       </asp:TableRow>


       <asp:TableRow runat="server" CssClass="content_row">
           <asp:TableCell runat="server" Text="Sources" CssClass="content_cell"></asp:TableCell>
           <asp:TableCell runat="server" ID="source_redirect_cell" CssClass="content_cell">
               <asp:Button runat="server" ID="sources_redirect_button" Text="GO" CssClass="button_style" OnClick="sources_redirect_button_Click" />
           </asp:TableCell>
       </asp:TableRow>
   </asp:Table>

</asp:Content>

