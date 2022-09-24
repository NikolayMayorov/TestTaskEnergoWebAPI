using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo.Domain.Core
{
    /// <summary>
    /// Трансформатор тока
    /// </summary>
    public class CurrentTransformer
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public DateTime VerificationDate { get; set; }

        [Required]
        public double TransformRatio { get; set; }

        public int MeasuringPointId { get; set; }

        //[Required]
        //public MeasuringPoint? MeasuringPoint { get; set; }
    }
}
