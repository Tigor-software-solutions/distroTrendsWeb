using System;
using System.Data;

namespace DAL
{
    public class Version
    {
        public DataSet GetVersion()
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Version";
            return conn.GetData(query);
        }
    }
}
