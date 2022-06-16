using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookly.Models
{
    public class ShippingDetails
    {
        public string FullNmae { get; set; }

        [Required(ErrorMessage ="Please enter the Adress Type ex:Work adress")]
        public string AdressType { get; set; }

        [Required(ErrorMessage = "Please enter the Adress")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Please enter the City")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Please enter the Semt")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Please enter the Mahalle")]
        public string Mahalle { get; set; }

        public string PostaKodu { get; set; }
    }
}