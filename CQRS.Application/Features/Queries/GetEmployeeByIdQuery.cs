using CQRS.Application.Repository;
using CQRS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Features.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }

        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
        {
            private readonly IApplicationDbContext _context;
            public GetEmployeeByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
            {
                var prod = await _context.Employees.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

                if (prod == null) return null;

                return prod;
            }
        }
    }
}
