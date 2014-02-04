

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Configuration file:     "App.config"
//     Connection String Name: "FoodTrackerContext"
//     Connection String:      "Data Source=.;Initial Catalog=FoodTracker;Integrated Security=SSPI;"

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

namespace FoodTrackerWebApi.Data
{
    // ************************************************************************
    // Unit of work
    public interface IFoodTrackerContext : IDisposable
    {
        IDbSet<Food> Foods { get; set; } // Foods
        IDbSet<Meal> Meals { get; set; } // Meals
        IDbSet<User> Users { get; set; } // Users

        int SaveChanges();
    }

    // ************************************************************************
    // Database context
    public class FoodTrackerContext : DbContext, IFoodTrackerContext
    {
        public IDbSet<Food> Foods { get; set; } // Foods
        public IDbSet<Meal> Meals { get; set; } // Meals
        public IDbSet<User> Users { get; set; } // Users

        static FoodTrackerContext()
        {
            Database.SetInitializer<FoodTrackerContext>(null);
        }

        public FoodTrackerContext()
            : base("Name=FoodTrackerContext")
        {
        }

        public FoodTrackerContext(string connectionString) : base(connectionString)
        {
        }

        public FoodTrackerContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new FoodConfiguration());
            modelBuilder.Configurations.Add(new MealConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new FoodConfiguration(schema));
            modelBuilder.Configurations.Add(new MealConfiguration(schema));
            modelBuilder.Configurations.Add(new UserConfiguration(schema));
            return modelBuilder;
        }
    }

    // ************************************************************************
    // POCO classes

    // Foods
    public class Food
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
    }

    // Meals
    public class Meal
    {
        public int Id { get; set; } // Id (Primary key)
        public int UserId { get; set; } // UserId
        public int FoodId { get; set; } // FoodId
        public DateTime Time { get; set; } // Time
    }

    // Users
    public class User
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
    }


    // ************************************************************************
    // POCO Configuration

    // Foods
    internal class FoodConfiguration : EntityTypeConfiguration<Food>
    {
        public FoodConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Foods");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(256);
        }
    }

    // Meals
    internal class MealConfiguration : EntityTypeConfiguration<Meal>
    {
        public MealConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Meals");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            Property(x => x.FoodId).HasColumnName("FoodId").IsRequired();
            Property(x => x.Time).HasColumnName("Time").IsRequired();
        }
    }

    // Users
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Users");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(256);
        }
    }

}

