using CQRSExp.DAL;
using CQRSExp.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSExp.Med.Queries
{
    public class GetAllProductQuery:IRequest<List<ProductEntity>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductEntity>>
        {
            private readonly AppDbContext _context;

            public GetAllProductQueryHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<List<ProductEntity>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                List<ProductEntity> product = await _context.Products.Where(x => x.IsDeleted == false).ToListAsync();
                return product;
            }
        }
    }
}
