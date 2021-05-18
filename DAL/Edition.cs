using System;
using System.Data;

namespace DAL
{
    public class Edition
    {
        public DataSet GetEdition(int distroId)
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Edition E Inner Join tbl_DistroEdition D ON E.Id = D.EditionId Where D.DistroId = " + distroId;
            return conn.GetData(query);
        }
    }
}
