<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="WebApplication1.AddEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Employee</title>
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
        .auto-style29 {
            width: 312px;
            text-align: right;
        }
        .auto-style30 {
            width: 312px;
            text-align: right;
            height: 26px;
        }
        .auto-style32 {
            width: 229px;
            height: 26px;
        }
        .auto-style33 {
            width: 312px;
            height: 23px;
        }
        .auto-style35 {
            width: 229px;
            height: 23px;
        }
        .auto-style40 {
            width: 312px;
        }
        .auto-style41 {
            width: 137px;
        }
        .auto-style42 {
            width: 137px;
            height: 26px;
        }
        .auto-style43 {
            width: 137px;
            height: 23px;
        }
    </style>

        <div class="auto-style18">
            <img alt="" class="auto-style12" src="images/HPic.png" /><span class="auto-style17"><strong>Add Employee</strong></span></strong><strong><img alt="" class="auto-style13" src="images/HPic.png" /><div class="auto-style18">
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
                <td class="auto-style40" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style41" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40" style="border-style: none; text-align: right;">
                    <strong>Full Name</strong></td>
                <td class="auto-style41" style="border-style: none">
                    <asp:TextBox ID="TextBox1" runat="server" EnableViewState="true" Width="525px"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29" style="border-style: none; font-weight: 700;">
                    Date of Birth</td>
                <td class="auto-style41" style="border-style: none">
                    Day<asp:TextBox ID="TextBox8" EnableViewState="true" runat="server" Width="91px"></asp:TextBox>
                    Month<asp:TextBox ID="TextBox9" EnableViewState="true" runat="server" Width="91px"></asp:TextBox>
                    Year<asp:TextBox ID="TextBox10" EnableViewState="true" runat="server" Width="91px"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29" style="border-style: none; font-weight: 700;">
                    Address</td>
                <td class="auto-style41" style="border-style: none">
                    <asp:TextBox ID="TextBox2" EnableViewState="true" runat="server" Width="525px"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style30" style="border-style: none; font-weight: 700;">
                    Telephone Number</td>
                <td class="auto-style42" style="border-style: none">
                    <asp:TextBox ID="TextBox3" EnableViewState="true" runat="server" Width="525px"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                </td>
                <td class="auto-style32" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29" style="border-style: none; font-weight: 700;">
                    Social Insurance Number</td>
                <td class="auto-style41" style="border-style: none">
                    <asp:TextBox ID="TextBox4" EnableViewState="true" runat="server" Width="525px"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29" style="border-style: none; font-weight: 700;">
                    MINC</td>
                <td class="auto-style41" style="border-style: none">
                    <asp:TextBox ID="TextBox5" EnableViewState="true" runat="server" Width="525px" ></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40" style="border-style: none; font-weight: 700; text-align: right;">
                    Employee Role</td>
                <td class="auto-style41" style="border-style: none">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="525px" AutoPostBack="True" >
                    </asp:DropDownList>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40" style="border-style: none; font-weight: 700; text-align: right;">
                    Username</td>
                <td class="auto-style41" style="border-style: none">
                    <asp:TextBox ID="TextBox6" EnableViewState="true" runat="server" Width="525px"></asp:TextBox>
                    <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40" style="border-style: none; font-weight: 700; text-align: right;">
                    Password</td>
                <td class="auto-style41" style="border-style: none">
                    <asp:TextBox ID="TextBox7" EnableViewState="true" runat="server" Width="525px" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="Error!" Visible="False"></asp:Label>
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style33" style="border-style: none">
                    </td>
                <td class="auto-style43" style="border-style: none">
                    </td>
                <td class="auto-style35" style="border-style: none">
                    </td>
            </tr>
            <tr>
                <td class="auto-style40" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style41" style="border-style: none">
                    <asp:Button ID="Button1" runat="server" Text="Add Employee" Width="525px" OnClick="Button1_Click" />
                </td>
                <td class="auto-style9" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style41" style="border-style: none">
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
                    <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="auto-style35" style="border-style: none">
                    </td>
            </tr>
    </body>
</html>
