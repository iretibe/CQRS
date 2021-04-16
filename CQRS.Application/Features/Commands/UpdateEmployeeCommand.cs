using CQRS.Application.Repository;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Features.Commands
{
    public class UpdateEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
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

        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateEmployeeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var emp = _context.Employees.Where(a => a.Id == request.Id).FirstOrDefault();

                if (emp == null)
                {
                    return default;
                }
                else
                {
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

                    await _context.SaveChangesAsync();

                    return emp.Id;
                }
            }
        }
    }
}
