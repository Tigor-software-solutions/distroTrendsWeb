using distroTrend.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace distroTrend
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = GetDistros();
            GridView1.DataBind();
        }
        private DataSet GetDistros()
        {
            DataSet ds = new DataSet();
            
            List<Model.Distro> listDistro = new List<Distro>();

            Distro objDistro = new Distro
            { 
                Code="UBT",
                Name = "Ubuntu"
            };
            listDistro.Add(objDistro);

            objDistro = new Distro
            {
                Code = "Mint",
                Name = "LinuxMint"
            };
            listDistro.Add(objDistro);

            DataTable dts = ToDataTable<Distro>(listDistro);

            GetDistroRanking(dts);

            ds.Tables.Add(dts);

            return ds;
        }
        private void GetDistroRanking(DataTable dt)
        {
            const string Rank = "Rank";
            dt.Columns.Add(Rank, typeof(Int32)).SetOrdinal(0);
            
            int rank = 1;
            foreach (DataRow dr in dt.Rows)
            {
                dr[Rank] = rank;
                rank++;

                dr["Name"] = "<a href='DistroMain.aspx?"+ Helper.Constants.URL_PARAMETER_DISTRO_CODE + "=" + dr["Code"].ToString() + "'>"+ dr["Name"] + "</a>";
            }
        }
        public DataTable ToDataTable<T>(IEnumerable<T> self)
        {
            var properties = typeof(T).GetProperties();

            var dataTable = new DataTable();
            foreach (var info in properties)
                dataTable.Columns.Add(info.Name, Nullable.GetUnderlyingType(info.PropertyType)
                   ?? info.PropertyType);

            foreach (var entity in self)
                dataTable.Rows.Add(properties.Select(p => p.GetValue(entity)).ToArray());

            return dataTable;
        }
    }
}