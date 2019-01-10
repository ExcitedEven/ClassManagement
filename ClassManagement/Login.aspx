<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    </head>
<body>
    <form id="form1" runat="server">

            <asp:Button ID="Button1"  runat="server" Text="门卫" OnClick="Button1_Click" />
    <div align="center">
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label_UserID" runat="server" Text="用户ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="style3" ID="TextBox_UserID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label_Pwd" runat="server" Text="密码"></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="style3" ID="TextBox_Pwd" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button_submit" runat="server" Text="登录" OnClick="Button_submit_Click" />&nbsp;
                    <asp:Button ID="Button_clear" runat="server" Text="重置" OnClick="Button_clear_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
