using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class Rating
    {
        public List<distroTrend.Model.Rating> GetRatings(string connString, int distroEditionId)
        {
            DAL.Rating objRating = new DAL.Rating();

            DataSet ds = objRating.GetRatings(connString, distroEditionId);

            var ratingList = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new distroTrend.Model.Rating
                {
                    Id = dataRow.Field<int>("Id"),
                    DistroEditionId = dataRow.Field<int>("DistroEditionId"),
                    UserId = dataRow.Field<int>("UserId"),
                    RatingUsability = dataRow.Field<byte?>("Usability"),
                    RatingStability = dataRow.Field<byte?>("Stability"),
                    RatingUserFriendly = dataRow.Field<byte?>("UserFriendly")
                }).ToList();

            return ratingList;
        }
        public int Update(string connString, int distroEditionId, int userId, float ratingUsability, float ratingStability)
        {
            DAL.Rating objRating = new DAL.Rating();

            return objRating.Update(connString, distroEditionId, userId, ratingUsability, ratingStability);
        }
        public int Insert(string connString, int distroEditionId, int userId, float ratingUsability)
        {
            DAL.Rating objRating = new DAL.Rating();

            return objRating.Insert(connString, distroEditionId, userId, ratingUsability);
        }
    }
}
