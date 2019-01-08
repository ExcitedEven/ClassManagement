<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

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
        <div align="right">
            <asp:Button ID="Button_Singout" align="end" runat="server" Text="退出" OnClick="Button_Singout_Click"/>
        </div>
        <div align="center">

            <asp:GridView ID="GridView1" runat="server"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" PageSize="1" AutoGenerateColumns="False" 
                ShowFooter="True" 
                onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowediting="GridView1_RowEditing" 
                onrowupdating="GridView1_RowUpdating" 
                onrowdeleting="GridView1_RowDeleting" >
                <Columns>
        <asp:TemplateField HeaderText="课程号">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditcno" runat="server" Text='<%# Bind("cno") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Labelcno" runat="server" Text='<%# Bind("cno") %>'/>
            </ItemTemplate>
            <FooterTemplate>
                    <asp:TextBox ID="TextBoxcno" runat="server"/>
            </FooterTemplate>
        </asp:TemplateField>
                    
        <asp:TemplateField HeaderText="课程名">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditcname" runat="server" Text='<%# Bind("cname") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Labelcname" runat="server" Text='<%# Bind("cname") %>'/>
            </ItemTemplate>
            <FooterTemplate>
                    <asp:TextBox ID="TextBoxcname" runat="server"/>
            </FooterTemplate>
        </asp:TemplateField>
                    
        <asp:TemplateField HeaderText="最大人数">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditcmax" runat="server" Text='<%# Bind("cmax") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Labelcmax" runat="server" Text='<%# Bind("cmax") %>'/>
            </ItemTemplate>
            <FooterTemplate>
                    <asp:TextBox ID="TextBoxcmax" runat="server"/>
            </FooterTemplate>
        </asp:TemplateField>
                    
        <asp:TemplateField HeaderText="剩余人数">
            <EditItemTemplate>
                <asp:TextBox ID="TextBoxEditcleft" runat="server" Text='<%# Bind("cleft") %>'/>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Labelcleft" runat="server" Text='<%# Bind("cleft") %>'/>
            </ItemTemplate>
            <FooterTemplate>
                    <asp:TextBox ID="TextBoxcleft" runat="server"/>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ShowDeleteButton HeaderText="操作" />
    </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                
    </asp:GridView>
       <asp:Button ID="Button1" Width="30%" runat="server" Text="增  加" OnClick="Button1_Click" />
            </div>
        </form>
</body>
</html>
