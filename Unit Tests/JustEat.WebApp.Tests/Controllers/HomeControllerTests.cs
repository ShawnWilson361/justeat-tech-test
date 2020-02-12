#region Usings

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using JustEat.BusinessLogic.Services.Interfaces;
using JustEat.Models;
using JustEat.WebApp.Controllers;
using JustEat.WebApp.Models.RequestModels;
using JustEat.WebApp.Models.ViewModels;
using Moq;
using NUnit.Framework;

#endregion

namespace JustEat.WebApp.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private Mock<IRestaurantService> _restaurantService;
        private HomeController _controller;

        [SetUp]
        public void SetUp()
        {
            _restaurantService = new Mock<IRestaurantService>();
            _controller = new HomeController(_restaurantService.Object);
        }

        [Test]
        public async Task WhenIndexIsRequested_WithNull_ThenTheBadRequestViewIsReturned()
        {
            var result = await _controller.Index(null);
            Assert.IsInstanceOf<ViewResult>(result);
            var view = (ViewResult) result;
            var name = view.ViewName;
            Assert.That(name, Is.EqualTo("BadRequest"));
        }

        [Test]
        public async Task WhenIndexIsRequested_ThenAGetRestaurantsRequestIsMadeViaTheRestaurant()
        {
            const string outcode = "se19";
            await _controller.Index(new RestaurantListRequestModel {Outcode = outcode});
            _restaurantService.Verify(x => x.GetRestaurants(outcode), Times.Once());
        }

        [Test]
        public async Task WhenIndexIsRequested_ThenARestaurantListViewModelIsSentToTheViewAsAModel()
        {
            _restaurantService.Setup(x => x.GetRestaurants(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<Restaurant>()));
            var result = await _controller.Index(new RestaurantListRequestModel());
            Assert.IsInstanceOf<ViewResult>(result);
            var view = (ViewResult) result;
            var model = view.ViewData.Model;
            Assert.IsInstanceOf<RestaurantListViewModel>(model);
        }

        [Test]
        public async Task WhenIndexIsRequested_AndSuppliedWithAnOrderByParameterOfName_ThenTheResultsAreSortedByName()
        {
            var results = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "Mikes Fish and chips"
                },
                new Restaurant
                {
                    Name = "Andy's Diner"
                },
                new Restaurant
                {
                    Name = "Chan's Chinese"
                },
            };


            _restaurantService.Setup(x => x.GetRestaurants(It.IsAny<string>())).Returns(Task.FromResult(results));
            var result = await _controller.Index(new RestaurantListRequestModel
            {
                Outcode = "se19",
                OrderBy = "Name"
            });
            Assert.IsInstanceOf<ViewResult>(result);
            var view = (ViewResult) result;
            var obj = view.ViewData.Model;
            Assert.IsInstanceOf<RestaurantListViewModel>(obj);
            var model = (RestaurantListViewModel) obj;

            Assert.That(model.Restaurants.Count, Is.EqualTo(3));
            Assert.That(model.Restaurants.First(), Is.Not.Null);
            Assert.That(model.Restaurants.First().Name, Is.EqualTo("Andy's Diner"));
            Assert.That(model.Restaurants[1], Is.Not.Null);
            Assert.That(model.Restaurants[1].Name, Is.EqualTo("Chan's Chinese"));
            Assert.That(model.Restaurants[2], Is.Not.Null);
            Assert.That(model.Restaurants[2].Name, Is.EqualTo("Mikes Fish and chips"));
        }

        [Test]
        public async Task
            WhenIndexIsRequested_AndSuppliedWithAnOrderByParameterOfRating_ThenTheResultsAreSortedByRating()
        {
            var results = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "Mikes Fish and chips",
                    RatingStars = 1
                },
                new Restaurant
                {
                    Name = "Andy's Diner",
                    RatingStars = 3
                },
                new Restaurant
                {
                    Name = "Chan's Chinese",
                    RatingStars = 2
                },
            };


            _restaurantService.Setup(x => x.GetRestaurants(It.IsAny<string>())).Returns(Task.FromResult(results));
            var result = await _controller.Index(new RestaurantListRequestModel
            {
                Outcode = "se19",
                OrderBy = "rating"
            });
            Assert.IsInstanceOf<ViewResult>(result);
            var view = (ViewResult) result;
            var obj = view.ViewData.Model;
            Assert.IsInstanceOf<RestaurantListViewModel>(obj);
            var model = (RestaurantListViewModel) obj;

            Assert.That(model.Restaurants.Count, Is.EqualTo(3));
            Assert.That(model.Restaurants.First(), Is.Not.Null);
            Assert.That(model.Restaurants.First().Name, Is.EqualTo("Mikes Fish and chips"));
            Assert.That(model.Restaurants[1], Is.Not.Null);
            Assert.That(model.Restaurants[1].Name, Is.EqualTo("Chan's Chinese"));
            Assert.That(model.Restaurants[2], Is.Not.Null);
            Assert.That(model.Restaurants[2].Name, Is.EqualTo("Andy's Diner"));
        }

        [Test]
        public async Task
            WhenIndexIsRequested_AndSuppliedWithAnOrderByParameterOfName_AndSuppliedWithOrderByDescendingIsTrue_ThenTheResultsAreSortedByName()
        {
            var results = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "Mikes Fish and chips"
                },
                new Restaurant
                {
                    Name = "Andy's Diner"
                },
                new Restaurant
                {
                    Name = "Chan's Chinese"
                },
            };


            _restaurantService.Setup(x => x.GetRestaurants(It.IsAny<string>())).Returns(Task.FromResult(results));
            var result = await _controller.Index(new RestaurantListRequestModel
            {
                Outcode = "se19",
                OrderBy = "Name",
                OrderByDescending = true
            });
            Assert.IsInstanceOf<ViewResult>(result);
            var view = (ViewResult) result;
            var obj = view.ViewData.Model;
            Assert.IsInstanceOf<RestaurantListViewModel>(obj);
            var model = (RestaurantListViewModel) obj;

            Assert.That(model.Restaurants.Count, Is.EqualTo(3));
            Assert.That(model.Restaurants.First(), Is.Not.Null);
            Assert.That(model.Restaurants.First().Name, Is.EqualTo("Mikes Fish and chips"));
            Assert.That(model.Restaurants[1], Is.Not.Null);
            Assert.That(model.Restaurants[1].Name, Is.EqualTo("Chan's Chinese"));
            Assert.That(model.Restaurants[2], Is.Not.Null);
            Assert.That(model.Restaurants[2].Name, Is.EqualTo("Andy's Diner"));
        }

        [Test]
        public async Task
            WhenIndexIsRequested_AndSuppliedWithAnOrderByParameterOfRating_AndSuppliedWithOrderByDescendingIsTrue_ThenTheResultsAreSortedByRating()
        {
            var results = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "Mikes Fish and chips",
                    RatingStars = 1
                },
                new Restaurant
                {
                    Name = "Andy's Diner",
                    RatingStars = 3
                },
                new Restaurant
                {
                    Name = "Chan's Chinese",
                    RatingStars = 2
                },
            };


            _restaurantService.Setup(x => x.GetRestaurants(It.IsAny<string>())).Returns(Task.FromResult(results));
            var result = await _controller.Index(new RestaurantListRequestModel
            {
                Outcode = "se19",
                OrderBy = "rating",
                OrderByDescending = true
            });
            Assert.IsInstanceOf<ViewResult>(result);
            var view = (ViewResult) result;
            var obj = view.ViewData.Model;
            Assert.IsInstanceOf<RestaurantListViewModel>(obj);
            var model = (RestaurantListViewModel) obj;

            Assert.That(model.Restaurants.Count, Is.EqualTo(3));
            Assert.That(model.Restaurants.First(), Is.Not.Null);
            Assert.That(model.Restaurants.First().Name, Is.EqualTo("Andy's Diner"));
            Assert.That(model.Restaurants[1], Is.Not.Null);
            Assert.That(model.Restaurants[1].Name, Is.EqualTo("Chan's Chinese"));
            Assert.That(model.Restaurants[2], Is.Not.Null);
            Assert.That(model.Restaurants[2].Name, Is.EqualTo("Mikes Fish and chips"));
        }

        [Test]
        public async Task
            WhenIndexIsRequested_AndSuppliedWithAnOrderByParameterOfSomeOtherString_ThenTheResultsAreSortedByDefaultDisplayRank()
        {
            var results = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "Mikes Fish and chips",
                    DefaultDisplayRank = 3
                },
                new Restaurant
                {
                    Name = "Andy's Diner",
                    DefaultDisplayRank = 2
                },
                new Restaurant
                {
                    Name = "Chan's Chinese",
                    DefaultDisplayRank = 1
                },
            };


            _restaurantService.Setup(x => x.GetRestaurants(It.IsAny<string>())).Returns(Task.FromResult(results));
            var result = await _controller.Index(new RestaurantListRequestModel
            {
                Outcode = "se19",
                OrderBy = "Some other string",
            });
            Assert.IsInstanceOf<ViewResult>(result);
            var view = (ViewResult) result;
            var obj = view.ViewData.Model;
            Assert.IsInstanceOf<RestaurantListViewModel>(obj);
            var model = (RestaurantListViewModel) obj;

            Assert.That(model.Restaurants.Count, Is.EqualTo(3));
            Assert.That(model.Restaurants.First(), Is.Not.Null);
            Assert.That(model.Restaurants.First().Name, Is.EqualTo("Mikes Fish and chips"));
            Assert.That(model.Restaurants[1], Is.Not.Null);
            Assert.That(model.Restaurants[1].Name, Is.EqualTo("Andy's Diner"));
            Assert.That(model.Restaurants[2], Is.Not.Null);
            Assert.That(model.Restaurants[2].Name, Is.EqualTo("Chan's Chinese"));
        }

        [Test]
        public async Task
            WhenIndexIsRequested_AndSuppliedWithAnOrderByParameterOfSomeOtherString_AndSuppliedWithOrderByDescendingIsTrue_ThenTheResultsAreSortedByDefaultDisplayRank()
        {
            var results = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "Mikes Fish and chips",
                    DefaultDisplayRank = 3
                },
                new Restaurant
                {
                    Name = "Andy's Diner",
                    DefaultDisplayRank = 2
                },
                new Restaurant
                {
                    Name = "Chan's Chinese",
                    DefaultDisplayRank = 1
                },
            };


            _restaurantService.Setup(x => x.GetRestaurants(It.IsAny<string>())).Returns(Task.FromResult(results));
            var result = await _controller.Index(new RestaurantListRequestModel
            {
                Outcode = "se19",
                OrderBy = "Some other string",
                OrderByDescending = true
            });
            Assert.IsInstanceOf<ViewResult>(result);
            var view = (ViewResult) result;
            var obj = view.ViewData.Model;
            Assert.IsInstanceOf<RestaurantListViewModel>(obj);
            var model = (RestaurantListViewModel) obj;

            Assert.That(model.Restaurants.Count, Is.EqualTo(3));
            Assert.That(model.Restaurants.First(), Is.Not.Null);
            Assert.That(model.Restaurants.First().Name, Is.EqualTo("Chan's Chinese"));
            Assert.That(model.Restaurants[1], Is.Not.Null);
            Assert.That(model.Restaurants[1].Name, Is.EqualTo("Andy's Diner"));
            Assert.That(model.Restaurants[2], Is.Not.Null);
            Assert.That(model.Restaurants[2].Name, Is.EqualTo("Mikes Fish and chips"));
        }
    }
}