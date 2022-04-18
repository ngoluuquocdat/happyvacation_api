﻿namespace HappyVacation.DTOs.Orders
{
    public class CreateTourOrderRequest
    {
        public int TourId { get; set; }
        public string DepartureDate { get; set; }   // yyyy-mm-dd
        public int Adults { get; set; }
        public int Children { get; set; }
        public string TouristName { get; set; }
        public string TouristPhone { get; set; }
        public string TouristEmail { get; set; }
    }
}