using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo.Domain.Core
{
    /// <summary>
    /// Точка измерения электроэнергии
    /// </summary>
    public class MeasuringPoint
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
   
        public int СonsumerObjectId { get; set; }

        //[Required]
        //public СonsumerObject? ConsumerObject{ get; set; }

        [Required]
        public ElectricEnergyMeter? ElectricEnergyMeter { get; set; }

        [Required]
        public CurrentTransformer? CurrentTransformer{ get; set; }

        [Required]
        public VoltageTransformer? VoltageTransformer{ get; set; }

        [Required]
        public ICollection<CalculationDevice>? CalculationDevices { get; set; }  
    }
}
