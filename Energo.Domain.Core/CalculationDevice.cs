using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo.Domain.Core
{
    /// <summary>
    /// Расчетный прибор учета
    /// </summary>
    public class CalculationDevice
    {
        public int Id { get; set; } 

        public DateTime SDate { get; set; }

        public DateTime EDate { get; set; }



        //[Required]
        //public ICollection<DeliveryPoint>? DeliveryPoints { get; set; }

        //public ICollection<MeasuringPoint>? MeasuringPoints { get; set; }
    }
}
