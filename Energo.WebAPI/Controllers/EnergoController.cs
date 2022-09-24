using Energo.Domain.Core;
using Energo.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Energo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergoController : ControllerBase
    {
     //   private IEnergoRepository repository;
        private IBusinessLogic businessLogic;

        //public EnergoController(IBusinessLogic businessLogic, IEnergoRepository repository, DbContext dbContext)
        //{
        //    this.repository = repository;
        //    this.businessLogic = businessLogic;
        // //   businessLogic.Db = repository;
        //}


        public EnergoController(IBusinessLogic businessLogic)
        {
            //  this.repository = repository;
            this.businessLogic = businessLogic;
        }

        /// <summary>
        /// По указанному объекту потребления выбрать все трансформаторы тока с закончившимся сроком поверке.
        /// </summary>
        /// <param name="consumerObjectId"></param>
        /// <returns></returns>
        [HttpGet("GetTransformer/{consumerObjectId}")]
        public ActionResult<IEnumerable<CurrentTransformer>> GetTransformer(int consumerObjectId)
        {
            return businessLogic.GetCurrentTransformerExpiredVerification(consumerObjectId).ToList();    
        }

        /// <summary>
        /// По указанному объекту потребления выбрать все трансформаторы напряжения с закончившимся сроком поверке.
        /// </summary>
        /// <param name="consumerObjectId"></param>
        /// <returns></returns>
        [HttpGet("GetVoltageTransformer/{consumerObjectId}")]
        public ActionResult<IEnumerable<VoltageTransformer>> GetVoltageTransformer(int consumerObjectId)
        {
            return businessLogic.GetVoltageTransformerExpiredVerification(consumerObjectId).ToList();
        }

        /// <summary>
        /// По указанному объекту потребления выбрать все счетчики с закончившимся сроком поверке..
        /// </summary>
        /// <param name="consumerObjectId"></param>
        /// <returns></returns>
        [HttpGet("GetElectricEnergyMeter/{consumerObjectId}")]
        public ActionResult<IEnumerable<ElectricEnergyMeter>> GetElectricEnergyMeter(int consumerObjectId)
        {
            return businessLogic.GetMeterExpiredVerification(consumerObjectId).ToList();
        }

        /// <summary>
        /// Выбрать расчетные приборы учета
        /// </summary>
        /// <param name="consumerObjectId"></param>
        /// <returns></returns>
        [HttpGet("GetCalculationDevice/{year}")]
        public ActionResult<IEnumerable<CalculationDevice>> GetCalculationDevice(int year)
        {
            return businessLogic.GetCalculationDevicesByYear(year).ToList();
        }


        /// <summary>
        /// Добавить новую точку измерения
        /// </summary>
        /// <param name="name"></param>
        /// <param name="electricEnergyMeterId"></param>
        /// <param name="currentTransformerId"></param>
        /// <param name="voltageTransformerId"></param>
        /// <param name="consumerObjectId"></param>
        /// <returns></returns>
        [HttpPost("{name}/{electricEnergyMeterId}/{currentTransformerId}/{voltageTransformerId}/{consumerObjectId}")]
        public ActionResult<MeasuringPoint> Post(string name, int electricEnergyMeterId, int currentTransformerId, int voltageTransformerId, int consumerObjectId)
        {
            var mp = businessLogic.AddMeasuringPoint(name, electricEnergyMeterId, currentTransformerId, voltageTransformerId, consumerObjectId);
            return mp;
        }




    }
}
