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
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
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
                    return default(Jeux);
                }
            }
            return new Jeux() { Id = jeux.Id, Nom = jeux.Nom, Editeur = jeux.Editeur, AnneeSortie = jeux.AnneeSortie, DateAjout = jeux.DateAjout };
        }

        public void Update(Jeux entity)
        {
            throw new NotImplementedException();
        }
    }
}
