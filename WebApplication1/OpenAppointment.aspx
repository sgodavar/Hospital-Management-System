<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenAppointment.aspx.cs" Inherits="WebApplication1.OpenAppointment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Open Appointment</title>
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
            height: 24px;
        }
        .auto-style22 {
            width: 151px;
            height: 24px;
        }
        .auto-style23 {
            height: 24px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="auto-style16">
        <strong style="text-align: justify">
        <img alt="" class="auto-style12" src="images/HPic.png" /><span class="auto-style17">Open Appointment</span></strong><img alt="" class="auto-style13" src="images/HPic.png" /><table class="auto-style2" border="0">
    </div>
    <table class="auto-style2" border="0">
            <tr>
                <td class="auto-style11" colspan="3" style="border-style: none">
                    <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White">Home</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style14" style="border-style: none"></td>
                <td class="auto-style8" style="border-style: none">
                    </td>
                <td class="auto-style15" style="border-style: none"></td>
            </tr>
            <tr>
                <td class="auto-style14" style="border-style: none"><strong>Patient Name</strong></td>
                <td class="auto-style8" style="border-style: none">
                    <asp:DropDownList ID="DropDownList1" Width="298px" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style15" style="border-style: none"></td>
            </tr>
            <tr>
                <td class="auto-style18" style="border-style: none"><strong>Date</strong></td>
                <td class="auto-style19" style="border-style: none">
                    <asp:Calendar ID="Calendar1" runat="server" Width="298px"></asp:Calendar>
                </td>
                <td style="border-style: none" class="auto-style20"></td>
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
                    <asp:Button ID="Button1" runat="server" Text="Open Appointment" Width="300px" OnClick="Button1_Click" />
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
                    &nbsp;</td>
                <td style="border-style: none">&nbsp;</td>
            </tr>
    
            <tr>
                <td class="auto-style3" style="border-style: none">
                    <asp:Label ID="Label6" runat="server" Text="Patient Name" Font-Bold="True" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    <asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td style="border-style: none">&nbsp;</td>
            </tr>
    
            <tr>
                <td class="auto-style3" style="border-style: none">
                    <asp:Label ID="Label4" runat="server" Text="Appointment Time" Font-Bold="True" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td style="border-style: none">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" style="border-style: none">
                    <asp:Label ID="Label1" runat="server" Text="Diagnosis" Font-Bold="True" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    <asp:TextBox ID="TextBox1" runat="server" Width="298px" Height="125px" Visible="False" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="border-style: none">&nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style3" style="border-style: none">
                    <asp:Label ID="Label2" runat="server" Text="Treatment" Font-Bold="True" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    <asp:DropDownList ID="DropDownList2"  Width="298px" runat="server" Visible="False">
                    </asp:DropDownList>
                </td>
                <td style="border-style: none">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21" style="border-style: none">
                    <asp:Label ID="Label3" runat="server" Text="Drug" Font-Bold="True" Visible="False"></asp:Label>
                </td>
                <td class="auto-style22" style="border-style: none">
                    <asp:DropDownList ID="DropDownList3"  Width="298px" runat="server" Visible="False">
                    </asp:DropDownList>
                </td>
                <td style="border-style: none" class="auto-style23"></td>
            </tr>
            <tr>
                <td class="auto-style3" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
                <td style="border-style: none">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    <asp:Button ID="Button2" Width="99px" runat="server" Text="Update" Visible="False" OnClick="Button2_Click" />
                    <asp:Button ID="Button3" Width="99px" runat="server" Text="Next" Visible="False" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" Width="99px" runat="server" Text="Previous" OnClick="Button4_Click" Visible="False" />
                </td>
                <td style="border-style: none">&nbsp;</td>
            </tr>
         </form>
        </body>
</html>
