using CQRSExp.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSExp.Med.Commands
{
    public class UpdateProductCommand:IRequest<ProductEntity>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductEntity>
        {
            public Task<ProductEntity> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
