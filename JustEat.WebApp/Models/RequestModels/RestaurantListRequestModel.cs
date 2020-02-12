namespace JustEat.WebApp.Models.RequestModels
{
    public class RestaurantListRequestModel
    {
        public string Outcode { get; set; }
        public string OrderBy { get; set; }
        public bool OrderByDescending { get; set; }
    }
}