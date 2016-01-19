<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Association.aspx.cs" Inherits="WebApplication1.Association" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personnel Association</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <style>
            .auto-style2 {
            width: 100%;
        }
        .auto-style9 {
            width: 229px;
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
        .auto-style17 {
            font-size: 50px;
        }
        .auto-style18 {
            text-align: center;
        }
        .auto-style25 {
            width: 294px;
        }
        .auto-style26 {
            width: 398px;
        }
    </style>
        <div class="auto-style18">
            <img alt="" class="auto-style12" src="images/HPic.png" /><span class="auto-style17"><strong>Personnel Associations</strong></span><strong><img alt="" class="auto-style13" src="images/HPic.png" /><div class="auto-style18">
                </div>
                </strong>
            </div>
            <table class="auto-style2" border="0">
            <tr>
                <td class="auto-style11" colspan="3" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style25" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none; font-weight: 700; text-align: right;">
                    Doctor Name</td>
                <td class="auto-style25" style="border-style: none">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="358px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                 </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none; font-weight: 700; text-align: right;">
                    Nurse Name</td>
                <td class="auto-style25" style="border-style: none">
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="358px">
                    </asp:DropDownList>
                 </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style25" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style25" style="border-style: none">
                    <asp:Button ID="Button1" runat="server" Text="Create Association" Width="358px" OnClick="Button1_Click" />
                 </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style25" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style25" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none; font-weight: 700; text-align: right;">
                    Doctor Name</td>
                <td class="auto-style25" style="border-style: none">
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="358px">
                    </asp:DropDownList>
                 </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none; font-weight: 700; text-align: right;">
                    Patient Name</td>
                <td class="auto-style25" style="border-style: none">
                    <asp:DropDownList ID="DropDownList4" runat="server" Width="358px">
                    </asp:DropDownList>
                 </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style25" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style25" style="border-style: none">
                    <asp:Button ID="Button2" runat="server" Text="Create Association" Width="358px" OnClick="Button2_Click"/>
                 </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="auto-style26" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style25" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>
