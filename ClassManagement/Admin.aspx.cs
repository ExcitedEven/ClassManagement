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

    private void DeleteRecord(string cno)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "DELETE FROM zhusu WHERE sno = @sno";

        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@cno", cno);
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

    private void AddNewRecord(string cno, string cname, string cmax, string cleft)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "INSERT INTO Course" +
                              "(cno,cname,cmax,cleft)" +
                               "VALUES (@cno,@cname,@cmax,@cleft)";
        try
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@cno", cno);
            cmd.Parameters.AddWithValue("@cname", cname);
            cmd.Parameters.AddWithValue("@cmax", cmax);
            cmd.Parameters.AddWithValue("@cleft", cleft);
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
        TextBox tbcno = (TextBox)GridView1.FooterRow.Cells[1].FindControl("TextBoxcno");
        TextBox tbcname = (TextBox)GridView1.FooterRow.Cells[2].FindControl("TextBoxcname");
        TextBox tbcmax = (TextBox)GridView1.FooterRow.Cells[3].FindControl("TextBoxcmax");
        TextBox tbcleft = (TextBox)GridView1.FooterRow.Cells[4].FindControl("TextBoxcleft");
        if ((tbcno.Text.Trim() != "") && (tbcname.Text.Trim() != "") && (tbcmax.Text.Trim() != "") && (tbcleft.Text.Trim() != ""))
        {
            AddNewRecord(tbcno.Text,tbcname.Text,tbcmax.Text,tbcleft.Text);
            BindGridView();
        }
    }

    private void UpdateRecord(string cno, string cname, string cmax, string cleft)
    {
        SqlConnection connection = new SqlConnection(GetConnectionString());
        string sqlStatement = "UPDATE Course " +
                              "SET cno = cno, cname = @cname, cmax= @cmax, cleft= @cleft " +
                              "WHERE cno = @cno";
        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.AddWithValue("@cno", cno);
            cmd.Parameters.AddWithValue("@cname", cname);
            cmd.Parameters.AddWithValue("@cmax", cmax);
            cmd.Parameters.AddWithValue("@cleft", cleft);
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
        string cno = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("TextBoxEditcno")).Text;
        string cname = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBoxEditcname")).Text;
        string cmax = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].FindControl("TextBoxEditcmax")).Text;
        string cleft = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBoxEditcleft")).Text;

        UpdateRecord(cno,cname, cmax, cleft); // call update method

        GridView1.EditIndex = -1; //Turn the Grid to read only mode

        BindGridView(); // Rebind GridView to reflect changes made
        

    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //get the ID of the selected row
        string cno = ((Label)GridView1.Rows[e.RowIndex].Cells[0].FindControl("Labelcno")).Text;
        DeleteRecord(cno); //call the method for delete

        BindGridView(); // Rebind GridView to reflect changes made

    }

}
