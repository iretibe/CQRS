using CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRS.Application.Repository
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; set; }
        Task<int> SaveChangesAsync();
    }
}
