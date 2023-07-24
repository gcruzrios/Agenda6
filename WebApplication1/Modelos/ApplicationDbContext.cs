using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda6.Modelos
{
    public class ApplicationDbContext: DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
          
        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Contacto> Contacto { get; set; }
    }
}
