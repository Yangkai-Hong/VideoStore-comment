using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoStore.Services.Interfaces;
using VideoStore.Services.MessageTypes;

namespace VideoStore.WebClient.ViewModels
{
    public class CreateReviewViewModel
    {
        public CreateReviewViewModel()
        {
        }

        public CreateReviewViewModel(User user)
        {
            Update(user);
        }

        public void Update(User user)
        {
            Date = DateTime.Now.ToString("d");
            Reviewer = user.Name;
            Location = user.Address;
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        public string Date { get; set; }

        public string Reviewer { get; set; }

        public string Location { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [Range(0, 5, ErrorMessage = "Rating must between 0-5")]
        public int Rating { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Content")]
        public string Content { get; set; }

        public Review ToReview(User user, Media media)
        {
            return new Review()
            {
                Title = Title,
                Date = DateTime.Now,
                Reviewer = user,
                Rating = Rating,
                Content = Content,
                Media = media
            };
        }
    }
}