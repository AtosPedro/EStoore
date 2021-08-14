using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoore.Domain.Entities
{
    public abstract class Entity
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}
