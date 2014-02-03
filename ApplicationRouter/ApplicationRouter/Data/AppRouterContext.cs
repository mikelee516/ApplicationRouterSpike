

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
        IDbSet<Endpoint> Endpoints { get; set; } // Endpoints
        IDbSet<Registration> Registrations { get; set; } // Registrations

        int SaveChanges();
    }

    // ************************************************************************
    // Database context
    public class AppRouterContext : DbContext, IAppRouterContext
    {
        public IDbSet<Endpoint> Endpoints { get; set; } // Endpoints
        public IDbSet<Registration> Registrations { get; set; } // Registrations

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

            modelBuilder.Configurations.Add(new EndpointConfiguration());
            modelBuilder.Configurations.Add(new RegistrationConfiguration());
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new EndpointConfiguration(schema));
            modelBuilder.Configurations.Add(new RegistrationConfiguration(schema));
            return modelBuilder;
        }
    }

    // ************************************************************************
    // POCO classes

    // Endpoints
    public class Endpoint
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public string Url { get; set; } // URL
        public DateTime? RegistrationTimeStamp { get; set; } // RegistrationTimeStamp

        public Endpoint()
        {
            RegistrationTimeStamp = System.DateTime.Now;
        }
    }

    // Registrations
    public class Registration
    {
        public int Id { get; set; } // Id (Primary key)
        public string EndPoint { get; set; } // EndPoint
        public string Version { get; set; } // Version
        public string Url { get; set; } // URL
        public DateTime RegistrationTime { get; set; } // RegistrationTime

        public Registration()
        {
            RegistrationTime = System.DateTime.Now;
        }
    }


    // ************************************************************************
    // POCO Configuration

    // Endpoints
    internal class EndpointConfiguration : EntityTypeConfiguration<Endpoint>
    {
        public EndpointConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Endpoints");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(256);
            Property(x => x.Url).HasColumnName("URL").IsRequired().HasMaxLength(1024);
            Property(x => x.RegistrationTimeStamp).HasColumnName("RegistrationTimeStamp").IsOptional();
        }
    }

    // Registrations
    internal class RegistrationConfiguration : EntityTypeConfiguration<Registration>
    {
        public RegistrationConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Registrations");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.EndPoint).HasColumnName("EndPoint").IsRequired().HasMaxLength(256);
            Property(x => x.Version).HasColumnName("Version").IsRequired().HasMaxLength(128);
            Property(x => x.Url).HasColumnName("URL").IsRequired().HasMaxLength(1024);
            Property(x => x.RegistrationTime).HasColumnName("RegistrationTime").IsRequired();
        }
    }

}

