using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RealFlix.Models;

public class RealFlixContext : DbContext
{
    private readonly IHttpContextAccessor accessor;
    private readonly IConfiguration configuration;
    public RealFlixContext(DbContextOptions<RealFlixContext> options, IHttpContextAccessor _accessor, IConfiguration _configuration)
            : base(options)
    {
        accessor = _accessor;
        configuration = _configuration;
    }

    public DbSet<RealFlix.Models.Show> Show { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var host = accessor.HttpContext?.Request.Host;
        if (host != null && host.ToString().IndexOf(configuration["APIUATUrl"]) >= 0)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("UATConnectionString"));
        }
        else if (host != null && host.ToString().IndexOf(configuration["APIProductionUrl"]) >= 0)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ProductionConnectionString"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUserRole>(userRole =>
        {
            userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

            userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

            userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
        });
    }
}
