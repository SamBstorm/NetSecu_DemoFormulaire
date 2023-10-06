using Microsoft.Data.SqlClient;
using NetSecu_DemoFormulaire.Models;
using NetSecu_DemoFormulaire.Models.Entities;
using NetSecu_DemoFormulaire.Repository.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Database;

namespace NetSecu_DemoFormulaire.Repository
{
    public class GameRepository : IGameRepository
    {
        string cnstr;

        public GameRepository(string connection)
        {
            cnstr = connection;
        }
        public void Create(Jeux entity)
        {
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                connection.ExecuteNonQuery("INSERT INTO Jeux (Nom, Editeur, AnneeSortie, DateAjout, CreateurId) VALUES (@nom, @editeur, @annee, @date, @c_id)", parameters: new { 
                    nom = entity.Nom,
                    editeur = entity.Editeur,
                    annee = entity.AnneeSortie,
                    date = entity.DateAjout,
                    c_id = entity.CreateurId
                });
            }
        }

        public void Delete(Guid id)
        {
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                connection.ExecuteNonQuery("DELETE FROM Jeux WHERE Id = @id)", parameters: new { id });
            }
        }

        public IEnumerable<Jeux> Get()
        {
            IEnumerable<Jeux> listFromDb = null;
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                return connection.ExecuteReader("SELECT Id, Nom, Editeur, AnneeSortie, DateAjout, CreateurId FROM Jeux", dr => dr.ToJeux());
            }
        }

        public Jeux Get(Guid id)
        {
            Jeux? jeux;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                jeux = connection.ExecuteReader("SELECT Id, Nom, Editeur, AnneeSortie, DateAjout, CreateurId FROM Jeux WHERE id= @GUID;", dr => dr.ToJeux(), parameters: new { GUID = id }).SingleOrDefault();

                if (jeux is null)
                {
                    return default;
                }
            }
            return new Jeux() { Id = jeux.Id, Nom = jeux.Nom, Editeur = jeux.Editeur, AnneeSortie = jeux.AnneeSortie, DateAjout = jeux.DateAjout };
        }

        public IEnumerable<Jeux> GetByCreateurId(Guid createurId)
        {
            IEnumerable<Jeux> listFromDb = null;
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                return connection.ExecuteReader("SELECT Id, Nom, Editeur, AnneeSortie, DateAjout, CreateurId FROM Jeux WHERE CreateurId = @c_id", dr => dr.ToJeux(), parameters : new { c_id = createurId });
            }
        }

        public void Update(Jeux entity)
        {
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                connection.ExecuteNonQuery("UPDATE Jeux SET Nom = @nom, Editeur  = @editeur, AnneeSortie = @annee WHERE Id = @id)", parameters: new
                {
                    id = entity.Id,
                    nom = entity.Nom,
                    editeur = entity.Editeur,
                    annee = entity.AnneeSortie,
                });
            }
        }


    }
}
