<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CleanTime.aspx.cs" Inherits="CleanTime" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td></td>
                    <td>星期一</td>
                    <td>星期二</td>
                    <td>星期三</td>
                    <td>星期四</td>
                    <td>星期五</td>
                    <td>星期六</td>
                    <td>星期日</td>
                </tr>
                <tr>
                    <td>人员</td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="休息"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="休息"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="休息"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="休息"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="休息"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="休息"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="休息"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <asp:SqlDataSource ID="SqlDataSource_cleaner" runat="server" ConnectionString="<%$ ConnectionStrings:dormitorymanagementConnectionString %>" SelectCommand="SELECT cleaner.cleaner_no, cleaner.cleaner_name, on_duty.dutytime FROM on_duty INNER JOIN cleaner ON on_duty.cleaner_no = cleaner.cleaner_no"></asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回" />
    </form>
</body>
</html>
