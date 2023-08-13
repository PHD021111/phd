using Microsoft.EntityFrameworkCore;
using Game.Models;
namespace Game.Data

{
    public class DataContext:DbContext
    {
        public DataContext()
        {
        
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];
            return strConn;
        }
        public DbSet<NhanVat> NhanVats { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<KyNang> KyNangs { get; set; }
        public DbSet<VuKhi> VuKhis { get; set; }
        public DbSet<KyNangNhanVat> KyNangNhanVats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KyNangNhanVat>()
                    .HasKey(kn => new { kn.NhanVatID, kn.KyNangID });
            modelBuilder.Entity<KyNangNhanVat>()
                    .HasOne(p => p.NhanVat)
                    .WithMany(pc => pc.KyNangNhanVats)
                    .HasForeignKey(p => p.NhanVatID);
            modelBuilder.Entity<KyNangNhanVat>()
                    .HasOne(p => p.KyNang)
                    .WithMany(pc => pc.KyNangNhanVats)
                    .HasForeignKey(c => c.KyNangID);

            
        }

    }
}
