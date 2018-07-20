using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoStore.Services.Interfaces;
using VideoStore.Services.MessageTypes;
using VideoStore.WebClient.ViewModels;

namespace VideoStore.WebClient.Controllers.api
{
    public class MediaController : ApiController
    {
        private ICatalogueService CatalogueService
        {
            get
            {
                return ServiceFactory.Instance.CatalogueService;
            }
        }

        public IEnumerable<Media> GetAllMedias()
        {
            return CatalogueService.GetMediaItems(0, int.MaxValue);
        }

        public IHttpActionResult GetMedia(string id)
        {
            var media = CatalogueService.GetMediaItems(0, int.MaxValue).FirstOrDefault((p) => p.Title == id);
            if (media == null)
            {
                return NotFound();
            }
            return Ok(media);
        } 
    }
}