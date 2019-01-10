using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{

    protected void Button_clear_Click(object sender, EventArgs e)
    {
        TextBox_UserID.Text = "";
        TextBox_Pwd.Text = "";
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        string userId = TextBox_UserID.Text.Trim();
        string userpwd = TextBox_Pwd.Text.Trim();
        mySqlData ms = new mySqlData();
       
                if (ms.MyRead( userId, "SELECT [admin_no] FROM Admin where [admin_no] = @userId").Equals(userpwd) == true)
                {
                    Session.Add("IsAdmin", "Yes");
                    Response.Redirect("Admin.aspx");
                }            
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("visitors.aspx");
    }
}