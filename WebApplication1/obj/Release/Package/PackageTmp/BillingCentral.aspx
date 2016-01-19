<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillingCentral.aspx.cs" Inherits="WebApplication1.BillingCentral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Billing Central</title>
    <style type="text/css">
        #form1 {
            height: 123px;
        }
        .auto-style18 {
            text-align: center;
        }
        .auto-style12 {
            width: 81px;
            height: 87px;
            float: left;
        }
         .auto-style11 {
            font-size: large;
            height: 43px;
            text-align: right;
            background-color: #3366FF;
        }
        .auto-style17 {
            font-size: 50px;
        }
        .auto-style13 {
            width: 79px;
            height: 85px;
            float: right;
        }
        .auto-style1 {
            font-size: large;
            height: 9px;
        }
        .auto-style19{
            width: 100%;
            height: 10px;
        }
        .auto-style20 {
            height: 38px;
        }
        .auto-style21 {
            height: 35px;
        }
        .auto-style22 {}
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style18">
    <div>
    
            <img alt="" class="auto-style12" src="images/HPic.png" /><span class="auto-style17"><strong>Billing Central</strong></span></strong><strong><img alt="" class="auto-style13" src="images/HPic.png" /></strong></div>
    <table class="auto-style19">
        <tr>
            <td class="auto-style11">&nbsp;</td>
        </tr>
    </table>
    <table class="auto-style19">
        <tr>
            <td class="auto-style20"></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ViewAppointment.aspx">View Patient Bills</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/PersonalInfo.aspx">Modify Personal Information</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="auto-style21"></td>
        </tr>
        <tr>
            <td class="auto-style20">
                <asp:Button ID="Button1" runat="server" CssClass="auto-style22" Text="Logout" Width="446px" OnClick="Button1_Click"/>
            </td>
        </tr>
        <tr>
            <td class="auto-style21"></td>
        </tr>
    </table>
    </form>
    </body>
</html>
