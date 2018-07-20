a. Components modified or introduced: 
	- VideoStore.Business/VideoStore.Business.Entities/VideoStoreEntityModel.edmx/Model1.tt/Review.cs   (Add a new business entity class Review)
	- VideoStore.Business/VideoStore.Business.Entities/VideoStoreEntityModel.edmx.sql   (Create tables including Reviews to database)
	- VideoStore.Services/VideoStore.Services.MessageTypes/Review.cs   (Add a new MessageType class Review)
	- VideoStore.Services/VideoStore.Services/MessageTypeConverter.cs   (Convert between business entity Review and MessageType Review)
	
	- VideoStore.Business/VideoStore.Business.Components.Interfaces/IReviewProvider.cs   (Create ReviewProvider Interface with GetReviews and CreateReview methods)
	- VideoStore.Business/VideoStore.Business.Components/ReviewProvider.cs   (Create Review Provider)
	- VideoStore.Services/VideoStore.Services.Interfaces/IReviewService.cs   (Create ReviewService Interface)
	- VideoStore.Services/VideoStore.Services/ReviewService.cs   (Create Review Service)
	- VideoStore.Application/VideoStore.Process/App.config   (Configure IReviewProvider, ReviewProvider, IReviewService and ReviewService)
	- VideoStore.Presentation/VideoStore.WebClient/ServiceFactory.cs   (Configure IReviewService and ReviewService)

	- VideoStore.Presentation/VideoStore.WebClient/ViewModels/DetailsViewModel.cs   (Model for Details View)
	- VideoStore.Presentation/VideoStore.WebClient/ViewModels/CreateReviewModel.cs   (Model for CreateReview View) 
	- VideoStore.Presentation/VideoStore.WebClient/Controllers/StoreController.cs   (Controller for all Views in Store folder)
	- VideoStore.Presentation/VideoStore.WebClient/Views/Store/ListMedia.cshtml   (View that lists all medias and links to details of every media)
	- VideoStore.Presentation/VideoStore.WebClient/Views/Store/Details.cshtml   (View that shows all details including reviews of the media)
	- VideoStore.Presentation/VideoStore.WebClient/Views/Store/CreateReview.cshtml   (View for creating review of the media)

	- VideoStore.Presentation/VideoStore.WebClient/Controllers/WebAPI/MediaController.cs   (ApiController for ListMediaWebAPI View)
	- VideoStore.Presentation/VideoStore.WebClient/Views/Store/ListMediaWebAPI.cshtml   (View that lists all medias using Web API approach)
	- VideoStore.Presentation/VideoStore.WebClient/App_Start/WebApiConfig.cs   (Configure Web Api Route)
	- VideoStore.Presentation/VideoStore.WebClient/Global.asax   (Register WebApiConfig)

b. Run the solution following these steps:
	1. Open VideoStore.sln file using Visual Studio.
	2. Build the solution.
	3. Create database Videos.
	4. SQL Execute VideoStoreEntityModel.edmx.sql.
	5. Debug VideoStore.Process.
	6. Debug VideoStore.WebClient.
	7. Register for a new user account, then log in.
	8. Now you can read and write reviews.
	9. For Web API part, browse to http://localhost:1274/Store/ListMediaWebAPI.
	