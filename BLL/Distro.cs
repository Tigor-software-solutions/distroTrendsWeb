using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class DistroBAL
    {
        public DataSet GetDistro()
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM distro";
            return conn.GetData(query);
        }
    }
}
