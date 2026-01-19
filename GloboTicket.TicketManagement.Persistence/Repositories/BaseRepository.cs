using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Classe genérica de repositório base para operações CRUD assíncronas.
// Implementa a interface IAsyncRepository<T>, fornecendo métodos comuns para manipulação de entidades no banco de dados.
// Utiliza o Entity Framework Core para acessar e modificar os dados de forma eficiente e reutilizável.
namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    /// <summary>
    /// Repositório base genérico para entidades do domínio.
    /// Centraliza operações assíncronas de adicionar, buscar, atualizar e remover registros no banco de dados.
    /// Facilita a reutilização de código e segue o padrão Repository, separando regras de negócio do acesso a dados.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade do domínio (deve ser uma classe).</typeparam>
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        // Contexto do banco de dados utilizado para acessar as tabelas e entidades.
        protected readonly GloboTicketDbContext _dbContext;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados via injeção de dependência.
        /// </summary>
        /// <param name="dbContext">Instância do contexto do banco de dados.</param>
        public BaseRepository(GloboTicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Busca uma entidade pelo seu identificador único (Guid).
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <returns>Entidade encontrada ou null.</returns>
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Retorna todas as entidades do tipo T presentes no banco de dados.
        /// </summary>
        /// <returns>Lista somente leitura de entidades.</returns>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Adiciona uma nova entidade ao banco de dados e salva as alterações.
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada.</param>
        /// <returns>Entidade adicionada.</returns>
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Atualiza uma entidade existente no banco de dados e salva as alterações.
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada.</param>
        /// <returns>Entidade atualizada.</returns>
        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Remove uma entidade do banco de dados e salva as alterações.
        /// </summary>
        /// <param name="entity">Entidade a ser removida.</param>
        /// <returns>Entidade removida.</returns>
        public async Task<T> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}