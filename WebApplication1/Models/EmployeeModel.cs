using NajotTalim.HR.DataAcces.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Foreign key for the Address
        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }

        // Navigation property to the Address
        public virtual Address Address { get; set; }
    }
}
