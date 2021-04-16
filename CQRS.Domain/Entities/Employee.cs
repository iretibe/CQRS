using CQRS.Domain.Common;
using System;

namespace CQRS.Domain.Entities
{
    public partial class Employee : BaseEntity
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
    }
}
