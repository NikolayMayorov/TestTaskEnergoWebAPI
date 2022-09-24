using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo.Domain.Core
{
    /// <summary>
    /// Точка поставки электроэнергии
    /// </summary>
    public class DeliveryPoint
    {

        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int MaxPower { get; set; }

        public int ConsumerObjectId { get; set; }

        //[Required]
        //public СonsumerObject? ConsumerObject { get; set; }

        public ICollection<CalculationDevice>? CalculationDevices { get; set; }  
    }
}
