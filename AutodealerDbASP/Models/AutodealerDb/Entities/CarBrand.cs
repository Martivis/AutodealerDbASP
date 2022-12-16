using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodealerDbASP.Models.AutodealerDb.Entities
{
    public class CarBrand : IBaseEntity
    {
        public int CarBrandId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
