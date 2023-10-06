using NetSecu_DemoFormulaire.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecu_DemoFormulaire.Repository
{
    internal interface IGameRepository
    {
        IEnumerable<Jeux> Get();
        Jeux Get(Guid id);
        void Create(Jeux entity);
        void Update(Jeux entity);
        void Delete(Guid id);
    }
}
