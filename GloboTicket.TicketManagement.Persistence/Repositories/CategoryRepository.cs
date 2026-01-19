using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TocketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Repositório específico para a entidade Category, responsável por operações de acesso a dados relacionadas a categorias.
// Herda métodos genéricos do BaseRepository<Category> e implementa a interface ICategoryRepository para métodos personalizados.
namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    /// <summary>
    /// Repositório de categorias que centraliza o acesso e manipulação de dados da entidade Category.
    /// Permite operações CRUD genéricas e métodos específicos, como buscar categorias com seus eventos.
    /// </summary>
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados e repassa para o repositório base.
        /// </summary>
        /// <param name="dbContext">Instância do contexto do banco de dados.</param>
        public CategoryRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Retorna uma lista de categorias, incluindo os eventos associados.
        /// Pode filtrar para incluir apenas eventos futuros, se desejado.
        /// </summary>
        /// <param name="includePassedEvents">Se falso, remove eventos já ocorridos da lista de cada categoria.</param>
        /// <returns>Lista de categorias com seus eventos (futuros ou todos, conforme o parâmetro).</returns>
        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            // Busca todas as categorias e inclui os eventos relacionados.
            var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();

            // Se não deve incluir eventos passados, remove eventos cuja data já passou.
            if (!includePassedEvents)
            {
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            return allCategories;
        }
    }
}