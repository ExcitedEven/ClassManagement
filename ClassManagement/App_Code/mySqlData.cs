using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// SqlData 的摘要说明
/// </summary>
public class mySqlData
{
    public mySqlData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public String MyRead(String userID,String SQL)
    {

        SqlDataReader dr;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DormitoryManagementConnectionString"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = System.Data.CommandType.Text;
        SqlParameter para = new SqlParameter();
        cmd.CommandText = SQL;
        para = new SqlParameter("@userId", System.Data.SqlDbType.VarChar, 50);
        para.Value = userID;
        cmd.Parameters.Add(para);
        try
        {
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string temp = dr.GetString(0);
                dr.Close();
                conn.Close();
                return temp;
            }
            else
            {
                dr.Close();
                conn.Close();
                return "E:NO USER";
            }
        }
        catch(SqlException e)
        {
            return "E:EORRO";
        }
    }
}