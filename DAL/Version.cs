using System;
using System.Data;

namespace DAL
{
    public class Version
    {
        public DataSet GetVersion(string connString)
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Version Order by ReleaseDate Desc";
            return conn.GetData(connString, query);
        }
    }
}
