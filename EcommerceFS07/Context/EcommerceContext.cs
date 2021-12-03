using EcommerceFS07.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceFS07.Context
{
   
    public class EcommerceContext : DbContext
    {
      
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<UsuarioMaster> UsuariosMaster { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Venda> Vendas { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("data source=45.93.100.120,1433;initial catalog=FS07;persist security info=True;user id=FS07;password=545648;MultipleActiveResultSets=True;App=exeEf;");
        }

    
    }
}
