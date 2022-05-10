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
    public class UpdateProductCommand:IRequest<ProductEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductEntity>
        {
            private AppDbContext _context;

            public UpdateProductCommandHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<ProductEntity> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                ProductEntity product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);
                if (request.Name != null)
                {
                    product.Name = request.Name;
                }
                if (request.Quantity != 0)
                {
                    product.Quantity = request.Quantity;
                }
                if (request.Value != 0)
                {
                    product.Amount = request.Value;
                }
                await _context.SaveChangesAsync();
                return product;
            }
        }
    }
}
