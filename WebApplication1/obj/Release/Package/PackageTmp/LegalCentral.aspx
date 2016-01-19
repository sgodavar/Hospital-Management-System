<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LegalCentral.aspx.cs" Inherits="WebApplication1.LegalCentral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Legal Central</title>
    <style type="text/css">
        #form1 {
            height: 123px;
        }
        .auto-style1 {
            height: 9px;
        }
        .auto-style2 {
            width: 100%;
            height: 149px;
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
        .auto-style17 {
            font-size: 50px;
        }
        .auto-style13 {
            width: 79px;
            height: 85px;
            float: right;
        }
        .auto-style18 {
            text-align: center;
        }
        .auto-style19 {
            font-size: large;
            height: 9px;
        }
        .auto-style22 {
            height: 38px;
        }
        .auto-style24 {}
        .auto-style26 {
            height: 38px;
        }
        .auto-style27 {
            height: 35px;
        }
        .auto-style28 {
            height: 8px;
        }
        .auto-style29 {}
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style18">
    <div>
    
        <table class="auto-style2">
            <tr>
                <td class="auto-style18">
            <img alt="" class="auto-style12" src="images/HPic.png" /><span class="auto-style17"><strong>Legal Central</strong></span></strong><strong><img alt="" class="auto-style13" src="images/HPic.png" /><div class="auto-style18">
                    </div>
                </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">&nbsp;</td>
            </tr>
        </table>
    
        <table class="auto-style2">
            <tr>
                <td class="auto-style22"></td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ViewAppointment.aspx">View Patient History</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="auto-style24" NavigateUrl="~/PersonalInfo.aspx">Modify Personal Information</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style27"></td>
            </tr>
            <tr>
                <td class="auto-style26">
                    <asp:Button ID="Button1" runat="server" CssClass="auto-style29" Text="Logout" Width="446px" OnClick="Button1_Click"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style27"></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
