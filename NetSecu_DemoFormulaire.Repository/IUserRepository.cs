using NetSecu_DemoFormulaire.Models;
using NetSecu_DemoFormulaire.Models.Entities;

namespace NetSecu_DemoFormulaire.Repository
{
    public interface IUserRepository : 
        ICRUDRepository<Utilisateur, Guid>
    { 
        Utilisateur? Login(string email, string password);
    }
}