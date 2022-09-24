using Energo.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo.Domain.Interfaces
{
    public interface IBusinessLogic
    {
        //  IEnergoRepository Db { get; set; }

        /// <summary>
        /// Добавить новую точку измерения
        /// </summary>
        /// <param name="name"></param>
        /// <param name="electricEnergyMeterId"></param>
        /// <param name="currentTransformerId"></param>
        /// <param name="voltageTransformerId"></param>
        /// <param name="consumerObjectId"></param>
        /// <returns></returns>
        MeasuringPoint? AddMeasuringPoint(string name, int electricEnergyMeterId, int currentTransformerId, int voltageTransformerId, int consumerObjectId);

        /// <summary>
        /// Выбрать расчетные приборы учета
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        IEnumerable<CalculationDevice> GetCalculationDevicesByYear(int year);

        /// <summary>
        /// По указанному объекту потребления выбрать все счетчики с закончившимся сроком поверке.
        /// </summary>
        /// <param name="consumerObjectId"></param>
        /// <returns></returns>
        IEnumerable<ElectricEnergyMeter> GetMeterExpiredVerification(int consumerObjectId);

        /// <summary>
        /// По указанному объекту потребления выбрать все трансформаторы напряжения с закончившимся сроком поверке
        /// </summary>
        /// <param name="consumerObjectId"></param>
        /// <returns></returns>
        IEnumerable<VoltageTransformer> GetVoltageTransformerExpiredVerification(int consumerObjectId);


        /// <summary>
        /// По указанному объекту потребления выбрать все трансформаторы тока с закончившимся сроком поверке
        /// </summary>
        /// <param name="consumerObjectId"></param>
        /// <returns></returns>
        IEnumerable<CurrentTransformer> GetCurrentTransformerExpiredVerification(int consumerObjectId);


    }
}
