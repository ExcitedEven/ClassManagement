<%@ Page Title="" Language="C#" MasterPageFile="~/V2.master" AutoEventWireup="true" CodeFile="visitors.aspx.cs" Inherits="visitors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="退出" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/visitor2.aspx">1.查看记录</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/visitor.aspx">2.添加记录</asp:HyperLink>
    <asp:Image ID="Image1" runat="server" Height="326px" ImageUrl="~/image/u=2001517475,2047419572&amp;fm=26&amp;gp=0.jpg" Width="473px" />
    <br />
</asp:Content>

