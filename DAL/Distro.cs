using System;
using System.Data;

namespace DAL
{
    public class Distro
    {
        public DataSet GetDistro()
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Distro";
            return conn.GetData(query);
        }
    }
}
