using System.ComponentModel.DataAnnotations;

namespace NajotTalim.HR.DataAcces
{
    public class EmployeeModel
    {
        public int Id { get; set; }
     
        public string Name { get; set; }
       
        public string Department { get; set; }
      
        public string Email { get; set; }
    }
}
