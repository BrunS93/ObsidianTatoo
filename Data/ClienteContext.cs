using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using herramientas_parcial1_brunosilva.Models;

    public class ClienteContext : DbContext
    {
        public ClienteContext (DbContextOptions<ClienteContext> options)
            : base(options)
        {
        }

        public DbSet<herramientas_parcial1_brunosilva.Models.ClienteModel> ClienteModel { get; set; } = default!;

        public DbSet<herramientas_parcial1_brunosilva.Models.Tatooh> Tatooh { get; set; } = default!;
    }
