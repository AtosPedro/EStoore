using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Domain.DTOs.Material
{
    public class CreateMaterialDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "O material precisa ter um nome")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "O material precisa ter um código")]
        public string Code { get; set; }
        [Required(ErrorMessage = "O material precisa ter um código fiscal")]
        public string FiscalCode { get; set; }
        public string Specie { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
