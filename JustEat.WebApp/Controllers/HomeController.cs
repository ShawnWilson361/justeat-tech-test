#region Usings

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using JustEat.BusinessLogic.Services.Interfaces;
using JustEat.Models;
using JustEat.WebApp.Models.RequestModels;
using JustEat.WebApp.Models.ViewModels;

#endregion

namespace JustEat.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public HomeController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<ActionResult> Index(RestaurantListRequestModel request)
        {
            if (request == null)
            {
                //Log Message about invalid request
                return View("BadRequest");
            }


            var list = !string.IsNullOrWhiteSpace(request.Outcode)
                ? await _restaurantService.GetRestaurants(request.Outcode)
                : new List<Restaurant>();
            var restaurantViewModels = new List<RestaurantViewModel>();
            if (list != null && list.Any())
            {
                list = OrderList(request.OrderBy, request.OrderByDescending, list);
                restaurantViewModels = list.Select(RestaurantViewModel.Create).ToList();
            }

            var model = RestaurantListViewModel.Create(restaurantViewModels, request.Outcode,
                request.OrderByDescending);

            return View(model);
        }

        private static List<Restaurant> OrderList(string orderBy, bool orderByDescending, List<Restaurant> list)
        {
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = orderBy.ToLowerInvariant();
            }

            switch (orderBy)
            {
                case "name":
                    return orderByDescending
                        ? list.OrderByDescending(x => x.Name).ToList()
                        : list.OrderBy(x => x.Name).ToList();
                case "rating":
                    return orderByDescending
                        ? list.OrderByDescending(x => x.RatingStars).ToList()
                        : list.OrderBy(x => x.RatingStars).ToList();
                default:
                    return orderByDescending
                        ? list.OrderBy(x => x.DefaultDisplayRank).ToList()
                        : list.OrderByDescending(x => x.DefaultDisplayRank).ToList();
            }
        }
    }
}