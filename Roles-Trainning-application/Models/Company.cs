﻿using System.ComponentModel.DataAnnotations;

namespace Roles_Trainning_application.Models
{
 public class Company
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
    }}
