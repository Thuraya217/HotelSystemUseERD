using HotelSystemUseERD.Models;

namespace HotelSystemUseERD.Repositories
{
    internal interface IReviewRepository
    {
        void AddReview(Review review);
        void DeleteReview(string reviewId);
        List<Review> GetAllReviews();
        Review GetReviewById(string reviewId);
    }
}