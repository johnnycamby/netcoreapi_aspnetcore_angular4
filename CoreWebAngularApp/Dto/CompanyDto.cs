using System;

namespace CoreWebAngularApp.Dto
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Lasted { get; set; }
        public string Overview { get; set; }
    }
}