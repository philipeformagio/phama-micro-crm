﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhamaMicroCrm.Web.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CompanyUnitId { get; set; }

        [DisplayName("Rua")]
        public string Street { get; set; }

        [DisplayName("CEP")]
        public string ZipCode { get; set; }

        [DisplayName("Estado")]
        public string State { get; set; }

        [DisplayName("Cidade")]
        public string City { get; set; }

        //public CompanyUnitViewModel CompanyUnit { get; set; }
    }
}