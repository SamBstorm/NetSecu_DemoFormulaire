using Microsoft.EntityFrameworkCore;
using NetSecu_DemoFormulaire.Models.Domain.Configurations;
using NetSecu_DemoFormulaire.Models.Entities;

namespace NetSecu_DemoFormulaire.Models.Domain
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get { return Set<Utilisateur>(); } }
        public DbSet<Jeux> Jeux { get { return Set<Jeux>(); } }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoFormulaire;Integrated Security=True;Encrypt=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Utilisateur defaultUser = new Utilisateur()
            {
                Id = Guid.NewGuid(),
                Nom = "Admin",
                Prenom = "Admin",
                Email = "admin@tftic.be",
                Passwd = "Admin1234="
            };

            Jeux j1 = new Jeux()
            { 
                Id = Guid.NewGuid(),
                Nom = "Super Mario Bros.",
                Editeur = "Nintendo",
                AnneeSortie = 1985,
                DateAjout = DateTime.Now,
                //Createur = defaultUser,
                CreateurId = defaultUser.Id
            };
            modelBuilder.ApplyConfiguration(new UtilisateurConfig());
            modelBuilder.ApplyConfiguration(new JeuxConfig());

            modelBuilder.Entity<Utilisateur>().HasData(defaultUser);
            modelBuilder.Entity<Jeux>().HasData(j1);
        }
    }
}