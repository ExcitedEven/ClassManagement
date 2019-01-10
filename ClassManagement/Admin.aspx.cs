using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["IsAdmin"].Equals("Yes") == false)
            {
                Response.Redirect("Login.aspx");
            }
        }
        catch (System.NullReferenceException)
        {
            Response.Redirect("Login.aspx");
        }
        
        if (!Page.IsPostBack)
        {
            BindGridView1();
            BindGridView2();
        }
    }

    private void DeleteRecord1(string sno)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "DELETE FROM zhusu WHERE s_no = @sno";

        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@sno", sno);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Deletion Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }

    private void BindGridView1()
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(GetConnectionString());
        try
        {
            connection.Open();
            string sqlStatement = "SELECT zhusu.s_no,zhusu.room_no,rest_money,s_name FROM zhusu,student,bedroom WHERE zhusu.s_no = student.s_no AND zhusu.room_no = bedroom.room_no";
            SqlCommand sqlCmd = new SqlCommand(sqlStatement, connection);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }

    private string GetConnectionString()
    {
        //Where MyConsString is the connetion string that was set up in the web config file
        //return System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString;
        string connstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dormitory_management.mdf;Integrated Security=True";
        return connstr;
    }

    private void AddNewRecord1(string roomno, string sno)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "INSERT INTO zhusu" +
                              "(room_no,s_no)" +
                               "VALUES (@roomno,@sno)";
        try
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@roomno", roomno);
            cmd.Parameters.AddWithValue("@sno", sno);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string roomno = ((TextBox)GridView1.FooterRow.Cells[0].FindControl("TextBoxroomno")).Text.ToString().Trim();
        string sno = ((TextBox)GridView1.FooterRow.Cells[1].FindControl("TextBoxsno")).Text.ToString().Trim();
        if ((roomno != "") && (sno != ""))
        {
            AddNewRecord1(roomno, sno);
            BindGridView1();
        }
    }

    private void UpdateRecord1(string roomno, string sno)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "UPDATE zhusu " +
                              "SET room_no = '" + roomno + "', s_no = '" +sno +"' " +"WHERE s_no = '" +sno +"'";
        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            //cmd.Parameters.AddWithValue("@roomno", roomno);
            //cmd.Parameters.AddWithValue("@sno", sno);
            //cmd.Parameters.AddWithValue("@sname", sname);
            //cmd.Parameters.AddWithValue("@restmoney", restmoney);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert/Update Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1; //swicth back to default mode
        BindGridView1(); // Rebind GridView to show the data in default mode
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex; // turn to edit mode
        BindGridView1(); // Rebind GridView to show the data in edit mode
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Accessing Edited values from the GridView
        string roomno =((TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("TextBoxEditroomno")).Text;
        string sno = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBoxEditsno")).Text;
        //string restmoney = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBoxEditrestmoney")).Text;
                 
        UpdateRecord1(roomno, sno); // call update method

        GridView1.EditIndex = -1; //Turn the Grid to read only mode

        BindGridView1(); // Rebind GridView to reflect changes made
        

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //get the ID of the selected row
        Label lsno = (Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("Labelsno");
        string sno = ((Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("Labelsno")).Text;
        DeleteRecord1(sno); //call the method for delete

        BindGridView1(); // Rebind GridView to reflect changes made

    }



    private void DeleteRecord2(string cleanerno)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "DELETE FROM on_duty WHERE cleaner_no = @cleanerno";

        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@cleanerno", cleanerno);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Deletion Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }

    private void BindGridView2()
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(GetConnectionString());
        try
        {
            connection.Open();
            string sqlStatement = "SELECT on_duty.dutytime, on_duty.cleaner_no, cleaner_name FROM on_duty, cleaner WHERE on_duty.cleaner_no = cleaner.cleaner_no";
            SqlCommand sqlCmd = new SqlCommand(sqlStatement, connection);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }

    private void AddNewRecord2(string dutytime,string cleanerno)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "INSERT INTO on_duty" +
                              "(cleaner_no,dutytime)" +
                               "VALUES (@cleanerno,@dutytime)";
        try
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@cleanerno", cleanerno);
            cmd.Parameters.AddWithValue("@dutytime", dutytime);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string dutytime = ((TextBox)GridView2.FooterRow.Cells[0].FindControl("TextBoxdutytime")).Text.ToString().Trim();
        string cleanerno = ((TextBox)GridView2.FooterRow.Cells[1].FindControl("TextBoxcleanerno")).Text.ToString().Trim();
        if ((dutytime != "") && (cleanerno != ""))
        {
            AddNewRecord2(dutytime, dutytime);
            BindGridView2();
        }
    }

    private void UpdateRecord2(string dutytime, string cleanerno)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "UPDATE on_duty " +
                              "SET dutytime = '" + dutytime + "', cleaner_no = '" + cleanerno + "' " + "WHERE cleaner_no = '" + cleanerno + "'";
        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            //cmd.Parameters.AddWithValue("@roomno", roomno);
            //cmd.Parameters.AddWithValue("@sno", sno);
            //cmd.Parameters.AddWithValue("@sname", sname);
            //cmd.Parameters.AddWithValue("@restmoney", restmoney);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Update Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }

    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1; //swicth back to default mode
        BindGridView2(); // Rebind GridView to show the data in default mode
    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex; // turn to edit mode
        BindGridView2(); // Rebind GridView to show the data in edit mode
    }

    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Accessing Edited values from the GridView
        string dutytime = ((TextBox)GridView2.Rows[e.RowIndex].Cells[0].FindControl("TextBoxEditdutytime")).Text;
        TextBox c = (TextBox)GridView2.Rows[e.RowIndex].Cells[1].FindControl("TextBoxEditcleanerno");
        string cleanerno = ((TextBox)GridView2.Rows[e.RowIndex].Cells[1].FindControl("TextBoxEditcleanerno")).Text;

        UpdateRecord2(dutytime, cleanerno); // call update method

        GridView2.EditIndex = -1; //Turn the Grid to read only mode

        BindGridView2(); // Rebind GridView to reflect changes made


    }

    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //get the ID of the selected row
        string cleanerno = ((Label)GridView2.Rows[e.RowIndex].Cells[1].FindControl("Labelcleanerno")).Text;
        DeleteRecord2(cleanerno); //call the method for delete

        BindGridView2(); // Rebind GridView to reflect changes made

    }

}
