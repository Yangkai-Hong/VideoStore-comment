using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore.Services.Interfaces;
using VideoStore.Business.Components.Interfaces;
using Microsoft.Practices.ServiceLocation;
using VideoStore.Services.MessageTypes;


namespace VideoStore.Services
{
    public class ReviewService : IReviewService
    {
        private IReviewProvider ReviewProvider
        {
            get
            {
                return ServiceFactory.GetService<IReviewProvider>();
            }
        }

        public List<Review> GetReviews(Media media)
        {
            var internalReviews = ReviewProvider.GetReviews(media.Id);
            var externalReviews =
                MessageTypeConverter.Instance.Convert<List<Business.Entities.Review>, List<Review>>(internalReviews);

            return externalReviews;
        }

        public void CreateReview(Review review)
        {
            var internalReview = MessageTypeConverter.Instance.Convert<Review, Business.Entities.Review>(review);
            ReviewProvider.CreateReview(internalReview);
        }
    }
}
