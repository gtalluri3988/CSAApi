﻿using DB.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entity
{
    public class ResidentDTO
    {
        public int Id { get; set; }  // Primary Key
        public int? StateId { get; set; }  // Primary Key
        public string? HouseNo { get; set; }
        public string? Name { get; set; }
        public string? LotNo { get; set; }
        public string? Level { get; set; }
        public string? BlockNo { get; set; }
        public string? RoadNo { get; set; }
        public string? NRIC { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? StateName { get; set; }
        public string? PaymentStatus { get; set; }
        public int RoleId { get; set; }
        public int CommunityId { get; set; }
        public int ParkingLotQty { get; set; }
        public int ParkingLotNos { get; set; }
        public int MaintenenceFeesCost { get; set; }
        public string? maintainanceFee { get; set; }
        public string? ContactPerson1 { get; set; }
        public string? ContactPerson2 { get; set; }
        public List<VehicleDetails>? VehicleDetails { get; set; }
        public State? State { get; set; }
        public List<ResidencePaymentDetails>? ResidencePaymentDetails { get; set; }
        public Community? Community { get; set; }

    }
}
