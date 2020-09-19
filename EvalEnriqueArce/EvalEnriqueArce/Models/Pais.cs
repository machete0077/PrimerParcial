using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace EvalEnriqueArce.Models
{
    public class Pais
    {
        [Required(ErrorMessage = "Introduzca el dato solicitado")]
        [Display(Name = "Pais")]
        [StringLength(20, ErrorMessage = "The field 0} must contain between {2} and {1} characters", MinimumLength = 2)]
        public String Name { get; set; }
        
        [Required(ErrorMessage = "Introduzca el dato solicitado")]
        [Display(Name = "Ciudad Capital")]
        [StringLength(20, ErrorMessage = "The field 0} must contain between {2} and {1} characters", MinimumLength = 2)]
        public String Capital { get; set; }

        [Key]
        [Required(ErrorMessage = "Introduzca el dato solicitado")]
        [Range(1, 999999999)]
        public int Poblacion { get; set; }

        [Required(ErrorMessage = "Introduzca el dato solicitado")]
        [Range(1, 999999.99999)]
        public int LatLng { get; set; }

        [Display(Name = "Zona Horaria")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM7yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TimeZone { get; set; }

        [Required(ErrorMessage = "Introduzca el dato solicitado")]
        [DataType(DataType.Currency)]
        public CurrencyWrapper Moneda { get; set; }
        
        [Key]
        [Required(ErrorMessage = "Introduzca el dato solicitado")]
        [RegularExpression(@"^\w+([-+.']\w+):*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Enlace no valido")]
        [DataType(DataType.Text)]
        public String Bandera { get; set; }
    }
}