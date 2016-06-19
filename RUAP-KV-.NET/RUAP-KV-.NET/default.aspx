
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RUAP_KV_.NET.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RUAP-KV</title>

    <style>
        h1{
            text-align: center;
        }
        #form1 {
            width: 442px;
        }
        #div_picture{
            position:absolute;
            top: 71px;
            left: 500px;
        }

        #div_picture #Label1,#Label2 {
            display: block;
        }

        #description{
            border: solid black;
            font-size: 20px;
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
        
    <div style="width: 440px; height: 202px;" id="div_picture">
        <asp:Image ID="Image1" runat="server" />

        <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>

        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </div>

        <br /><br /><br /><br />

        <div id="description">
            
How to use:<br /><br />

1) Upload picture containing face (.jpg and up to 2MB)<br /><br />

2) Click Upload button.<br /><br />

3) The program will detect a face on the image (if any) and based on uniform LBP + PCA features classify you to some of the Croatian politicians. Classification is made in Microsoft Azure Machine Learning Studio.
        </div>

    </form>

    </body>
</html>
