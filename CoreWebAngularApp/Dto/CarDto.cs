using System;
using CoreWebAngularApp.Dto.Hateoas;

namespace CoreWebAngularApp.Dto
{
    public class CarDto : LinkedResourceBaseDto
    {
        public Guid Id { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string Rating { get; set; }
        public string ImageUrl { get; set; }
        public Guid CompanyId { get; set; }
        
    }
}