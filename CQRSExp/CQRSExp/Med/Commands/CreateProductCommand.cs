using CQRSExp.DAL;
using CQRSExp.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSExp.Med.Commands
{
    public class CreateProductCommand:IRequest<ProductEntity>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductEntity>
        {
            private AppDbContext _context;

            public CreateProductCommandHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<ProductEntity> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                ProductEntity product = new ProductEntity
                {
                    Name = request.Name,
                    Quantity = request.Quantity,
                    Amount = request.Value,
                    IsDeleted = false,
                };
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
            }
        }
    }
}
