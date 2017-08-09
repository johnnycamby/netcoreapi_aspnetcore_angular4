using System.Collections.Generic;

namespace CoreWebAngularApp.Dto.Hateoas
{
    public class LinkedResourceBaseDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}