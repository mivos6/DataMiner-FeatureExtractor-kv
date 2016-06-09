
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RUAP_KV_.NET.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RUAP-KV</title>

    <style>
        h1{
            text-align: center;
        }
    </style>

</head>
<body>
    <h1>RUAP - KV</h1>

    <form id="form1" runat="server">

        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />  <br />
        <asp:Button ID="btn_Upload" runat="server" OnClick="btn_Upload_Click" Text="Upload" />
        <br />
        <br />
        
        <br />
        <asp:Label ID="control_label" runat="server"></asp:Label>
        
    <br /><br />
        <br />
        <br />

        <asp:Label ID="label_features" runat="server"></asp:Label>
        
    </form>

    </body>
</html>
