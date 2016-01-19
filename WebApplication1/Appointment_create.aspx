<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointment_create.aspx.cs" Inherits="WebApplication1.Appointment" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Appointment Registration</title>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            font-size: large;
            width: 617px;
            text-align: right;
        }
        .auto-style8 {
            width: 151px;
            font-size: large;
            height: 9px;
        }
        .auto-style9 {
            width: 151px;
        }
        .auto-style10 {
            width: 151px;
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
            width: 81px;
            height: 87px;
            float: right;
        }
        .auto-style14 {
            width: 617px;
            font-size: large;
            height: 9px;
            text-align: right;
        }
        .auto-style15 {
            height: 9px;
        }
        .auto-style16 {
            text-align: center;
        }
        .auto-style17 {
            font-size: 50px;
        }
        .auto-style18 {
            font-size: large;
            width: 617px;
            text-align: right;
            height: 192px;
        }
        .auto-style19 {
            width: 151px;
            height: 192px;
        }
        .auto-style20 {
            height: 192px;
        }
        .auto-style21 {
            font-size: large;
            width: 617px;
            text-align: right;
            height: 26px;
        }
        .auto-style22 {
            width: 151px;
            height: 26px;
        }
        .auto-style23 {
            height: 26px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="auto-style16">
        <strong style="text-align: justify">
        <img alt="" class="auto-style12" src="images/HPic.png" /><span class="auto-style17">Appointment Registration</span></strong><img alt="" class="auto-style13" src="images/HPic.png" /><table class="auto-style2" border="0">
    </div>
    <table class="auto-style2" border="0">
            <tr>
                <td class="auto-style11" colspan="3" style="border-style: none"></td>
            </tr>
            <tr>
                <td class="auto-style14" style="border-style: none">&nbsp;</td>
                <td class="auto-style8" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style15" style="border-style: none">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14" style="border-style: none"><strong>Patient Name</strong></td>
                <td class="auto-style8" style="border-style: none">
                    <asp:DropDownList ID="DropDownList1" Width="291px" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style15" style="border-style: none"></td>
            </tr>
            <tr>
                <td class="auto-style14" style="border-style: none"><strong>Doctor Name</strong></td>
                <td class="auto-style10" style="border-style: none">
                    <asp:DropDownList ID="DropDownList2" Width="291px" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style15" style="border-style: none"></td>
            </tr>
            <tr>
                <td class="auto-style18" style="border-style: none"><strong>Date</strong></td>
                <td class="auto-style19" style="border-style: none">
                    <asp:Calendar ID="Calendar1" runat="server" Width="291px"></asp:Calendar>
                </td>
                <td style="border-style: none" class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style21" style="border-style: none"><strong>Time</strong></td>
                <td class="auto-style22" style="border-style: none">
                    <asp:TextBox ID="TextBox4" runat="server" Width="291px"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                </td>
                <td style="border-style: none" class="auto-style23"></td>
            </tr>
            <tr>
                <td class="auto-style3" style="border-style: none"><strong>Reason</strong></td>
                <td class="auto-style9" style="border-style: none">
                    <asp:TextBox ID="TextBox5" runat="server" Height="183px" Width="293px"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                </td>
                <td style="border-style: none">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" style="border-style: none">&nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
                <td style="border-style: none">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" style="border-style: none">&nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    <asp:Button ID="Button1" runat="server" Text="Create Appointment" Width="300px" OnClick="Button1_Click" />
                </td>
                <td style="border-style: none">&nbsp;</td>
            </tr>
        </form>
            <tr>
                <td class="auto-style33" style="border-style: none">
                    </td>
                <td class="auto-style43" style="border-style: none">
                    <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="auto-style35" style="border-style: none">
                    </td>
            </tr>
</body>
</html>
