using CQRS.Application.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Features.Commands
{
    public class DeleteEmployeeByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteEmployeeByIdCommandHandler : IRequestHandler<DeleteEmployeeByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public DeleteEmployeeByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Employees.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

                if (product == null) return default;

                _context.Employees.Remove(product);

                await _context.SaveChangesAsync();

                return product.Id;
            }
        }
    }
}
