using HotelSystemUseERD.Models;
using HotelSystemUseERD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemUseERD.Services
{
    class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void AddReview(Review review)
        {

            if (string.IsNullOrWhiteSpace(review.Comment))
            {
                Console.WriteLine("Review comment cannot be empty.");
                return;
            }

            var existingReviews = _reviewRepository.GetAllReviews();
            bool alreadyReviewed = existingReviews.Any(r =>
                r.GuestId == review.GuestId &&
                r.RoomId == review.RoomId
            );

            if (alreadyReviewed)
            {
                Console.WriteLine("You have already reviewed this room.");
                return;
            }

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

        public List<Review> GetReviewsByRoomId(string roomId)
        {
            return _reviewRepository.GetAllReviews()
                .Where(r => r.RoomId == roomId)
                .ToList();
        }

        public List<Review> GetReviewsByGuestId(string guestId)
        {
            return _reviewRepository.GetAllReviews()
                .Where(r => r.GuestId == guestId)
                .ToList();
        }
    }
}

