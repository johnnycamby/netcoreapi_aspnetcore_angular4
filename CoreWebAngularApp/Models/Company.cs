using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreWebAngularApp.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string ImageLogo { get; set; }
        public DateTimeOffset FoundedAt { get; set; }
        public string Overview { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();
        public DateTimeOffset? PresentDate { get; set; }
    }
}