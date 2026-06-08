using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries.ProductQueries
{
    public class GatProductByNameQuery :IRequest<IList<ProductResponseDto>>
    {
        public GatProductByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
