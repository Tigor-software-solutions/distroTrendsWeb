using distroTrend.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;

namespace distroTrend
{
    public partial class Home : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        string _connString = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Trace("Inside " + this.GetType().Name + ".Page_Load()");

            string _connString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

            gvMain.DataSource = GetDistros();
            gvMain.DataBind();
        }
        private DataTable GetDistros()
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
        private DataTable GetDistrosFromDB()
        {
            DataSet ds = new DataSet();

            BLL.Distro distro = new BLL.Distro();
            ds = distro.GetDistroAsDataSet(_connString);

            DataTable dt = GetDistroRanking(ds.Tables[0]);

            return dt;
        }

        private DataTable GetDistroRanking(DataTable dt)
        {
            const string Points = "Points";
            const string Rank = "Rank";

            BLL.Points objPoints = new BLL.Points();
            List<distroTrend.Model.Points> listPoints;
            listPoints = objPoints.GetPoints(_connString);

            dt.Columns.Add(Points, typeof(Decimal)).SetOrdinal(2);

            foreach (DataRow dr in dt.Rows)
            {
                string tempDistroId = null;
                if (dr["Id"] != null)//distroId
                    tempDistroId = dr["Id"].ToString();
                int distroId = 0;

                if (tempDistroId != null)
                    distroId = Convert.ToInt32(tempDistroId);

                distroTrend.Model.Points point = listPoints.Where(x => x.distroId == distroId).FirstOrDefault();
                string points = "0";
                if (point != null)
                    points = point.TotalPoints.ToString();

                logger.Debug("distroId=" + distroId + ", points=" + points);

                dr[Points] = points;
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "points desc";
            DataTable sortedDT = dv.ToTable();

            sortedDT.Columns.Add(Rank, typeof(Int32)).SetOrdinal(0);

            int rank = 1;
            foreach (DataRow dr in sortedDT.Rows)
            {
                dr[Rank] = rank;
                rank++;

                //dr["Name"] = "<a href='DistroMain.aspx?" + Helper.Constants.URL_PARAMETER_DISTRO_CODE + "=" + dr["Code"].ToString() + "'>" + dr["Name"] + "</a>";
                dr["Name"] = "<a href='DistroMain.aspx?" + Helper.Constants.URL_PARAMETER_DISTRO_ID + "=" + dr["Id"].ToString() + "'>" + dr["Name"] + "</a>";
            }

            return sortedDT;
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