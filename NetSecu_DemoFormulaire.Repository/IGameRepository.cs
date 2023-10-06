using NetSecu_DemoFormulaire.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecu_DemoFormulaire.Repository
{
    public interface IGameRepository :
        IGetRepository<Jeux, Guid>,
        IGetAllRepository<Jeux, Guid>,
        ICreateRepository<Jeux, Guid>,
        IUpdateRepository<Jeux, Guid>,
        IDeleteRepository<Jeux, Guid>
    {
        IEnumerable<Jeux> Get();
        IEnumerable<Jeux> GetByCreateurId(Guid createurId);
        Jeux Get(Guid id);
        void Create(Jeux entity);
        void Update(Jeux entity);
        void Delete(Guid id);
    }
}
