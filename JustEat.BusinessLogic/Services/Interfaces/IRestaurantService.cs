#region Usings

using System.Collections.Generic;
using System.Threading.Tasks;
using JustEat.Models;

#endregion

namespace JustEat.BusinessLogic.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetRestaurants(string outcode);
    }
}