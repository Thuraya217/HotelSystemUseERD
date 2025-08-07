using HotelSystemUseERD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemUseERD.Repositories
{
    class ReviewRepository : IReviewRepository
    {
        private readonly HotelDbContext _context;

        public ReviewRepository(HotelDbContext context)
        {
            _context = context;
        }

        public void AddReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void DeleteReview(string reviewId)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.ReviewId == reviewId);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
        }

        public Review GetReviewById(string reviewId)
        {
            return _context.Reviews.FirstOrDefault(r => r.ReviewId == reviewId);
        }

        public List<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }

    }
}
