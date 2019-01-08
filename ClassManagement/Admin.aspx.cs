using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    if (Session["usertype"].Equals("Teachers") == true)
        //    {
        //        Response.Redirect("Teacher.aspx");
        //    }
        //    else if(Session["usertype"].Equals("Students") == true)
        //    {
        //        Response.Redirect("Studnet.aspx");
        //    }
        //    else if (Session["usertype"].Equals("Admin") == false)
        //    {
        //        Response.Redirect("Login.aspx");
        //    }
        //}
        //catch (System.NullReferenceException)
        //{
        //    Response.Redirect("Login.aspx");
        //}
        //
        //if (!Page.IsPostBack)
        //{
            BindGridView();
        //}
    }

    private void DeleteRecord(string sno)
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

    private void BindGridView()
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

    private void AddNewRecord(string roomno, string sno, string sname, string restmoney)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "INSERT INTO zhusu" +
                              "(room_no,s_no,sname,restmoney)" +
                               "VALUES (@roomno,@sno,@sname,@restmoney)";
        try
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@roomno", roomno);
            cmd.Parameters.AddWithValue("@sno", sno);
            cmd.Parameters.AddWithValue("@sname", sname);
            cmd.Parameters.AddWithValue("@restmoney", restmoney);
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox tbroomno = (TextBox)GridView1.FooterRow.Cells[1].FindControl("TextBoxroomno");
        TextBox tbsno = (TextBox)GridView1.FooterRow.Cells[2].FindControl("TextBoxsno");
        TextBox tbsname = (TextBox)GridView1.FooterRow.Cells[3].FindControl("TextBoxsname");
        TextBox tbrestmoney = (TextBox)GridView1.FooterRow.Cells[4].FindControl("TextBoxrestmoney");
        if ((tbroomno.Text.Trim() != "") && (tbsno.Text.Trim() != "") && (tbsname.Text.Trim() != "") && (tbrestmoney.Text.Trim() != ""))
        {
            AddNewRecord(tbroomno.Text, tbsno.Text, tbsname.Text, tbrestmoney.Text);
            BindGridView();
        }
    }

    private void UpdateRecord(string roomno, string sno)
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
        BindGridView(); // Rebind GridView to show the data in default mode
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex; // turn to edit mode
        BindGridView(); // Rebind GridView to show the data in edit mode
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Accessing Edited values from the GridView
        string roomno =((TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("TextBoxEditroomno")).Text;
        string sno = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBoxEditsno")).Text;
        //string sname = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].FindControl("TextBoxEditsname")).Text;
        //string restmoney = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBoxEditrestmoney")).Text;
                 
        UpdateRecord(roomno, sno); // call update method

        GridView1.EditIndex = -1; //Turn the Grid to read only mode

        BindGridView(); // Rebind GridView to reflect changes made
        

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //get the ID of the selected row
        string sno = ((Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("Labelsno")).Text;
        DeleteRecord(sno); //call the method for delete

        BindGridView(); // Rebind GridView to reflect changes made

    }

}
