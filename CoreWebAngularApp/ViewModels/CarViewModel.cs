using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace CoreWebAngularApp.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class CarViewModel
    {
        public CarViewModel()
        {}

        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; }

        [DefaultValue(0)]
        public int Flags { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public int ViewCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}