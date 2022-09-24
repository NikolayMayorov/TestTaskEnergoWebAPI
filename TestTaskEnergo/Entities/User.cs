using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestTaskEnergo.Entities
{
    public class Company
    {
        public int Id { get; set; }
  
        public string? Name { get; set; }
        public List<User> Users { get; set; } = new(); // сотрудники компании
    }

    public class User
    {
        public int Id { get; set; }

        [Required]  
      //  [Index(IsUnique=true)]
        public string? Name { get; set; }

        public int CompanyId { get; set; }
        public Company? Company { get; set; }  // компания пользователя
    }

}
