using Energo.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energo.Infrastructure.Data
{
    public class EnergoContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public DbSet<Company> Companies => Set<Company>();

        public DbSet<ChildCompany> ChildCompanies => Set<ChildCompany>();

        public DbSet<СonsumerObject> ConsumerObjects => Set<СonsumerObject>();

        public DbSet<MeasuringPoint> MeasuringPoints => Set<MeasuringPoint>();

        public DbSet<ElectricEnergyMeter> ElectricEnergyMeters => Set<ElectricEnergyMeter>();

        public DbSet<VoltageTransformer> VoltageTransformers => Set<VoltageTransformer>();

        public DbSet<CurrentTransformer> CurrentTransformers => Set<CurrentTransformer>();

        public DbSet<DeliveryPoint> DeliveryPoints => Set<DeliveryPoint>();

        public DbSet<CalculationDevice> CalculationDevices => Set<CalculationDevice>();


        public EnergoContext(IConfiguration configuration)
        {
            Configuration = configuration;
         //   Database.EnsureDeleted();
            var res = Database.EnsureCreated();
            if (res)
                FillDB();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration["ConnectionStrings:SqLiteDB"]);   
        }


        private void FillDB()
        {
            Company company1 = new Company { Name = "MosEnergo", Address = "ул. Ленина, 1234" };
            Company company2 = new Company { Name = "SankEnergo", Address = "ул. Ленина, 4321" };
            this.Companies.AddRange(company1, company2);

            ChildCompany childCompany1 = new ChildCompany { Name = "SubMosEnergo Sever", Address = "ул. Ленина, 78764" };
            ChildCompany childCompany2 = new ChildCompany { Name = "SubMosEnergo Center", Address = "ул. Ленина, 345" };

            ChildCompany childCompany3 = new ChildCompany { Name = "SubSankEnergo Sever", Address = "ул. Ленина, 3244" };
            ChildCompany childCompany4 = new ChildCompany { Name = "SubSankEnergo Center", Address = "ул. Ленина, 555" };

            company1.ChildCompanies = new List<ChildCompany>();
            company1.ChildCompanies.Add(childCompany1);
            company1.ChildCompanies.Add(childCompany2);

            company2.ChildCompanies = new List<ChildCompany>();
            company2.ChildCompanies.Add(childCompany3);
            company2.ChildCompanies.Add(childCompany4);

            СonsumerObject сonsumerObject1 = new СonsumerObject() { Name = "ПС 110/10 Весна", Address = "ул. Ленина, 123" };
            СonsumerObject сonsumerObject2 = new СonsumerObject() { Name = "ПС 112/10 Весна", Address = "ул. Ленина, 12133" };
            childCompany1.ConsumerObjects = new List<СonsumerObject>() { сonsumerObject1, сonsumerObject2 };
  
            СonsumerObject сonsumerObject3 = new СonsumerObject() { Name = "ПС 113/10 Весна", Address = "ул. Ленина, 0003" };
            childCompany2.ConsumerObjects = new List<СonsumerObject>() { сonsumerObject3 };
  
            СonsumerObject сonsumerObject4 = new СonsumerObject() { Name = "ПС 114/10 Весна", Address = "ул. Ленина, 2345" };
            СonsumerObject сonsumerObject5 = new СonsumerObject() { Name = "ПС 115/10 Весна", Address = "ул. Ленина, 4433" };
            childCompany3.ConsumerObjects = new List<СonsumerObject>() { сonsumerObject4, сonsumerObject5 };

            СonsumerObject сonsumerObject6 = new СonsumerObject() { Name = "ПС 116/10 Весна", Address = "ул. Ленина, 113" };
            childCompany4.ConsumerObjects = new List<СonsumerObject>() { сonsumerObject6 };


            MeasuringPoint measuringPoint1 = new MeasuringPoint() { Name = "Точка измерения 1"};
            MeasuringPoint measuringPoint2 = new MeasuringPoint() { Name = "Точка измерения 2" };
            MeasuringPoint measuringPoint3 = new MeasuringPoint() { Name = "Точка измерения 3" };
            MeasuringPoint measuringPoint4 = new MeasuringPoint() { Name = "Точка измерения 4" };
            MeasuringPoint measuringPoint5 = new MeasuringPoint() { Name = "Точка измерения 5" };
            MeasuringPoint measuringPoint6 = new MeasuringPoint() { Name = "Точка измерения 6" };
            MeasuringPoint measuringPoint7 = new MeasuringPoint() { Name = "Точка измерения 7" };
            MeasuringPoint measuringPoint8 = new MeasuringPoint() { Name = "Точка измерения 8" };
            MeasuringPoint measuringPoint9 = new MeasuringPoint() { Name = "Точка измерения 9" };

            сonsumerObject1.MeasuringPoints = new List<MeasuringPoint>() { measuringPoint1, measuringPoint2 };          
            сonsumerObject2.MeasuringPoints = new List<MeasuringPoint>() { measuringPoint3, measuringPoint4 };         
            сonsumerObject2.MeasuringPoints = new List<MeasuringPoint>() { measuringPoint5, measuringPoint6 }; 
            сonsumerObject3.MeasuringPoints = new List<MeasuringPoint>() { measuringPoint6, measuringPoint7 };
            сonsumerObject4.MeasuringPoints = new List<MeasuringPoint>() { measuringPoint7, measuringPoint8};  
            сonsumerObject5.MeasuringPoints = new List<MeasuringPoint>() { measuringPoint8 };   
            сonsumerObject6.MeasuringPoints = new List<MeasuringPoint>() { measuringPoint9 };

            measuringPoint1.ElectricEnergyMeter = new ElectricEnergyMeter() { Number = 1, VerificationDate = new DateTime(2018, 1, 1), Type = "Стандартный" };
            measuringPoint2.ElectricEnergyMeter = new ElectricEnergyMeter() { Number = 2, VerificationDate = new DateTime(2018, 1, 1), Type = "Стандартный" };
            measuringPoint3.ElectricEnergyMeter = new ElectricEnergyMeter() { Number = 3, VerificationDate = new DateTime(2015, 1, 1), Type = "Стандартный" };
            measuringPoint4.ElectricEnergyMeter = new ElectricEnergyMeter() { Number = 4, VerificationDate = new DateTime(2020, 1, 1), Type = "Стандартный" };
            measuringPoint5.ElectricEnergyMeter = new ElectricEnergyMeter() { Number = 5, VerificationDate = new DateTime(2018, 1, 1), Type = "Стандартный" };
            measuringPoint6.ElectricEnergyMeter = new ElectricEnergyMeter() { Number = 6, VerificationDate = new DateTime(2019, 1, 1), Type = "Стандартный" };
            measuringPoint7.ElectricEnergyMeter = new ElectricEnergyMeter() { Number = 7, VerificationDate = new DateTime(2022, 1, 1), Type = "Стандартный" };
            measuringPoint8.ElectricEnergyMeter = new ElectricEnergyMeter() { Number = 8, VerificationDate = new DateTime(2017, 1, 1), Type = "Стандартный" };
            measuringPoint9.ElectricEnergyMeter = new ElectricEnergyMeter() { Number = 9, VerificationDate = new DateTime(2022, 1, 1), Type = "Стандартный" };

            measuringPoint1.VoltageTransformer = new VoltageTransformer() { Number = 1, TransformRatio = 2, VerificationDate = new DateTime(2018, 1, 1), Type = "Стандартный" };
            measuringPoint2.VoltageTransformer = new VoltageTransformer() { Number = 2, TransformRatio = 1.2, VerificationDate = new DateTime(2019, 1, 1), Type = "Стандартный" };
            measuringPoint3.VoltageTransformer = new VoltageTransformer() { Number = 3, TransformRatio = 1, VerificationDate = new DateTime(2012, 1, 1), Type = "Стандартный" };
            measuringPoint4.VoltageTransformer = new VoltageTransformer() { Number = 4, TransformRatio = 2, VerificationDate = new DateTime(2022, 1, 1), Type = "Стандартный" };
            measuringPoint5.VoltageTransformer = new VoltageTransformer() { Number = 5, TransformRatio = 1.8, VerificationDate = new DateTime(2021, 1, 1), Type = "Стандартный" };
            measuringPoint6.VoltageTransformer = new VoltageTransformer() { Number = 6, TransformRatio = 1.2, VerificationDate = new DateTime(2019, 1, 1), Type = "Стандартный" };
            measuringPoint7.VoltageTransformer = new VoltageTransformer() { Number = 7, TransformRatio = 0.5, VerificationDate = new DateTime(2018, 1, 1), Type = "Стандартный" };
            measuringPoint8.VoltageTransformer = new VoltageTransformer() { Number = 8, TransformRatio = 1, VerificationDate = new DateTime(2011, 1, 1), Type = "Стандартный" };
            measuringPoint9.VoltageTransformer = new VoltageTransformer() { Number = 9, TransformRatio = 3, VerificationDate = new DateTime(2022, 1, 1), Type = "Стандартный" };

            measuringPoint1.CurrentTransformer = new CurrentTransformer() { Number = 1, TransformRatio = 2, VerificationDate = new DateTime(2018, 1, 1), Type = "Стандартный" };
            measuringPoint2.CurrentTransformer = new CurrentTransformer() { Number = 2, TransformRatio = 2.4, VerificationDate = new DateTime(2019, 1, 1), Type = "Стандартный" };
            measuringPoint3.CurrentTransformer = new CurrentTransformer() { Number = 3, TransformRatio = 1, VerificationDate = new DateTime(2014, 1, 1), Type = "Стандартный" };
            measuringPoint4.CurrentTransformer = new CurrentTransformer() { Number = 4, TransformRatio = 2.1, VerificationDate = new DateTime(2022, 1, 1), Type = "Стандартный" };
            measuringPoint5.CurrentTransformer = new CurrentTransformer() { Number = 5, TransformRatio = 3, VerificationDate = new DateTime(2019, 1, 1), Type = "Стандартный" };
            measuringPoint6.CurrentTransformer = new CurrentTransformer() { Number = 6, TransformRatio = 0.8, VerificationDate = new DateTime(2018, 1, 1), Type = "Стандартный" };
            measuringPoint7.CurrentTransformer = new CurrentTransformer() { Number = 7, TransformRatio = 0.1, VerificationDate = new DateTime(2021, 1, 1), Type = "Стандартный" };
            measuringPoint8.CurrentTransformer = new CurrentTransformer() { Number = 8, TransformRatio = 2, VerificationDate = new DateTime(2019, 1, 1), Type = "Стандартный" };
            measuringPoint9.CurrentTransformer = new CurrentTransformer() { Number = 9, TransformRatio = 1, VerificationDate = new DateTime(2018, 1, 1), Type = "Стандартный" };
         
            DeliveryPoint deliveryPoint1 = new DeliveryPoint() { Name = "Точка поставки 1", MaxPower = 1000 };
            DeliveryPoint deliveryPoint2 = new DeliveryPoint() { Name = "Точка поставки 2", MaxPower = 3000 };
            DeliveryPoint deliveryPoint3 = new DeliveryPoint() { Name = "Точка поставки 3", MaxPower = 5000 };
            DeliveryPoint deliveryPoint4 = new DeliveryPoint() { Name = "Точка поставки 4", MaxPower = 7000 };

            сonsumerObject1.DeliveryPoints = new List<DeliveryPoint>() { deliveryPoint1, deliveryPoint2 };
            сonsumerObject2.DeliveryPoints = new List<DeliveryPoint>() { deliveryPoint1 };
            сonsumerObject3.DeliveryPoints = new List<DeliveryPoint>() { deliveryPoint3, deliveryPoint4 };
            сonsumerObject4.DeliveryPoints = new List<DeliveryPoint>() { deliveryPoint3, deliveryPoint4 };
            сonsumerObject5.DeliveryPoints = new List<DeliveryPoint>() { deliveryPoint2 };
            сonsumerObject6.DeliveryPoints = new List<DeliveryPoint>() { deliveryPoint1, deliveryPoint4 };

            CalculationDevice calculationDevice1 = new CalculationDevice() { SDate = new DateTime(2018, 1, 1), EDate = new DateTime(2019, 1, 1) };
            CalculationDevice calculationDevice2 = new CalculationDevice() { SDate = new DateTime(2017, 1, 1), EDate = new DateTime(2018, 1, 1) };
            CalculationDevice calculationDevice3 = new CalculationDevice() { SDate = new DateTime(2020, 1, 1), EDate = new DateTime(2021, 1, 1) };
            CalculationDevice calculationDevice4 = new CalculationDevice() { SDate = new DateTime(2021, 1, 1), EDate = new DateTime(2022, 1, 1) };

            deliveryPoint1.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };
            deliveryPoint2.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };
            deliveryPoint3.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };
            deliveryPoint4.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };

            measuringPoint1.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };
            measuringPoint2.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };
            measuringPoint3.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };
            measuringPoint4.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };
            measuringPoint5.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };
            measuringPoint6.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };
            measuringPoint7.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };
            measuringPoint8.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };
            measuringPoint9.CalculationDevices = new List<CalculationDevice>() { calculationDevice1, calculationDevice2, calculationDevice3, calculationDevice4 };




            this.SaveChanges();
        }

    }
}
