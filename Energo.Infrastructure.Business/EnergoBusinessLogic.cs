using Energo.Domain.Core;
using Energo.Domain.Interfaces;
using Energo.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo.Infrastructure.Business
{
    public class EnergoBusinessLogic : IBusinessLogic
    {
        private readonly IConfiguration Configuration;
 
        public EnergoBusinessLogic(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
    

        public MeasuringPoint? AddMeasuringPoint(string name, int electricEnergyMeterId, int currentTransformerId, int voltageTransformerId, int consumerObjectId)
        {
            using (var db = new EnergoContext(Configuration))
            {
                var em = db.ElectricEnergyMeters.FirstOrDefault(e => e.Id == electricEnergyMeterId);
                var ct = db.CurrentTransformers.FirstOrDefault(e => e.Id == currentTransformerId);
                var vt = db.VoltageTransformers.FirstOrDefault(e => e.Id == voltageTransformerId);
                var co = db.ConsumerObjects.FirstOrDefault(e => e.Id == consumerObjectId);
                if (em is null || ct is null || vt is null || co is null)
                    return null;
                var cd = db.CalculationDevices.ToList();
                var mp = new MeasuringPoint()
                {
                    Name = name,
                    VoltageTransformer = vt,  
                    CurrentTransformer = ct,
                    ElectricEnergyMeter = em,
                    CalculationDevices = cd
                };
                if (co.MeasuringPoints is null)
                    co.MeasuringPoints = new List<MeasuringPoint>();
                co.MeasuringPoints.Add(mp);
                db.SaveChanges();
                return mp;  
            }
        }

        public IEnumerable<CalculationDevice> GetCalculationDevicesByYear(int year)
        {
            List<CalculationDevice>? cd;
            using (var db = new EnergoContext(Configuration))
            {
                cd = db.CalculationDevices.Where(c => c.SDate.Year == year || (c.SDate.Year <= year && c.EDate.Year > year)).ToList();
            }
            return cd;
        }


        public IEnumerable<CurrentTransformer> GetCurrentTransformerExpiredVerification(int consumerObjectId)
        {
            List<CurrentTransformer>? currentTransformers;
            try
            {
                using (var db = new EnergoContext(Configuration))
                {
                    var date = DateTime.Now.AddYears(-3);
                    currentTransformers = db.CurrentTransformers.Where(c => c.VerificationDate < date).ToList();
                    var measuringPoints = db.ConsumerObjects.Where(c => c.Id == consumerObjectId).FirstOrDefault()?.MeasuringPoints;
                    var res = currentTransformers.Where(c => measuringPoints.Select(m => m.Id).Contains(c.MeasuringPointId)).ToList();

                }
                return currentTransformers;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<ElectricEnergyMeter> GetMeterExpiredVerification(int consumerObjectId)
        {

            List<ElectricEnergyMeter>? electricEnergyMeters;
            try
            {
                using (var db = new EnergoContext(Configuration))
                {
                    var date = DateTime.Now.AddYears(-3);
                    electricEnergyMeters = db.ElectricEnergyMeters.Where(c => c.VerificationDate < date).ToList();
                    var measuringPoints = db.ConsumerObjects.Where(c => c.Id == consumerObjectId).FirstOrDefault()?.MeasuringPoints;
                    var res = electricEnergyMeters.Where(c => measuringPoints.Select(m => m.Id).Contains(c.MeasuringPointId));

                }
                return electricEnergyMeters;
            }
            catch (Exception)
            {
                return null;
            }
        }

 
        public IEnumerable<VoltageTransformer> GetVoltageTransformerExpiredVerification(int consumerObjectId)
        {
            List<VoltageTransformer>? voltageTransformers;
            try
            {
                using (var db = new EnergoContext(Configuration))
                {
                    var date = DateTime.Now.AddYears(-3);
                    voltageTransformers = db.VoltageTransformers.Where(c => c.VerificationDate < date).ToList();
                    var measuringPoints = db.ConsumerObjects.Where(c => c.Id == consumerObjectId).FirstOrDefault()?.MeasuringPoints;
                    var res = voltageTransformers.Where(c => measuringPoints.Select(m => m.Id).Contains(c.MeasuringPointId));

                }
                return voltageTransformers;
            }
            catch (Exception)
            {
                return null;
            }
        }






    }
    
}
