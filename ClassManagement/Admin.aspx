<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="apple-touch-fullscreen" content="yes">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <meta name="format-detection" content="telephone=no">
    <title>Admin</title>

    <link href="css/base.css" rel="stylesheet" type="text/css">
    <link href="css/home.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <script src="/demos/googlegg.js"></script>

    <form id="form1" runat="server">
        <div class="index-page" style="height: 100%">
            <div class="solution-more">
                <div class="solution-more-slide">
                    <div class="container">
                        <div class="hd">
                            <ul>
                                <li class="item-1 on">
                                    <i></i>
                                    <div class="text">
                                        <h3>宿舍</h3>
                                        <p>管理宿舍、学生</p>
                                    </div>
                                </li>

                                <li class="item-2" style="left: 0px; top: 0px">
                                    <i></i>
                                    <div class="text">
                                        <h3>排班</h3>
                                        <p>管理职工排班</p>
                                    </div>
                                </li>
                            </ul>
                        </div>


                        <ul class="bd" style="position: relative; width: 1920px; height: 600px;">
                            <li class="item-1" style="position: absolute; width: 1920px; left: 0px; top: 0px; display: list-item;">
                                <div class="container">
                                    <div class="inner">

                                        <div align="center">
                                            <asp:GridView ID="GridView1" runat="server"
                                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="4" PageSize="1" AutoGenerateColumns="False"
                                                ShowFooter="True"
                                                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                                OnRowEditing="GridView1_RowEditing"
                                                OnRowUpdating="GridView1_RowUpdating"
                                                OnRowDeleting="GridView1_RowDeleting"
                                                CssClass="auto-style1"
                                                EnableModelValidation="True" ForeColor="Black" GridLines="Horizontal">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="寝室号">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBoxEditroomno" runat="server" Text='<%# Bind("room_no") %>' />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labelroomno" runat="server" Text='<%# Bind("room_no") %>' />
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="TextBoxroomno" runat="server" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="学号">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBoxEditsno" runat="server" Text='<%# Bind("s_no") %>' />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labelsno" runat="server" Text='<%# Bind("s_no") %>' />
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="TextBoxsno" runat="server" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="学生姓名">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labelsname" runat="server" Text='<%# Bind("s_name") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="电费">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBoxEditrestmoney" runat="server" Text='<%# Bind("rest_money") %>' />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labelrestmoney" runat="server" Text='<%# Bind("rest_money") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton HeaderText="操作" />
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />

                                            </asp:GridView>
                                            <asp:Button ID="Button1" Width="30%" runat="server" Style="color: black" Text="增  加" OnClick="Button1_Click" />
                                        </div>

                                    </div>
                                </div>
                            </li>

                            <li class="item-2" style="position: absolute; width: 1920px; left: 0px; top: 0px; display: none;">
                                <div class="container">
                                    <div class="inner">

                                        <div align="center">
                                            <asp:GridView ID="GridView2" runat="server"
                                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="4" PageSize="1" AutoGenerateColumns="False"
                                                ShowFooter="True"
                                                OnRowCancelingEdit="GridView2_RowCancelingEdit"
                                                OnRowEditing="GridView2_RowEditing"
                                                OnRowUpdating="GridView2_RowUpdating"
                                                OnRowDeleting="GridView2_RowDeleting"
                                                CssClass="auto-style1"
                                                EnableModelValidation="True" ForeColor="Black" GridLines="Horizontal">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="时间">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBoxEditdutytime" runat="server" Text='<%# Bind("dutytime") %>' />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labeldutytime" runat="server" Text='<%# Bind("dutytime") %>' />
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="TextBoxdutytime" runat="server" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="职工编号">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBoxEditcleanerno" runat="server" Text='<%# Bind("cleaner_no") %>' />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labelcleanerno" runat="server" Text='<%# Bind("cleaner_no") %>' />
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="TextBoxcleanerno" runat="server" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="职工姓名">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labelcleanername" runat="server" Text='<%# Bind("cleaner_name") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:CommandField ShowEditButton="True" ShowDeleteButton HeaderText="操作" />
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />

                                            </asp:GridView>
                                            <asp:Button ID="Button2" Width="30%" runat="server" Style="color: black" Text="增  加" OnClick="Button2_Click" />
                                        </div>
                                    </div>

                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
        <script type="text/javascript" src="js/SuperSlide.js"></script>
        <script type="text/javascript">
            $(".solution-more-slide").slide({
                effect: 'fold'
            });
	//hover
        </script>
        <asp:Button ID="Button3" runat="server" Text="退出" OnClick="Button3_Click" />
    </form>

</body>
</html>
