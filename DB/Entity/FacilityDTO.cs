﻿using DB.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entity
{
    public class FacilityDTO
    {
        public int Id { get; set; }  // Primary Key
        public string? FacilityName { get; set; }
        public string? FacilityLocation { get; set; }
        public int CommunityId { get; set; }
        public string? FacilityDetails { get; set; }
        public int FacilityTypeId { get; set; }
        public string? Rate { get; set; }
        public FacilityType? FacilityType { get; set; }
        public CommunityDTO? community { get; set; }

        public List<FacilityPhoto>? FacilityPhotos { get; set; }
      


    }
}
