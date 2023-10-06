using NetSecu_DemoFormulaire.Models;
using NetSecu_DemoFormulaire.Models.Entities;
using NetSecu_DemoFormulaire.WebApp.Models.Forms;
using System.Data;

namespace NetSecu_DemoFormulaire.WebApp.Models.Mappers
{
    internal static class Mappers
    {
        //Pas utile car déjà présent dans le Mapper du repository
        //internal static Utilisateur ToUtilisateur(this IDataRecord record)
        //{
        //    return new Utilisateur()
        //    {
        //        Id = (Guid)record["Id"],
        //        Nom = (string)record["Nom"],
        //        Prenom = (string)record["Prenom"],
        //        Email = (string)record["Email"]
        //    };
        //}

        internal static Utilisateur ToUtilisateur(this RegisterForm form)
        {
            return new Utilisateur()
            {
                Nom = form.Nom,
                Prenom = form.Prenom,
                Email = form.Email,
                Passwd = form.Passwd
            };
        }
        internal static UserModel ToUserModel(this Utilisateur entity)
        {
            return new UserModel()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email
            };
        }

        internal static Utilisateur ToUtilisateur(this UserModel entity)
        {
            return new Utilisateur()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                Passwd = "********"
            };
        }
    }
}
