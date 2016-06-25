<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" MasterPageFile="~/Site.master"
    Inherits="WebClient.Home" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <title>Grability Test</title>
    <link href="css/cubesum.css" rel="stylesheet">
    <link href="css/jquery-ui.min.css" rel="stylesheet">
    <script src="js/jquery.min.js"></script>
    <script src="js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/CubeSum.js"></script>
    <link href="css/Styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="MainDiv">
        <h2>Cube Summation <span>Grability - Rappi</span>
        </h2>

        <div class="button">            
            <button id="btnexphelper">Expression Helper</button>
        </div>
        <div class="all">
            <span class="inputoutputtext">
                Input
            </span>
            <span>
                <asp:TextBox ID="taInput" TextMode="MultiLine" Columns="20" Rows="20" runat="server" CssClass="taInput"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="taInput" ID="reqInput" runat="server" 
                    ErrorMessage="*" CssClass="validationErrors">
                </asp:RequiredFieldValidator>
            </span>
            <span class="inputoutputtext">
                Output
            </span>
            <span>
                <asp:TextBox ID="taOutput" TextMode="MultiLine" Columns="20" Rows="20" runat="server"
                    Enabled="false"></asp:TextBox>
            </span>
        </div>
        
        <div class="button">            
            <asp:Button ID="btnProcess" runat="server" Text="Process" OnClick="btnProcess_Click" CssClass="buttonP"/>
        </div>
        <div class="validationErrors">            
            <asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label>
        </div>

        <div id="new-exp">
            <p>
                Added Expressions
                <input type="text" name="expcount" id="expcount" value="0" class="numvalue" disabled="disabled">
            </p>
            <p>
                Matriz Size
                <input type="text" name="size" id="size" class="numvalue">
                Number of Operations
                <input type="text" name="opercount" id="opercount" class="numvalue">
            </p>
            <p>
                <div id="queries">
                </div>
            </p>
        </div>
    </div>
</asp:Content>
