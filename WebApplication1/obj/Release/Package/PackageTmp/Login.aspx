<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>System Login</title>
    <style type="text/css">
        #form1 {
            height: 0px;
        }
        .auto-style1 {
            font-size: 50px;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            font-size: large;
            width: 568px;
            text-align: center;
        }
        .auto-style8 {
            width: 234px;
            font-size: large;
            height: 9px;
        }
        .auto-style9 {
            width: 234px;
        }
        .auto-style10 {
            width: 234px;
            height: 9px;
        }
        .auto-style11 {
            font-size: large;
            height: 43px;
            text-align: right;
            background-color: #3366FF;
        }
        .auto-style12 {
            width: 81px;
            height: 87px;
            float: left;
        }
        .auto-style13 {
            width: 79px;
            height: 85px;
            float: right;
        }
        .auto-style14 {
            width: 568px;
            font-size: large;
            height: 9px;
            text-align: right;
        }
        .auto-style15 {
            height: 9px;
            width: 495px;
        }
        .auto-style16 {
            width: 495px;
        }
        .auto-style17 {
            font-size: large;
            width: 234px;
            text-align: center;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="form1" runat="server" class="auto-style1">
        <strong style="text-align: justify">
        <img alt="" class="auto-style12" src="images/HPic.png" />Login Page</strong><img alt="" class="auto-style13" src="images/HPic.png" /><table class="auto-style2" border="0">
            <tr>
                <td class="auto-style11" colspan="3" style="border-style: none"></td>
            </tr>
            <tr>
                <td class="auto-style14" style="border-style: none"><strong>Username</strong></td>
                <td class="auto-style8" style="border-style: none">
                    <asp:TextBox ID="TextBox1" runat="server" Width="211px"></asp:TextBox>
                </td>
                <td class="auto-style15" style="border-style: none"></td>
            </tr>
            <tr>
                <td class="auto-style14" style="border-style: none"><strong>Password</strong></td>
                <td class="auto-style10" style="border-style: none">
                    <asp:TextBox ID="TextBox2" runat="server" Width="211px"></asp:TextBox>
                </td>
                <td class="auto-style15" style="border-style: none"></td>
            </tr>
            <tr>
                <td class="auto-style3" style="border-style: none">&nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    <asp:Button ID="Button1" runat="server" Text="Login" Width="222px" OnClick="Button1_Click" />
                </td>
                <td style="border-style: none" class="auto-style16">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" style="border-style: none">&nbsp;</td>
                <td class="auto-style17" style="border-style: none">
                    <asp:Label ID="Label1" runat="server" Text="Error! Incorrect Username or Password" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td style="border-style: none" class="auto-style16">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
