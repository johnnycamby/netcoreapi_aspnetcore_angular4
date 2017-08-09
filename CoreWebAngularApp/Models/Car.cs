using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CoreWebAngularApp.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
    }
}