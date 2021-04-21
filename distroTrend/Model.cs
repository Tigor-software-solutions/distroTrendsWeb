using System;
using System.Data;

namespace distroTrend.ModelDB
{
    public class Distro
    {
        public DataSet GetDistro()
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM distro";
            return conn.GetData(query);
        }
    }
}