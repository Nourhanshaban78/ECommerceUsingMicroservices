using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commands
{
    public class DeleteShoppingCartCommand :IRequest<Unit> //uint bykon feh prpoperty return unit not value in mediatR
    {
        public DeleteShoppingCartCommand(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
