using AutoMapper;
using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TocketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    /// <summary>
    /// Handler responsável por processar o comando de criação de categoria.
    /// Realiza a validação, cria a entidade e retorna a resposta.
    /// </summary>
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
        
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor recebe as dependências via injeção (mapper e repositório).
        /// </summary>
        public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Executa a lógica de criação da categoria, incluindo validação e persistência.
        /// </summary>
        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Cria o objeto de resposta
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();

            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            // Se houver erros de validação, adiciona ao objeto de resposta
            if (validationResult.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            // Se a validação for bem-sucedida, cria e salva a categoria
            if (createCategoryCommandResponse.Success)
            {
                var category = new Category(request.Name);

                category = await _categoryRepository.AddAsync(category);
                createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
            }
            return createCategoryCommandResponse;
        }
    }
}
