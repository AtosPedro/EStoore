using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Domain.DTOs.Supplier
{
    public class CreateSupplierDto
    {
        [Required(ErrorMessage = "O material precisa ter um nome")]
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string ZipCode { get; set; }
        public string QrCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<Entities.Material> Materials { get; set; }
    }
}
