#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace JustEat.Models
{
    public class Restaurant
    {
        public List<object> Badges { get; set; }
        public decimal Score { get; set; }
        public decimal? DriveDistance { get; set; }
        public bool DriveInfoCalculated { get; set; }
        public DateTime NewnessDate { get; set; }
        public int? DeliveryMenuId { get; set; }
        public DateTime? DeliveryOpeningTime { get; set; }
        public decimal? DeliveryCost { get; set; }
        public decimal? MinimumDeliveryValue { get; set; }
        public object DeliveryTimeMinutes { get; set; }
        public int? DeliveryWorkingTimeMinutes { get; set; }
        public DateTime? OpeningTime { get; set; }
        public DateTime? OpeningTimeIso { get; set; }
        public bool SendsOnItsWayNotifications { get; set; }
        public decimal RatingAverage { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<string> Tags { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public List<CuisineType> CuisineTypes { get; set; }
        public string Url { get; set; }
        public bool IsOpenNow { get; set; }
        public bool IsPremier { get; set; }
        public bool IsSponsored { get; set; }
        public int SponsoredPosition { get; set; }
        public bool IsNew { get; set; }
        public bool IsTemporarilyOffline { get; set; }
        public string ReasonWhyTemporarilyOffline { get; set; }
        public string UniqueName { get; set; }
        public bool IsCloseBy { get; set; }
        public bool IsHalal { get; set; }
        public bool IsTestRestaurant { get; set; }
        public int DefaultDisplayRank { get; set; }
        public bool IsOpenNowForDelivery { get; set; }
        public bool IsOpenNowForCollection { get; set; }
        public decimal RatingStars { get; set; }
        public List<Logo> Logo { get; set; }
        public List<Deal> Deals { get; set; }
        public int NumberOfRatings { get; set; }

        public Restaurant()
        {
            Badges = new List<object>();
            Tags = new List<string>();
            CuisineTypes = new List<CuisineType>();
            Logo = new List<Logo>();
            Deals = new List<Deal>();
        }
    }
}