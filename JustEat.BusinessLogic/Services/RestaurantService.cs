#region Usings

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JustEat.BusinessLogic.Services.Interfaces;
using JustEat.Models;
using RestSharp;

#endregion

namespace JustEat.BusinessLogic.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestClient _restClient;

        public RestaurantService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<List<Restaurant>> GetRestaurants(string outcode)
        {
            var restRequest = new RestRequest($"restaurants?q={outcode}");
            restRequest.AddHeader("Accept-Tenant", "uk");
            restRequest.AddHeader("Accept-Language", "en-GB");
            restRequest.AddHeader("Authorization", "Basic VGVjaFRlc3RBUEk6dXNlcjI=");
            restRequest.AddHeader("Host", "public.je-apis.com");

            var cancellationTokenSource = new CancellationTokenSource();

            var response = await _restClient.ExecuteTaskAsync<ApiResponse>(restRequest, cancellationTokenSource.Token);

            return response?.Data?.Restaurants;
        }
    }
}