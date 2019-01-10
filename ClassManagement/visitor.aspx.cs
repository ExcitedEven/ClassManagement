using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class visitor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        string x;
        x = "";
        x += TextBox1.Text + "\n";
        x += TextBox2.Text + "\n";
        x += RadioButtonList1.Text + "\n";
        x += TextBox3.Text + "\n";
        x += ListBox1.SelectedItem.Text + "\n";
        x += TextBox4.Text + "\n";
        x += TextBox5.Text + "\n";    
        TextBox6.Text = x;
        
    }

    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["dormitorymanagementConnectionString"].ConnectionString;
       
        SqlCommand Cmd = new SqlCommand();
        Cmd.Connection = conn;
      
        string SqlStr;
        SqlStr = "Insert into visitor ([visitor_date],[visitor_name],[visitor_phone]) values (@visitor_date,@visitor_name,@visitor_phone)";
        Cmd.CommandText = SqlStr;
        SqlParameter para1 = new SqlParameter("@visitor_date", SqlDbType.VarChar, 20);
        para1.Value = TextBox2.Text;
        Cmd.Parameters.Add(para1);
        SqlParameter para2 = new SqlParameter("@visitor_name", SqlDbType.VarChar, 10);
        para2.Value = TextBox1.Text;
        Cmd.Parameters.Add(para2);
        SqlParameter para3 = new SqlParameter("@visitor_phone", SqlDbType.VarChar, 10);
        para3.Value = TextBox3.Text;
        Cmd.Parameters.Add(para3);
        try
        {
            conn.Open();
            Cmd.ExecuteNonQuery();
            Label1.Text = "登记成功!";
        }
        catch (SqlException sqlException)
        {
            Response.Write(sqlException.Message);
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("visitors.aspx");
    }
}