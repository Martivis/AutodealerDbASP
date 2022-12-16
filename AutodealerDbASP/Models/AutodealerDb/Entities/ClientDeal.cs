using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodealerDbASP.Models.AutodealerDb.Entities
{
    public class ClientDeal : IBaseEntity
    {
        public int ClientDealId { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public int LotId { get; set; }
        public Lot Lot { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
