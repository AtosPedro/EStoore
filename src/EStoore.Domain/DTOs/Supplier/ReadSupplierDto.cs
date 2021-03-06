using EStoore.Domain.DTOs.Material;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Domain.DTOs.Supplier
{
    public class ReadSupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string ZipCode { get; set; }
        public string QrCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IEnumerable<MaterialSupplierDto> Materials { get; set; }
    }
}
