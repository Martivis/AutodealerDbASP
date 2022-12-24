using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodealerDbASP.Models.AutodealerDb.Entities
{
    public class Model : IBaseEntity
    {
        public int ModelId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int CarColorId { get; set; }
        public CarColor CarColor { get; set; }
        [Required]
        public int Power { get; set; }
        [Required]
        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
        public ICollection<Lot> Lots { get; set; }
    }
}
