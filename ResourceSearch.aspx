<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResourceSearch.aspx.cs" Inherits="Buldoc_Reader_Take_4.ResourceSearch" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="MAIN_Table_of_Contents" runat="server" CssClass="contents_table" >

        <asp:TableRow runat="server" CssClass="table_title">
            <asp:TableCell runat="server" Text="Search For A Resource By Name or Description" ColumnSpan="2" CssClass="title_cell"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server" CssClass="content_row">

            <asp:TableCell runat="server" ID="searchButtonCell" CssClass="content_cell">
                <asp:Button runat="server" ID="searchButton" Text="GO" CssClass="button_style" OnClick="searchButton_Click" />
            </asp:TableCell>
            <asp:TableCell runat="server"  CssClass="content_cell">
                <asp:TextBox runat="server" ID="searchTB" CssClass="textbox" Width="100%"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

     </asp:Table>

    <asp:PlaceHolder runat="server" ID="content"></asp:PlaceHolder>
    </asp:Content>