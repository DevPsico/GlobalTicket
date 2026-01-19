using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Application.Responses;
using GloboTicket.TocketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Repositório específico para a entidade Order, responsável por operações de acesso a dados relacionadas a pedidos.
// Herda métodos genéricos do BaseRepository<Order> e implementa a interface IOrderRepository para métodos personalizados.
namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    /// <summary>
    /// Repositório de pedidos que centraliza o acesso e manipulação de dados da entidade Order.
    /// Permite operações CRUD genéricas e métodos específicos, como paginação e contagem de pedidos por mês.
    /// </summary>
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        /// <summary>
        /// Construtor que recebe o contexto do banco de dados e repassa para o repositório base.
        /// </summary>
        /// <param name="dbContext">Instância do contexto do banco de dados.</param>
        public OrderRepository(GloboTicketDbContext dbContext) : base(dbContext) 
        {
        }

        /// <summary>
        /// Retorna uma lista paginada de pedidos realizados em um determinado mês e ano.
        /// </summary>
        /// <param name="date">Data de referência (mês e ano serão usados para o filtro).</param>
        /// <param name="page">Número da página desejada.</param>
        /// <param name="size">Quantidade de itens por página.</param>
        /// <returns>Lista de pedidos da página solicitada para o mês/ano informado.</returns>
        public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            return await _dbContext.Orders.Where(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year)
                .Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retorna o total de pedidos realizados em um determinado mês e ano.
        /// </summary>
        /// <param name="date">Data de referência (mês e ano serão usados para o filtro).</param>
        /// <returns>Número total de pedidos para o mês/ano informado.</returns>
        public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
        {
            return await _dbContext.Orders.CountAsync(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year);
        }

    }
}
