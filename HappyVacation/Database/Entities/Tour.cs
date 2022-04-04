﻿namespace HappyVacation.Database.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public string Overview { get; set; }
        public float Duration { get; set; }
        public int GroupSize { get; set; }
        public int MinAdults { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public int PricePerAdult { get; set; }
        public int PricePerChild { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsAvailable { get; set; }
        public int ViewCount { get; set; }
        public int PlaceId { get; set; }
        public int ProviderId { get; set; }

        // navigation props
        // 1 place - n tours
        public Place Place { get; set; }
        // 1 provider - n tours
        public Provider Provider { get; set; }
        // 1 tour - n tour categories
        public List<TourCategory> TourCategories { get; set; }
        // 1 tour - n images
        public List<TourImage> TourImages { get; set; }
        // 1 tour - n itinerary items
        public List<Itinerary> Itineraries { get; set; }
        // 1 tour - n expenses 
        public List<Expense> Expenses { get; set; }
        // 1 tour - n reviews
        public List<Review> Reviews { get; set; }
        // 1 tour - n orders
        public List<Order> Orders { get; set; }
    }
}
