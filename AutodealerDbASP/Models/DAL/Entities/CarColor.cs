using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodealerDbASP.Models.AutodealerDb.Entities
{
    public class CarColor : IBaseEntity
    {
        public int CarColorId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
