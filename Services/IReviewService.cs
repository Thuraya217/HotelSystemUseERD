using HotelSystemUseERD.Models;

namespace HotelSystemUseERD.Services
{
    internal interface IReviewService
    {
        void AddReview(Review review);
        void DeleteReview(string reviewId);
        List<Review> GetAllReviews();
        Review GetReviewById(string reviewId);
        List<Review> GetReviewsByGuestId(string guestId);
        List<Review> GetReviewsByRoomId(string roomId);
    }
}