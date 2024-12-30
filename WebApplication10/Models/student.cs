﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class student
    {
       
        [Display(Name = "Student Id")]
        public int Sid { get; set; }
        public string Name { get; set; }
        public int? Class { get; set; }
        public decimal? Fees { get; set; }
        public string Photo { get; set; }
    }
}
