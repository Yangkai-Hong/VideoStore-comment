using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStore.Services.Interfaces;
using VideoStore.Services.MessageTypes;

namespace VideoStore.WebClient.ViewModels
{
    public class DetailsViewModel
    {
        private ICatalogueService CatalogueService
        {
            get
            {
                return ServiceFactory.Instance.CatalogueService;
            }
        }
        private IReviewService ReviewService
        {
            get
            {
                return ServiceFactory.Instance.ReviewService;
            }
        }

        public Media Media { get; }
        public List<Review> Reviews { get; }
        public string AverageRating { get; }

        public DetailsViewModel(int id)
        {
            Media = CatalogueService.GetMediaById(id);
            Reviews = ReviewService.GetReviews(Media);
            AverageRating = Reviews.Select(r => r.Rating).DefaultIfEmpty(0).Average().ToString("f1");
        }
    }
}