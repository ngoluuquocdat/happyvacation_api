﻿namespace HappyVacation.DTOs.Providers
{
    public class ProviderVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DateCreated { get; set; }
        public float AverageRating { get; set; }
        public int TourAvailable { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public bool IsEnabled { get; set; }
    }
}
