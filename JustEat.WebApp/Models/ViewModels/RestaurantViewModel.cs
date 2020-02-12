#region Usings

using System.Collections.Generic;
using JustEat.Models;

#endregion

namespace JustEat.WebApp.Models.ViewModels
{
    public class RestaurantViewModel
    {
        private RestaurantViewModel()
        {
        }

        public string Name { get; set; }
        public decimal RatingStars { get; set; }
        public List<CuisineType> CuisineTypes { get; set; }

        public static RestaurantViewModel Create(Restaurant restaurant)
        {
            return new RestaurantViewModel
            {
                CuisineTypes = restaurant.CuisineTypes,
                Name = restaurant.Name,
                RatingStars = restaurant.RatingStars
            };
        }
    }
}