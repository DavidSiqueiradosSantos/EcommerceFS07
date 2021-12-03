using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceFS07.Entity
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Produto produto { get; set; }
        public DateTime MomentoDaCompra { get; set; }
    }
}
