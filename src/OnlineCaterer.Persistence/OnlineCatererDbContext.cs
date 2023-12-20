using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Domain.Common;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Domain.Identity.Relationship;
using System.Reflection;

namespace OnlineCaterer.Persistence
{
	public class OnlineCatererDbContext : DbContext
	{
		public OnlineCatererDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public virtual async Task<int> SaveChangesAsync(int userId, int userTypeId)
		{
			foreach (var entry in base.ChangeTracker.Entries<IAuditableEntity>()
				.Where(e => e.State == EntityState.Added
					|| e.State == EntityState.Modified))
			{
				if (entry.Entity is not null)
				{
					entry.Entity.ModifiedByUserType = userTypeId;

					entry.Entity.LastModifiedDate = DateTime.Now;
					entry.Entity.LastModifiedBy = userId;

					if (entry.State == EntityState.Added)
					{
						entry.Entity.CreatedDate = DateTime.Now;
						entry.Entity.CreatedBy = userId;
					}
				}
			}

			return await base.SaveChangesAsync();
		}

		// identity
		public DbSet<Domain.Identity.Action> Actions { get; set; } = null!;
		public DbSet<Group> Groups { get; set; } = null!;
		public DbSet<Domain.Identity.Object> Objects { get; set; } = null!;
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<UserType> UserTypes { get; set; } = null!;

		// identity rel
		public DbSet<GroupPermission> GroupPermissions { get; set; } = null!;
		public DbSet<GroupUser> GroupUsers { get; set; } = null!;
		public DbSet<UserPermission> UserPermissions { get; set; } = null!;

		// core
		public DbSet<Customer> Customers { get; set; } = null!;
		public DbSet<Employee> Employees { get; set; } = null!;
		public DbSet<Event> Events { get; set; } = null!;
		public DbSet<Feedback> Feedbacks { get; set; } = null!;
		public DbSet<Food> Foods { get; set; } = null!;
		public DbSet<FoodCategory> FoodCategories { get; set; } = null!;
		public DbSet<FoodImage> FoodImages { get; set; } = null!;
		public DbSet<Order> Orders { get; set; } = null!;
		public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
		public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
		public DbSet<Supplier> Suppliers { get; set; } = null!;
	}
}
