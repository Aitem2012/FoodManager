﻿namespace FoodManager.Application.DTO.Addresses
{
    public class GetAddressResponseObjectDto
    {
        public Guid Id { get; set; }
        public string AppUserId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
