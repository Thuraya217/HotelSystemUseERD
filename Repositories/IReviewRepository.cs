using HotelSystemUseERD.Models;

namespace HotelSystemUseERD.Repositories
{
    public interface IReviewRepository
    {
        void AddReview(Review review);
        void DeleteReview(string reviewId);
        List <Review> GetAllReviews();
        List<Review> GetReviewsByGuestId(string guestId);
        List<Review> GetReviewsByRoomId(string roomId);
        Review GetReviewById(string reviewId);
    }
}