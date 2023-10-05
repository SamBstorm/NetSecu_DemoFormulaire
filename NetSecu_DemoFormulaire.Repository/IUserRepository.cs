using NetSecu_DemoFormulaire.Models;
using NetSecu_DemoFormulaire.Models.Entities;

namespace NetSecu_DemoFormulaire.Repository
{
    public interface IUserRepository
    { 
        IEnumerable<UserModel> Get();
        UserModel GetById(Guid id);

        void Create(Utilisateur user);
        void Update(Utilisateur user);
        void Delete(Guid id);

    }
}