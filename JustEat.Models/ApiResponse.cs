#region Usings

using System.Collections.Generic;

#endregion

namespace JustEat.Models
{
    public class ApiResponse
    {
        public string ShortResultText { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        public string Area { get; set; }
        public object Errors { get; set; }
        public bool HasErrors { get; set; }
        public Metadata MetaData { get; set; }

        public ApiResponse()
        {
            Restaurants = new List<Restaurant>();
        }
    }
}