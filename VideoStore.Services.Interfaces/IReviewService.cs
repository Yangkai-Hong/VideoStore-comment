using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using VideoStore.Services.MessageTypes;

namespace VideoStore.Services.Interfaces
{
    [ServiceContract]
    public interface IReviewService
    {
        [OperationContract]
        List<Review> GetReviews(Media media);

        [OperationContract]
        void CreateReview(Review review);
    }
}
