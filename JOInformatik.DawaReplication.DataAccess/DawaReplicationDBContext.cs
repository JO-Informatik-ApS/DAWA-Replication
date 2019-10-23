using Microsoft.EntityFrameworkCore;

namespace JOInformatik.DawaReplication.DataAccess
{
    public partial class DawaReplicationDBContext : DawaReplicationDBContextBase
    {
        public DawaReplicationDBContext()
            : base()
        {
        }

        public DawaReplicationDBContext(DbContextOptions<DawaReplicationDBContextBase> options)
            : base(options)
        {
        }

        public DbSet<Entitystate> Entitystate { get; set; }

        public DbSet<EntitystateHistory> EntitystateHistory { get; set; }

        public DbSet<DAGI__Afstemningsomraader> Dagi_Afstemningsomraader { get; set; }

        public DbSet<DAGI__Kommuner> Dagi_Kommuner { get; set; }

        public DbSet<DAGI__Landsdele> Dagi_Landsdele { get; set; }

        public DbSet<DAGI__Menighedsraadsafstemningsomraader> Dagi_Menighedsraadsafstemningsomraader { get; set; }

        public DbSet<DAGI__Opstillingskredse> Dagi_Opstillingskredse { get; set; }

        public DbSet<DAGI__Politikredse> Dagi_Politikredse { get; set; }

        public DbSet<DAGI__Postnumre> Dagi_Postnumre { get; set; }

        public DbSet<DAGI__Regioner> Dagi_Regioner { get; set; }

        public DbSet<DAGI__Retskredse> Dagi_Retskredse { get; set; }

        public DbSet<DAGI__Sogne> Dagi_Sogne { get; set; }

        public DbSet<DAGI__Steder> Dagi_Steder { get; set; }

        public DbSet<DAGI__Stednavne> Dagi_Stednavne { get; set; }

        public DbSet<DAGI__Storkredse> Dagi_Storkredse { get; set; }

        public DbSet<DAGI__Supplerendebynavne2> Dagi_Supplerendebynavne2 { get; set; }

        public DbSet<DAGI__Valglandsdele> Dagi_Valglandsdele { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entitystate>()
                .HasKey(c => new { c.Entity });
            modelBuilder.Entity<EntitystateHistory>()
                .HasKey(c => new { c.Entity, c.Starttime });
            modelBuilder.Entity<DAGI__Afstemningsomraader>()
                .HasKey(c => new { c.Dagi_id });
            modelBuilder.Entity<DAGI__Kommuner>()
                .HasKey(c => new { c.Dagi_id });
            modelBuilder.Entity<DAGI__Landsdele>()
                .HasKey(c => new { c.Dagi_id });
            modelBuilder.Entity<DAGI__Menighedsraadsafstemningsomraader>()
                .HasKey(c => new { c.Dagi_id });
            modelBuilder.Entity<DAGI__Opstillingskredse>()
                .HasKey(c => new { c.Dagi_id });
            modelBuilder.Entity<DAGI__Politikredse>()
                .HasKey(c => new { c.Dagi_id });
            modelBuilder.Entity<DAGI__Postnumre>()
                .HasKey(c => new { c.Nr });
            modelBuilder.Entity<DAGI__Regioner>()
                .HasKey(c => new { c.Dagi_id });
            modelBuilder.Entity<DAGI__Retskredse>()
                .HasKey(c => new { c.Dagi_id });
            modelBuilder.Entity<DAGI__Sogne>()
                .HasKey(c => new { c.Dagi_id });
            modelBuilder.Entity<DAGI__Steder>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<DAGI__Stednavne>()
                .HasKey(c => new { c.Id });
            modelBuilder.Entity<DAGI__Storkredse>()
                .HasKey(c => new { c.Nummer });
            modelBuilder.Entity<DAGI__Supplerendebynavne2>()
                .HasKey(c => new { c.Dagi_id });
            modelBuilder.Entity<DAGI__Valglandsdele>()
                .HasKey(c => new { c.Bogstav });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["DawaDatabase"].ConnectionString);
        }

    }
}
