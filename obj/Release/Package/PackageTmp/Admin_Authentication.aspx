<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Authentication.aspx.cs" Inherits="Buldoc_Reader_Take_4.Admin_Authentication" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" Text="YOU MUST BE AUTHENTICATED BEFORE ACCESSING THIS CONTENT!!!!" Style="margin:auto; font-size:x-large; font-weight:800; display:table"></asp:Label>

     <div id="authenticationDiv" style="display: none;">
          <asp:Table ID="authentication_table" runat="server" CssClass="contents_table" Style="width:60%">
        <asp:TableRow CssClass="table_title">
            <asp:TableCell ID="title_Cell" runat="server" Text="AUTHENTICATION TABLE" ColumnSpan="2" CssClass="title_cell"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow CssClass="content_row">
            <asp:TableCell Text="Username:" CssClass="content_cell" Style="width:30%"></asp:TableCell>
            <asp:TableCell CssClass="content_cell" Style="width:70%" >
                <asp:TextBox runat="server" ID="username_entry" CssClass="textbox"> </asp:TextBox>
            </asp:TableCell>

           
        </asp:TableRow>

         <asp:TableRow CssClass="content_row" >
            <asp:TableCell Text="Password:" CssClass="content_cell" Style="width:30%"></asp:TableCell>
            <asp:TableCell CssClass="content_cell" Style="width:70%" >
                <asp:TextBox runat="server" ID="password_entry_box" CssClass="textbox" TextMode="Password"> </asp:TextBox>
                <%--<TextBox x:Name="password_entry_box" CssClass ="textbox" PreviewTextInput="PasswordTextBox_PreviewTextInput" />--%>
            </asp:TableCell>

           
        </asp:TableRow>

        <asp:TableRow CssClass="table_title">
            <asp:TableCell runat="server" ColumnSpan="2" Style="width:100%">
                <asp:Button runat="server" ID="login_button" Text="Login" CssClass="login_button" OnClick="login_button_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
     </div>


    <script>
    function showAuthenticationForm() {
        document.getElementById('authenticationDiv').style.display = 'block';
        }

        function maskInput(textbox) {
            // Replace each character with a dot
            textbox.value = '*'.repeat(textbox.value.length);
        }
    </script>



 </asp:Content>