using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceFS07.Entity
{
    public class Produto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descrição { get; set; }
        public string Marca { get; set; }
        public string Imagem { get; set; }
        public int Valor { get; set; }
        UsuarioMaster usuarioMaster { get; set; }
        Categoria categoria { get; set; }
    }
}
