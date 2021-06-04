using System;
using System.Data;

namespace DAL
{
    public class Points
    {
        public DataSet GetPoints()
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Points";
            return conn.GetData(query);
        }
    }
}
