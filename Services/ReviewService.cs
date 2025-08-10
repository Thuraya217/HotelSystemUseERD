using HotelSystemUseERD.Models;
using HotelSystemUseERD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemUseERD.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void AddReview(Review review)
        {

            _reviewRepository.AddReview(review);
        }

        public void DeleteReview(string reviewId)
        {
            _reviewRepository.DeleteReview(reviewId);
        }

        public Review GetReviewById(string reviewId)
        {
            return _reviewRepository.GetReviewById(reviewId);
        }

        public List<Review> GetAllReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        public List<Review> GetReviewsByGuestId(string guestId)
        {
            return _reviewRepository.GetReviewsByGuestId(guestId);
        }

        public List<Review> GetReviewsByRoomId(string roomId)
        {
            return _reviewRepository.GetReviewsByRoomId(roomId);
        }
    }
}


