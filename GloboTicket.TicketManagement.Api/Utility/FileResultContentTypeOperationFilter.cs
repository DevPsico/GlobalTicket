using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class FileResultContentTypeOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Adiciona o tipo de conteúdo para respostas de arquivo no Swagger
        operation.Responses["200"].Content.Add("text/csv", new OpenApiMediaType());
    }
}