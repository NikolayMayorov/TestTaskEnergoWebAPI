using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo.Domain.Core
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Address { get; set; }

        public ICollection<ChildCompany>? ChildCompanies { get; set; } 

    }
}
