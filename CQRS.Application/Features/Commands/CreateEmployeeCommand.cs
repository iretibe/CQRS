using CQRS.Application.Repository;
using CQRS.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Features.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string EmpNo { get; set; }
        public string EmpTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string SocialSecurity { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Position { get; set; }
        public DateTime? HireDate { get; set; }
        public string HomeAddress { get; set; }
        public string HomePhone { get; set; }
        public string PostalCode { get; set; }

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateEmployeeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var emp = new Employee();

                emp.EmpNo = request.EmpNo;
                emp.EmpTitle = request.EmpTitle;
                emp.FirstName = request.FirstName;
                emp.LastName = request.LastName;
                emp.MiddleName = request.MiddleName;
                emp.SocialSecurity = request.SocialSecurity;
                emp.BirthDate = request.BirthDate;
                emp.Position = request.Position;
                emp.HireDate = request.HireDate;
                emp.HomeAddress = request.HomeAddress;
                emp.HomePhone = request.HomePhone;
                emp.PostalCode = request.PostalCode;

                _context.Employees.Add(emp);

                await _context.SaveChangesAsync();

                return emp.Id;
            }
        }
    }
}
