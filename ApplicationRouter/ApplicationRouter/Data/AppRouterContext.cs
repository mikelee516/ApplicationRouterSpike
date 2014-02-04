

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Configuration file:     "ApplicationRouter\App.config"
//     Connection String Name: "AppRouterContext"
//     Connection String:      "Data Source=.;Initial Catalog=AppRouter;Integrated Security=SSPI;"

// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace ApplicationRouter.Data
{
    // ************************************************************************
    // Unit of work
    public interface IAppRouterContext : IDisposable
    {
        IDbSet<EndpointRegistration> EndpointRegistrations { get; set; } // EndpointRegistrations

        int SaveChanges();
    }

    // ************************************************************************
    // Database context
    public class AppRouterContext : DbContext, IAppRouterContext
    {
        public IDbSet<EndpointRegistration> EndpointRegistrations { get; set; } // EndpointRegistrations

        static AppRouterContext()
        {
            Database.SetInitializer<AppRouterContext>(null);
        }

        public AppRouterContext()
            : base("Name=AppRouterContext")
        {
        }

        public AppRouterContext(string connectionString) : base(connectionString)
        {
        }

        public AppRouterContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new EndpointRegistrationConfiguration());
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new EndpointRegistrationConfiguration(schema));
            return modelBuilder;
        }
    }

    // ************************************************************************
    // POCO classes

    // EndpointRegistrations
    public class EndpointRegistration
    {
        public int Id { get; set; } // Id (Primary key)
        public string EndPoint { get; set; } // EndPoint
        public string Version { get; set; } // Version
        public string Url { get; set; } // URL
        public DateTime RegistrationTime { get; set; } // RegistrationTime

        public EndpointRegistration()
        {
            RegistrationTime = System.DateTime.Now;
        }
    }


    // ************************************************************************
    // POCO Configuration

    // EndpointRegistrations
    internal class EndpointRegistrationConfiguration : EntityTypeConfiguration<EndpointRegistration>
    {
        public EndpointRegistrationConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".EndpointRegistrations");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.EndPoint).HasColumnName("EndPoint").IsRequired().HasMaxLength(256);
            Property(x => x.Version).HasColumnName("Version").IsRequired().HasMaxLength(128);
            Property(x => x.Url).HasColumnName("URL").IsRequired().HasMaxLength(1024);
            Property(x => x.RegistrationTime).HasColumnName("RegistrationTime").IsRequired();
        }
    }

}

