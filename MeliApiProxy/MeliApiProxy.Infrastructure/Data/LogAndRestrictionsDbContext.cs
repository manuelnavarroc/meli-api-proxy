using MeliApiProxy.Domain.Entities.Log;
using MeliApiProxy.Domain.Entities.Restriction;
using Microsoft.EntityFrameworkCore;

namespace MeliApiProxy.Infrastructure.Data;
public class LogAndRestrictionsDbContext : DbContext
{
    public LogAndRestrictionsDbContext(DbContextOptions<LogAndRestrictionsDbContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<RequestLog> RequestLog { get; set; }
    public virtual DbSet<ResponseLog> ResponseLog { get; set; }
    public virtual DbSet<RestrictionLog> RestrictionLog { get; set; }
    public virtual DbSet<RestrictionByIp> RestrictionByIp { get; set; }
    public virtual DbSet<RestrictionByPath> RestrictionByPath { get; set; }
    public virtual DbSet<RestrictionByIpAndPath> RestrictionByIpAndPath { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestLog>()
            .HasKey(c => c.RequestLogId);

        modelBuilder.Entity<ResponseLog>()
            .HasKey(c => c.ResponseLogId);

        modelBuilder.Entity<RestrictionLog>()
            .HasKey(c => c.RestrictionLogId);

        modelBuilder.Entity<RestrictionByIp>()
            .HasKey(c => c.RestrictionByIpId);
        
        modelBuilder.Entity<RestrictionByPath>()
            .HasKey(c => c.RestrictionByPathId);

        modelBuilder.Entity<RestrictionByIpAndPath>()
            .HasKey(c => c.RestrictionByIpAndPathId);

        modelBuilder.Entity<RequestLog>()
            .HasMany(e => e.ResponseLogs)
            .WithOne(c => c.RequestLog);
    }
}