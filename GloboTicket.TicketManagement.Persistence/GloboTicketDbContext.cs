using GloboTicket.TocketManagement.Domain.Common;
using GloboTicket.TocketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence
{
    // Classe responsável por gerenciar a conexão com o banco de dados e mapear as entidades
    public class GloboTicketDbContext : DbContext
    {
        // Construtor que recebe as opções de configuração do DbContext (como string de conexão)
        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options) : base(options)
        {
        }
        // DbSets representam tabelas no banco de dados
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        // Método chamado quando o modelo é criado (configurações adicionais e dados iniciais)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todas as configurações de entidades definidas no assembly atual
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);

            // Criação de GUIDs fixos para categorias (servem como IDs únicos)
            var concertGuid = Guid.Parse("b0788d2f-8003-43c1-92a4-edc76a7c5dde");
            var musicalGuid = Guid.Parse("6313179f-7837-473a-a4d5-a5571b43e6a6");
            var playGuid = Guid.Parse("bf3f3002-7e53-441e-8b76-f6280be284aa");
            var conferenceGuid = Guid.Parse("fe98f549-e790-4e9f-aa16-18c2292a2ee9");


            // Criação de GUIDs fixos para categorias (servem como IDs únicos)
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = concertGuid,
                    Name = "Concerts",
                    CreatedBy = "System",
            CreatedDate = new DateTime(2025, 11, 10),
            LastModifiedBy = "System",
            LastModifiedDate = new DateTime(2025, 11, 10)
        },
        new Category
        {
            CategoryId = musicalGuid,
            Name = "Musicals",
            CreatedBy = "System",
            CreatedDate = new DateTime(2025, 11, 10),
            LastModifiedBy = "System",
            LastModifiedDate = new DateTime(2025, 11, 10)
        },
        new Category
        {
            CategoryId = playGuid,
            Name = "Plays",
            CreatedBy = "System",
            CreatedDate = new DateTime(2025, 11, 10),
            LastModifiedBy = "System",
            LastModifiedDate = new DateTime(2025, 11, 10)
        },
        new Category
        {
            CategoryId = conferenceGuid,
            Name = "Conferences",
            CreatedBy = "System",
            CreatedDate = new DateTime(2025, 11, 10),
            LastModifiedBy = "System",
            LastModifiedDate = new DateTime(2025, 11, 10)
        }
    );


            // GUIDs fixos para eventos
            var event1Guid = Guid.Parse("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b");
            var event2Guid = Guid.Parse("aa0c2c10-8d14-4a1c-9e5c-1b1e8a2b3c4d");
            var event3Guid = Guid.Parse("bb1d5f3e-3c4a-4d5e-8f6a-7b8c9d0e1f2a");




            modelBuilder.Entity<Event>().HasData(
                    new Event
                    {
                        EventId = event1Guid,
                        Name = "John Egbert Live",
                        Price = 65,
                        Artist = "John Egbert",
                        Date = new DateTime(2025, 6, 1),
                        Description = "Descrição evento 01",
                        ImageUrl = "img1.jpg",
                        CategoryId = concertGuid,
                        CreatedBy = "System",
                        CreatedDate = new DateTime(2025, 11, 10),
                        LastModifiedBy = "System",
                        LastModifiedDate = new DateTime(2025, 11, 10)
                    },
                    new Event
                    {
                        EventId = event2Guid,
                        Name = "The State of Affairs: Michael Live!",
                        Price = 85,
                        Artist = "Michael Johnson",
                        Date = new DateTime(2025, 9, 1),
                        Description = "Descrição evento 02",
                        ImageUrl = "img2.jpg",
                        CategoryId = concertGuid,
                        CreatedBy = "System",
                        CreatedDate = new DateTime(2025, 11, 10),
                        LastModifiedBy = "System",
                        LastModifiedDate = new DateTime(2025, 11, 10)
                    }
                );

            // Orders (também com GUIDs fixos e datas fixas)
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = Guid.Parse("e1a1c2d3-e4f5-6789-0a1b-2c3d4e5f6a7b"),
                    OrderTotal = 400,
                    OrderPaid = true,
                    OrderPlaced = new DateTime(2025, 11, 10),
                    UserId = Guid.Parse("f1b2c3d4-e5f6-7890-1a2b-3c4d5e6f7a8b"),
                    CreatedBy = "System",
                    CreatedDate = new DateTime(2025, 11, 10),
                    LastModifiedBy = "System",
                    LastModifiedDate = new DateTime(2025, 11, 10)
                }
            );
        }

      

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach ( var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.Entity is Event || entry.Entity is Category || entry.Entity is Order)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            entry.Entity.LastModifiedDate = DateTime.Now;
                            break;
                        case EntityState.Deleted:
                            // Lógica para entidades deletadas
                            break;
                    }
                }
            }
            // Aqui você pode adicionar lógica personalizada antes de salvar as mudanças, como auditoria
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
