<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Test.WebForm1" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        #TextArea1 {
            width: 455px;
        }
        #Text1 {
            height: 197px;
        }
    </style>
    <script src="JavaScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
  <div class="navigation">
	  <a href="#.html" title="Home">Home</a> 
	  <a href="#.html" title="About Us">About</a> 
	  <a href="#.html" title="Products">Products</a> 
	  <a href="#.html" title="Services">Services</a> 
	  <a href="#.html" title="Contact">Contact</a> 
  </div>
  <div class="logo"> <img src="Pics/bul.png" style="width:250px;height:50px;"/></div>
            </div>
        <br /><br />
        <div style="margin-left : 380px">
            <div class="text_field">
            <asp:TextBox ID="Searchtxtbox" style="text-align: right; text-size-adjust : 200%; margin-bottom : -16px" runat="server" onfocus="MakeTextBoxUrduEnabled(this)" 
                Height="35px" Width="328px" TextMode="MultiLine" Font-Bold="True" Font-Size="Large"></asp:TextBox>

                &nbsp;&nbsp;

            <asp:Button ID="btnSearch" runat="server" Text="Search Word" Width="124px" Height="40px" OnClick="btnSearch_Click"/>

            <br /><br /><br />

            <asp:TextBox ID="TextBox1" runat="server" Height="368px" Width="469px" BorderStyle="Dashed"
               ReadOnly="true" TextMode="MultiLine" Rows="100" style="text-align : right; text-size-adjust : 200%" Font-Bold="True" Font-Size="Large"></asp:TextBox>
            </div>
                </div>   
        <br /><br />
    </form>
</body>
</html>
