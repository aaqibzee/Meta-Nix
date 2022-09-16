using System;
using System.Collections.Generic;

namespace Meta_Nix.Models
{
    public partial class Advertiser
    {
        public int Id { get; set; }
        public string AdvertiserId { get; set; } = null!;
        public string? AdvertiserName { get; set; }
    }
}
