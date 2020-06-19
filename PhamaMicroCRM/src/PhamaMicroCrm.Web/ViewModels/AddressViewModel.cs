using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhamaMicroCrm.Web.ViewModels
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public Guid CompanyUnitId { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; set; }

        public CompanyUnitViewModel CompanyUnit { get; set; }
    }
}