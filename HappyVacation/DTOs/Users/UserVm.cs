﻿namespace HappyVacation.DTOs.Users
{
    public class UserVm
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AvatarUrl { get; set; }
        public int? ProviderId { get; set; }
    }
}
