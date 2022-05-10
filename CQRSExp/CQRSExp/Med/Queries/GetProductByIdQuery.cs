using CQRSExp.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSExp.Med.Queries
{
    public class GetProductByIdQuery:IRequest<ProductEntity>
    {
        public int Id { get; set; }
    }
}
