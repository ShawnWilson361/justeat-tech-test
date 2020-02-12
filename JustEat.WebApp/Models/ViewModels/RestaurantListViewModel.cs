#region Usings

using System.Collections.Generic;

#endregion

namespace JustEat.WebApp.Models.ViewModels
{
    public class RestaurantListViewModel
    {
        private RestaurantListViewModel()
        {
        }

        public string Outcode { get; set; }
        public List<RestaurantViewModel> Restaurants { get; set; }
        public bool OrderByDescending { get; set; }

        public static RestaurantListViewModel Create(List<RestaurantViewModel> restaurants, string outcode,
            bool orderByDesc = false)
        {
            return new RestaurantListViewModel
            {
                Restaurants = restaurants,
                Outcode = outcode,
                OrderByDescending = orderByDesc
            };
        }
    }
}