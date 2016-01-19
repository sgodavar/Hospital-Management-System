<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="WebApplication1.PersonalInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personal Info</title>
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
        .auto-style27 {
            width: 119px;
        }
        .auto-style28 {
            width: 357px;
        }
        .auto-style29 {
            width: 357px;
            text-align: right;
        }
        .auto-style30 {
            width: 357px;
            text-align: right;
            height: 26px;
        }
        .auto-style31 {
            width: 119px;
            height: 26px;
        }
        .auto-style32 {
            width: 229px;
            height: 26px;
        }
    </style>

        <div class="auto-style18">
            <img alt="" class="auto-style12" src="images/HPic.png" /><span class="auto-style17"><strong>Update Personal Information</strong></span></strong><strong><img alt="" class="auto-style13" src="images/HPic.png" /><div class="auto-style18">
                </div>
                </strong>
            </div>
            <table class="auto-style2" border="0">
            <tr>
                <td class="auto-style11" colspan="3" style="border-style: none">
                    <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White">Home</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style28" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style27" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style28" style="border-style: none; text-align: right;">
                    <strong>Name</strong></td>
                <td class="auto-style27" style="border-style: none">
                    <asp:TextBox ID="TextBox1" runat="server" style="text-align: center" Width="525px"></asp:TextBox>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29" style="border-style: none; font-weight: 700;">
                    Date of Birth</td>
                <td class="auto-style41" style="border-style: none">
                    Day: <asp:DropDownList ID="DropDownList1" EnableViewState="true" runat="server" Width="91px" >
                       </asp:DropDownList>
                    Month: <asp:DropDownList ID="DropDownList2" EnableViewState="true" runat="server" Width="91px">
                       </asp:DropDownList>
                    Year: <asp:DropDownList ID="DropDownList3" EnableViewState="true" runat="server" Width="91px" >
                       </asp:DropDownList>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29" style="border-style: none; font-weight: 700;">
                    Address</td>
                <td class="auto-style27" style="border-style: none">
                    <asp:TextBox ID="TextBox2" runat="server" Width="525px"></asp:TextBox>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style30" style="border-style: none; font-weight: 700;">
                    Telephone Number</td>
                <td class="auto-style31" style="border-style: none">
                    <asp:TextBox ID="TextBox3" runat="server" Width="525px"></asp:TextBox>
                </td>
                <td class="auto-style32" style="border-style: none">
                    </td>
            </tr>
            <tr>
                <td class="auto-style29" style="border-style: none; font-weight: 700;">
                    Social Insurance Number</td>
                <td class="auto-style27" style="border-style: none">
                    <asp:TextBox ID="TextBox4" runat="server" Width="525px"></asp:TextBox>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29" style="border-style: none; font-weight: 700;">
                    MINC</td>
                <td class="auto-style27" style="border-style: none">
                    <asp:TextBox ID="TextBox5" runat="server" Width="525px"></asp:TextBox>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style28" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style27" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style28" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style27" style="border-style: none">
                    <asp:Button ID="Button1" runat="server" Text="Update Information" Width="525px" OnClick="Button1_Click" />
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style28" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style27" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style28" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style27" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
        </div>
        </form>
            <tr>
                <td class="auto-style33" style="border-style: none">
                    </td>
                <td class="auto-style43" style="border-style: none">
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="auto-style35" style="border-style: none">
                    </td>
            </tr>
    </body>
</html>
