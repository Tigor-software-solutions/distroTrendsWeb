namespace distroTrend.Model
{
    public class Version
    {
        public int Id { get; set; }
        public int DistroId { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
    }
}
