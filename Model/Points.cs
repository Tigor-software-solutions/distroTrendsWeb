using System;

namespace distroTrend.Model
{
    public class Points
    {
        public int distroId { get; set; }
        public DateTime Date { get; set; }
        public decimal DistroWatchPoints { get; set; }
        public decimal TotalPoints { get; set; }
    }
}
