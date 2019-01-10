<%@ Page Title="" Language="C#" MasterPageFile="~/V2.master" AutoEventWireup="true" CodeFile="visitor2.aspx.cs" Inherits="visitor2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            margin-top: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        点击图片查询信息！</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/u=1288734072,276208469&amp;fm=26&amp;gp=0.jpg" OnClick="ImageButton1_Click" Width="209px" />
    <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style5" Height="136px" TextMode="MultiLine" Width="38px"></asp:TextBox>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style5" Height="135px" TextMode="MultiLine" Width="87px"></asp:TextBox>
    <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style5" Height="135px" TextMode="MultiLine" Width="92px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回首页" />
</asp:Content>

