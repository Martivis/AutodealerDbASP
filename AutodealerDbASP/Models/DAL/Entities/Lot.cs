using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodealerDbASP.Models.AutodealerDb.Entities
{
    public class Lot : IBaseEntity
    {
        public int LotId { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public decimal PriceAmount { get; set; }
        public decimal PresalePreporationCosts { get; set; }
        public decimal TransportCosts  { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public ICollection<ClientDeal> ClientDeals { get; set; }
    }
}
