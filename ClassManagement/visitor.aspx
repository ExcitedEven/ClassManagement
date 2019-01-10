<%@ Page Language="C#" AutoEventWireup="true" CodeFile="visitor.aspx.cs" Inherits="visitor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" Height="562px" Width="500
                px" OnFinishButtonClick="Wizard1_FinishButtonClick">
                <HeaderStyle  BackColor="#FFCC66" BorderColor="#FFFBD6" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="2em" ForeColor="#333333" HorizontalAlign="Center" />
                <NavigationButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                <SideBarButtonStyle ForeColor="White" />
                <SideBarStyle BackColor="#990000" Font-Size="2em" VerticalAlign="Middle" />
                <WizardSteps>
                    <asp:WizardStep runat="server" title="第一步">
                        基本信息登记<br /> 
                         
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                            <DayStyle Width="14%" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                            <TodayDayStyle BackColor="#CCCC99" />
                        </asp:Calendar>
                        <br /> 姓名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator">姓名不能为空！</asp:RequiredFieldValidator>
                        <br />
                        性别：<asp:RadioButtonList ID="RadioButtonList1" runat="server" BorderStyle="Ridge" Height="60px" RepeatDirection="Horizontal" Width="286px">
                            <asp:ListItem>男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        联系电话：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator">不能为空！</asp:RequiredFieldValidator>
                        <br />
                        进入时间：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="RequiredFieldValidator">不能为空！</asp:RequiredFieldValidator>
                        <br />
                        <br />
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" title="第二步">
                        是否为当天值班的职工人员？<br /> 
                         
                        <br />
                        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Width="73px">
                            <asp:ListItem>保洁员</asp:ListItem>
                            <asp:ListItem>保安</asp:ListItem>
                            <asp:ListItem>不是</asp:ListItem>
                        </asp:ListBox>
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" Title="第三步">
                        <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                        <br />
                        人员离开时间：
                     
                        <br />
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <br />
                        备注信息：<br /> 
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" Title="第四步">
                        <asp:TextBox ID="TextBox6" runat="server" Height="193px" OnTextChanged="TextBox6_TextChanged" style="margin-top: 0px" TextMode="MultiLine" Width="341px"></asp:TextBox>
                        <br />
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="更新数据库" />
                        <br />
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回首页" />
                        <br />
                    </asp:WizardStep>
                </WizardSteps>
                <HeaderTemplate>
                    非住宿人员进出登记
                </HeaderTemplate>
            </asp:Wizard>
        </div>
    </form>
</body>
</html>
