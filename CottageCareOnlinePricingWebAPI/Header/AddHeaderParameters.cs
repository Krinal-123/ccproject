using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace CottageCareOnlinePricingWebAPI.Header
{
    public class AddHeaderParameters: IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            // Specify the routes or actions where you want to add the header
            var specificRoutes = new List<string>
            {
              "api/add-home-information",
              "api/get-additionalrooms",
              "api/add-room-information",
               "api/get-room-information",
              "api/manage-room-information"
            };

            if (apiDescription.RelativePath != null && specificRoutes.Any(route => apiDescription.RelativePath.Contains(route)))
            {
                if (operation.parameters == null)
                    operation.parameters = new List<Parameter>();

                operation.parameters.Add(new Parameter
                {
                    name = "SessionId",
                    @in = "header",
                    type = "string",
                    required = true,
                });
            }
        }
    }
}