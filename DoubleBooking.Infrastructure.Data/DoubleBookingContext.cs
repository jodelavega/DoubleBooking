using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DoubleBooking.Domain.Entities;

namespace DoubleBooking.Infrastructure.Data
{
    public interface IDoubleBookingContext
    {
        DbSet<Clerk> Clerks { get; set; }
        DbSet<LocalAuthorities> LocalAuthorities { get; set; }
        DbSet<Booking> Bookings { get; set; }
        Database Database { get; }
        DbChangeTracker ChangeTracker { get; }
        DbContextConfiguration Configuration { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
        void Dispose();
        string ToString();
        bool Equals(object obj);
        int GetHashCode();
        Type GetType();
    }

    public class DoubleBookingContext: DbContext, IDoubleBookingContext
    {

        public DoubleBookingContext(): base("Name=DoubleBookingContext")
        {

        }

        public DbSet<Clerk> Clerks { get; set; }
        public DbSet<LocalAuthorities> LocalAuthorities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        
    }
}
