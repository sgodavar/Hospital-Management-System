<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAppointment.aspx.cs" Inherits="WebApplication1.ViewAppointment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        .auto-style19 {
            width: 229px;
            height: 23px;
        }
        .auto-style20 {
            width: 327px;
            text-align: right;
        }
        .auto-style21 {
            width: 327px;
            height: 23px;
            text-align: right;
        }
        .auto-style23 {
            width: 327px;
            height: 23px;
        }
        .auto-style24 {
            width: 327px;
        }
        .auto-style26 {
            width: 114px;
            height: 23px;
        }
        .auto-style27 {
            width: 114px;
        }
    </style>
        <div class="auto-style18">
            <img alt="" class="auto-style12" src="images/HPic.png" /><span class="auto-style17"><strong>View Appointments</strong></span></strong><strong><img alt="" class="auto-style13" src="images/HPic.png" /><div class="auto-style18">
                </div>
                </strong>
            </div>
            <table class="auto-style2" border="0">
            <tr>
                <td class="auto-style11" colspan="3" style="border-style: none">
                    <asp:HyperLink ID="HyperLink1" runat="server">Home</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style24" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style27" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style23" style="border-style: none; text-align: right; font-weight: 700;">
                    Patient Name</td>
                <td class="auto-style26" style="border-style: none">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style19" style="border-style: none">
                    <asp:Label ID="Label1" runat="server" Text="Please select only your name"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td class="auto-style20" style="border-style: none; font-weight: 700;">
                    From Date</td>
                <td class="auto-style27" style="border-style: none">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/calendar.png" OnClick="ImageButton1_Click" Width="18px" />
                    <br />
                    <asp:Calendar ID="Calendar3" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="Calendar3_SelectionChanged" ShowGridLines="True" Width="220px">
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                    </asp:Calendar>
                </td>
                <td class="auto-style9" style="border-style: none">
                    <asp:Label ID="Label2" runat="server" ForeColor="#CC3300" Text="Select From Date"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style21" style="border-style: none; font-weight: 700;">
                    To Date</td>
                <td class="auto-style26" style="border-style: none">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/image/calendar.png" OnClick="ImageButton2_Click" Width="20px" />
                    <asp:Calendar ID="Calendar4" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" OnSelectionChanged="Calendar4_SelectionChanged" ShowGridLines="True" Width="220px">
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                    </asp:Calendar>
                </td>
                <td class="auto-style19" style="border-style: none">
                    <asp:Label ID="Label3" runat="server" ForeColor="#CC3300" Text="Select To Date"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td class="auto-style24" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style27" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style24" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style27" style="border-style: none">
                    <asp:Button ID="Button1" runat="server" Text="View Appointments" Width="466px" OnClick="Button1_Click" />
                </td>
                <td class="auto-style9" style="border-style: none">
                    <asp:Label ID="Label4" runat="server" ForeColor="#CC3300" Text="Not Authorised"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style24" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style27" style="border-style: none">
                    <asp:Label ID="Label7" runat="server" Text="No Records!"></asp:Label>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                    <br />
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </div>
    </form>
</body>
</html>
