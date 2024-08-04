using DataAcessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<ExemploEntity> Exemplos { get; set; } Criar uma coluna no BD com base na entity
        public DbSet<UserEntity> tb_user { get; set; }
    }
}
