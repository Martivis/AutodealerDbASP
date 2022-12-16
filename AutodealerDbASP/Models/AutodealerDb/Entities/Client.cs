using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodealerDbASP.Models.AutodealerDb.Entities
{
    public class Client : IBaseEntity
    {
        public int ClientId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(14)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(128)]
        public string Address { get; set; }
        public ICollection<ClientDeal> ClientDeals { get; set; }
    }
}
