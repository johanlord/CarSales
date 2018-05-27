using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarSales.Filters;
using CarSales.Resources;

namespace CarSales.Models
{
    [Table("Automobil")]
    public class Automobil
    {
        public int AutomobilId { get; set; }

        public string Korisnik { get; set; }

        [Required(ErrorMessageResourceName = "BrandError", ErrorMessageResourceType = typeof(Resources.Resource))]
        [StringLength(50, ErrorMessageResourceName = "BrandLength", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string Marka { get; set; }

        [Required(ErrorMessageResourceName = "ModelError", ErrorMessageResourceType = typeof(Resources.Resource))]
        [StringLength(50, ErrorMessageResourceName = "ModelLength", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string Model { get; set; }

        [Required(ErrorMessageResourceName = "YearError", ErrorMessageResourceType = typeof(Resources.Resource))]
        public int Godiste { get; set; }

        [Required(ErrorMessageResourceName = "DisplacementError", ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "Zapremina Motora")]
        public int ZapreminaMotora { get; set; }

        [Required(ErrorMessageResourceName = "HPError", ErrorMessageResourceType = typeof(Resources.Resource))]
        public int Snaga { get; set; }

        [Required(ErrorMessageResourceName = "FuelError", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string Gorivo { get; set; }

        [Required(ErrorMessageResourceName = "BodyError", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string Karoserija { get; set; }

        [Required(ErrorMessageResourceName = "DescriptionError", ErrorMessageResourceType = typeof(Resources.Resource))]
        [DataType(DataType.MultilineText)]
        [StringLength(150, ErrorMessageResourceName = "LengthError", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string Opis { get; set; }

        [Required(ErrorMessageResourceName = "PriceError", ErrorMessageResourceType = typeof(Resources.Resource))]
        public decimal Cena { get; set; }

        [Required(ErrorMessageResourceName = "ContactError", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string Kontakt { get; set; }

        [Display(Name = "Fotografija")]
        [MaxLength]
        public byte[] FajlSlike { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string TipFajla { get; set; }
    }
}