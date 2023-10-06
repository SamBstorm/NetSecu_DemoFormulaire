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

        public UserModel? GetById(Guid id)
        {
            Utilisateur? utilisateur;
            using (DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = cnstr;
                connection.Open();
                 utilisateur = connection.ExecuteReader("SELECT Id, Nom, Prenom, Email FROM Utilisateur WHERE id= @GUID;", dr => dr.ToUtilisateur(), parameters: new {  GUID=id }).SingleOrDefault();

                if (utilisateur is null)
                {
                    return default;
                }
            }
            return new UserModel() { 
                Id = utilisateur.Id,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Email = utilisateur.Email
            };
        }

        public Utilisateur? Login(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoFormulaire;Integrated Security=True;Encrypt=False";
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
