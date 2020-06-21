using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineRecipes.Models
{
    public class Recipe
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public int Rating { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }
/*
        [Required]
        public string ApplicationUserId { get; set; }*/

       /* public Recipe(string title, string description, int rating, string applicationUserId)
        {
            this.Title = title;
            this.Description = description;
            this.Rating = rating;
            this.ApplicationUserId = applicationUserId;
        }*/

    }
}