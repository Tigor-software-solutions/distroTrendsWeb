namespace distroTrend.Model
{
    public class Rating
    {
        public int Id { get; set; }
        public int DistroEditionId { get; set; }
        public int UserId { get; set; }
        public byte? RatingUsability { get; set; }
        public byte? RatingStability { get; set; }
        public byte? RatingUserFriendly { get; set; }
    }
}
