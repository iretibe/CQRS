using CQRS.Application.Repository;
using CQRS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Features.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
        public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllEmployeesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            {
                var list = await _context.Employees.ToListAsync();

                if (list == null)
                {
                    return null;
                }

                return list.AsReadOnly();
            }
        }
    }
}
