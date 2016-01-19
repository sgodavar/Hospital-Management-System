<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NurseCentral.aspx.cs" Inherits="WebApplication1.NurseCentral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nurse Central</title>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            font-size: large;
            text-align: right;
        }
        .auto-style8 {
            width: 229px;
            font-size: large;
            height: 9px;
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
        .auto-style14 {
            font-size: large;
            height: 9px;
            text-align: center;
        }
        .auto-style15 {
            height: 9px;
        }
        .auto-style17 {
            font-size: 50px;
        }
        .auto-style18 {
            text-align: center;
        }
        .auto-style19 {
            font-size: large;
            height: 9px;
        }
        .auto-style20 {
            font-size: large;
            height: 9px;
            text-align: center;
            width: 548px;
        }
        .auto-style21 {
            font-size: large;
            text-align: right;
            width: 548px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style18">
            <div class="auto-style18">
            <img alt="" class="auto-style12" src="images/HPic.png" /><span class="auto-style17"><strong>Nurse Central</strong></span></strong><strong><img alt="" class="auto-style13" src="images/HPic.png" /><div class="auto-style18">
                </div>
                </strong>
            </div>
            <table class="auto-style2" border="0">
            <tr>
                <td class="auto-style11" colspan="3" style="border-style: none">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style20" style="border-style: none">&nbsp;</td>
                <td class="auto-style8" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style15" style="border-style: none">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14" style="border-style: none" colspan="3">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Appointment_create.aspx">Create Appointment</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style19" style="border-style: none" colspan="3">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ViewAppointment.aspx">View Appointments</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style19" style="border-style: none" colspan="3">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/PersonalInfo.aspx">Modify Personal Information</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style19" style="border-style: none" colspan="3">
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/AddPatient.aspx">Add New Patient</asp:HyperLink>
                </td>
            </tr>
                <tr>
                <td class="auto-style19" style="border-style: none" colspan="3">
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/UpdatePatient.aspx">Update Patient Information</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style19" style="border-style: none" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19" style="border-style: none" colspan="3">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" Width="209px" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
