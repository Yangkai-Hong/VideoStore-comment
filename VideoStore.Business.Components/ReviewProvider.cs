using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Business.Components.Interfaces;
using VideoStore.Business.Entities;
using System.Transactions;

namespace VideoStore.Business.Components
{
    public class ReviewProvider : IReviewProvider
    {
        public List<Review> GetReviews(int pId)
        {
            using (var lContainer = new VideoStoreEntityModelContainer())
            {
                return lContainer.Reviews.Include("Reviewer.LoginCredential").Include("Media.Stocks").Where(p => p.Media.Id == pId).ToList();
            }
        }

        public void CreateReview(Review review)
        {
            using (var lScope = new TransactionScope())
            using (var lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Entry(review.Media).State = EntityState.Unchanged;
                lContainer.Entry(review.Reviewer).State = EntityState.Unchanged;
                ;
                lContainer.Reviews.Add(review);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }
    }
}
