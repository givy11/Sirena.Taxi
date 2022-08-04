﻿using Sirena.Taxi.Core.Domain;

namespace Sirena.Taxi.PseudoProviders.Models.Internal
{
    public class OrderRequest : BaseEntity
    {
        public string DepartureAddress { get; set; }
        public double DepartureLongitude { get; set; }
        public double DepartureLatitude { get; set; }
        public string DestinationAddress { get; set; }
        public double DestinationLongitude { get; set; }
        public double DestinationLatitude { get; set; }
        public double? Price { get; set; }
        public int StateCode { get; set; }
        public int StatusCode { get; set; }
        public bool ResponseReceived { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
