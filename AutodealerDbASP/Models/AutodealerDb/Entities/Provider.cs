using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodealerDbASP.Models.AutodealerDb.Entities
{
    public class Provider : IBaseEntity
    {
        public int ProviderId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(14)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string WebsiteUrl { get; set; }
        public ICollection<Lot> Lots { get; set; }
    }
}
