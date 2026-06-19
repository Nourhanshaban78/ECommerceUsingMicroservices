using Catalog.Application.Responses;
using Catalog.Core.Specs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries.ProductQueries
{
    public class GetAllProductQuery :IRequest<Pagination<ProductResponseDto>>
    {
        public GetAllProductQuery(CatalogSpecParam specParam)
        {
            this.specParam = specParam;
        }

        public CatalogSpecParam specParam  { get; set; }
    }
}
