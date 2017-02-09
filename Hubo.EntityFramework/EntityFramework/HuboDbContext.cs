using System.Data.Common;
using Abp.Zero.EntityFramework;
using Hubo.Authorization.Roles;
using Hubo.MultiTenancy;
using Hubo.Users;
using System.Data.Entity;
using System;

namespace Hubo.EntityFramework
{
    public class HuboDbContext : AbpZeroDbContext<Tenant, Role, User>, IDisposable 
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual DbSet<Break> BreakSet { get; set; }
        public virtual DbSet<Company> CompanySet { get; set; }
        public virtual DbSet<Driver> DriverSet { get; set; }
        public virtual DbSet<DriverCompany> DriverCompanySet { get; set; }
        public virtual DbSet<DrivingShift> DrivingShiftSet { get; set; }
        public virtual DbSet<GeoData> GeoDataSet { get; set; }
        public virtual DbSet<Note> NoteSet { get; set; }
        public virtual DbSet<Vehicle> VehicleSet { get; set; }
        public virtual DbSet<WorkShift> WorkShiftSet { get; set; }
        public virtual DbSet<Licence> LicenceSet { get; set; }
        //public virtual DbSet<User> UserSet { get; set; }


        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public HuboDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in HuboDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of HuboDbContext since ABP automatically handles it.
         */
        public HuboDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public HuboDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
