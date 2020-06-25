using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
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
        [Range(1, 5)]
        public int Rating { get; set; }

        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }


        [Display(Name = "Category")]
        public  RecipeCategory RecipeCategories { get; set; }
        
    }
}