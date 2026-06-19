using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries.ProductQueries
{
    public class GetProductByNameQuery :IRequest<IList<ProductResponseDto>>
    {
        public GetProductByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
