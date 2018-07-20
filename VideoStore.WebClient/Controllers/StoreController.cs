using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.WebClient.ViewModels;
using VideoStore.Services.Interfaces;

namespace VideoStore.WebClient.Controllers
{
    public class StoreController : Controller
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

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListMedia()
        {
            return View(new CatalogueViewModel());
        }

        public ActionResult Details(int media)
        {
            return View(new DetailsViewModel(media));
        }

        public ActionResult CreateReview(UserCache pUser, int media)
        {
            ViewBag.Media = CatalogueService.GetMediaById(media);
            return View(new CreateReviewViewModel(pUser.Model));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReview(CreateReviewViewModel pReviewViewModel, UserCache pUser, int media)
        {
            ViewBag.Media = CatalogueService.GetMediaById(media);
            pReviewViewModel.Update(pUser.Model);

            if (!ModelState.IsValid)
            {
                return View(pReviewViewModel);
            }
   
            ReviewService.CreateReview(pReviewViewModel.ToReview(pUser.Model, ViewBag.Media));
            return RedirectToAction("Details", new { media = media });
        }

        public ActionResult ListMediaWebAPI()
        {
            return View();
        }
    }
}