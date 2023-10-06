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
using Tools;
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
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                connection.ExecuteNonQuery("INSERT INTO Utilisateur (Nom, Prenom, Email, Passwd) VALUES (@Nom, @Prenom, @Email, @Passwd)", parameters: new { user.Nom, user.Prenom, user.Email, Passwd = user.Passwd.Hash() });
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Utilisateur> Get()
        {
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                return connection.ExecuteReader("SELECT Id, Nom, Prenom, Email FROM Utilisateur", dr => dr.ToUtilisateur());
            }            
        }

        public Utilisateur? Get(Guid id)
        {
            Utilisateur? utilisateur;
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                 utilisateur = connection.ExecuteReader("SELECT Id, Nom, Prenom, Email FROM Utilisateur WHERE id= @GUID;", dr => dr.ToUtilisateur(), parameters: new {  GUID=id }).SingleOrDefault();

                return utilisateur;
            }
            
        }

        public Utilisateur? Login(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                Utilisateur? utilisateur = connection.ExecuteReader("SELECT Id, Nom, Prenom, Email FROM Utilisateur WHERE Email = @Email AND Passwd = @Passwd;", dr => dr.ToUtilisateur(), parameters: new { email, Passwd = password.Hash() }).SingleOrDefault();
                return utilisateur;
            }
        }

        public void Update(Utilisateur user)
        {
            throw new NotImplementedException();
        }
    }
}
