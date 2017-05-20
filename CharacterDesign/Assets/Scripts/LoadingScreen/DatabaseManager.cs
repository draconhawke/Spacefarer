using System;
using System.Data;
using System.Data.SqlClient;

public class DatabaseManager {

    string DBConnectionString="Data Source=spacefarerdb.database.windows.net;Initial Catalog=SpacefarerDB;Persist Security Info=false;User ID=risenAshes;Password=Sund@10May;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=false;Connection Timeout=30";

    public DataTable GetAccount(string account)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnectionString;
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(account, conn);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr);
                var cnt = dt.Rows.Count;
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
