﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Licenser.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        public string HomePageUrl { get; set; }
        public string DownloadUrl { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
    }
}