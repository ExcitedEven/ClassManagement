<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>

</title>
    <style>
        .abc {
            background:#FF0000;
            font-size: 24px;
            padding: 5px;
            color: white;
            align-content:center;
        }
        .abd{
            width:400px;
            height:275px;
           border-style:solid; 
           border-width:2px; 
           border-color:#AEEEEE;
           
        }
        .a{
            width:100px;
            height:80px;
             float:left;
        }
        .b{
            width:300px;
            height:80px;
            float:left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div>
</div>
<div>

	
</div>
        <div align="center">
        <div class="abd" align="center">
            <div class="abc">
                信息查询
            </div>
            <div class="a">
               
                <br />
                <br />
                <span id="Label4" style="display:inline-block;font-size:Medium;width:100px;">用户名:</span>

            </div>
            <div class="b">
                <br />
                &nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="25px" style="margin-left: 0px; margin-top: 7px; margin-bottom: 30px"></asp:TextBox>
                
            </div>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">电费查询</asp:ListItem>
                <asp:ListItem>工作安排</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="Button1" runat="server" Text="查询" Width="85px" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="管理员登录" OnClick="Button2_Click" />
            <asp:Label ID="xianshi" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
        </div>

    </form>
</body>
</html>

