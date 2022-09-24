using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo.Domain.Core
{
    /// <summary>
    /// Объект потребления
    /// </summary>
    public class СonsumerObject
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Address { get; set; }
      
        public int ChildCompanyId { get; set; }

        //[Required]
        //public ChildCompany? ChildCompany { get; set; }

        [Required]
        public ICollection<MeasuringPoint>? MeasuringPoints { get; set; }

        [Required]
        public ICollection<DeliveryPoint>? DeliveryPoints { get; set; }  
    }
}
