using NetSecu_DemoFormulaire.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecu_DemoFormulaire.Repository.Mappers
{
    internal static class MesMappers
    {
        internal static Utilisateur ToUtilisateur(this IDataRecord record)
        {
            return new Utilisateur()
            {
                Id = (Guid)record["Id"],
                Nom = (string)record["Nom"],
                Prenom = (string)record["Prenom"],
                Email = (string)record["Email"]
            };
        }
    }
}
