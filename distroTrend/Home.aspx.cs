using distroTrend.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace distroTrend
{
    public partial class Home : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Trace("Inside " + this.GetType().Name + ".Page_Load()");
            gvMain.DataSource = GetDistros();
            gvMain.DataBind();
        }
        private DataSet GetDistros()
        {
            //return GetDistrosFromClass();
            return GetDistrosFromDB();
        }
        private DataSet GetDistrosFromClass()
        {
            DataSet ds = new DataSet();

            List<Model.Distro> listDistro = new List<Distro>();

            Distro objDistro = new Distro
            {
                Code = "UBT",
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
        private DataSet GetDistrosFromDB()
        {
            DataSet ds = new DataSet();

            BLL.Distro distro = new BLL.Distro();
            ds = distro.GetDistroAsDataSet();

            GetDistroRanking(ds.Tables[0]);

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

                //dr["Name"] = "<a href='DistroMain.aspx?" + Helper.Constants.URL_PARAMETER_DISTRO_CODE + "=" + dr["Code"].ToString() + "'>" + dr["Name"] + "</a>";
                dr["Name"] = "<a href='DistroMain.aspx?" + Helper.Constants.URL_PARAMETER_DISTRO_ID + "=" + dr["Id"].ToString() + "'>" + dr["Name"] + "</a>";
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

        protected void gvMain_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvMain.PageIndex = e.NewPageIndex;
            gvMain.DataBind();
        }
    }
}