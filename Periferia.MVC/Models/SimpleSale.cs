using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Periferia.MVC.Models
{
    public class SimpleSale
    {
        public Int64 Id { get; set; }
        public Int64 ProductId { get; set; }
        public Int64 ClientId { get; set; }

        [DisplayName("Total")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public float TotalValue { get; set; }

        [DisplayName("Valor unitario")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public float UnitValue { get; set; }

        [DisplayName("Cantidad")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Cantidad debe ser entero")]
        public int Count { get; set; }


        [DisplayName("Producto")]
        public Product Product { get; set; }

        [DisplayName("Cliente")]
        public Client Client { get; set; }
    }
}
