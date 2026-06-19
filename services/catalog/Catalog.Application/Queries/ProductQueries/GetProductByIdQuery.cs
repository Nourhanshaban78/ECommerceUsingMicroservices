using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries.ProductQueries
{
    public class GetproductByNameQuery :IRequest<ProductResponseDto>
    {
        public GetproductByNameQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

    }
}
