using DataAccessLayer.Entities;
using Domain.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> op) : IdentityDbContext<ApplicationUser, ApplicationRole, long>(op)
    {
        public virtual ICollection<IdentityUserClaim<long>> Claims { get; set; } = null!;
        public virtual ICollection<IdentityUserLogin<long>> Logins { get; set; } = null!;
        public virtual ICollection<IdentityUserToken<long>> Tokens { get; set; } = null!;
        public virtual DbSet<ApplicationRole> AspNetRoles { get; set; }
        public override DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //#region IdentityDbContext 
            //modelBuilder.Entity<User>(b =>
            //{
            //    b.ToTable("Users");
            //    b.HasKey(p => p.Id);
            //    b.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UQ_AspNetUsers_UserName").IsUnique();
            //    b.HasIndex(u => u.NormalizedEmail).HasDatabaseName("UQ_AspNetUsers_Email").IsUnique();
            //    b.HasIndex(u => u.PhoneNumber).HasDatabaseName("UQ_AspNetUsers_Phone").IsUnique();
            //    b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            //    b.HasMany<IdentityUserClaim<long>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired().HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            //    b.HasMany<IdentityUserRole<long>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired().HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            //    b.HasMany<IdentityUserToken<long>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired().HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            //    b.HasMany<IdentityUserLogin<long>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired().HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            //});

            //modelBuilder.Entity<IdentityUserClaim<long>>(b =>
            //{
            //    b.ToTable("UserClaims");
            //    b.HasKey(p => p.Id);
            //    b.HasIndex(p => p.UserId).HasDatabaseName("IX_AspNetUserClaims_UserId");
            //});

            //modelBuilder.Entity<IdentityUserLogin<long>>(b =>
            //{
            //    b.ToTable("UserLogins");
            //    b.HasKey(p => new { p.UserId, p.LoginProvider, p.ProviderKey });
            //    b.HasIndex(p => p.UserId).HasDatabaseName("IX_AspNetUserLogins_UserId");
            //});

            //modelBuilder.Entity<IdentityUserToken<long>>(b =>
            //{
            //    b.ToTable("UserTokens");
            //    b.HasKey(p => new { p.UserId, p.LoginProvider, p.Name });
            //    b.HasIndex(p => p.UserId).HasDatabaseName("IX_AspNetUserTokens_UserId");
            //});

            //modelBuilder.Entity<IdentityRole<long>>(b =>
            //{
            //    b.ToTable("Roles");
            //    b.HasKey(p => p.Id);
            //    b.HasAlternateKey(r => r.NormalizedName).HasName("UQ_AspNetRoles_Name");
            //    b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            //    b.HasMany<IdentityUserRole<long>>().WithOne().HasForeignKey(us => us.RoleId).IsRequired().HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");
            //    b.HasMany<IdentityRoleClaim<long>>().WithOne().HasForeignKey(uc => uc.RoleId).IsRequired().HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            //});

            //modelBuilder.Entity<IdentityUserRole<long>>(b =>
            //{
            //    b.ToTable("UserRoles");
            //    b.HasKey(p => new { p.UserId, p.RoleId });
            //    b.HasIndex(p => p.UserId).HasDatabaseName("IX_AspNetUserRoles_UserId");
            //    b.HasIndex(p => p.RoleId).HasDatabaseName("IX_AspNetUserRoles_RoleId");
            //});

            //modelBuilder.Entity<IdentityRoleClaim<long>>(b =>
            //{
            //    b.ToTable("RoleClaims");
            //    b.HasKey(p => p.Id);
            //    b.HasIndex(p => p.RoleId).HasDatabaseName("IX_AspNetsRoleClaim_RoleId");
            //});
            //#endregion

        }

    }
}

//add-migration "name" -Context nameoftheDbcontext
//remove-migration  -Context nameoftheDbcontext 
//update-database -Context nameoftheDbcontext 

