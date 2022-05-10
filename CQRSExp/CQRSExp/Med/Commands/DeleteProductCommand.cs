using CQRSExp.DAL;
using CQRSExp.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSExp.Med.Commands
{
    public class DeleteProductCommand:IRequest<ProductEntity>
    {
        public int Id { get; set; }
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductEntity>
        {
            private AppDbContext _context;

            public DeleteProductCommandHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<ProductEntity> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                ProductEntity product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);
                product.IsDeleted = true;
                await _context.SaveChangesAsync();
                return product;
            }
        }
    }
}
