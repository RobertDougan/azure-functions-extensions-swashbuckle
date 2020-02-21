using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace AzureFunctions.Extensions.Swashbuckle
{
    internal class QueryStringParameterAttributeFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var attributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<QueryStringParameterAttribute>();

            foreach (var attribute in attributes)
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = attribute.Name,
                    Description = attribute.Description,
                    In = ParameterLocation.Query,
                    Required = attribute.Required
                });
        }
    }
}
