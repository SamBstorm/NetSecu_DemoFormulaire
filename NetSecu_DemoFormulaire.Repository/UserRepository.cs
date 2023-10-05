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
    public class UserRepository : IUserRepository
    {
        string cnstr;

        public UserRepository(string connection)
        {
            cnstr = connection;
        }

        public void Create(Utilisateur user)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> Get()
        {
            IEnumerable<Utilisateur> listFromDb = null;
            IEnumerable<UserModel> list = null;
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                listFromDb=   connection.ExecuteReader("SELECT Id, Nom, Prenom, Email FROM Utilisateur", dr => dr.ToUtilisateur()).ToList();
            }
            return listFromDb.Select(u=> new UserModel() { Email = u.Email, Id=u.Id, Nom=u.Nom, Prenom=u.Prenom }); ;
        }

        public UserModel GetById(Guid id)
        {
            Utilisateur? utilisateur;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                 utilisateur = connection.ExecuteReader("SELECT Id, Nom, Prenom, Email FROM Utilisateur WHERE id= @GUID;", dr => dr.ToUtilisateur(), parameters: new {  GUID=id }).SingleOrDefault();

                if (utilisateur is null)
                {
                    return default(UserModel);
                }
            }
            return new UserModel() { Email = utilisateur.Email, Id = utilisateur.Id, Nom = utilisateur.Nom, Prenom = utilisateur.Prenom };
        }

        public void Update(Utilisateur user)
        {
            throw new NotImplementedException();
        }
    }
}
