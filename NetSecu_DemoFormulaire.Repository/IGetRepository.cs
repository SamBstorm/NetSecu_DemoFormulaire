using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecu_DemoFormulaire.Repository
{
    public interface IGetRepository<TEntity, TId> where TEntity : class where TId : struct
    {
        TEntity Get(TId id);
    }
}
