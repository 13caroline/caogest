using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using trial2.Models;

namespace trial2.Models
{
    public class trial2Context : DbContext
    {
        public trial2Context(DbContextOptions<trial2Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Canil_has_Parceria>(entity =>
            {
                entity.HasKey(cp => new { cp.canil_user_email, cp.parceria_identificacao });

            });
            modelBuilder.Entity<Favoritos>(entity =>
            {
                entity.HasKey(f => new { f.utilizador_user_email, f.cao_idCa });

                entity.HasOne(f => f.utilizador)
                    .WithMany(u => u.favoritos)
                    .HasForeignKey(f => f.utilizador_user_email);

                entity.HasOne(f => f.cao)
                    .WithMany(u => u.favoritos)
                    .HasForeignKey(f => f.cao_idCa);

            });
            modelBuilder.Entity<Horario>().HasKey(h => new { h.dataInicio, h.dataFim, h.canil_user_email, h.dia });
            modelBuilder.Entity<Horario_has_Utilizador>().HasKey(hu => new { hu.horario_DataInicio, hu.horario_DataFim, hu.horario_Canil_User_Email, hu.utilizador_email, hu.horario_Dia });
            modelBuilder.Entity<Voluntarios>().HasKey(v => new { v.canil_user_email, v.utilizador_user_email });
        }

        public DbSet<trial2.Models.Cao> Cao { get; set; }

        public DbSet<trial2.Models.Favoritos> Favoritos { get; set; }

        public DbSet<trial2.Models.Adocao> Adocao { get; set; }

        public DbSet<trial2.Models.Fotografia> Fotografia { get; set; }

        public DbSet<trial2.Models.Horario> Horario { get; set; }

        public DbSet<trial2.Models.Parceria> Parceria { get; set; }

        public DbSet<trial2.Models.User> User { get; set; }
        public DbSet<trial2.Models.Canil> Canil { get; set; }
        public DbSet<trial2.Models.Utilizador> Utilizador { get; set; }
        public DbSet<trial2.Models.Horario_has_Utilizador> Horarios_has_Utilizador { get; set; }
        public DbSet<trial2.Models.Canil_has_Parceria> Canil_has_Parceria { get; set; }
        public DbSet<trial2.Models.Donativos> Donativos { get; set; }
        public DbSet<trial2.Models.Voluntarios> Voluntarios { get; set; }
        public DbSet<trial2.Models.Sugestoes> Sugestoes { get; set; }
        public DbSet<trial2.Models.Documento> Documento { get; set; }
        public DbSet<trial2.Models.Comprovativo> Comprovativo { get; set; }
    }
}
