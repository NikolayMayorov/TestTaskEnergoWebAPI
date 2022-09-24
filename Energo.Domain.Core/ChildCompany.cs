using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo.Domain.Core
{
    /// <summary>
    /// Дочерняя организация
    /// </summary>
    public class ChildCompany
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Address { get; set; }

        public int CompanyId { get; set; }

        [Required]
        public Company? Company { get; set; }

        public ICollection<СonsumerObject>? ConsumerObjects { get; set; }

    }
}
