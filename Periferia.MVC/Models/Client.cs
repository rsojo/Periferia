using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Periferia.MVC.Models
{
    public class Client
    {
        public Int64 Id { get; set; }

        [DisplayName("Nombre")]
        public string FirstName { get; set; }

        [DisplayName("Apellido")]
        public string LastName { get; set; }

        [DisplayName("Nombre")]
        public string FullName
        {
            get { return FirstName + " " + (LastName ?? ""); }
        }

        [DisplayName("Teléfono")]
        public string Phone { get; set; }

        [DisplayName("Número de documento")]
        public string DocNumber { get; set; }
    }
}
