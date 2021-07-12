﻿using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entites
{
    public class UserDetail :RecordBase
    {
        public string EMail { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        [Required]
        [StringLength(1000)]
        public string Address { get; set; }
        public User User { get; set; }
    }
}
