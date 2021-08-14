using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Domain.DTOs.Material
{
    public class UpdateMaterialDto
    {
        [Required(ErrorMessage = "O material precisa ter um nome")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "O material precisa ter um código")]
        public string Code { get; set; }
        [Required(ErrorMessage = "O material precisa ter um código fiscal")]
        public string FiscalCode { get; set; }
        public string Specie { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
