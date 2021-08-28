using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Periferia.API._3._Data.Entities
{
    public class SimpleSale
    {
        public Int64 Id { get; set; }
        public Int64 ProductId { get; set; }
        public Int64 ClientId { get; set; }
        public float TotalValue { get; set; }
        public float UnitValue { get; set; }
        public int Count { get; set; }

        //Navigation Property
        public Product Product { get; set; }
        public Client Client { get; set; }

    }
}
