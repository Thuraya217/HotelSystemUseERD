using HotelSystemUseERD.Models;
using HotelSystemUseERD.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemUseERD.Repositories
{
    public class ReviewRepository: IReviewRepository
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
                var review = _context.Reviews.Find(reviewId);
                if (review != null)
                {
                    _context.Reviews.Remove(review);
                    _context.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException($"Review with ID {reviewId} not found.");
                }
            }

            public Review GetReviewById(string reviewId)
            {
                return _context.Reviews.Find(reviewId);
            }

            public List<Review> GetAllReviews()
            {
                return _context.Reviews.ToList();
            }

            public List<Review> GetReviewsByGuestId(string guestId)
            {
                return _context.Reviews.Where(r => r.GuestId == guestId).ToList();
            }

            public List<Review> GetReviewsByRoomId(string roomId)
            {
                return _context.Reviews.Where(r => r.RoomId == roomId).ToList();
            }
        
    }
}
