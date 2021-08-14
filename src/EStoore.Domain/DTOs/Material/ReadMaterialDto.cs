using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStoore.Domain.DTOs.Supplier;
using EStoore.Domain.Entities;

namespace EStoore.Domain.DTOs.Material
{
    public class ReadMaterialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string FiscalCode { get; set; }
        public string Specie { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int SupplierId { get; set; }
        public SupplierMaterialDto Supplier { get; set; }
    }
}
